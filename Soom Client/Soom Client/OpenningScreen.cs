using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                int length = 0;
                byte[] data;
                if (loginClick.Visible)
                {
                    
                    if (LogInfoCheck())
                    {
                        length += loginClick.UserName.Length + loginClick.Password.Length + 1;
                        this._userInfo += $"LOG{length.ToString("00")}{loginClick.UserName}#{loginClick.Password}";
                        loginClick.ClearBoxes();
                    }
                }
                else
                {
                    if (RegInfoCheck())
                    {
                        length += registerClick.UserName.Length + registerClick.Password.Length + registerClick.Age.Length + registerClick.Sex.ToString().Length + 3;
                        if (registerClick.Bio != "")
                        {
                            length += registerClick.Bio.Length + 1;
                            this._userInfo += $"REG{length.ToString("0000")}{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}#{registerClick.Bio}";
                        }
                        else
                            this._userInfo += $"REG{length.ToString("0000")}{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}";
                        registerClick.ClearBoxes(); 
                    }
                }
                if (this._userInfo != null)
                {
                    data = new byte[length + 3];
                    data = Encoding.UTF8.GetBytes(this._userInfo); //Future: Test if i can do it without the variable data: _socket.Send(Encoding.UTF8.GetBytes(this._userInfo)); and changed the regiter as well
                    _socket.Send(data);
                    data = new byte[2];
                    _socket.Receive(data, 2, SocketFlags.None);
                    if (data == new byte[2])
                    {
                        throw new SocketException();
                    }
                    else if (Encoding.UTF8.GetString(data) == "OK")
                    {
                        this.Close();
                    }
                    else
                    {
                        this._userInfo = null;
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
    }
}
