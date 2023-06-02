using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class CallScreen : UserControl, IMainScreenComponents
    {
        #region Properties
        public bool IsCreateScreen { get; set; }
        public event FinishedEvent Event;
        public event MeetingEvent MeetingEvent;
        public bool IsFinished { get; private set; }
        private Socket _socket;
        private int _id;
        #endregion

        #region CTor
        public CallScreen(Socket socket, int id, bool isCreateScreen)
        {
            InitializeComponent();
            IsFinished = false;
            _socket = socket;
            _id = id;
            IsCreateScreen = isCreateScreen;
            if (!IsCreateScreen)
            {
                this.generateInfoBtn.Hide();
                this.startMeetingBtn.Text = "Join a Meeting";
            } 
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
        private string GenerateRandomString(int length)
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

        #region Public Functions
        public void MeetingEventCaller(Socket vidSock, Socket audSock)
        {
            if (MeetingEvent != null)
            {
                MeetingEvent(this, new MeetingEventArgs(vidSock, audSock, callsNameBox.Text));
            }
        }
        #endregion

        #region Buttons Click
        private void generateInfoBtn_Click(object sender, EventArgs e)
        {
            callsNameBox.Text = GenerateRandomString(6);
            callsPasswordBox.Text = GenerateRandomString(8);
        }
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
            byte[] msg, callInfo = SymmetricEncryption.EncryptStringToBytesAES($"{callsNameBox.Text}#{callsPasswordBox.Text}");
            if(IsCreateScreen)
                msg = Encoding.UTF8.GetBytes($"STR{idbytes.Length.ToString("00")}").Concat(idbytes).ToArray();
            else
                msg = Encoding.UTF8.GetBytes($"JON{idbytes.Length.ToString("00")}").Concat(idbytes).ToArray();
            msg = msg.Concat(Encoding.UTF8.GetBytes(callInfo.Length.ToString("00"))).Concat(callInfo).ToArray();
            _socket.Send(msg);
            byte[] data = new byte[2];
            _socket.Receive(data, 2, SocketFlags.None);
            string sData = Encoding.UTF8.GetString(data);
            if (Encoding.UTF8.GetString(data) != "OK")
            {
                data = new byte[1];
                _socket.Receive(data, 1, SocketFlags.None);
                if (sData == "E")
                {
                    IsFinished = true;
                    Finished();
                    return;
                }
                else
                {
                    int errNum = int.Parse(Encoding.UTF8.GetString(data));
                    OpenningScreen.ServerErrorsHandler((ServerErrors)errNum);
                }
                _socket.Send(Encoding.UTF8.GetBytes("OK"));
            }
            else
            {
                _socket.Send(Encoding.UTF8.GetBytes("OK"));
                data = new byte[16];
                _socket.Receive(data,16, SocketFlags.None);
                int meetingPort = int.Parse(SymmetricEncryption.DecryptBytesToStringAES(data));
                // Get the remote endpoint
                EndPoint remoteEndpoint = _socket.RemoteEndPoint;
                IPEndPoint ipEndpoint = remoteEndpoint as IPEndPoint;
                IPAddress remoteAddress = ipEndpoint.Address;
                IPEndPoint meetingIPEndPoint = new IPEndPoint(remoteAddress, meetingPort);
                Socket vidSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket audSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                vidSock.Connect(meetingIPEndPoint);
                audSock.Connect(meetingIPEndPoint);
                MeetingEventCaller(vidSock, audSock);
            }
        }
        #endregion
    }
    public class MeetingEventArgs : EventArgs
    {
        public Socket VidSock { get;private set; }
        public string Name { get;private set; }
        public Socket AudSock { get;private set; }
        public MeetingEventArgs(Socket vidSock, Socket audSock, string name)
        {
            VidSock = vidSock;
            AudSock = audSock;
            Name = name;
        }
    }
    public delegate void MeetingEvent(object sender, MeetingEventArgs e);
}
