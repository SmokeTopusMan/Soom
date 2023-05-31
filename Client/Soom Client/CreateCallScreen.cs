using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class CreateCallScreen : UserControl, IMainScreenComponents
    {
        #region Properties
        public event FinishedEvent Event;
        public bool IsFinished { get; private set; }
        private Socket _socket;
        private int _id;
        #endregion

        #region CTor
        public CreateCallScreen(Socket socket, int id)
        {
            InitializeComponent();
            IsFinished = false;
            _socket = socket;
            _id = id;
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
                Event(this, new ExitEventArgs(this, Name));
            }
        }
        #endregion

        #region Terms & Buttons Hoverred Settings
        private void RestrictedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetterOrDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) && e.KeyChar != '\b')
            {
                e.Handled = true; // Ignore the key press
            }
            else
            {
                // Convert the character to uppercase if it's a letter
                if (char.IsLetter(e.KeyChar))
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
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

        #region Private Functions
        private void generateInfoBtn_Click(object sender, EventArgs e)
        {
            callsNameBox.Text = GenerateRandomString(6);
            callsPasswordBox.Text = GenerateRandomString(8);
        }
        #endregion

        #region Public Functions
        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();

            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }
        #endregion

        #region Buttons Click
        private void startMeetingBtn_Click(object sender, EventArgs e)
        {
            if(callsNameBox.Text.Length < 6)
            {
                MessageBox.Show("The Name is not good, need at least 6 characters!");
                return;
            }
            if(callsPasswordBox.Text.Length < 6)
            {
                MessageBox.Show("The password is not good, need at least 6 characters!");
                return;
            }
            byte[] idbytes = SymmetricEncryption.EncryptStringToBytesAES(_id.ToString());
            if(sendFriendsBox.Checked)
                _socket.Send(Encoding.UTF8.GetBytes($"STR{idbytes.Length.ToString("00")}").Concat(idbytes).Concat(Encoding.UTF8.GetBytes("YE")).ToArray());
            else
                _socket.Send(Encoding.UTF8.GetBytes($"STR{idbytes.Length.ToString("00")}").Concat(idbytes).Concat(Encoding.UTF8.GetBytes("NO")).ToArray());
        }
        #endregion
    }
}
