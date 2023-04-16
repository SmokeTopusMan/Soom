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

namespace Soom_server
{
    public static class DataBaseAccess
    {
        public static Errors RegiterUser(User user) //ToDo: Add a GeneralError by comparing the username to all the usernames in the DB and then put 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    cnn.Execute("INSERT INTO UsersInfo (Username, Password, Age, Sex, Bio) VALUES (@Username, @Password, @Age, @Sex, @Bio)", user);
                    return Errors.None;
                }
                catch (SQLiteException)
                {
                    Console.WriteLine("Registration Failed!");
                    return Errors.UsernameIsTaken;
                }

            }
        }

        public static Errors LoginUser(User user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    var output = cnn.Query<User>("SELECT Username, Password FROM UsersInfo");
                    var test = output.ToList();
                    foreach (User item in test)
                    {
                        if (item.Username == user.Username)
                        {
                            if (item.Password == user.Password)
                                return Errors.None;
                        }
                    }
                    return Errors.UserNotExist;
                }
                catch(SQLiteException) 
                {
                    return Errors.GeneralError;
                }
            }
        }
        public static User GetUser(string username)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<User>($"SELECT Username, Password, Age, Sex, Bio FROM UsersInfo WHERE Username = '{username}'");
                return (User)output.ToList()[0];
            }
        }

        private static string LoadConnectionString(string connectionString = "Default")
        {
            return ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
        }
    }
}
