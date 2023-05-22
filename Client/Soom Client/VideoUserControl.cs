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

namespace Soom_Client
{
    public partial class VideoUserControl : UserControl, ISettingsScreenComponent
    {
        public bool IsVidMirrored { get; private set; }
        public bool IsVideoOnWhenJoining { get; private set; }
        public string DeviceName { get; private set; }

        public event ValuesChangedEvent ChangedEvent;

        public VideoUserControl()
        {
            InitializeComponent();
            FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cameraCboBox.Items.Add(filterInfo.Name);
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
            return (this.cameraCboBox.SelectedText != DeviceName || this.mirrorBox.Checked != IsVidMirrored || this.enterCallBox.Checked != IsVideoOnWhenJoining);
        }
        public List<string> Convert2Str()
        {
            return null;
        }
        public void OrgenizeData(string data)
        {
            string[] dataComponents = data.Split('#');
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
        private void PresentDataInBoxes(string[] dataArray)
        {
            FindDevice(dataArray[0]);
            if (dataArray[1] == "0")
                this.mirrorBox.Checked = false;
            else
                this.mirrorBox.Checked = true;
            if (dataArray[2] == "0")
                this.enterCallBox.Checked = false;
            else
                this.enterCallBox.Checked = true;
        }
        private void FindDevice(string name)
        {
            for (int i = 0; i<this.cameraCboBox.Items.Count; i++)
            {
                if((string)this.cameraCboBox.Items[i] == name)
                {
                    this.cameraCboBox.SelectedIndex = i;
                    return;
                }
            }
            this.cameraCboBox.SelectedIndex = 0;
        }
    }
}
