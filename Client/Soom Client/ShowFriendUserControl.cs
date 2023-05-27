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
        public void SetUsername(string username)
        {
            this.username.Text = username;
        }
        public void SetAge(string age)
        {
            this.age.Text = age;
        }
        public void SetSex(string sex)
        {
            this.sex.Text = sex;
        }
        public void SetBio(string bio)
        {
            this.bio.Text = bio;
        }
        public void SetPoints(string points)
        {
            this.pointsBox.Text = points;
        }
        public void ClearLabels()
        {
            this.username.Text = "";
            this.age.Text = "";
            this.sex.Text = "";
            this.bio.Text = "";
        }
    }
}
