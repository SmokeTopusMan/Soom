using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Soom_server
{
    internal static class Server
    {
        #region ServerSettings
        public static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // The socket is set to InterNetwork
        public static int _clientsNum = 0;
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
            _clientsNum++;
        }
        private static void ClientLeft()
        {
            if (_clientsNum > 0)
                _clientsNum--;
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
                    int bytes_recieved = user.Socket.Receive(buffer, 3, SocketFlags.None);  //Useful: Change the flag to Partial
                    if (bytes_recieved < 3)
                    {
                        SendErrors(user.Socket, Errors.CommandIsCorrupted);
                    }
                    else
                    {
                        string command = Encoding.UTF8.GetString(buffer);
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

        private static string GetData(Socket sock, string command)
        {
            if (command == "LOG")
            {
                byte[] userInfo = new byte[2];
                sock.Receive(userInfo, 2, SocketFlags.None);
                int length = int.Parse(Encoding.UTF8.GetString(userInfo));
                userInfo = new byte[length];
                sock.Receive(userInfo, length, SocketFlags.None);
                return Encoding.UTF8.GetString(userInfo);
            }
            else if(command == "REG")
            {
                byte[] userInfo = new byte[4];
                sock.Receive(userInfo, 4, SocketFlags.None);
                int length = int.Parse(Encoding.UTF8.GetString(userInfo));
                userInfo = new byte[length];
                sock.Receive(userInfo, length, SocketFlags.None);
                return Encoding.UTF8.GetString(userInfo);
            }
            return null;
        }
        private static void SendErrors(Socket clientSock, Errors error) //ToDo: Finish the SendErrors Function.
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
        private static void Login(User user)
        {
            string[]  userInfo = GetData(user.Socket, "LOG").Split('#');
            user = new User(user, userInfo[0], userInfo[1]);
            Errors err = DataBaseAccess.LoginUser(user);
            if (err == Errors.None) user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
            else { SendErrors(user.Socket, err); Log("NOLOG", user.Id); } 
        }
        private static void Register(User user)
        {
            string[] userInfo = GetData(user.Socket, "REG").Split('#');
            try
            {
                user = new User(user, userInfo[0], userInfo[1], int.Parse(userInfo[2]), char.Parse(userInfo[3]), userInfo[4]);
            }
            catch(IndexOutOfRangeException)
            {
                user = new User(user, userInfo[0], userInfo[1], int.Parse(userInfo[2]), char.Parse(userInfo[3]));
            }
            Errors err = DataBaseAccess.RegiterUser(user);
            if (err == Errors.None) user.Socket.Send(Encoding.UTF8.GetBytes("OK"));
            else { SendErrors(user.Socket, err); Log("NOREG", user.Id); }

        }
        private static void Log(string command, int id)
        {
            if(command == "JOIN") Console.WriteLine($"Server => Server: Client '{id}' Has Been Connected!");
            else if(command == "LEFT") Console.WriteLine($"Server => Server: Client '{id}' Has Been Disconnected!");
            else if(command == "LOG") Console.WriteLine($"Client => Server: Client '{id}' Sent Login Request!");
            else if (command == "REG") Console.WriteLine($"Client => Server: Client '{id}' Sent Register Request!");
            else if( command == "NOLOG") Console.WriteLine($"Server => Client: Client's '{id} Login Request Has Failed!'");
            else if (command == "NOREG") Console.WriteLine($"Server => Client: Client's '{id} Registration Request  Has Failed! ");
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
