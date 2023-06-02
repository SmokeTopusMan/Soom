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
using System.CodeDom.Compiler;
using System.Runtime.InteropServices.WindowsRuntime;
using AForge.Video;
using System.Reflection.Emit;

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
        private VideoCaptureDevice _videoCaptureDevice;
        private WaveInEvent _inputAudioDevice;
        private Stopwatch _stopwatch;
        TimeSpan _frameRate;
        TimeSpan _minFrameTime;
        private Dictionary<string, PictureBox> _MatchUserVideo;
        //private Dictionary<string, WaveOutEvent> _MatchUserAudio = new Dictionary<string, WaveOutEvent>();
        //private int _BytesPerMillisecond;

        #endregion

        #region CTor
        public MeetingScreen(Socket vidSock, Socket audSock, Socket mainSock, string name)
        {
            InitializeComponent();
            label2.Text = name;
            _vidSock = vidSock;
            _audSock = audSock;
            _mainSock = mainSock;
            _stopwatch = new Stopwatch();
            _frameRate = TimeSpan.FromMilliseconds(1000.0 / 30);
            _minFrameTime = _frameRate;
            SetSettings();
            IsAlive = true;
            _MatchUserVideo = new Dictionary<string, PictureBox>
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
                if (frameTime > _minFrameTime)
                {
                    _minFrameTime = _minFrameTime.Add(TimeSpan.FromMilliseconds(_frameRate.TotalMilliseconds));
                    Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                    byte[] frame = BitmapToBytes(bitmap);
                    _vidSock.Send(Encoding.UTF8.GetBytes(frame.Length.ToString("00000")).Concat(frame).ToArray());
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
        private void _inputAudioDevice_DataAvailable(object sender, WaveInEventArgs e)
        {
            if(_isMuted)
                _audSock.Send(Encoding.UTF8.GetBytes(e.Buffer.Length.ToString("00000")).Concat(e.Buffer).ToArray());
        }
        private byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Save the bitmap to the memory stream
                bitmap.Save(stream, ImageFormat.Jpeg);

                // Get the byte array from the memory stream
                byte[] bytes = stream.ToArray();

                return bytes;
            }
        }
        private Bitmap BytesToBitmap(MemoryStream bytes)
        {
            Bitmap bitmap = new Bitmap(bytes);
            return bitmap;
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
        private void PresentDataToScreen(string username, MemoryStream frame)
        {
            PictureBox pictureBox = _MatchUserVideo[username];
            Bitmap picture = BytesToBitmap(frame);
            try
            {
                pictureBox.Image = picture;
            }
            catch 
            {
                picture.Dispose();
            }
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
                MemoryStream stm = new MemoryStream();
                byte[] temp = new byte[length];
                int bytesCount = 0;
                while (bytesCount < length)
                {
                    int bytes = _vidSock.Receive(temp, length - bytesCount, SocketFlags.None);
                    byte[] d = new byte[bytes];
                    Array.Copy(temp, d, bytes);
                    stm.Write(d, 0, d.Length);
                    bytesCount += bytes;
                    temp = new byte[length - bytesCount];
                }
                PresentDataToScreen(username, stm);
            }
        }
        /*
        private void RecieveAudioFromServer()
        {
            while (IsAlive)
            {
                byte[] segment = new byte[2];
                _audSock.Receive(segment);
                int length = int.Parse(Encoding.UTF8.GetString(segment));
                segment = new byte[length];
                _vidSock.Receive(segment);
                string username = SymmetricEncryption.DecryptBytesToStringAES(segment);
                segment = new byte[5];
                _vidSock.Receive(segment);
                Thread thread = new Thread(() => { PlayAudio(username, segment); });
                thread.Start();
            }
        }
        
        private void PlayAudio(string username, byte[] data)
        {
            WaveOutEvent waveOut = _MatchUserAudio[username];
            MemoryStream stream = new MemoryStream(data);
            int timeToPlay = (int)stream.Length / _BytesPerMillisecond * 4 / 5;
            stream.Position = 0;
            RawSourceWaveStream audioStream = new RawSourceWaveStream(stream, new WaveFormat(44100, WaveInEvent.GetCapabilities(FindAudioInputDeviceNumber()).Channels));
            waveOut.Init(audioStream);
            waveOut.Play();
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                if (timeToPlay > 8)
                {
                    Thread.Sleep(8); //ToDo: Fix here.
                    timeToPlay -= 8;
                }
                else
                {
                    Thread.Sleep(timeToPlay);
                    waveOut.Stop();
                    break;
                }

            }
        }
        */
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
            }
        }
        private void AddNewUserToCall(string name)
        {
            if (_MatchUserVideo.Count == 1)
                _MatchUserVideo.Add(name, pictureBox2);
            else if (_MatchUserVideo.Count == 2)
                _MatchUserVideo.Add(name, pictureBox3);
            else
                _MatchUserVideo.Add(name, pictureBox4);
            WaveOutEvent waveOut = new WaveOutEvent();
            waveOut.DeviceNumber = FIndAudioOutputDeviceNumber();
            //_MatchUserAudio.Add(name, waveOut);
        }
        private int FindAudioInputDeviceNumber()
        {
            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
            {
                if (WaveInEvent.GetCapabilities(i).ProductName == _audioInputDeviceName)
                {
                    return i;
                }
            }
            return -1;
        }
        private int FIndAudioOutputDeviceNumber()
        {
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                if (WaveOut.GetCapabilities(i).ProductName == _audioOutputDeviceName)
                {
                    return i;
                }
            }
            return -1;
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
        public void StartGetFromServer()
        {
            _videoCaptureDevice = new VideoCaptureDevice(FindIndexOfVideoDevice().MonikerString);
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities.First(v => v.FrameSize.Width == 320 && v.FrameSize.Height == 240);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;

            /*
            _inputAudioDevice = new WaveInEvent();
            _inputAudioDevice.DeviceNumber = FindAudioInputDeviceNumber();
            _inputAudioDevice.WaveFormat = new WaveFormat(44100, WaveInEvent.GetCapabilities(FindAudioInputDeviceNumber()).Channels);
            _BytesPerMillisecond = _inputAudioDevice.WaveFormat.SampleRate * _inputAudioDevice.WaveFormat.BitsPerSample / 8 * _inputAudioDevice.WaveFormat.Channels / 1000;
            _inputAudioDevice.DataAvailable += _inputAudioDevice_DataAvailable;
            */
            Thread t = new Thread(new ThreadStart(() => RecieveVideoFromServer()));
            t.Start();
            Thread t1 = new Thread(new ThreadStart(()=> RecieveUsersInfo()));
            t1.Start();

            /*
            Thread t2 = new Thread(new ThreadStart(() => RecieveAudioFromServer()));
            t2.Start();
            */

            _videoCaptureDevice.Start();
            //_inputAudioDevice.StartRecording();
        }
        #endregion
        private void Meeting_FormClosing(object sender, FormClosingEventArgs e)
        {
            _vidSock.Close();
            _audSock.Close();
        }
    }
}
