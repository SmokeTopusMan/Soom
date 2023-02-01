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
    public partial class RegisterClick : UserControl
    {
        public string userInfo { get; private set; }
        public RegisterClick()
        {
            InitializeComponent();
        }

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

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void registerSubmitBtn_Click(object sender, EventArgs e)
        {
            if (CheckAllBoxes())
            {
                string sex = "";
                if (maleCheckBox.Checked)
                    sex += "sex:M";
                else
                    sex += "sex:F";
                this.userInfo += $"REG#username:{usernameRegTextBox.Text}#password:{passRegTextBox.Text}#age:{ageTextBox.Text}" +
                                 $"#sex:{sex}#bio:{bioTextBox.Text}";
            }
            else
            {
                if (usernameRegTextBox.Text == "")
                    MessageBox.Show("You need to choose a username!");
                else if (passRegTextBox.Text == "")
                    MessageBox.Show("You need to choose a password!");
                else if (ageTextBox.Text == "")
                    MessageBox.Show("You need to enter an age!");
                else
                    MessageBox.Show("You need to choose your sex!");
            }
        }

        private bool CheckAllBoxes()
        {
            return (usernameRegTextBox.Text != "" && passRegTextBox.Text != "" && ageTextBox.Text != "" && (maleCheckBox.Checked || femaleCheckBox.Checked));
        }

        public void IsInfo(Queue<string> info)
        {
            while (this.userInfo == null)
            {
                System.Threading.Thread.Sleep(1000);
            }
            info.Enqueue(this.userInfo);
        }
    }
}
