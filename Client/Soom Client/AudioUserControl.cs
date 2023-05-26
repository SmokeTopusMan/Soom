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
        public bool CheckIfChanged()
        {
            if(int.Parse(this.volumeNumberBox.Text) == Volume)
            {
                if((string)this.inputCboBox.SelectedItem == InputDeviceName)
                {
                    if((string)this.outputCboBox.SelectedItem == OutputDeviceName)
                    {
                        if (this.enterCallBox.Checked == IsMuteWhenJoined)
                            return false;
                    }
                }
            }
            return true;
        }
        public void OrgenizeData(string data)
        {
            string[] dataComponents = data.Split('#');
            if (dataComponents[0] == "")
            {
                this.InputDeviceName = (string)inputCboBox.Items[0];
            }
            else
                this.InputDeviceName = dataComponents[0];
            if (dataComponents[1] == "")
            {
                this.OutputDeviceName = (string)outputCboBox.Items[0];
            }
            else
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
            FindDevice(this.InputDeviceName, this.inputCboBox);
            FindDevice(this.OutputDeviceName, this.outputCboBox);
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
            if (box.Name == "inputCboBox")
            {
                this.InputDeviceName = (string)box.Items[0];
            }
            else
                this.OutputDeviceName = (string)box.Items[0];
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

        public void ResetSettingsToDefault()
        {
            enterCallBox.Checked = IsMuteWhenJoined;
            volumeBar.Value = Volume;
            volumeNumberBox.Text = $"{Volume}";
            for (int i = 0; i < this.inputCboBox.Items.Count; i++)
            {
                if (this.inputCboBox.Items[i].ToString() == this.InputDeviceName)
                {
                    this.inputCboBox.SelectedIndex = i;
                    break;
                }

            }
            for (int i = 0; i < this.outputCboBox.Items.Count; i++)
            {
                if (this.outputCboBox.Items[i].ToString() == this.OutputDeviceName)
                {
                    this.outputCboBox.SelectedIndex = i;
                    break;
                }

            }
        }

        public List<string> GetChanges()
        {
            List<string> changes = new List<string>();
            if (InputDeviceName == this.inputCboBox.Text) changes.Add("None");
            else changes.Add(this.inputCboBox.Text);
            if (OutputDeviceName == this.outputCboBox.Text) changes.Add("None");
            else changes.Add(this.outputCboBox.Text);
            if (Volume == int.Parse(this.volumeNumberBox.Text)) changes.Add("None");
            else changes.Add(this.volumeNumberBox.Text);
            if (IsMuteWhenJoined == this.enterCallBox.Checked) changes.Add("None");
            else
            {
                if (this.enterCallBox.Checked) changes.Add("1");
                else changes.Add("0");
            }
            return changes;
        }
        public void UpdateAudio()
        {
            InputDeviceName = this.inputCboBox.Text;
            OutputDeviceName = this.outputCboBox.Text;
            Volume = int.Parse(this.volumeNumberBox.Text);
            IsMuteWhenJoined = this.enterCallBox.Checked;
        }
    }
}
