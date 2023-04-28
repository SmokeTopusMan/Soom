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
    public partial class LoginPanel : UserControl
    {
        #region Properties
        public string UserName { get { return usernameLogTextBox.Text; } private set { } }
        public string Password { get { return passLogTextBox.Text; } private set { } }
        #endregion
        public LoginPanel()
        {
            InitializeComponent();
        }

        #region ClearFunctions
        public void ClearBoxes()
        {
            usernameLogTextBox.Text = "";
            passLogTextBox.Text = "";
        }
        public void ClearPassword()
        {
            passLogTextBox.Text = "";
        }
        public void ClearUsername()
        {
            usernameLogTextBox.Text = "";
        }
        #endregion

        private void usernameLogTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }

        private void passLogTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            passLogTextBox.PasswordChar = '*';
        }
    }
}
