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
        #region Properties

        public string UserName { get { return usernameBox.Text; } private set { } }
        public string Password { get { return passwordBox.Text; } private set { } }
        public string Age { get { return ageBox.Text; } private set { } }
        public Sex Sex
        {
            get
            {
                if (maleCheckBox.Checked)
                    return Sex.Male;
                else if (femaleCheckBox.Checked)
                    return Sex.Female;
                else
                    return Sex.NotChecked;
            }
            private set { }
        }
        public string Bio { get { return bioBox.Text; } private set { } }
        #endregion Properties
        public event ValuesChangedEvent ChangedEvent;
        public ProfileUserControl()//ToDO: need to trasfer the data from the server to settingsScreen to this constructor.
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
            if (this.usernameBox.Text != "" && this.passwordBox.Text != "" && this.ageBox.Text != "" && sex != Sex.NotChecked && this.passwordBox.Text.Length >= 8 && this.usernameBox.Text.Length >= 4)
                return true;
            if (this.usernameBox.Text == "")
                MessageBox.Show("Fill Your Username!");
            else if (this.usernameBox.Text.Length < 4)
            {
                MessageBox.Show("Write At Least 4 Characters In The Username Box!");
            }
            if (this.passwordBox.Text == "")
                MessageBox.Show("Fill Your Password!");
            else if (this.passwordBox.Text.Length < 8)
            {
                MessageBox.Show("Write At Least 8 Characters In The Password Box!");
            }
            if (this.ageBox.Text == "")
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
            return (this.usernameBox.Text != UserName || this.passwordBox.Text != Password || this.ageBox.Text != Age || GetSex() != Sex || this.bioBox.Text != Bio);
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
    }
}
