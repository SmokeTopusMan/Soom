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
    public partial class AddFriendUserControl : UserControl, IFriendsComponents
    {
        public string UserName { get { return usernameBox.Text; } private set { } }
        public AddFriendUserControl()
        {
            InitializeComponent();
        }
        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        public void ClearUsername()
        {
            usernameBox.Text = "";
        }
    }
}
