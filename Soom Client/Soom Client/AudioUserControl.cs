using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class AudioUserControl : UserControl, ISettingsScreenComponent 
    {
        public bool IsMuteWhenJoined { get; private set; }
        public int Volume { get; private set; }
        public string InputDeviceName { get; private set; }
        public string OutputDeviceName { get; private set; }

        public AudioUserControl()
        {
            InitializeComponent();
        }

        public event ValuesChangedEvent ChangedEvent;

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            volumeNumberBox.Text = $"{volumeBar.Value*10}";
        }

        private void AudioUserControl_Load(object sender, EventArgs e)
        {
            volumeNumberBox.Text = $"{volumeBar.Value * 100}";
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
            return (int.Parse(this.volumeNumberBox.Text) != Volume || this.inputCboBox.SelectedText != InputDeviceName || this.outputCboBox.SelectedText != OutputDeviceName || this.enterCallBox.Checked != IsMuteWhenJoined);
        }
        public List<string> Convert2Str()
        {
            throw new NotImplementedException();
        }

        public void OrgenizeData(string data)
        {
            throw new NotImplementedException();
        }
    }
}
