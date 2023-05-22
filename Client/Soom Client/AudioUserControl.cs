using NAudio.Wave;
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
            for (int i = 0; i < WaveInEvent.DeviceCount; i++)
                this.inputCboBox.Items.Add(WaveInEvent.GetCapabilities(i).ProductName);
            for (int i = 0; i < WaveOut.DeviceCount; i++)
                this.outputCboBox.Items.Add(WaveOut.GetCapabilities(i).ProductName);
        }

        public event ValuesChangedEvent ChangedEvent;

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            volumeNumberBox.Text = $"{volumeBar.Value}";
            IsChanged();
        }
        public void IsChanged()
        {
            if (ChangedEvent != null)
            {
                ChangedEvent(new ValuesChangedEventArgs(CheckIfChanged()));
            }
        }
        public void ResetSettings()
        {
            enterCallBox.Checked = IsMuteWhenJoined;
            volumeBar.Value = Volume;
            volumeNumberBox.Text = $"{Volume}";
            for (int i = 0; i < this.inputCboBox.Items.Count; i++)
            {
                if (this.inputCboBox.Items[i].ToString() == this.InputDeviceName)
                    this.inputCboBox.SelectedIndex = i;
            }
            for (int i = 0; i < this.outputCboBox.Items.Count; i++)
            {
                if (this.outputCboBox.Items[i].ToString() == this.OutputDeviceName)
                    this.outputCboBox.SelectedIndex = i;
            }
        }
        public bool CheckIfChanged()
        {
            if(int.Parse(this.volumeNumberBox.Text) == Volume)
            {
                if(this.inputCboBox.SelectedText == InputDeviceName)
                {
                    if(this.outputCboBox.SelectedText == OutputDeviceName)
                    {
                        if (this.enterCallBox.Checked == IsMuteWhenJoined)
                            return false;
                    }
                }
            }
            return true;

            return (int.Parse(this.volumeNumberBox.Text) != Volume || this.inputCboBox.SelectedText != InputDeviceName || this.outputCboBox.SelectedText != OutputDeviceName || this.enterCallBox.Checked != IsMuteWhenJoined);
        }
        public List<string> Convert2Str()
        {
            throw new NotImplementedException();
        }

        public void OrgenizeData(string data)
        {
            string[] dataComponents = data.Split('#');
            this.InputDeviceName = dataComponents[0];
            this.OutputDeviceName = dataComponents[1];
            this.Volume = int.Parse(dataComponents[2]);
            if (dataComponents[3] == "0")
                this.IsMuteWhenJoined = false;
            else
                this.IsMuteWhenJoined = true;
            PresentDataInBoxes(dataComponents);
        }
        private void PresentDataInBoxes(string[] dataArray)
        {
            FindDevice(dataArray[0], this.inputCboBox);
            FindDevice(dataArray[1], this.outputCboBox);
            this.volumeBar.Value = int.Parse(dataArray[2]);
            this.volumeNumberBox.Text = this.volumeBar.Value.ToString();
            if (dataArray[3] == "0")
                this.enterCallBox.Checked = false;
            else
                this.enterCallBox.Checked = true;
        }
        private void FindDevice(string name, ComboBox box)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                if ((string)box.Items[i] == name)
                {
                    box.SelectedIndex = i;
                    return;
                }
            }
            box.SelectedIndex = 0;
        }

        private void inputCboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged();
        }
        private void outputCboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged();
        }
        private void enterCallBox_CheckedChanged(object sender, EventArgs e)
        {
            IsChanged();
        }

        private void outputCboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void inputCboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
