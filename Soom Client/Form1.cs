using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class Form1 : Form
    {
        private string _userInfo;
        public Form1()
        {
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

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (loginClick.Visible)
            {
                if (LogInfoCheck())
                {
                    loginClick.ClearBoxes();
                    this._userInfo += $"LOG#{loginClick.UserName}#{loginClick.Password}";

                }
            }
            else
            {
                if (RegInfoCheck())
                {
                    registerClick.ClearBoxes();
                    this._userInfo += $"REG#{registerClick.UserName}#{registerClick.Password}#{registerClick.Age}#{registerClick.Sex}";
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
        /*
private void getInfo()
{
Thread log = new Thread(new ThreadStart(() => loginClick.IsInfo(this.info)));
Thread reg = new Thread(new ThreadStart(() => registerClick.IsInfo(this.info)));
reg.Start();
log.Start();
while (log.IsAlive || reg.IsAlive) 
{
if (!log.IsAlive)
 reg.Abort();
else if(!reg.IsAlive)
 log.Abort();
}
MessageBox.Show("Yay Works!");
}
*/
    }
}
