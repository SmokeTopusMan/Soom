using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Soom_Client
{
    public partial class SettingsScreen : UserControl
    {
        private Socket _socket;
        public bool IsFinished { get; set; }
        public event FinishedEvent Event;

        public SettingsScreen(Socket sock)
        {
            InitializeComponent();
            _socket = sock;
            IsFinished = false;
            this.videoUserControl.Hide();
            this.videoUserControl.ChangedEvent += CheckIfChanged;
            this.profileUserControl.Hide();
            this.profileUserControl.ChangedEvent += CheckIfChanged;
            this.audioUserControl.Hide();
            this.audioUserControl.ChangedEvent += CheckIfChanged;
            this.applyBtn.Enabled = false;
            this.applyBtn.Hide();
            this.title.Hide();
        }

        #region Buttons Hoverred settings
        private void profileSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            profileSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            profileSettingsButton.Font = new Font("Microsoft JhengHei Light", 20F,(FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void profileSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            profileSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            profileSettingsButton.Font = new Font("Microsoft JhengHei Light", profileSettingsButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void generalSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            generalSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            generalSettingsButton.Font = new Font("Microsoft JhengHei Light", 20F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void generalSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            generalSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            generalSettingsButton.Font = new Font("Microsoft JhengHei Light", generalSettingsButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void audioSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            audioSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            audioSettingsButton.Font = new Font("Microsoft JhengHei Light", 20F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void audioSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            audioSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            audioSettingsButton.Font = new Font("Microsoft JhengHei Light", audioSettingsButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void videoSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            videoSettingsButton.ForeColor = Color.FromArgb(195, 42, 196);
            videoSettingsButton.Font = new Font("Microsoft JhengHei Light", 20F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void videoSettingsButton_MouseLeave(object sender, EventArgs e)
        {
            videoSettingsButton.ForeColor = Color.FromArgb(125, 0, 19);
            videoSettingsButton.Font = new Font("Microsoft JhengHei Light", videoSettingsButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            backButton.Image = Resources.HoverredbackButton;
            this.Cursor = Cursors.Hand;
        }
        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            backButton.Image = Resources.backButton;
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region Back Button Press
        private void backButton_Click(object sender, EventArgs e)
        {
            Finished();
        }

        public void Finished()
        {
            // Raise the event with custom EventArgs
            if (Event != null)
            {
                Event(this, new SettingsEventArgs(this));
            }
        }
        #endregion
        private void profileSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.profileUserControl.Visible)
            {
                MessageBox.Show("Need to do here: the action u did are not saved. click apply to save them.");
                this.title.Hide();
                this.applyBtn.Hide();
                this.profileUserControl.Hide();
            }
            else
            {
                HideAllComponents(this.profileUserControl);
                this.title.Show();
                this.applyBtn.Show();
                this.profileUserControl.Show();
            }
        }
        private void videoSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.videoUserControl.Visible)
            {
                MessageBox.Show("Need to do here: the action u did are not saved. click apply to save them.");
                this.title.Hide();
                this.applyBtn.Hide();
                this.videoUserControl.Hide();
            }
            else
            {
                HideAllComponents(this.videoUserControl);
                this.title.Show();
                this.applyBtn.Show();
                this.videoUserControl.Show();
            }
        }
        private void audioSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.audioUserControl.Visible)
            {
                MessageBox.Show("Need to do here: the action u did are not saved. click apply to save them.");
                this.title.Hide();
                this.applyBtn.Hide();
                this.audioUserControl.Hide();
            }
            else
            {
                HideAllComponents(this.audioUserControl);
                this.title.Show();
                this.applyBtn.Show();
                this.audioUserControl.Show();
            }
        }
        private void CheckIfChanged(ValuesChangedEventArgs e)
        {
            if (e.IsChanged)
            {
                if (!this.applyBtn.Enabled)
                    this.applyBtn.Enabled = true;
            }
            else
                this.applyBtn.Enabled = false;
        }
        private void HideAllComponents(Component component)
        {
            this.applyBtn.Enabled = false;
            if (component != this.profileUserControl && this.profileUserControl.Visible)
                this.profileUserControl.Hide();
            else if (component != this.videoUserControl && this.videoUserControl.Visible)
                this.videoUserControl.Hide();
            else if (component != this.audioUserControl && this.audioUserControl.Visible)
                this.audioUserControl.Hide();
        }
    }
    public class SettingsEventArgs : EventArgs
    {
        public SettingsScreen settingsScreen { get; }

        public SettingsEventArgs(SettingsScreen screen)
        {
            settingsScreen = screen;
        }
    }
    public delegate void FinishedEvent(object sender, SettingsEventArgs e);
}
