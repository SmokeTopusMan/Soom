using System.Net.Sockets;
using System.Security.Cryptography;
namespace Soom_server
{
    public class User
    {
        #region Properties
        public Socket Socket { get; set; }
        public int Id { get; set; }
        public bool Connected { get; set; }
        public Aes Key { get; set; }
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
        public void SetKey(Aes aes)
        {
            Key = aes;
        }
    }
}
