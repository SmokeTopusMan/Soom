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
    public partial class SettingsScreen : UserControl, IMainScreenComponents
    {
        #region Properties
        private readonly Socket _socket;
        private readonly int _id;
        public bool IsFinished { get; private set; }
        public event FinishedEvent Event;
        #endregion

        #region CTor
        public SettingsScreen(Socket sock, int id)
        {
            InitializeComponent();
            _socket = sock;
            IsFinished = false;
            _id = id;
            GetDataFromServer("PRO", this.profileUserControl);
            GetDataFromServer("AUD", this.audioUserControl);
            GetDataFromServer("VID", this.videoUserControl);
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
        #endregion

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
            Event?.Invoke(this, new ExitEventArgs(this, Name));
        }
        #endregion

        #region Button Clicks
        private void profileSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.profileUserControl.Visible)
            {
                this.title.Hide();
                this.applyBtn.Hide();
                this.profileUserControl.Hide();
                this.profileUserControl.ResetSettingsToDefault();
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
                this.title.Hide();
                this.applyBtn.Hide();
                this.videoUserControl.Hide();
                this.videoUserControl.StopVid();
                this.videoUserControl.ResetSettingsToDefault();
            }
            else
            {
                HideAllComponents(this.videoUserControl);
                this.applyBtn.Show();
                this.videoUserControl.Show();
                this.videoUserControl.StartVid();
            }
        }
        private void audioSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.audioUserControl.Visible)
            {
                this.title.Hide();
                this.applyBtn.Hide();
                this.audioUserControl.Hide();
                this.audioUserControl.ResetSettingsToDefault();
            }
            else
            {
                HideAllComponents(this.audioUserControl);
                this.title.Show();
                this.applyBtn.Show();
                this.audioUserControl.Show();
            }
        }
        private void applyBtn_Click(object sender, EventArgs e)
        {
            string stringData;
            List<string> changesList;
            if (profileUserControl.Visible)
            {
                changesList = this.profileUserControl.GetChanges();
                stringData = "CNGPRO";
            }
            else if (audioUserControl.Visible)
            {
                changesList = this.audioUserControl.GetChanges();
                stringData = "CNGAUD";
            }
            else
            {
                changesList = this.videoUserControl.GetChanges();
                stringData = "CNGVID";
            }
            if (changesList != null)
            {
                string stringChanges = $"{_id}";
                foreach (string item in changesList)
                {
                    stringChanges += "#";
                    if (item != "None")
                        stringChanges += item;
                }
                byte[] byteChanges = SymmetricEncryption.EncryptStringToBytesAES(stringChanges);
                byte[] msg = Encoding.UTF8.GetBytes(stringData);
                msg = msg.Concat(Encoding.UTF8.GetBytes(byteChanges.Length.ToString("0000"))).Concat(byteChanges).ToArray();
                try
                {
                    _socket.Send(msg);
                    byte[] bytes = new byte[2];
                    _socket.Receive(bytes, 2, SocketFlags.None);
                    if (Encoding.UTF8.GetString(bytes) == "OK")
                    {
                        if (profileUserControl.Visible)
                            profileUserControl.UpdateProfile();
                        else if (audioUserControl.Visible)
                            audioUserControl.UpdateAudio();
                        else
                            videoUserControl.UpdateVideo();
                        _socket.Send(Encoding.UTF8.GetBytes("OK"));
                        this.applyBtn.Enabled = false;
                    }
                    else
                    {
                        byte[] temp = new byte[1];
                        _socket.Receive(temp, 1, SocketFlags.None);
                        bytes = bytes.Concat(temp).ToArray();
                        if (Encoding.UTF8.GetString(bytes) == "BYE")
                        {
                            IsFinished = true;
                            Finished();
                        }
                        else
                        {
                            int errNum = int.Parse(Encoding.UTF8.GetString(bytes)[2].ToString());
                            OpenningScreen.ServerErrorsHandler((ServerErrors)errNum);
                        }
                    }
                }
                catch (SocketException)
                {
                    this._socket.Close();
                    MessageBox.Show("The Server is Having Some Technical Difficulties...\r\n Try Again Later <3");
                    IsFinished = true;
                    Finished();
                }
            }

        }
        #endregion

        #region Private Functions
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
            {
                this.title.Hide();
                this.profileUserControl.Hide();
                this.profileUserControl.ResetSettingsToDefault();
            }
            else if (component != this.videoUserControl && this.videoUserControl.Visible)
            {
                this.title.Hide();
                this.videoUserControl.Hide();
                this.videoUserControl.StopVid();
                this.videoUserControl.ResetSettingsToDefault();
            }
            else if (component != this.audioUserControl && this.audioUserControl.Visible)
            {
                this.title.Hide();
                this.audioUserControl.Hide();
                this.audioUserControl.ResetSettingsToDefault();
            }
        }
        private void GetDataFromServer(string command, ISettingsScreenComponent component)
        {
            try
            {
                byte[] idbytes = SymmetricEncryption.EncryptStringToBytesAES(_id.ToString());
                _socket.Send(Encoding.UTF8.GetBytes($"{command}{idbytes.Length:00}").Concat(idbytes).ToArray());
                byte[] data = new byte[2];
                _socket.Receive(data, 2, SocketFlags.None);
                if (Encoding.UTF8.GetString(data) == "OK")
                {
                    data = new byte[4];
                    _socket.Receive(data, 4, SocketFlags.None);
                    int length = int.Parse(Encoding.UTF8.GetString(data));
                    data = new byte[length];
                    _socket.Receive(data, length, SocketFlags.None);
                    component.OrgenizeData(SymmetricEncryption.DecryptBytesToStringAES(data));
                    _socket.Send(Encoding.UTF8.GetBytes("OK"));
                }
            }
            catch (SocketException)
            {
                this._socket.Close();
                MessageBox.Show("The Server is Having Some Technical Difficulties...\r\n Try Again Later <3");
                IsFinished = true;
                Finished();
            }
        }
        #endregion

        #region Public Functions
        public void CloseVid()
        {
            videoUserControl.StopVid();
        }
        #endregion

        #region Form's Settings
        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            GetDataFromServer("PRO", this.profileUserControl);
            GetDataFromServer("AUD", this.audioUserControl);
            GetDataFromServer("VID", this.videoUserControl);
        }
        #endregion

    }

}
