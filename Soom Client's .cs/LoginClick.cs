using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class LoginClick : UserControl
    {
        public LoginClick()
        {
            InitializeComponent();
        }

        private void loginSubmitBtn_Click(object sender, EventArgs e)
        {
            string userInfo = "LOG#";
            if (CheckAllBoxes())
            {
                userInfo += $"username:{usernameLogTextBox.Text}#password:{passLogTextBox.Text}";
            }
            else
            {
                if (usernameLogTextBox.Text == "")
                    MessageBox.Show("You need to choose a username!");
                else if (passLogTextBox.Text == "")
                    MessageBox.Show("You need to choose a password!");
            }
        }
        private bool CheckAllBoxes()
        {
            return (usernameLogTextBox.Text != "" && passLogTextBox.Text != "");
        }
    }
}
