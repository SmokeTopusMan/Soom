using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Soom_Client
{
    public partial class OpenningScreen : Form
    {
        private string _userInfo;
        private Socket _socket;
        public OpenningScreen(Socket socket)
        {
            _socket = socket;
            InitializeComponent();
            registerClick.Hide();
            loginClick.Hide();
            submitBtn.Hide();
        }

        private void register_Click(object sender, EventArgs e)
        {
            if (!submitBtn.Visible)
                submitBtn.Show();
            registerClick.Show();
            loginClick.Hide();
            loginClick.ClearBoxes();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (!submitBtn.Visible)
                submitBtn.Show();
            loginClick.Show();
            registerClick.Hide();
            registerClick.ClearBoxes();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data;
                if (loginClick.Visible)
                {
                    if (LogInfoCheck())
                    {
                        this._userInfo += $"{loginClick.UserName}#{loginClick.Password}";
                        data = PrepareDataViaProtocol("LOG");
                    }
                    else data = null;
                }
                else
                {
                    if (RegInfoCheck())
                    {
                        this._userInfo += $"{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}#{registerClick.Bio}";
                        data = PrepareDataViaProtocol("REG");
                    }
                    else data = null;
                }
                if (this._userInfo != null)
                {

                    _socket.Send(data); // ToDo: encrypt Here!
                    data = new byte[3];
                    int bytes = _socket.Receive(data, 2, SocketFlags.None);
                    string sData = Encoding.UTF8.GetString(data);
                    sData = sData.Replace("\0", string.Empty);
                    if (sData.Length > 0)
                    {
                        if (bytes == 2 && sData == "OK")
                        {
                            bool isGood = false;
                            for(int i = 0; i < 5; i++) // check of the data need to be removed
                            {
                                try
                                {
                                    data = new byte[4];
                                    _socket.Receive(data, 4, SocketFlags.None);
                                    int id = BitConverter.ToInt32(data, 0);
                                    if (id >= 10000 && id <= 99999)
                                    {
                                        isGood = true;
                                        _socket.Send(Encoding.UTF8.GetBytes("OK"));
                                        if (loginClick.Visible)
                                            loginClick.ClearBoxes();
                                        else
                                            registerClick.ClearBoxes();
                                        this.Hide();
                                        var mainScreen = new MainScreen(_socket, id);
                                        mainScreen.StartPosition = FormStartPosition.Manual;
                                        mainScreen.Location = this.Location;
                                        mainScreen.Closed += (s, args) => this.Close(); // Closes the current form and opens the other.
                                        mainScreen.Show();
                                        break;
                                    }
                                }
                                catch (SocketException)
                                {
                                    throw new SocketException();
                                }
                                catch 
                                {
                                    _socket.Send(Encoding.UTF8.GetBytes("NO"));
                                    continue;   
                                }
                            }
                            if (!isGood)
                                MessageBox.Show("There Was an Unknown Error.\r\nTry Again!");

                        }
                        else
                        {
                            _socket.Receive(data, 1, SocketFlags.None);
                            sData += Encoding.UTF8.GetString(data)[0];
                            if (sData == "BYE")
                                throw new SocketException();
                            else
                            {
                                this._userInfo = null;
                                int errNum = int.Parse(sData[2].ToString());
                                ServerErrorsHandler((ServerErrors)errNum);
                            }
                        }
                    }
                    else throw new SocketException();
                }
            }
            catch(SocketException)
            {
                this._userInfo = null;
                this._socket.Close();
                MessageBox.Show("The Server is Having Some Technical Difficulties...\r\n Try Again Later <3");
                this.Close();
            }
        }

        private bool LogInfoCheck()
        {
            if (loginClick.UserName != "" && loginClick.Password != "" && loginClick.Password.Length >= 8 && loginClick.UserName.Length >= 4)
                return true;
            if (loginClick.UserName == "")
                MessageBox.Show("Fill Your Username!");
            else if (loginClick.UserName.Length < 4)
            {
                MessageBox.Show("Write At Least 4 Characters In The Username Box!");
                loginClick.ClearUsername();
            }
            if (loginClick.Password == "")
                MessageBox.Show("Fill Your Password!");
            else if (loginClick.Password.Length < 8)
            {
                MessageBox.Show("Write At Least 8 Characters In The Password Box!");
                loginClick.ClearPassword();
            }
            return false;
        }
        private bool RegInfoCheck()
        {
            if (registerClick.UserName != "" && registerClick.Password != "" && registerClick.Age != "" && registerClick.Sex != Sex.NotChecked && registerClick.Password.Length >= 8 && registerClick.UserName.Length >= 4)
                return true;
            if (registerClick.UserName == "")
                MessageBox.Show("Fill Your Username!");
            else if(registerClick.UserName.Length < 4)
            {
                MessageBox.Show("Write At Least 4 Characters In The Username Box!");
                registerClick.ClearUsername();
            }
            if (registerClick.Password == "")
                MessageBox.Show("Fill Your Password!");
            else if (registerClick.Password.Length < 8)
            {
                MessageBox.Show("Write At Least 8 Characters In The Password Box!");
                registerClick.ClearPassword();
            }
            if (registerClick.Age == "")
                MessageBox.Show("Fill Your Age!");
            if (registerClick.Sex == Sex.NotChecked)
                MessageBox.Show("Select Your Sex!");
            return false;
        }
        public bool HasUserInfo()
        {
            return _userInfo != null;
        }
        private static void ServerErrorsHandler(ServerErrors err)
        {
            if (err == ServerErrors.GeneralError)
                throw new SocketException();
            else if (err == ServerErrors.UserNotExist) MessageBox.Show("The User Does Not Exist!\r\nPlease Try Again And Check The Your Data.");
            else if (err == ServerErrors.UsernameIsTaken) MessageBox.Show("This Username is Already Taken!\r\nPlease Think of Anouther Name.");
            else if (err == ServerErrors.UnknownFormat) MessageBox.Show("USE ENGLISH ONLY [and numbers :) ]!");
            else if (err == ServerErrors.CommandIsCorrupted) MessageBox.Show("Please Try Again To Do Your Action!");

        }
        private byte[] PrepareDataViaProtocol(string command)
        {
            string[] temp = this._userInfo.Split('#');
            temp[1] = EncodingMD5andSha256.CreateSha256(EncodingMD5andSha256.CreateMD5(temp[1]) + temp[0]); //ToDo: Hashing on the client side is useless, need to figure how to use keys (RSA?)
            string data = string.Join("#", temp);
            byte[] encryptedData = SymmetricEncryption.EncryptStringToBytesAES(data);
            if (command == "REG")
            {
                return Encoding.UTF8.GetBytes(command + (encryptedData.Length).ToString("0000")).Concat(encryptedData).ToArray();
            }
            return Encoding.UTF8.GetBytes(command + (encryptedData.Length).ToString("00")).Concat(encryptedData).ToArray();
        }
    }
}
