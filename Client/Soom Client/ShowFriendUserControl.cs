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
    public partial class ShowFriendUserControl : UserControl, IFriendsComponents
    {
        #region CTor
        public ShowFriendUserControl()
        {
            InitializeComponent();
            ClearLabels();
        }
        #endregion

        #region Get Functions
        public string GetUsername()
        {
            return this.usernameBox.Text;
        }
        #endregion

        #region Set Functions
        public void SetUsername(string username)
        {
            this.usernameBox.Text = username;
        }
        public void SetAge(string age)
        {
            this.ageBox.Text = age;
        }
        public void SetSex(string sex)
        {
            this.sexBox.Text = sex;
        }
        public void SetBio(string bio)
        {
            this.bioBox.Text = bio;
        }
        public void SetPoints(string points)
        {
            this.pointsBox.Text = points;
        }
        #endregion

        #region Clear Functions
        public void ClearLabels()
        {
            this.usernameBox.Text = "";
            this.ageBox.Text = "";
            this.sexBox.Text = "";
            this.bioBox.Text = "";
        }
        #endregion
    }
}
