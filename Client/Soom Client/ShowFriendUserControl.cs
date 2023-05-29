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
        public ShowFriendUserControl()
        {
            InitializeComponent();
            ClearLabels();
        }
        public string GetUsername()
        {
            return this.usernameBox.Text;
        }
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
        public void ClearLabels()
        {
            this.usernameBox.Text = "";
            this.ageBox.Text = "";
            this.sexBox.Text = "";
            this.bioBox.Text = "";
        }
    }
}
