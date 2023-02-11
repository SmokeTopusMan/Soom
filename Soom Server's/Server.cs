using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.SqlClient;

namespace Soom_server
{
    internal static class Server
    {
        public static Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // The socket is set to InterNetwork
        public static int _clientsNum = 0;
        public static string _ip = "127.0.0.1";
        public static int _port = 13000;
        public static SqlConnection _db = new SqlConnection(@"Data Source=PC\SQLEXPRESS;Initial Catalog=SoomDB;Integrated Security=true");
        private static List<Thread> _threads = new List<Thread>();

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
        public static void ClientLeft()
        {
            if (_clientsNum > 0)
                _clientsNum--;
            else
                throw new Exception("!********!- Cant Decriment since the server has 0 clients online -!********!");
        }



        public static void HandleClient(Socket clientSock, int tid)
        {

        }
    }
}
