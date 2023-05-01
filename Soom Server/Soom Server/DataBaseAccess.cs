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
        public static int RegiterUser(UserDB user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UserDB> users = GetAllUsers("REG");
                if (users.Count == 0)
                {
                    user.ID = 10000;
                    cnn.Execute($"INSERT INTO UsersInfo (UserID, Username, Password, Age, Sex, Bio) VALUES ({10000}, @Username, @Password, @Age, @Sex, @Bio)", user);
                    return (int)user.ID;
                }
                else
                {
                    foreach (UserDB item in users)
                    {
                        if (item.Username == user.Username)
                        {
                            throw new UsernameTakenException();
                        }
                    }
                    cnn.Execute("INSERT INTO UsersInfo (Username, Password, Age, Sex, Bio) VALUES (@Username, @Password, @Age, @Sex, @Bio)", user);
                    return int.Parse(string.Join("", cnn.Query<string>($"SELECT UserID FROM UsersInfo WHERE Username = '{user.Username}'")));
                }

            }
        }
        public static int LoginUser(UserDB user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UserDB> users = GetAllUsers("LOG");
                foreach (UserDB item in users)
                {
                    if (item.Username == user.Username && item.Password == user.Password)
                    {
                        var temp = cnn.Query<UserDB>($"SELECT Age, Sex, Bio, Points FROM UsersInfo WHERE Username = '{user.Username}'");
                        List<UserDB> data = temp.ToList();
                        return int.Parse(string.Join("", cnn.Query<string>($"SELECT UserID FROM UsersInfo WHERE Username = '{user.Username}'")));
                    }
                }
                throw new UsernameNotExistException();
            }
        }
        public static UserDB GetUser(string username)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserDB>($"SELECT Username, Password, Age, Sex, Bio, Points FROM UsersInfo WHERE Username = '{username}'");
                return (UserDB)output.ToList()[0];
            }
        }
        public static List<UserDB> GetAllUsers(string command = null)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (command == "REG")
                {
                    var output = cnn.Query<UserDB>("SELECT Username FROM UsersInfo");
                    return output.ToList();
                }
                else if (command == "LOG")
                {
                    var output = cnn.Query<UserDB>("SELECT Username, Password FROM UsersInfo");
                    return output.ToList();
                }
                return cnn.Query<UserDB>("SELECT Username, Password, Age, Sex, Bio, Points FROM UsersInfo").ToList();
            }
        }

        #region Get Connection String
        private static string LoadConnectionString(string connectionString = "Default")
        {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }
        #endregion
    }
}
