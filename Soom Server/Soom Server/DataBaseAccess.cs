using Dapper;
using Soom_Client;
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
                string encodedPassword = EncodingMD5AndSha256.CreateMD5(EncodingMD5AndSha256.CreateSha256(user.Password) + user.Username);
                if (users.Count == 0)
                {
                    user.ID = 10000;
                    cnn.Execute($"INSERT INTO UsersInfo (UserID, Username, Password, Age, Sex, Bio) VALUES (@ID, @Username, @Password, @Age, @Sex, @Bio)", new
                    {
                        user.ID,
                        user.Username,
                        Password = encodedPassword, // Pass the custom password value as a parameter
                        user.Age,
                        user.Sex,
                        user.Bio
                    });

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
                    cnn.Execute($"INSERT INTO UsersInfo (Username, Password, Age, Sex, Bio) VALUES (@Username, @Password, @Age, @Sex, @Bio)", new
                    {
                        user.Username,
                        Password = encodedPassword, // Pass the custom password value as a parameter
                        user.Age,
                        user.Sex,
                        user.Bio
                    });
                    user.ID = int.Parse(string.Join("", cnn.Query<string>($"SELECT UserID FROM UsersInfo WHERE Username = '{user.Username}'")));
                }
                cnn.Execute($"INSERT INTO AudioSettingsTable (UserID) VALUES {user.ID}");
                cnn.Execute($"INSERT INTO VideoSettingsTable (UserID) VALUES {user.ID}");
                return (int)user.ID;
            }
        }
        public static int LoginUser(UserDB user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UserDB> users = GetAllUsers("LOG");
                string encodedPassword = EncodingMD5AndSha256.CreateMD5(EncodingMD5AndSha256.CreateSha256(user.Password) + user.Username);
                foreach (UserDB item in users)
                {
                    if (item.Username == user.Username && item.Password == encodedPassword)
                    {
                        return int.Parse(string.Join("", cnn.Query<string>($"SELECT UserID FROM UsersInfo WHERE Username = '{user.Username}'")));
                    }
                }
                throw new UsernameNotExistException();
            }
        }
        public static UserDB GetUserProfile(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserDB>($"SELECT Username, Password, Age, Sex, Bio, Points FROM UsersInfo WHERE UserID = {id}");
                return (UserDB)output.ToList()[0];
            }
        }
        public static string[] GetUserAudio(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<string>($"SELECT InputDeviceName, OutputDeviceName, Volume, IsMicOff FROM AudioSettingsTable WHERE UserID = {id}");
                return output.ToArray();
            }
        }
        private static List<UserDB> GetAllUsers(string command = null)
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
