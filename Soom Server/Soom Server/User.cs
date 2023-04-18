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
    public class User
    {
        #region Properties
        public Socket Socket { get; set; }
        public int Id { get; set; }
        public bool Connected { get; set; }
        #endregion

        #region CTor
        public User(Socket socket, int id) 
        {
            Socket = socket;
            Id = id;
            Connected = true;
        }
        #endregion
        public override string ToString()
        {
            return $"Client's ID : '{Id}'";
        }
    }
}
