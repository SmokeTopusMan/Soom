using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Soom_server
{
    public static class DataBaseAccess
    {
        public static void RegiterUser(User user) //ToDo: Add a GeneralError by comparing the username to all the usernames in the DB and then put 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<User> users = GetAllUsers("REG");
                foreach (User item in users)
                {
                    if (item.Username == user.Username)
                    {
                        throw new UsernameTakenException();
                    }
                }
                cnn.Execute("INSERT INTO UsersInfo (Username, Password, Age, Sex, Bio) VALUES (@Username, @Password, @Age, @Sex, @Bio)", user);
            }
        }

        public static void LoginUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                    var output = cnn.Query<User>("SELECT Username, Password FROM UsersInfo");
                    var users = output.ToList();
                    foreach (User item in users)
                    {
                        if (item.Username == user.Username)
                        {
                            if (item.Password == user.Password)
                                return;
                        }
                    }
                    throw new UsernameNotExistException();
            }
        }
        public static User GetUser(string username)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>($"SELECT Username, Password, Age, Sex, Bio, Points FROM UsersInfo WHERE Username = '{username}'");
                return (User)output.ToList()[0];
            }
        }

        private static string LoadConnectionString(string connectionString = "Default")
        {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }
        public static List<User> GetAllUsers(string command = null)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (command == "REG")
                {
                    var output = cnn.Query<User>("SELECT Username FROM UsersInfo");
                    return output.ToList();
                }
                else if (command == "LOG")
                {
                    var output = cnn.Query<User>("SELECT Username, Password FROM UsersInfo");
                    return output.ToList();
                }
                return cnn.Query<User>("SELECT Username, Password, Age, Sex, Bio, Points FROM UsersInfo").ToList();
            }
        }
    }
}
