using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;
using System.Data;

namespace Soom_server
{
    internal static class Server
    {
        #region ServerSettings
        public static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // The socket is set to InterNetwork
        public static int _clientsNum = 0;
        public static string _ip = "10.0.0.15";
        public static int _port = 13000;
        public static SqlConnection _db = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=SoomDB;Integrated Security=true");
        private static List<Thread> _threads = new List<Thread>();
        #endregion

        public static void AddThread(Thread thread)
        {
            
            _threads.Add(thread);
        }
        public static void ClientJoined(int clientNum = 0)
        {
            _clientsNum++;
            if (clientNum != 0)
            {
                Console.WriteLine("client '{0}' has joined", clientNum);
            }
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
            Console.WriteLine("Client Number '{0}' Has Connected To The Server!", user.Id);
            while (user.Connected)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytes_recieved = user.Socket.Receive(buffer, 3, SocketFlags.None);  //Useful: Socket.Recieve (sync and async) returns the number of bytes recieved and put them in the buffer.
                    if (bytes_recieved < 3)
                    {
                        SendErrors(user.Socket, Errors.CommandIsCorrupted);
                    }
                    else
                    {
                        string command = Encoding.UTF8.GetString(buffer);
                        if (command == "LOG")
                            Login(user.Socket);
                        else if (command == "REG")
                            Register(user.Socket);
                    }
                }
                catch
                {
                    Console.WriteLine("Something caused the server to close the connection with client '{0}'", user.Id);
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
            Console.WriteLine("Client '{0}' has been disconneted", user.Id);
        }

        private static string GetData(Socket sock) //ToDo: Finish the function and decide of the protocol of the message.
        {
            return "";
        }
        private static void SendErrors(Socket clientSock, Errors error) //ToDo: Finish the SendErrors Function.
        {

        }
        private static void Login(Socket clientSock) //ToDo: Finish the Login Function (Use GetData).
        {

        }
        private static void Register(Socket clientSock) //ToDo: Finish the regiter function (Use GetData).
        {

        }
    }
}
