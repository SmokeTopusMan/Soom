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
    public partial class SettingsPanel : UserControl
    {
        public SettingsPanel()
        {
            InitializeComponent();
        }
        #region ButtonsHoverSettings
        private void profileSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            profileSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            profileSettingsButton.Font = new Font(profileSettingsButton.Font.Name, profileSettingsButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void profileSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            profileSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            profileSettingsButton.Font = new Font(profileSettingsButton.Font.Name, profileSettingsButton.Font.SizeInPoints, FontStyle.Regular);
        }
        private void generalSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            generalSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            generalSettingsButton.Font = new Font(generalSettingsButton.Font.Name, generalSettingsButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void generalSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            generalSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            generalSettingsButton.Font = new Font(generalSettingsButton.Font.Name, generalSettingsButton.Font.SizeInPoints, FontStyle.Regular);
        }
        private void audioSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            audioSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            audioSettingsButton.Font = new Font(audioSettingsButton.Font.Name, audioSettingsButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void audioSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            audioSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            audioSettingsButton.Font = new Font(audioSettingsButton.Font.Name, audioSettingsButton.Font.SizeInPoints, FontStyle.Regular);
        }
        private void videoSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            videoSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            videoSettingsButton.Font = new Font(videoSettingsButton.Font.Name, videoSettingsButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void videoSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            videoSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            videoSettingsButton.Font = new Font(videoSettingsButton.Font.Name, videoSettingsButton.Font.SizeInPoints, FontStyle.Regular);
        }
        #endregion
    }
}
