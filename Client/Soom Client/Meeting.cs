using Soom_Client.Properties;
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
    public partial class Meeting : Form
    {
        #region CTor
        public Meeting()
        {
            InitializeComponent();
        }
        #endregion

        #region Hoverred Settings
        private void muteBtn_MouseEnter(object sender, EventArgs e)
        {
            muteBtn.Image = Resources.Hoverred_Mute_Button;
        }
        private void muteBtn_MouseLeave(object sender, EventArgs e)
        {
            muteBtn.Image = Resources.Mute_Button;
        }
        private void videoBtn_MouseEnter(object sender, EventArgs e)
        {
            videoBtn.Image = Resources.Hoverred_Video_Button;
        }
        private void videoBtn_MouseLeave(object sender, EventArgs e)
        {
            videoBtn.Image= Resources.Video_Button;
        }
        #endregion

        #region Buttons Clicks
        private void muteBtn_Click(object sender, EventArgs e)
        {
            if (muteBtn.Image == Resources.Mute_Button)
                muteBtn.Image = Resources.Unmute_Button;
            else
                muteBtn.Image = Resources.Mute_Button;
        }

        private void videoBtn_Click(object sender, EventArgs e)
        {
            if (videoBtn.Image == Resources.Video_Button)
                videoBtn.Image = Resources.UnVideo_Button;
            else
                videoBtn.Image = Resources.Video_Button;
        }
        #endregion
    }
}
