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
        public Int64 Age { get; set; }
        public string Sex { get; set; }
        public string Bio { get; set; }
        public Int64 Points { get; set; }
        public Socket Socket { get; set; }
        public int Id { get; set; }
        public bool Connected { get; set; }
        #endregion

        #region CTors
        public User(string username, string password, Int64 age, string sex, string bio)
        {
            Username = username;
            Password = password;
            Age = age;
            Sex = sex;
            Bio = bio;
        }
        public User(string username)
        {
            Username = username;
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password; //ToDo: Sort this User's constructors
        }
        public User(Socket socket, int id) 
        {
            Socket = socket;
            Id = id;
            Connected = true;
        }
        public User(User user, string username, string password, Int64 age, string sex, string bio) : this(username, password, age, sex, bio)
        {
            Socket = user.Socket;
            Id = user.Id;
            Connected = user.Connected;
        }
        public User(User user, string username, string password, Int64 age, string sex) : this(username, password, age, sex, "")
        {
            Socket = user.Socket;
            Id = user.Id;
            Connected = user.Connected;
        }
        public User(User user, string username, string password) : this(username, password, 0, "", "")
        {
            Socket = user.Socket;
            Id = user.Id;
            Connected = user.Connected;
        }
        #endregion

        public override string ToString()
        {
            return $"{Username}#{Password}#{Age}#{Sex}#{Bio}";
        }
    }
}
