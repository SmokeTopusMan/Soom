using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soom_Client
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string password;
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public string Bio { get; set; }
        public int Points { get; set; }

        public UserInfo(string userName, string password, int age, Sex sex, string bio, int points)
        {
            UserName = userName;
            this.password = password;
            Age = age;
            Sex = sex;
            Bio = bio;
            Points = points;
        }
    }
}
