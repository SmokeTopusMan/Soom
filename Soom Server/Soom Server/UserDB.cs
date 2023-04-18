using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soom_server
{
    public class UserDB
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public Int64 Age { get; set; }
        public string Sex { get; set; }
        public string Bio { get; set; }
        public Int64 Points { get; set; }

        public UserDB(string username, string password, long age, string sex, string bio, long points)
        {
            Username = username;
            Password = password;
            Age = age;
            Sex = sex;
            Bio = bio;
            Points = points;
        }
        public UserDB(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public UserDB(string username)
        {
            Username = username;
        }
    }
}
