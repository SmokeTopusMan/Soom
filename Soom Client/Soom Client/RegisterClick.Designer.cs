namespace Soom_Client
{
    partial class RegisterClick
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameRegTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passRegTextBox = new System.Windows.Forms.TextBox();
            this.bioTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maleCheckBox = new System.Windows.Forms.CheckBox();
            this.femaleCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameRegTextBox
            // 
            this.usernameRegTextBox.Location = new System.Drawing.Point(114, 42);
            this.usernameRegTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.usernameRegTextBox.MaxLength = 35;
            this.usernameRegTextBox.Name = "usernameRegTextBox";
            this.usernameRegTextBox.Size = new System.Drawing.Size(202, 20);
            this.usernameRegTextBox.TabIndex = 25;
            this.usernameRegTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameRegTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(48, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(48, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Password:";
            // 
            // passRegTextBox
            // 
            this.passRegTextBox.Location = new System.Drawing.Point(112, 92);
            this.passRegTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.passRegTextBox.MaxLength = 35;
            this.passRegTextBox.Name = "passRegTextBox";
            this.passRegTextBox.Size = new System.Drawing.Size(202, 20);
            this.passRegTextBox.TabIndex = 28;
            this.passRegTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passRegTextBox_KeyPress);
            // 
            // bioTextBox
            // 
            this.bioTextBox.Location = new System.Drawing.Point(397, 42);
            this.bioTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.bioTextBox.MaxLength = 1000;
            this.bioTextBox.Multiline = true;
            this.bioTextBox.Name = "bioTextBox";
            this.bioTextBox.Size = new System.Drawing.Size(181, 229);
            this.bioTextBox.TabIndex = 24;
            this.bioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bioTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Chocolate;
            this.label5.Location = new System.Drawing.Point(364, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Bio:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maleCheckBox);
            this.panel1.Controls.Add(this.femaleCheckBox);
            this.panel1.Location = new System.Drawing.Point(44, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 40);
            this.panel1.TabIndex = 22;
            // 
            // maleCheckBox
            // 
            this.maleCheckBox.AutoSize = true;
            this.maleCheckBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.maleCheckBox.Location = new System.Drawing.Point(3, 20);
            this.maleCheckBox.Name = "maleCheckBox";
            this.maleCheckBox.Size = new System.Drawing.Size(49, 17);
            this.maleCheckBox.TabIndex = 11;
            this.maleCheckBox.Text = "Male";
            this.maleCheckBox.UseVisualStyleBackColor = false;
            // 
            // femaleCheckBox
            // 
            this.femaleCheckBox.AutoSize = true;
            this.femaleCheckBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.femaleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.femaleCheckBox.Name = "femaleCheckBox";
            this.femaleCheckBox.Size = new System.Drawing.Size(60, 17);
            this.femaleCheckBox.TabIndex = 10;
            this.femaleCheckBox.Text = "Female";
            this.femaleCheckBox.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(48, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Sex:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(48, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Age:";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(85, 142);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 10);
            this.ageTextBox.MaxLength = 3;
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(31, 20);
            this.ageTextBox.TabIndex = 19;
            this.ageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ageTextBox_KeyPress);
            // 
            // RegisterClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usernameRegTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passRegTextBox);
            this.Controls.Add(this.bioTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ageTextBox);
            this.Name = "RegisterClick";
            this.Size = new System.Drawing.Size(622, 312);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameRegTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passRegTextBox;
        private System.Windows.Forms.TextBox bioTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox maleCheckBox;
        private System.Windows.Forms.CheckBox femaleCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageTextBox;
    }
}
