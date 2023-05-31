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
        #region Properties
        public string UserName { get { return usernameBox.Text; } private set { } }
        #endregion

        #region CTor
        public AddFriendUserControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Components Terms
        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        #endregion

        #region Public Functions
        public void ClearUsername()
        {
            usernameBox.Text = "";
        }
        #endregion
    }
}
