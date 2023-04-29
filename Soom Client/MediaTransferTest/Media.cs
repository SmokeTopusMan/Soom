using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge.Imaging.Filters;
using System.Diagnostics;
using System.Threading;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace MediaTransferTest
{
    public partial class Media : Form
    {
        private FilterInfoCollection filterInfoCollection { get; set; }
        VideoCaptureDevice videoCaptureDevice;
        Stopwatch stopwatch;
        TimeSpan minFrameTime;
        private WaveInEvent waveIn { get; set; }
        private WaveOutEvent waveOut;
        private MemoryStream waveStream;
        private MemoryStream backUpStream;
        private MemoryStream videoStream;
        Thread audioPlayThread;
        private bool stream1Taken;
        public bool IsFormAlive { get;private set; }


        public Media(double frameRate = 30)
        {
            this.stopwatch = new Stopwatch();
            this.stopwatch.Start();
            this.minFrameTime = TimeSpan.FromMilliseconds(1000.0 / frameRate);
            this.waveIn = new WaveInEvent();
            this.waveOut = new WaveOutEvent();
            this.waveStream = new MemoryStream();
            this.backUpStream = new MemoryStream();
            this.videoStream = new MemoryStream();
            this.stream1Taken = false;
            IsFormAlive = true;
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            this.waveIn.DeviceNumber = cboMicrophone.SelectedIndex;
            this.waveOut.DeviceNumber = cboHeadphones.SelectedIndex;
            this.waveIn.WaveFormat = new WaveFormat(44100, WaveInEvent.GetCapabilities(cboCamera.SelectedIndex).Channels);
            this.waveIn.DataAvailable += WaveIn_DataAvailable;
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.VideoResolution = videoCaptureDevice.VideoCapabilities.First(v => v.FrameSize.Width == 320 && v.FrameSize.Height == 240); // needs a method to change it and not set default.
            this.waveIn.StartRecording();
            videoCaptureDevice.Start();

            audioPlayThread = new Thread(WaveOutPlay); audioPlayThread.Start();
            StartBtn.Enabled = false;
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (!this.stream1Taken)
            {
                this.waveStream.Write(e.Buffer, 0, e.BytesRecorded);
            }
            else
            {
                this.backUpStream.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }
        private void WaveOutPlay()
        {
            while (IsFormAlive)
            {
                this.stream1Taken = !this.stream1Taken;
                if (this.stream1Taken)
                {
                    waveStream.Position = 0;
                    RawSourceWaveStream audioStream = new RawSourceWaveStream(waveStream, this.waveIn.WaveFormat);
                    int bytesPerSecond = audioStream.WaveFormat.SampleRate * audioStream.WaveFormat.BitsPerSample / 8 * audioStream.WaveFormat.Channels;
                    this.waveOut.Init(new RawSourceWaveStream(waveStream, this.waveIn.WaveFormat));
                    this.waveOut.Play();
                    while (this.waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(8); //ToDo: Fix here.
                    }
                    waveStream.SetLength(0);
                }
                else
                {
                    backUpStream.Position = 0;
                    this.waveOut.Init(new RawSourceWaveStream(backUpStream, this.waveIn.WaveFormat));
                    this.waveOut.Play();
                    while (this.waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(8); //ToDO: Fix here.
                    }
                    backUpStream.SetLength(0);
                }
            }
        }
        
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            
            var frameTime = stopwatch.Elapsed;
            if (frameTime > minFrameTime)
            {   
                stopwatch.Restart();
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
                var filter = new Mirror(false, true);
                filter.ApplyInPlace(bitmap);
                bitmap.Save(videoStream, ImageFormat.Jpeg);
                pic.Image = bitmap;
            }
            else
            {
                eventArgs.Frame.Dispose();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            AddCboInputDevices();
            AddCboOutputDevices();
            foreach (FilterInfo filterInfo in filterInfoCollection) cboCamera.Items.Add(filterInfo.Name);
            cboMicrophone.SelectedIndex = 0;
            cboCamera.SelectedIndex = 0;
            cboHeadphones.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsFormAlive = false;
            if(videoCaptureDevice.IsRunning == true)
                videoCaptureDevice.Stop();
            if (audioPlayThread != null)
            {
                if (audioPlayThread.ThreadState == System.Threading.ThreadState.Running)
                    audioPlayThread.Join();
            }
            waveIn.Dispose();
            waveOut.Dispose();
            waveStream.Dispose();
        }

        private void cboCamera_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cboMicrophone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cboHeadphones_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void AddCboInputDevices()
        {
            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
            {
                cboMicrophone.Items.Add(WaveInEvent.GetCapabilities(i).ProductName);
            }

        }
        private void AddCboOutputDevices()
        {
            for (int i = 0; i < WaveOut.DeviceCount; i++)
                cboHeadphones.Items.Add(WaveOut.GetCapabilities(i).ProductName);
        }
        private void ShowCapabilities()
        {
            string capabilities = "";
            foreach (var capability in videoCaptureDevice.VideoCapabilities)
                capabilities += $"Resolution: {capability.FrameSize.Width}x{capability.FrameSize.Height}, Frame Rate: {capability.AverageFrameRate}\r\n";
            MessageBox.Show(capabilities);
            capabilities = "";
            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
            {
                capabilities += $"Device Num: {i}, Device: {WaveInEvent.GetCapabilities(i).ProductName}";
            }
            MessageBox.Show(capabilities);
        }
    }
}
