using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using NAudio.Wave;
using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Drawing.Imaging;

namespace Soom_Client
{
    public partial class MeetingScreen : Form
    {
        #region Properties
        public bool IsAlive { get;set; }
        private Socket _vidSock;
        private Socket _audSock;
        private Socket _mainSock;
        private bool _isMuted;
        private bool _isVidOn;
        private bool _isMirrored;
        private int _volume;
        private string _audioInputDeviceName;
        private string _audioOutputDeviceName;
        private string _videoDeviceName;
        VideoCaptureDevice _videoCaptureDevice;
        private Stopwatch _stopwatch;
        TimeSpan _frameRate;
        TimeSpan _minFrameTime;
        private Dictionary<string, PictureBox> _MatchUserToBox;

        #endregion

        #region CTor
        public MeetingScreen(Socket vidSock, Socket audSock, Socket mainSock)
        {
            InitializeComponent();
            _vidSock = vidSock;
            _audSock = audSock;
            _mainSock = mainSock;
            _stopwatch = new Stopwatch();
            _frameRate = TimeSpan.FromMilliseconds(1000.0 / 30);
            _minFrameTime = _frameRate;
            SetSettings();
            IsAlive = true;
            _MatchUserToBox = new Dictionary<string, PictureBox>
            {
                { "me", pictureBox1 }
            };
        }
        #endregion

        #region Hoverred Settings
        private void muteBtn_MouseEnter(object sender, EventArgs e)
        {
            if(_isMuted)
                muteBtn.Image = Resources.Hoverred_Mute_Button;
            else
                muteBtn.Image= Resources.Hoverred_Unmute_Button;
        }
        private void muteBtn_MouseLeave(object sender, EventArgs e)
        {
            if (_isMuted)
                muteBtn.Image = Resources.Mute_Button;
            else
                muteBtn.Image = Resources.Unmute_Button;
        }
        private void videoBtn_MouseEnter(object sender, EventArgs e)
        {
            if (_isVidOn)
                videoBtn.Image = Resources.Hoverred_Video_Button;
            else
                videoBtn.Image = Resources.Hoverred_UnVideo_Button;
        }
        private void videoBtn_MouseLeave(object sender, EventArgs e)
        {
            if (_isVidOn)
                videoBtn.Image = Resources.Video_Button;
            else
                videoBtn.Image = Resources.UnVideo_Button;
        }
        #endregion

        #region Buttons Clicks
        private void muteBtn_Click(object sender, EventArgs e)
        {
            if (!_isMuted)
                muteBtn.Image = Resources.Hoverred_Unmute_Button;
            else
                muteBtn.Image = Resources.Hoverred_Mute_Button;
            _isMuted = !_isMuted;
        }
        private void videoBtn_Click(object sender, EventArgs e)
        {
            if (!_isVidOn)
            {
                videoBtn.Image = Resources.Hoverred_UnVideo_Button;
                _stopwatch.Reset();
            }
            else
                videoBtn.Image = Resources.Hoverred_Video_Button;
            _isVidOn = !_isVidOn;
        }
        #endregion

        #region Private Functions
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            if (_isVidOn)
            {
                if (_stopwatch.Elapsed == TimeSpan.Zero)
                    _stopwatch.Start();
                var frameTime = _stopwatch.Elapsed;
                if (frameTime > _frameRate)
                {
                    _minFrameTime = _minFrameTime.Add(TimeSpan.FromMilliseconds(_frameRate.TotalMilliseconds));
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                    byte[] frame = BitmapToBytes(bitmap, out int length);
                    _vidSock.Send(Encoding.UTF8.GetBytes(length.ToString("00000")).Concat(frame).ToArray());
                    if (_isMirrored)
                    {
                        var filter = new Mirror(false, true);
                        filter.ApplyInPlace(bitmap);
                    }
                    pictureBox1.Image = bitmap;
                }
                else
                {
                    eventArgs.Frame.Dispose();
                }
            }
            else
            {
                try
                {
                    if (pictureBox1.Image != null)
                        pictureBox1.Image = null;
                }
                catch (NullReferenceException)
                {

                }
            }
        }
        private byte[] BitmapToBytes(Bitmap bitmap, out int length)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Save the bitmap to the memory stream
                bitmap.Save(stream, ImageFormat.Jpeg);

                // Get the byte array from the memory stream
                byte[] bytes = stream.ToArray();
                length = bytes.Length;

                return bytes;
            }
        }
        private Bitmap BytesToBitmap(byte[] bytes)
        {
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                // Create a new bitmap from the memory stream
                Bitmap bitmap = new Bitmap(stream);
                if (_isMirrored)
                {
                    var filter = new Mirror(false, true);
                    filter.ApplyInPlace(bitmap);
                }
                return bitmap;
            }
        }
        private void SetSettings()
        {
            string videoInfo = RecieveSettingsFromServer();
            OrgenizeVideoData(videoInfo.Split('#'));
            string audioInfo = RecieveSettingsFromServer();
            OrgenizeAudioData(audioInfo.Split('#'));
        }
        private string RecieveSettingsFromServer()
        {
            byte[] temp = new byte[2];
            _mainSock.Receive(temp);
            temp = new byte[4];
            _mainSock.Receive(temp);
            int length = int.Parse(Encoding.UTF8.GetString(temp));
            temp = new byte[length];
            _mainSock.Receive(temp);
            _mainSock.Send(Encoding.UTF8.GetBytes("OK"));
            return SymmetricEncryption.DecryptBytesToStringAES(temp);
        }
        private void PresentDataToScreen(string username, byte[] frame)
        {
            PictureBox pictureBox = _MatchUserToBox[username];
            Bitmap picture = BytesToBitmap(frame);
            pictureBox.Image = picture;
        }
        private void RecieveVideoFromServer()
        {
            while (IsAlive)
            {
                byte[] frame = new byte[2];
                _vidSock.Receive(frame);
                int length = int.Parse(Encoding.UTF8.GetString(frame));
                frame = new byte[length];
                _vidSock.Receive(frame);
                string username = SymmetricEncryption.DecryptBytesToStringAES(frame);
                frame = new byte[5];
                _vidSock.Receive(frame);
                length = int.Parse(Encoding.UTF8.GetString(frame));
                frame = new byte[length];
                _vidSock.Receive(frame);
                PresentDataToScreen(username, frame);
            }
        }
        private void RecieveUsersInfo()
        {
            while (true)
            {
                byte[] command = new byte[3];
                _mainSock.Receive(command);
                byte[] bytes = new byte[2];
                _mainSock.Receive(bytes);
                int length = int.Parse(Encoding.UTF8.GetString(bytes));
                bytes = new byte[length];
                _mainSock.Receive(bytes);
                string username = SymmetricEncryption.DecryptBytesToStringAES(bytes);
                if (Encoding.UTF8.GetString(command) == "JON")
                    AddNewUserToCall(username);
                else
                    RemoveNewUserFromCall(username);
            }
        }
        private void AddNewUserToCall(string name)
        {
            if (_MatchUserToBox.Count == 1)
                _MatchUserToBox.Add(name, pictureBox2);
            else if (_MatchUserToBox.Count == 2)
                _MatchUserToBox.Add(name, pictureBox3);
            else
                _MatchUserToBox.Add(name, pictureBox4);
        }
        private void RemoveNewUserFromCall(string name) 
        {

        }
        private FilterInfo FindIndexOfVideoDevice()
        {
            FilterInfoCollection f = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            int i = 0;
            foreach (FilterInfo item in f)
            {
                if (item.Name == _videoDeviceName)
                    return item;
                i++;
            }
            return null;
        }
        #endregion

        #region Public Functions
        public void OrgenizeAudioData(string[] dataComponents)
        {
            if (dataComponents[0] == "")
            {
                _audioInputDeviceName = WaveInEvent.GetCapabilities(0).ProductName;
            }
            else
                this._audioInputDeviceName = dataComponents[0];
            if (dataComponents[1] == "")
            {
                _audioOutputDeviceName = WaveOut.GetCapabilities(0).ProductName;
            }
            else
                _audioOutputDeviceName = dataComponents[1];
            _volume = int.Parse(dataComponents[2]);
            if (dataComponents[3] != "0")
            {
                _isMuted = false;
                muteBtn.Image = Resources.Unmute_Button;
            }
            else
                _isMuted = true;
        }
        public void OrgenizeVideoData(string[] dataComponents)
        {
            if (dataComponents[0] == "")
                _videoDeviceName = new FilterInfoCollection(FilterCategory.VideoInputDevice)[0].Name;
            else
                _videoDeviceName = dataComponents[0];
            if (dataComponents[1] == "0")
            {
                _isMirrored = false;
            }
            else
                _isMirrored = true;
            if (dataComponents[2] != "0")
            {
                _isVidOn = false;
                videoBtn.Image = Resources.UnVideo_Button;
            }
            else
            {
                _isVidOn = true;
            }

        }
        public void StartGetVideoFromServer()
        {
            _videoCaptureDevice = new VideoCaptureDevice(FindIndexOfVideoDevice().MonikerString);
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities.First(v => v.FrameSize.Width == 320 && v.FrameSize.Height == 240);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            Thread t = new Thread(new ThreadStart(() => RecieveVideoFromServer()));
            t.Start();
            Thread t1 = new Thread(new ThreadStart(()=> RecieveUsersInfo()));
            t1.Start();
            _videoCaptureDevice.Start();
        }
        #endregion
        private void Meeting_FormClosing(object sender, FormClosingEventArgs e)
        {
            _vidSock.Close();
            _audSock.Close();
        }
    }
}
