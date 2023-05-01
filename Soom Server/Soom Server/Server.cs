using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Data.SQLite;

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
        #endregion

        public static void AddThread(Thread thread)
        {
            
            _threads.Add(thread);
        }
        public static void ClientJoined()
        {
            ClientsNum++;
        }
        private static void ClientLeft()
        {
            if (ClientsNum > 0)
                ClientsNum--;
            else
                throw new Exception("!********!- Cant Decrement since the server has 0 clients online -!********!");
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
                    HandleCommand(command, user);
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
            ClientLeft();
            Log("LEFT", user.Id);
        }

        private static void HandleCommand(string command, User user)
        {
            if (command == "LOG")
            {
                Log("LOG", user.Id);
                Login(user);
            }
            else if (command == "REG")
            {
                Log("REG", user.Id);
                Register(user);
            }
        }

        private static string GetData(Socket sock, int arrayLength)
        {
                byte[] userInfo = new byte[arrayLength];
                sock.Receive(userInfo, arrayLength, SocketFlags.None);
                int length = int.Parse(Encoding.UTF8.GetString(userInfo));
                userInfo = new byte[length];
                sock.Receive(userInfo, length, SocketFlags.None);
                return Encoding.UTF8.GetString(userInfo);
        }
        private static void SendErrors(Socket clientSock, Errors error)
        {
            if (error == Errors.GeneralError)
            {
                clientSock.Send(Encoding.UTF8.GetBytes($"NO0"));
                throw new SocketException();
            }
            else if (error == Errors.CommandIsCorrupted) clientSock.Send(Encoding.UTF8.GetBytes($"NO1"));
            else if (error == Errors.UsernameIsTaken) clientSock.Send(Encoding.UTF8.GetBytes($"NO2"));
            else if (error == Errors.UserNotExist) clientSock.Send(Encoding.UTF8.GetBytes($"NO3"));
        }
        private static void SendID(Socket socket, int id)
        {
            byte[] bytes1 = BitConverter.GetBytes(id);
            byte[] bytes2 = Encoding.UTF8.GetBytes("OK");
            byte[] result = new byte[bytes1.Length + bytes2.Length];
            Buffer.BlockCopy(bytes2, 0, result, 0, bytes2.Length);
            Buffer.BlockCopy(bytes1, 0, result, bytes2.Length, bytes1.Length);
            socket.Send(result);
        }
        private static void Login(User user)
        {
            string[] userInfo = GetData(user.Socket, 2).Split('#');
            UserDB userDB = new UserDB(userInfo[0], userInfo[1]);
            try
            {
                int id = DataBaseAccess.LoginUser(userDB);
                for (int i = 0; i < 5; i++)
                {
                    SendID(user.Socket, id);
                    byte[] confirmation = new byte[2];
                    user.Socket.Receive(confirmation, 2, SocketFlags.None);
                    if (Encoding.UTF8.GetString(confirmation) == "OK")
                        return;
                }
                SendErrors(user.Socket, Errors.GeneralError);
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
            string[] userInfo = GetData(user.Socket, 4).Split('#');
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
                int id = DataBaseAccess.RegiterUser(userDetails);
                for (int i = 0; i < 5; i++)
                {
                    SendID(user.Socket, id);
                    byte[] confirmation = new byte[2];
                    user.Socket.Receive(confirmation, 2, SocketFlags.None);
                    if (Encoding.UTF8.GetString(confirmation) == "OK")
                        return;
                }
                SendErrors(user.Socket, Errors.GeneralError);
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
        private static void Log(string command, int id, Errors err = Errors.None)
        {
            if(command == "JOIN") Console.WriteLine($"Server => Server: Client '{id}' Has Been Connected!");
            else if(command == "LEFT") Console.WriteLine($"Server => Server: Client '{id}' Has Been Disconnected!");
            else if(command == "LOG") Console.WriteLine($"Client => Server: Client '{id}' Sent Login Request!");
            else if (command == "REG") Console.WriteLine($"Client => Server: Client '{id}' Sent Register Request!");
            else if( command == "NOLOG") Console.WriteLine($"Server => Client: Client's '{id} Login Request Has Failed', ERROR:{err}");
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
