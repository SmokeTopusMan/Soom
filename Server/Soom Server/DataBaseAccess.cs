using Dapper;
using Soom_Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                string encodedPassword = EncodingMD5AndSha256.CreateMD5(EncodingMD5AndSha256.CreateSha256(user.Password));
                if (users.Count == 0)
                {
                    user.ID = 10000;
                    cnn.Execute($"INSERT INTO UsersInfo (UserID, Username, Password, Age, Sex, Bio, Points) VALUES (@ID, @Username, @Password, @Age, @Sex, @Bio, @Points)", new
                    {
                        user.ID,
                        user.Username,
                        Password = encodedPassword, // Pass the custom password value as a parameter
                        user.Age,
                        user.Sex,
                        user.Bio,
                        user.Points
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
                    cnn.Execute($"INSERT INTO UsersInfo (Username, Password, Age, Sex, Bio, Points) VALUES (@Username, @Password, @Age, @Sex, @Bio, @Points)", new
                    {
                        user.Username,
                        Password = encodedPassword, // Pass the custom password value as a parameter
                        user.Age,
                        user.Sex,
                        user.Bio,
                        user.Points
                    });
                    user.ID = int.Parse(string.Join("", cnn.Query<string>($"SELECT UserID FROM UsersInfo WHERE Username = '{user.Username}'")));
                }
                cnn.Execute($"INSERT INTO AudioSettingsTable (UserID, Volume, IsMicOff) VALUES ({user.ID}, '50', '0')");
                cnn.Execute($"INSERT INTO VideoSettingsTable (UserID, IsMirrored, IsVidOff) VALUES ({user.ID}, '0', '0')");
                cnn.Execute($"INSERT INTO FriendsTable (UserID) VALUES ({user.ID})");
                return (int)user.ID;
            }
        }
        public static int LoginUser(UserDB user)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UserDB> users = GetAllUsers("LOG");
                string encodedPassword = EncodingMD5AndSha256.CreateMD5(EncodingMD5AndSha256.CreateSha256(user.Password));
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
                var output = cnn.Query<UserDB>($"SELECT Username, Age, Sex, Bio, Points FROM UsersInfo WHERE UserID = {id}");
                return (UserDB)output.ToList()[0];
            }
        }
        public static string[] GetUserAudio(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<(string, string, string, string)>($"SELECT InputDeviceName, OutputDeviceName, Volume, IsMicOff FROM AudioSettingsTable WHERE UserID = {id}").ToList();
                return new string[] { output[0].Item1, output[0].Item2, output[0].Item3, output[0].Item4 };
            }
        }
        public static string[] GetUserVideo(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<(string, string, string)>($"SELECT DeviceName, IsMirrored, IsVidOff FROM VideoSettingsTable WHERE UserID = {id}").ToList();
                return new string[] { output[0].Item1, output[0].Item2, output[0].Item3};
            }
        }
        public static string GetFriends(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<string>($"SELECT Friends FROM FriendsTable WHERE UserID = {id}").ToList();
                if (output[0] != null)
                    return output[0];
                else
                    return "#";
            }
        }
        public static string GetPendingRequests(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<string>($"SELECT RequestsPending FROM FriendsTable WHERE UserID = ({id})").ToList();
                if (output[0] != null)
                {
                    if (output[0] != "")
                        return output[0];
                    else 
                        return "#";
                }
                else
                    return "#";
            }
        }
        public static UserDB GetFriendDetails(string username)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<UserDB>($"SELECT Username, Age, Sex, Bio, Points FROM UsersInfo WHERE Username = '{username}'").ToList();
                if (output[0] != null)
                    return output[0];
                else
                    return null;
            }
        }
        public static void SendFriendRequest(int senderId, string recieverUsername)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UserDB> usernames = GetAllUsers("REQ");
                foreach (UserDB item in usernames)
                {
                    if (item.Username == recieverUsername)
                    {
                        int recieverId = cnn.Query<int>($"SELECT UserID FROM UsersInfo WHERE Username = '{recieverUsername}'").ToList()[0];
                        if(recieverId  == senderId)
                            throw new AlreadyFriendException();
                        string senderUsername = cnn.Query<string>($"SELECT Username FROM UsersInfo WHERE UserID = {senderId}").ToList()[0];
                        string recieverPendingList = cnn.Query<string>($"SELECT RequestsPending FROM FriendsTable WHERE UserID = {recieverId}").ToList()[0];
                        string recieverFriendsList = cnn.Query<string>($"SELECT Friends FROM FriendsTable WHERE UserID = {recieverId}").ToList()[0];
                        if (recieverFriendsList != null)
                        {
                            string[] friendsUsernames = recieverFriendsList.Split('#');
                            foreach (string username in friendsUsernames)// check if not already in friends
                            {
                                if (username == senderUsername)
                                    throw new AlreadyFriendException();
                            }
                        }
                        if (recieverPendingList == null) //check if not already in pending
                            recieverPendingList = senderUsername;
                        else
                        {
                            string[] pendingUsernames = recieverPendingList.Split('#');
                            foreach (string username in pendingUsernames)
                            {
                                if (username == senderUsername)
                                    throw new AlreadySentRequestException();
                            }
                            if (recieverFriendsList != null)
                            {
                                string[] friendsUsernames = recieverFriendsList.Split('#');
                                foreach (string username in friendsUsernames)
                                {
                                    if (username == senderUsername)
                                        throw new AlreadyFriendException();
                                }
                            }
                            recieverPendingList += $"#{senderUsername}";
                        }
                        cnn.Execute($"UPDATE FriendsTable SET RequestsPending = '{recieverPendingList}' WHERE UserID = {recieverId}");
                        return;
                    }
                }
                throw new UsernameNotExistException();
            }
        }
        public static void AnswerFriendRequest(int senderId, string recieverUsername, string answer)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                List<UserDB> usernames = GetAllUsers("ANS");
                foreach (UserDB item in usernames)
                {
                    if(item.Username == recieverUsername)
                    {
                        if (answer == "YE")
                        {
                            string senderFriendsList = cnn.Query<string>($"SELECT Friends FROM FriendsTable WHERE UserID = {senderId}").ToList()[0]; 
                            string senderPendingList = cnn.Query<string>($"SELECT RequestsPending FROM FriendsTable WHERE UserID = {senderId}").ToList()[0];
                            if (senderFriendsList == null)
                                senderFriendsList = recieverUsername;
                            else
                            {
                                senderFriendsList += $"#{recieverUsername}";
                            }
                            cnn.Execute($"UPDATE FriendsTable SET Friends = '{senderFriendsList}' WHERE UserID = {senderId}");

                            int reciverId = cnn.Query<int>($"SELECT UserID FROM UsersInfo WHERE Username = '{recieverUsername}'").ToList()[0];
                            string senderUsername = cnn.Query<string>($"SELECT Username FROM UsersInfo WHERE UserID = '{senderId}'").ToList()[0];
                            string recieveFriendsList = cnn.Query<string>($"SELECT Friends FROM FriendsTable WHERE UserID = {reciverId}").ToList()[0];
                            if (recieveFriendsList == null)
                                recieveFriendsList = senderUsername;
                            else
                            {
                                recieveFriendsList += $"#{senderUsername}";
                            }
                            cnn.Execute($"UPDATE FriendsTable SET Friends = '{recieveFriendsList}' WHERE UserID = {reciverId}");
                        }
                        string[] pendingList = cnn.Query<string>($"SELECT RequestsPending FROM FriendsTable WHERE UserID = {senderId}").ToList()[0].Split('#');
                        string newPending = null;
                        foreach (string pending in pendingList)
                        {
                            if (pending != recieverUsername)
                            {
                                if (newPending == null)
                                    newPending = pending;
                                else
                                    newPending += "#" + pending;
                            }
                        }
                        cnn.Execute($"UPDATE FriendsTable SET RequestsPending = '{newPending}' WHERE UserID = {senderId}");
                        return;
                    }
                }
                throw new UsernameNotExistException();

            }
        }
        public static void ChangeUserProfile(string[] data) //First element in this array is the user's id.
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = int.Parse(data[0]);
                if (data[1] != "")
                {
                    List<UserDB> users = GetAllUsers("REG");
                    foreach (UserDB item in users)
                    {
                        if (item.Username == data[1])
                            throw new UsernameTakenException();
                    }
                    cnn.Execute($"UPDATE UsersInfo SET Username = '{data[1]}' WHERE UserID = {id}");
                }
                if (data[2] != "")
                    cnn.Execute($"UPDATE UsersInfo SET Age = {data[2]} WHERE UserID = {id}");
                if (data[3] != "")
                    cnn.Execute($"UPDATE UsersInfo SET Sex = '{data[3]}' WHERE UserID = {id}");
                if (data[4] != "")
                    cnn.Execute($"UPDATE UsersInfo SET Bio = '{data[4]}' WHERE UserID = {id}");
            }
        }
        public static void ChangeUserAudio(string[] data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = int.Parse(data[0]);
                if (data[1] != "")
                    cnn.Execute($"UPDATE AudioSettingsTable SET InputDeviceName = '{data[1]}' WHERE UserID = {id}");
                if (data[2] != "")
                    cnn.Execute($"UPDATE AudioSettingsTable SET OutputDeviceName = '{data[2]}' WHERE UserID = {id}");
                if (data[3] != "")
                    cnn.Execute($"UPDATE AudioSettingsTable SET Volume = '{data[3]}' WHERE UserID = {id}");
                if (data[4] != "")
                    cnn.Execute($"UPDATE AudioSettingsTable SET IsMicOff = {data[4]} WHERE UserID = {id}");
            }
        }
        public static void ChangeUserVideo(string[] data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                int id = int.Parse(data[0]);
                if (data[1] != "")
                    cnn.Execute($"UPDATE VideoSettingsTable SET DeviceName = '{data[1]}' WHERE UserID = {id}");
                if (data[2] != "")
                    cnn.Execute($"UPDATE VideoSettingsTable SET IsMirrored = '{data[2]}' WHERE UserID = {id}");
                if (data[3] != "")
                    cnn.Execute($"UPDATE VideoSettingsTable SET IsVidOff = '{data[3]}' WHERE UserID = {id}");
            }
        }
        private static List<UserDB> GetAllUsers(string command)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                if (command == "REG")
                {
                    var output = cnn.Query<UserDB>("SELECT Username FROM UsersInfo");
                    return output.ToList();
                }
                else if (command == "LOG" || command == "REQ" || command == "ANS")
                {
                    var output = cnn.Query<UserDB>("SELECT Username, Password FROM UsersInfo");
                    return output.ToList();
                }
                return null;
            }
        }
        public static List<string> GetUserName(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<string>($"SELECT Username FROM UsersInfo WHERE UserID = {id}").ToList();
                return output;
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
