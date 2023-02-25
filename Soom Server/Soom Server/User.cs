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
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int Age { get; set; }
        public char Sex { get; set; }
        public string Bio { get; set; }
        public Socket Socket { get; set; }
        public int Id { get; set; }
        public bool Connected { get; set; }
        #endregion

        #region CTors

        public User(Socket socket, int id)
        {
            Socket = socket;
            Id = id;
            Connected = true;
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public User(string username, string password, int age = 0, char sex = '\0', string bio = "")
        {
            Username = username;
            Password = CreateSha256(CreateMD5(password) + username);
            if(Age != age)
                Age = age;
            if (Sex != sex)
                Sex = sex;
            if (Bio != bio)
                Bio = bio;
        }
        public User(User user, string username, string password, int age = 0, char sex = '\0', string bio = "") : this(username, password, age, sex, bio)
        {
            Socket = user.Socket;
            Id = user.Id;
            Connected = user.Connected;
        }
        #endregion
        private static string CreateSha256(string input)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        private static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
