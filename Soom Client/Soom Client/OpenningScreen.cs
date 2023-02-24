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

        private void submitBtn_Click(object sender, EventArgs e) //Future: add here the try and catch for the socket loop and find a way to stop the current form.
        {
            if (loginClick.Visible)
            {
                if (LogInfoCheck())
                {
                    int length = loginClick.UserName.Length + loginClick.Password.Length + 1;
                    this._userInfo += $"LOG{length.ToString("000")}{loginClick.UserName}#{loginClick.Password}"; //ToDo: Change to the decided message protocol (with or without 3 bytes of data length before #).
                    loginClick.ClearBoxes();
                    try
                    {
                        byte[] data = new byte[1024];
                        data = Encoding.UTF8.GetBytes(this._userInfo);
                        _socket.Send(data);
                    }
                    catch
                    {

                    }
                }
            }
            else
            {
                if (RegInfoCheck())
                {
                    registerClick.ClearBoxes();
                    this._userInfo += $"REG#{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}"; //ToDo: Change to the decided message protocol (with or without 3 bytes of data length before #).
                    if (registerClick.Bio != "")
                        this._userInfo += $"#{registerClick.Bio}";
                }
            }
        }
        private bool LogInfoCheck()
        {
            if (loginClick.UserName != "" && loginClick.Password != "")
                return true;
            if (loginClick.UserName == "")
                MessageBox.Show("Fill Your Username!");
            if (loginClick.Password == "")
                MessageBox.Show("Fill Your Password!");
            return false;
        }
        private bool RegInfoCheck()
        {
            if (registerClick.UserName != "" && registerClick.Password != "" && registerClick.Age != "" && registerClick.Sex != Sex.NotChecked)
                return true;
            if (registerClick.UserName == "")
                MessageBox.Show("Fill Your Username!");
            if (registerClick.Password == "")
                MessageBox.Show("Fill Your Password!");
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
