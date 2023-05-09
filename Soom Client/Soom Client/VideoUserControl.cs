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
        private bool _isMirrored;
        private bool _isVideoOnWhenJoining;
        private string _deviceName;
        private FilterInfoCollection _filterInfoCollection;

        public event ValuesChangedEvent ChangedEvent;

        public VideoUserControl()
        {
            InitializeComponent();
            _filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in _filterInfoCollection)
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
            return (this.cameraCboBox.SelectedText != _deviceName || this.mirrorBox.Checked != _isMirrored || this.enterCallBox.Checked != _isVideoOnWhenJoining);
        }
        public List<string> Convert2Str()
        {
            return null;
        }
    }
}
