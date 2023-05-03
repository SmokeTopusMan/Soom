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
        public bool IsVideoMirrored {  get; private set; }
        public bool IsChanged { get; private set; }
        public bool IsVideoOnWhenJoining { get; private set; }
        public string DeviceName { get; private set; }
        private FilterInfoCollection _filterInfoCollection;

        public VideoUserControl()
        {
            InitializeComponent();
            _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in _filterInfoCollection)
                cameraCboBox.Items.Add(filterInfo.Name);
            DeviceName = cameraCboBox.SelectedText;
        }

        private void mirrorBox_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            if(mirrorBox.Checked)
                IsVideoMirrored = true;
            else
                IsVideoMirrored = false;
        }

        private void enterCallBox_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged = true;
            if (enterCallBox.Checked)
                IsVideoOnWhenJoining = true;
            else
                IsVideoOnWhenJoining = false;
        }

        private void cameraCboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DeviceName != cameraCboBox.SelectedText)
            {
                DeviceName = cameraCboBox.SelectedText;
                IsChanged = true;
            }
        }
    }
}
