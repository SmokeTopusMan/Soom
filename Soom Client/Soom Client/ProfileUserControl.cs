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
    public partial class ProfileUserControl : UserControl, ISettingsScreenComponent
    {
        public event ValuesChangedEvent ChangedEvent;
        private int _age;
        #region Properties
        public string Username { get; private set; }
        public int Age { get; private set; }
        public Sex Sex { get; private set; }
        public string Bio { get; private set; }
        #endregion Properties
        public ProfileUserControl()
        {
            InitializeComponent();
        }
        #region Boxes Propeties
        private void femaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheckBox.Checked)
                maleCheckBox.Checked = false;
        }
        private void maleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
                femaleCheckBox.Checked = false;
        }
        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        private void passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        private void ageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void bioBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#')
                e.Handled = true;
        }
        private bool CheckBoxes()
        {
            Sex sex = GetSex();
            if (this.usernameBox.Text != "" && this.ageBox.Text != "" && sex != Sex.NotChecked && this.usernameBox.Text.Length >= 4)
                return true;
            if (this.usernameBox.Text == "")
                MessageBox.Show("Fill Your Username!");
            else if (this.usernameBox.Text.Length < 4)
            {
                MessageBox.Show("Write At Least 4 Characters In The Username Box!");
            }
                MessageBox.Show("Fill Your Age!");
            if (sex == Sex.NotChecked)
                MessageBox.Show("Select Your Sex!");
            return false;
        }
        #endregion
        public void IsChanged()
        {
            if (ChangedEvent != null)
            {
                ChangedEvent(new ValuesChangedEventArgs(CheckIfChanged()));
            }
        }
        public bool CheckIfChanged()
        {
            return (this.usernameBox.Text != Username || int.Parse(this.ageBox.Text) != Age || GetSex() != Sex || this.bioBox.Text != Bio);
        }
        private Sex GetSex()
        {
            if (this.maleCheckBox.Checked)
                return Sex.Male;
            else if (this.femaleCheckBox.Checked)
                return Sex.Female;
            else
                return Sex.NotChecked;
        }
        public List<string> Convert2Str()
        {
            throw new NotImplementedException();
        }

        public void OrgenizeData(string data)
        {
            string[] dataComponents = data.Split('#');
            this.Username = dataComponents[0];
            this.Age = int.Parse(dataComponents[1]);
            this.Sex = GetSexEnumValue(dataComponents[2]);
            this.Bio = dataComponents[3];
            PresentDataInBoxes(dataComponents);
        }
        private void PresentDataInBoxes(string[] dataArray)
        {
            this.usernameBox.Text = dataArray[0];
            this.ageBox.Text = dataArray[1];
            if (dataArray[2] == "Male")
                this.maleCheckBox.Checked = true;
            else
                this.femaleCheckBox.Checked = true;
            this.bioBox.Text = dataArray[3];
            this.pointsBox.Text = dataArray[4];
            
        }
        private Sex GetSexEnumValue(string enumName)
        {
            if (Enum.TryParse<Sex>(enumName, out Sex enumValue))
            {
                return enumValue;
            }
            else
            {
                throw new ArgumentException("Invalid Enum Name");
            }
        }
    }
}
