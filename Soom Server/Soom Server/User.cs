using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Soom_server
{
    /*
    internal class User
    {
        public string _name { get; set; }
        public string _password { get; set; }
        public Socket _socket { get; private set; }

        public User(Socket socket)
        {
            _socket = socket;
        }
    }
    */

    public struct User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Socket Socket { get; set; }
        public int Id { get; set; }
        public bool Connected { get; set; }

        public User(int Id, Socket socket) => (this.Id, this.Socket, Connected, Name, Password) = (Id, socket, true, "", "");
    }
}
