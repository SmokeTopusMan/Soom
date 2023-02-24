using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class RegisterClick : UserControl
    {
        #region Properties
        public string UserName { get { return usernameRegTextBox.Text; } private set { } }
        public string Password { get { return passRegTextBox.Text; } private set { } }
        public string Age { get { return ageTextBox.Text; } private set { } }
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
        public string Bio { get { return bioTextBox.Text; } private set { } }
        #endregion Properties

        #region CTor
        public RegisterClick()
        {
            InitializeComponent();
        }
        #endregion

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

        #region KeyPressTerms
        private void usernameRegTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        private void passRegTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void bioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
        }
        #endregion

        #region ClearFunctions
        public void ClearBoxes()
        {
            usernameRegTextBox.Text = "";
            passRegTextBox.Text = "";
            ageTextBox.Text = "";
            femaleCheckBox.Checked = false;
            maleCheckBox.Checked = false;
            bioTextBox.Text = "";
        }
        public void ClearPassword()
        {
            passRegTextBox.Text = "";
        }
        public void ClearUsername()
        {
            usernameRegTextBox.Text = "";
        }
        #endregion
    }
}
