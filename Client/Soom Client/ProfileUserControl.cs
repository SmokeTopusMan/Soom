using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Soom_Client
{
    public partial class ProfileUserControl : UserControl, ISettingsScreenComponent
    {
        public event ValuesChangedEvent ChangedEvent;
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
            IsChanged();
        }
        private void maleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
                femaleCheckBox.Checked = false;
            IsChanged();
        }
        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '#' && e.KeyChar != ' ')
            {
                if (e.KeyChar == '\b')
                {
                    if (this.usernameBox.Text != "")
                    {
                       if (this.usernameBox.SelectionLength > 0)
                            this.usernameBox.SelectedText = string.Empty;
                        else
                            this.usernameBox.Text = this.usernameBox.Text.Remove(this.usernameBox.Text.Length - 1);
                    } 
                }
                else
                    this.usernameBox.Text += e.KeyChar;
            }
            this.usernameBox.SelectionStart = this.usernameBox.Text.Length;
            e.Handled = true;
            IsChanged();

        }
        private void ageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                if (this.ageBox.Text != "")
                {
                    if (this.ageBox.SelectionLength > 0)
                        this.ageBox.SelectedText = string.Empty;
                    else
                        this.ageBox.Text = this.ageBox.Text.Remove(this.ageBox.Text.Length - 1);
                }
            }
            else if(char.IsDigit(e.KeyChar) && this.ageBox.Text.Length < 3)
                this.ageBox.Text += e.KeyChar;
            this.ageBox.SelectionStart = this.ageBox.Text.Length;
            e.Handled = true;
            IsChanged();
        }
        private void bioBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '#')
            {
                if (e.KeyChar == '\b')
                {
                    if (this.bioBox.Text != "")
                    {
                        if (this.bioBox.SelectionLength > 0)
                            this.bioBox.SelectedText = string.Empty;
                        else
                            this.bioBox.Text = this.bioBox.Text.Remove(this.bioBox.Text.Length - 1);
                    }
                }
                else
                    this.bioBox.Text += e.KeyChar;
            }
            this.bioBox.SelectionStart = this.bioBox.Text.Length;
            e.Handled = true;
            IsChanged();
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
            if (int.TryParse(ageBox.Text, out int age))
            {
                ;
            }
            else
                age = 0;

            return (this.usernameBox.Text != Username || age != Age || GetSex() != Sex || this.bioBox.Text != Bio);
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
        public static Sex GetSexEnumValue(string enumName)
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

        public void ResetSettingsToDefault()
        {
            this.usernameBox.Text = Username;
            this.ageBox.Text = Age.ToString();
            if(Sex == Sex.Male)
            {
                this.maleCheckBox.Checked = true;
                this.femaleCheckBox.Checked = false;
            }
            else
            {
                this.maleCheckBox.Checked = false;
                this.femaleCheckBox.Checked = true;
            }
            this.bioBox.Text = Bio;

            this.usernameBox.SelectionStart = this.usernameBox.Text.Length;
            this.ageBox.SelectionStart = this.ageBox.Text.Length;
            this.bioBox.SelectionStart = this.bioBox.Text.Length;
        }
        public List<string> GetChanges()
        {
            if (CheckData())
            {
                List<string> changes = new List<string>();
                if (Username == usernameBox.Text) changes.Add("None");
                else changes.Add(usernameBox.Text);
                if(Age == int.Parse(ageBox.Text)) changes.Add("None");
                else changes.Add(ageBox.Text);
                if (Sex == GetSex()) changes.Add("None");
                else changes.Add(GetSex().ToString());
                if (Bio == bioBox.Text) changes.Add("None");
                else changes.Add(bioBox.Text);
                return changes;
            }
            return null;
        }
        public void UpdateProfile()
        {
            Username = usernameBox.Text;
            Age = int.Parse(ageBox.Text);
            Sex = GetSex();
            Bio = bioBox.Text;
        }
        private bool CheckData()
        {
            if (int.Parse(ageBox.Text) >= 12 && int.Parse(ageBox.Text) <= 117 && GetSex() != Sex.NotChecked && usernameBox.Text.Length >= 4)
                return true;
            if (this.usernameBox.Text == "")
                MessageBox.Show("Fill Your Username!");
            else if (this.usernameBox.Text.Length < 4)
            {
                MessageBox.Show("Write At Least 4 Characters In The Username Box!");
            }
            if (ageBox.Text != "")
            {
                if (int.Parse(ageBox.Text) < 12 || int.Parse(ageBox.Text) > 117)
                {
                    MessageBox.Show("Your Age Isn't Appropriate For This App, Sorry.");
                }
            }
            else
                MessageBox.Show("Fill Your Age!");
            if (GetSex() == Sex.NotChecked)
                MessageBox.Show("Select Your Sex!");
            return false;
        }
    }
}
