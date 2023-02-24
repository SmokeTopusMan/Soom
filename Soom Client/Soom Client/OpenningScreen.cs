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
            if (loginClick.Visible)
            {
                if (LogInfoCheck())
                {
                    int length = loginClick.UserName.Length + loginClick.Password.Length + 1;
                    this._userInfo += $"LOG{length.ToString("00")}{loginClick.UserName}#{loginClick.Password}";
                    loginClick.ClearBoxes();
                    try
                    {
                        byte[] data = new byte[length + 3];
                        data = Encoding.UTF8.GetBytes(this._userInfo); //Future: Test if i can do it without the variable data: _socket.Send(Encoding.UTF8.GetBytes(this._userInfo)); and changed the regiter as well
                        _socket.Send(data);
                    }
                    catch // ToDo: catch the sock error and close the app
                    {

                    }
                }
            }
            else
            {
                if (RegInfoCheck())
                {
                    int length = registerClick.UserName.Length + registerClick.Password.Length + registerClick.Age.Length + registerClick.Sex.ToString().Length + 3;
                    if (registerClick.Bio != "")
                    {
                        length += registerClick.Bio.Length + 1; 
                        this._userInfo += $"REG{length.ToString("0000")}{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}#{registerClick.Bio}";
                    }
                    else
                        this._userInfo += $"REG{length.ToString("0000")}{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}";

                    registerClick.ClearBoxes();

                    try
                    {
                        byte[] data = new byte[length + 3];
                        data = Encoding.UTF8.GetBytes(this._userInfo);
                        _socket.Send(data);
                    }
                    catch // ToDo: catch the sock error and close the app
                    {

                    }
                }
            }
            this._userInfo = null;
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
