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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Soom_Client
{
    public partial class OpenningScreen : Form
    {
        private string _userInfo;
        private Socket _socket;
        public OpenningScreen(Socket sock)
        {
            _socket = sock;
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
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (!submitBtn.Visible)
                submitBtn.Show();
            loginClick.Show();
            registerClick.Hide();
        }

        private void submitBtn_Click(object sender, EventArgs e) //Future: find a way to stop the current form.
        {
            try
            {
                byte[] data;
                if (loginClick.Visible)
                {
                    if (LogInfoCheck())
                    {
                        this._userInfo += $"{loginClick.UserName}#{loginClick.Password}";
                        loginClick.ClearBoxes();
                        data = PrepareDataViaProtocol("LOG");
                    }
                    else data = null;
                }
                else
                {
                    if (RegInfoCheck())
                    {
                        this._userInfo += $"{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}#{registerClick.Bio}";
                        registerClick.ClearBoxes();
                        data = PrepareDataViaProtocol("REG");
                    }
                    else data = null;
                }
                if (this._userInfo != null)
                {
                    _socket.Send(data);
                    data = new byte[3];
                    int bytes = _socket.Receive(data, 3, SocketFlags.None);
                    string sData = Encoding.UTF8.GetString(data);
                    sData = sData.Replace("\0", string.Empty);
                    if (bytes == 2 && sData == "OK")
                    {
                        this.Close();
                    }
                    else if (sData == "BYE")
                        throw new SocketException();
                    else
                    {
                        this._userInfo = null;
                        int errNum = int.Parse(sData[2].ToString());
                        ServerErrorsHandler((ServerErrors)errNum);
                    }

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
            else if (err == ServerErrors.CommandIsCorrupted) MessageBox.Show("Please Try Again To Do Your Action!");
        }
        private Byte[] PrepareDataViaProtocol(string command)
        {
            if (command == "REG")
            {
                return Encoding.UTF8.GetBytes(command + (this._userInfo.Length + 4).ToString("0000") + this._userInfo);
            }
            return Encoding.UTF8.GetBytes(command + (this._userInfo.Length + 1).ToString("00") + this._userInfo);
        }
    }
}
