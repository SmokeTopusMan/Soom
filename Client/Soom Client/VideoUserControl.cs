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

namespace Soom_Client
{
    public partial class VideoUserControl : UserControl, ISettingsScreenComponent
    {
        #region Propeties
        public bool IsVidMirrored { get; private set; }
        public bool IsVideoOnWhenJoining { get; private set; }
        public string DeviceName { get; private set; }
        private VideoCaptureDevice _videoCaptureDevice;
        private FilterInfoCollection _filterInfoCollection;
        public event ValuesChangedEvent ChangedEvent;
        #endregion

        #region CTor
        public VideoUserControl()
        {
            InitializeComponent();
            _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in _filterInfoCollection)
                cameraCboBox.Items.Add(filterInfo.Name);
        }
        #endregion

        #region Key Press Terms
        private void cameraCboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        #region Buttons Click
        private void enterCallBox_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged();
        }
        private void mirrorBox_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged();
        }
        private void cameraCboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged();
            if (_videoCaptureDevice == null)
            {
                return;
            }
            StopVid();
            this._videoCaptureDevice = null;
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[cameraCboBox.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities.First(v => v.FrameSize.Width == 320 && v.FrameSize.Height == 240);
            StartVid();
        }
        #endregion

        #region Public Functions
        public void StartVid()
        {
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.Start();
        }
        public void StopVid() 
        {
            _videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.SignalToStop();
            _videoCaptureDevice.WaitForStop();
        }
        public void IsChanged()
        {
            if (ChangedEvent != null)
            {
                ChangedEvent(new ValuesChangedEventArgs(CheckIfChanged()));
            }
        }
        public bool CheckIfChanged()
        {
            return (this.cameraCboBox.SelectedItem.ToString() != DeviceName || this.mirrorBox.Checked != IsVidMirrored || this.enterCallBox.Checked != IsVideoOnWhenJoining);
        }
        public void OrgenizeData(string data)
        {
            string[] dataComponents = data.Split('#');
            if (dataComponents[0] == "")
                this.DeviceName = (string)cameraCboBox.Items[0];
            else
                this.DeviceName = dataComponents[0];
            if (dataComponents[1] == "0")
                this.IsVidMirrored = false;
            else
                this.IsVidMirrored = true;
            if (dataComponents[2] == "0")
                this.IsVideoOnWhenJoining = false;
            else
                this.IsVideoOnWhenJoining = true;
            PresentDataInBoxes(dataComponents);
        }
        public void ResetSettingsToDefault()
        {
            this.mirrorBox.Checked = IsVidMirrored;
            this.enterCallBox.Checked = IsVideoOnWhenJoining;
            FindDevice(out int index);
            this.cameraCboBox.SelectedIndex = index;
        }

        public List<string> GetChanges()
        {
            List<string> changes = new List<string>();
            if (DeviceName == this.cameraCboBox.Text) changes.Add("None");
            else changes.Add(this.cameraCboBox.Text);
            if (IsVidMirrored == this.mirrorBox.Checked) changes.Add("None");
            else
            {
                if (this.mirrorBox.Checked) changes.Add("1");
                else changes.Add("0");
            }
            if (IsVideoOnWhenJoining == this.enterCallBox.Checked) changes.Add("None");
            else
            {
                if (this.enterCallBox.Checked) changes.Add("1");
                else changes.Add("0");
            }
            return changes;
        }
        public void UpdateVideo()
        {
            DeviceName = this.cameraCboBox.Text;
            IsVidMirrored = this.mirrorBox.Checked;
            IsVideoOnWhenJoining = this.enterCallBox.Checked;
        }
        #endregion

        #region Private Functions
        private void PresentDataInBoxes(string[] dataArray)
        {
            bool isExist = FindDevice(out int index);
            if (isExist)
                this.cameraCboBox.SelectedIndex = index;
            else
            {
                this.cameraCboBox.SelectedIndex = 0;
                this.DeviceName = this.cameraCboBox.Items[0].ToString();
            }
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[cameraCboBox.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.VideoResolution = _videoCaptureDevice.VideoCapabilities.First(v => v.FrameSize.Width == 320 && v.FrameSize.Height == 240);

            if (dataArray[1] == "0")
                this.mirrorBox.Checked = false;
            else
                this.mirrorBox.Checked = true;
            if (dataArray[2] == "0")
                this.enterCallBox.Checked = false;
            else
                this.enterCallBox.Checked = true;
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            if (mirrorBox.Checked)
            {
                var filter = new Mirror(false, true);
                filter.ApplyInPlace(bitmap);
            }
            pictureBox.Image = bitmap;
        }
        private bool FindDevice(out int index)
        {
            for (int i = 0; i < this.cameraCboBox.Items.Count; i++)
            {
                if(this.cameraCboBox.Items[i].ToString() == this.DeviceName)
                {
                    index = i;
                    return true;
                }
            }
            index = 0;
            return false;
        }
        #endregion
    }
}
