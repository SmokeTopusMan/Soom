﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Net.Configuration;
using System.Web;
using System.Reflection;

namespace Soom_server
{
    internal static class Server
    {
        #region ServerSettings
        public static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // The socket is set to InterNetwork
        public static int ClientsNum = 0;
        public static string _ip { get { return GetLocalIPAddress(); } private set { } }
        public static int _port = 13000;
        private static List<Thread> _threads = new List<Thread>();
        private static List<string> _activeUsers = new List<string>();
        private static Dictionary<string, string> _activeMeetingsInfo = new Dictionary<string,string>();
        private static Dictionary<string, List<User>> _activeMeetingsParticipants = new Dictionary<string, List<User>>();
        private static Dictionary<User, (Socket, Socket, Socket)> _usersMeetingSockets = new Dictionary<User, (Socket, Socket, Socket)>();
        private static Dictionary<string, Socket> _meetingsSockets = new Dictionary<string, Socket>();
        #endregion
        public static void AddThread(Thread thread)
        {
            _threads.Add(thread);
        }
        public static void ClientJoined()
        {
            ClientsNum++;
        }
        private static void ClientLeft(string username)
        {
            if (ClientsNum <= 0)
                throw new Exception("!********!- Cant Decrement since the server has 0 clients online -!********!");
            ClientsNum--;
            _activeUsers.Remove(username);
        }
        private static void MeetingEnded(string meetingName) // ToDo: Use the func
        {
            _activeMeetingsInfo.Remove(meetingName);
            _activeMeetingsParticipants.Remove(meetingName);
            _meetingsSockets.Remove(meetingName);
        }
        public static void HandleClient(User user)
        {
            Log("JOIN", user.Id);
            while (user.Connected)
            {
                try
                {
                    byte[] buffer = new byte[3];
                    int bytes_recieved = user.Socket.Receive(buffer, 3, SocketFlags.None);
                    if (bytes_recieved == 0)
                        throw new SocketException();
                    while(bytes_recieved < 3 && bytes_recieved != 0)
                    {
                        try
                        {
                            user.Socket.ReceiveTimeout = 2000;
                            bytes_recieved += user.Socket.Receive(buffer, 3 - bytes_recieved, SocketFlags.None);
                            if (bytes_recieved == 0)
                                throw new Exception("Client has disconnected");
                        }
                        catch (SocketException)
                        {
                            throw new SocketException();
                        }
                        catch (Exception)
                        {
                            SendErrors(user.Socket, Errors.CommandIsCorrupted);
                        }
                    }
                    string command = Encoding.UTF8.GetString(buffer);
                    if (!HandleCommand(command, user))
                        break;
                }
                catch (SocketException)
                {
                    break;
                }
            }
            try
            {
                user.Socket.Send(Encoding.UTF8.GetBytes("BYE"));
                user.Socket.Close();
            }
            catch { user.Socket.Close(); }
            user.Connected = false;
            ClientLeft(user.Username);
            Log("LEFT", user.Id);
        }
        private static bool HandleCommand(string command, User user)
        {
            Log(command, user.Id);
            if (command == "LOG") Login(user);
            else if (command == "REG") Register(user);
            else if (command == "KEY")
            {
                bool isSecure = ExchangeKeys(user);
                if (!isSecure)
                    throw new SocketException();
            }
            else if (command == "PRO" || command == "AUD" || command == "VID") GetSettings(user, command);
            else if (command == "CNG") ChangeSettings(user);
            else if (command == "FRD" || command == "PND") GerFriendsSettings(user, command);
            else if (command == "USR") GetUserDetails(user);
            else if (command == "REQ") SendFriendRequest(user);
            else if (command == "ANS") HandleFriendRequest(user);
            else if (command == "STR") StartNewMeeting(user);
            else if (command == "JON") JoinMeeting(user);
            else
                return false;
            return true;
        }
        private static string GetData(User user, int arrayLength)
        {
            byte[] userInfo = new byte[arrayLength];
            user.Socket.Receive(userInfo, arrayLength, SocketFlags.None);
            int length = int.Parse(Encoding.UTF8.GetString(userInfo));
            userInfo = new byte[length];
            user.Socket.Receive(userInfo, length, SocketFlags.None);
            return SymmetricEncryption.DecryptBytesToStringAES(userInfo, user.SymmetricKey);
        }
        private static void SendErrors(Socket clientSock, Errors error)
        {
            if (error == Errors.GeneralError)
            {
                clientSock.Send(Encoding.UTF8.GetBytes("NO0"));
                throw new SocketException();
            }
            else if (error == Errors.CommandIsCorrupted) clientSock.Send(Encoding.UTF8.GetBytes("NO1"));
            else if (error == Errors.UsernameIsTaken) clientSock.Send(Encoding.UTF8.GetBytes("NO2"));
            else if (error == Errors.UserNotExist) clientSock.Send(Encoding.UTF8.GetBytes("NO3"));
            else if (error == Errors.UnknownFormat) clientSock.Send(Encoding.UTF8.GetBytes("NO4"));
            else if (error == Errors.AlreadySentRequest) clientSock.Send(Encoding.UTF8.GetBytes("NO5"));
            else if (error == Errors.AlreadyFriends) clientSock.Send(Encoding.UTF8.GetBytes("NO6"));
            else if (error == Errors.AlreadyOnline) clientSock.Send(Encoding.UTF8.GetBytes("NO7"));
            else if (error == Errors.MeetingNameTaken) clientSock.Send(Encoding.UTF8.GetBytes("NO8"));
            else if (error == Errors.MeetingNotFound) clientSock.Send(Encoding.UTF8.GetBytes("NO9"));
        }
        private static void SendID(User user, int id)
        {
            byte[] idBytes = SymmetricEncryption.EncryptStringToBytesAES(id.ToString(), user.SymmetricKey);
            byte[] result = Encoding.UTF8.GetBytes($"OK{idBytes.Length.ToString("00")}").Concat(idBytes).ToArray();
            user.Socket.Send(result);
        }
        private static bool ExchangeKeys(User user)
        {
            byte[] data = new byte[3];
            user.Socket.Receive(data);
            int length = int.Parse(Encoding.UTF8.GetString(data));
            data = new byte[length];
            user.Socket.Receive(data);
            RSAParameters publicKeyParams = new RSAParameters
            {
                Modulus = data,
                Exponent = new byte[] { 0x01, 0x00, 0x01 } // Example exponent value (usually a fixed value like 3 or 65537)
            };
            RSA rsa = RSA.Create();
            rsa.ImportParameters(publicKeyParams);
            user.GenerateKey();
            byte[] keyAndIv = user.SymmetricKey.Key.Concat(new byte[] { 35, 35, 35 }).Concat(user.SymmetricKey.IV).ToArray();
            byte[] publicKey = rsa.Encrypt(keyAndIv, RSAEncryptionPadding.Pkcs1);
            byte[] msg = Encoding.UTF8.GetBytes("OK" + publicKey.Length.ToString("000"));
            msg = msg.Concat(publicKey).ToArray();
            user.Socket.Send(msg);
            byte[] answer = new byte[2];
            user.Socket.Receive(answer, 2, SocketFlags.None);
            if (Encoding.UTF8.GetString(answer) == "OK")
            {
                return true;
            }
            return false;
        }
        private static void Login(User user)
        {
            string[] userInfo;
            try
            {
                userInfo = GetData(user, 3).Split('#');
            }
            catch
            {
                SendErrors(user.Socket, Errors.UnknownFormat); Log("NOLOG", user.Id, Errors.UnknownFormat);
                return;
            }
            UserDB userDB = new UserDB(userInfo[0], userInfo[1]);
            try
            {
                if (_activeUsers.Contains(userInfo[0]))
                    throw new AlreadyOnlineException();
                int id = DataBaseAccess.LoginUser(userDB);
                for (int i = 0; i < 5; i++)
                {
                    SendID(user, id);
                    byte[] confirmation = new byte[2];
                    user.Socket.Receive(confirmation, 2, SocketFlags.None);
                    if (Encoding.UTF8.GetString(confirmation) == "OK")
                    {
                        user.Username = userInfo[0];
                        _activeUsers.Add(user.Username);
                        return;
                    }
                }
                SendErrors(user.Socket, Errors.GeneralError);
            }
            catch (AlreadyOnlineException)
            {
                SendErrors(user.Socket, Errors.AlreadyOnline); Log("NOLOG", user.Id, Errors.AlreadyOnline);
            }
            catch (UsernameNotExistException)
            {
                SendErrors(user.Socket, Errors.UserNotExist); Log("NOLOG", user.Id, Errors.UserNotExist);
            }
            catch (SQLiteException)
            {
                SendErrors(user.Socket, Errors.GeneralError); Log("NOLOG", user.Id, Errors.GeneralError);
            }
            
        }
        private static void Register(User user)
        {
            string[] userInfo;
            try
            {
                userInfo = GetData(user, 4).Split('#');
            }
            catch
            {
                SendErrors(user.Socket, Errors.UnknownFormat); Log("NOLOG", user.Id, Errors.UnknownFormat);
                return;
            }
            UserDB userDetails;
            try
            {
                userDetails = new UserDB(userInfo[0], userInfo[1], int.Parse(userInfo[2]), userInfo[3], userInfo[4]);
            }
            catch(IndexOutOfRangeException)
            {
                userDetails = new UserDB(userInfo[0], userInfo[1], int.Parse(userInfo[2]), userInfo[3]);
            }
            try
            {
                if (_activeUsers.Contains(userInfo[0]))
                    throw new AlreadyOnlineException();
                userDetails.Points = 50;
                int id = DataBaseAccess.RegiterUser(userDetails);
                for (int i = 0; i < 5; i++)
                {
                    SendID(user, id);
                    byte[] confirmation = new byte[2];
                    user.Socket.Receive(confirmation, 2, SocketFlags.None);
                    if (Encoding.UTF8.GetString(confirmation) == "OK")
                    {
                        user.Username = userInfo[0];
                        _activeUsers.Add(user.Username);
                        return;
                    }
                }
                SendErrors(user.Socket, Errors.GeneralError);
            }
            catch (AlreadyOnlineException) 
            {
                SendErrors(user.Socket, Errors.AlreadyOnline); Log("NOREG", user.Id, Errors.AlreadyOnline);
            }
            catch (UsernameTakenException)
            {
                SendErrors(user.Socket, Errors.UsernameIsTaken); Log("NOREG", user.Id, Errors.UsernameIsTaken);
            }
            catch (SQLiteException)
            {
                SendErrors(user.Socket, Errors.GeneralError); Log("NOREG", user.Id, Errors.GeneralError);
            }
        }
        private static void GetSettings(User user, string command, string id = "")
        {
            if(id == "")
                id = GetData(user, 2);
            byte[] msg;
            if (command == "PRO")
            {
                UserDB userDB = DataBaseAccess.GetUserProfile(int.Parse(id));
                msg = SymmetricEncryption.EncryptStringToBytesAES($"{userDB.Username}#{userDB.Age}#{userDB.Sex}#{userDB.Bio}#{userDB.Points}", user.SymmetricKey);
            }
            else if(command == "AUD")
            {
                string audioSettings = string.Join("#", DataBaseAccess.GetUserAudio(int.Parse(id)));
                msg = SymmetricEncryption.EncryptStringToBytesAES(audioSettings, user.SymmetricKey);
            }
            else
            {
                string videoSettings = string.Join("#", DataBaseAccess.GetUserVideo(int.Parse(id)));
                msg = SymmetricEncryption.EncryptStringToBytesAES(videoSettings, user.SymmetricKey);
            }
            byte[] result = Encoding.UTF8.GetBytes("OK" + msg.Length.ToString("0000")).Concat(msg).ToArray();
            user.Socket.Send(result);
            byte[] confirmation = new byte[2];
            user.Socket.Receive(confirmation);
            if (Encoding.UTF8.GetString(confirmation) == "OK")
                return;
        }
        private static void GerFriendsSettings(User user, string command)
        {
            string id = GetData(user, 2);
            string temp;
            if (command == "FRD")
                temp = DataBaseAccess.GetFriends(int.Parse(id));
            else
                temp = DataBaseAccess.GetPendingRequests(int.Parse(id));
            SendDataToUser(user, temp);
        }
        private static void GetUserDetails(User user)
        {
            string username = GetData(user, 2);
            UserDB userDetails = DataBaseAccess.GetFriendDetails(username);
            string data = "";
            if (userDetails != null)
            {
                data += $"{userDetails.Username}#{userDetails.Age}#{userDetails.Sex}#{userDetails.Bio}#{userDetails.Points}";
            }
            else
                data += "#";
            SendDataToUser(user, data);
        }
        private static void SendDataToUser(User user, string data)
        {
            byte[] msg = SymmetricEncryption.EncryptStringToBytesAES(data, user.SymmetricKey);
            byte[] result = Encoding.UTF8.GetBytes("OK" + msg.Length.ToString("0000")).Concat(msg).ToArray();
            user.Socket.Send(result);
            byte[] confirmation = new byte[2];
            user.Socket.Receive(confirmation);
            if (Encoding.UTF8.GetString(confirmation) == "OK")
                return;
        }
        private static void SendFriendRequest(User user)
        {
            string id = GetData(user, 2);//error
            string username = GetData(user, 2);
            try
            {
                DataBaseAccess.SendFriendRequest(int.Parse(id), username);
                user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
            }
            catch (UsernameNotExistException)
            {
                SendErrors(user.Socket, Errors.UserNotExist);
            }
            catch (AlreadySentRequestException)
            {
                SendErrors(user.Socket, Errors.AlreadySentRequest);
            }
            catch(AlreadyFriendException)
            {
                SendErrors(user.Socket, Errors.AlreadyFriends);
            }
            byte[] confirmation = new byte[2];
            user.Socket.Receive(confirmation);
            if (Encoding.UTF8.GetString(confirmation) == "OK")
                return;
        }
        private static void HandleFriendRequest(User user)
        {
            string id = GetData(user, 2);
            string[] usernameAnswer = GetData(user, 2).Split('#');
            try
            {
                DataBaseAccess.AnswerFriendRequest(int.Parse(id), usernameAnswer[0], usernameAnswer[1]);
                user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
            }
            catch (UsernameNotExistException)
            {
                SendErrors(user.Socket, Errors.UserNotExist);
            }
            byte[] confirmation = new byte[2];
            user.Socket.Receive(confirmation);
            if (Encoding.UTF8.GetString(confirmation) == "OK")// todo: maybe turn this into a function
                return;
        }
        private static void ChangeSettings(User user)
        {
            byte[] commandBytes = new byte[3];
            user.Socket.Receive(commandBytes, 3, SocketFlags.None);
            string[] data = GetData(user, 4).Split('#');
            string command = Encoding.UTF8.GetString(commandBytes);
            if (command == "PRO")
            {
                try
                {
                    DataBaseAccess.ChangeUserProfile(data);
                }
                catch (UsernameTakenException)
                {
                    SendErrors(user.Socket, Errors.UsernameIsTaken);
                }
            }
            else if(command == "AUD")
            {
                DataBaseAccess.ChangeUserAudio(data);
            }
            else if (command == "VID")
            {
                DataBaseAccess.ChangeUserVideo(data);
            }
            user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
            byte[] confirmation = new byte[2];
            user.Socket.Receive(confirmation);
            if (Encoding.UTF8.GetString(confirmation) == "OK")
                return;

        }
        private static void JoinMeeting(User user)
        {
            string id = GetData(user, 2);
            string[] meetingInfo = GetData(user, 2).Split('#');
            if (!CheckForMeeting(meetingInfo[0], meetingInfo[1]))
            {
                SendErrors(user.Socket, Errors.MeetingNotFound);
                byte[] confirmation = new byte[2];
                user.Socket.Receive(confirmation);
                if (Encoding.UTF8.GetString(confirmation) == "OK")
                { return; }
            }
            else
            {
                user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
                byte[] confirmation = new byte[2];
                user.Socket.Receive(confirmation);
                if (Encoding.UTF8.GetString(confirmation) == "OK")
                {
                    int boundPort = ((IPEndPoint)_meetingsSockets[meetingInfo[0]].LocalEndPoint).Port;
                    user.Socket.Send(SymmetricEncryption.EncryptStringToBytesAES($"{boundPort}", user.SymmetricKey));
                    Socket vidSock = _meetingsSockets[meetingInfo[0]].Accept();
                    Socket audSock = _meetingsSockets[meetingInfo[0]].Accept();
                    GetSettings(user, "VID", id);
                    GetSettings(user, "AUD", id);
                    foreach (var item in _usersMeetingSockets)
                    {
                        byte[] username = SymmetricEncryption.EncryptStringToBytesAES(user.Username, item.Key.SymmetricKey);
                        item.Value.Item3.Send(Encoding.UTF8.GetBytes($"JON{username.Length:00}").Concat(username).ToArray());
                        username = SymmetricEncryption.EncryptStringToBytesAES(item.Key.Username, user.SymmetricKey);
                        user.Socket.Send(Encoding.UTF8.GetBytes($"JON{username.Length:00}").Concat(username).ToArray());
                    }
                    _usersMeetingSockets.Add(user, (vidSock, audSock, user.Socket));
                    _activeMeetingsParticipants[meetingInfo[0]].Add(user);
                    HandleMeeting(meetingInfo[0], user);
                }
            }
        }
        private static void StartNewMeeting(User user)
        {
            string id = GetData(user, 2);
            string[] meetingInfo = GetData(user, 2).Split('#');
            bool canStartNewMeeting = CheckForMeeting(meetingInfo[0]);
            if (canStartNewMeeting)
            {
                user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
                CreateMeeting(meetingInfo, user);
                byte[] confirmation = new byte[2];
                user.Socket.Receive(confirmation);
                if (Encoding.UTF8.GetString(confirmation) == "OK")
                {
                    Socket meetingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    int counter = 1;
                    while (true)
                    {
                        try
                        {
                            meetingSocket.Bind(new IPEndPoint(IPAddress.Parse(Server._ip), Server._port + counter));
                            meetingSocket.Listen(10);
                            _meetingsSockets.Add(meetingInfo[0], meetingSocket);
                            user.Socket.Send(SymmetricEncryption.EncryptStringToBytesAES($"{Server._port + counter}", user.SymmetricKey));
                            break;
                        }
                        catch
                        {
                            counter++;
                        }
                    }
                    Socket vidSock = meetingSocket.Accept();
                    Socket audSock = meetingSocket.Accept();
                    GetSettings(user, "VID", id);
                    GetSettings(user, "AUD", id);
                    _usersMeetingSockets.Add(user, (vidSock, audSock, user.Socket));
                    HandleMeeting(meetingInfo[0], user);
                }
            }
            else
            {
                SendErrors(user.Socket, Errors.MeetingNameTaken);
                byte[] confirmation = new byte[2];
                user.Socket.Receive(confirmation);
                if (Encoding.UTF8.GetString(confirmation) == "OK")
                    return;
            }
        }
        private static void CreateMeeting(string[] meetingInfo, User user)
        {
            _activeMeetingsInfo.Add(meetingInfo[0], meetingInfo[1]);
            _activeMeetingsParticipants.Add(meetingInfo[0], new List<User>() {user});
        }
        private static bool CheckForMeeting(string meetingName, string meetingPassword = "")
        {
            foreach (var meeting in _activeMeetingsInfo) 
            {
                if (meeting.Key == meetingName)
                {
                    if (meetingPassword == "")
                        return false;
                    else if (meetingPassword == meeting.Value)
                        return true;
                    else
                        return false;
                }
            }
            if (meetingPassword != "")
                return false;
            return true;
        }
        private static void HandleMeeting(string meetingName, User user)
        {
            Socket vidSock = _usersMeetingSockets[user].Item1;
            Socket audSock = _usersMeetingSockets[user].Item2;
            bool connected = vidSock.Connected;
            vidSock.ReceiveTimeout = 30;
            audSock.ReceiveTimeout = 30;

            while (connected)
            {
                try
                {
                    try
                    {
                        byte[] Data = GetDataFromSocket(vidSock);
                        SendMediaToParticipants(Data, user, meetingName);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode != SocketError.TimedOut)
                        {
                            throw new SocketException();
                        }
                    }
                    /*
                    try
                    {
                        byte[] Data = GetDataFromSocket(audSock);
                        SendMediaToParticipants(Data, user, meetingName);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode != SocketError.TimedOut)
                        {
                            throw new SocketException();
                        }
                    }
                    */
                }
                catch 
                {
                    _activeMeetingsParticipants[meetingName].Remove(user);
                    _usersMeetingSockets.Remove(user);
                    if (_activeMeetingsParticipants[meetingName].Count == 0)
                    {
                        _meetingsSockets[meetingName].Close();
                        MeetingEnded(meetingName);
                    }
                    vidSock.Close();
                    audSock.Close();
                    break;
                }
            }
        }
        private static byte[] GetDataFromSocket(Socket socket)
        {
            byte[] Data = new byte[5];
            int bytesRecieved = socket.Receive(Data);
            if (bytesRecieved == 0)
                throw new SocketException();
            int Length = int.Parse(Encoding.UTF8.GetString(Data));
            Data = new byte[0];
            byte[] temp = new byte[Length];
            int bytesCount = 0;
            while (bytesCount < Length)
            {
                int bytes = socket.Receive(temp, SocketFlags.None);
                byte[] d = new byte[bytes];
                Array.Copy(temp, d, bytes);
                bytesCount += bytes;
                Data = Data.Concat(d).ToArray();
                temp = new byte[Length - bytesCount];
            }
            return Data;
        }
        private static void SendMediaToParticipants(byte[] data, User userSender, string meetingName)
        {
            int length = data.Length;
            List<User> users = _activeMeetingsParticipants[meetingName];
            foreach (User userReciever in users)
            {
                if (userReciever != userSender)
                {
                    byte[] usernameBytes = SymmetricEncryption.EncryptStringToBytesAES(userSender.Username, userReciever.SymmetricKey);
                    _usersMeetingSockets[userReciever].Item1.Send(Encoding.UTF8.GetBytes(usernameBytes.Length.ToString("00")).Concat(usernameBytes).Concat(Encoding.UTF8.GetBytes(length.ToString("00000"))).Concat(data).ToArray());
                }
            }
        }
        private static void Log(string command, int id, Errors err = Errors.None)
        {
            if (command == "JOIN") Console.WriteLine($"Server => Server: Client '{id}' Has Been Connected!");
            else if (command == "LEFT") Console.WriteLine($"Server => Server: Client '{id}' Has Been Disconnected!");
            else if (command == "KEY") Console.WriteLine($"Client => Server: Client '{id}' Sent Keys Exchange Request!");
            else if (command == "LOG") Console.WriteLine($"Client => Server: Client '{id}' Sent Login Request!");
            else if (command == "REG") Console.WriteLine($"Client => Server: Client '{id}' Sent Register Request!");
            else if (command == "PRO" || command == "AUD" || command == "VID") Console.WriteLine($"Client => Server: '{id}' Sent General Settings Request!");
            else if (command == "CNG") Console.WriteLine($"Client => Server: Client '{id}' Sent Change General Settings Request!");
            else if (command == "FRD" || command == "PND") Console.WriteLine($"Client => Server: Client '{id}' Sent Friends Settings Request!");
            else if (command == "USR") Console.WriteLine($"Client => Server: Client '{id}' Sent Get Other User Details Request");
            else if (command == "REQ") Console.WriteLine($"Client => Server: Client '{id}' Sent Friend Request to Other User");
            else if (command == "ANS") Console.WriteLine($"Client => Server: Client '{id}' Sent Answer Friend Requset to Other User");
            else if (command == "NOLOG") Console.WriteLine($"Server => Client: Client's '{id} Login Request Has Failed', ERROR:{err}");
            else if (command == "NOREG") Console.WriteLine($"Server => Client: Client's '{id} Registration Request Has Failed', ERROR:{err}");
        }
        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }

    }
}
