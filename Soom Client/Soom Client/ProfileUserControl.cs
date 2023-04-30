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
        public bool IsChanged { get; private set; }
        #endregion Properties
        public ProfileUserControl()
        {
            IsChanged = false;
            InitializeComponent();
        }

        private void femaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheckBox.Checked)
                maleCheckBox.Checked = false;
            if (!IsChanged)
            {
                IsChanged = true;
            }
        }
        private void maleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
                femaleCheckBox.Checked = false;
            if (!IsChanged)
            {
                IsChanged = true;
            }
        }
        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
            if (!IsChanged)
            {
                IsChanged = true;
            }
        }
        private void passwordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#' || e.KeyChar == ' ')
                e.Handled = true;
            if (!IsChanged)
            {
                IsChanged = true;
            }
        }
        private void ageBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (!IsChanged)
            {
                IsChanged = true;
            }
        }
        private void bioBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '#')
                e.Handled = true;
            if (!IsChanged)
            {
                IsChanged = true;
            }
        }
    }
}
