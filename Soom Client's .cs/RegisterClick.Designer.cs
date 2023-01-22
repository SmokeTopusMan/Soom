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
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.femaleCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maleCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bioTextBox = new System.Windows.Forms.TextBox();
            this.registerSubmitBtn = new System.Windows.Forms.Button();
            this.usernameRegTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passRegTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(99, 133);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 10);
            this.ageTextBox.MaxLength = 3;
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(31, 20);
            this.ageTextBox.TabIndex = 3;
            this.ageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ageTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(62, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(62, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sex:";
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
            this.femaleCheckBox.CheckedChanged += new System.EventHandler(this.femaleCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maleCheckBox);
            this.panel1.Controls.Add(this.femaleCheckBox);
            this.panel1.Location = new System.Drawing.Point(58, 202);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 40);
            this.panel1.TabIndex = 11;
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
            this.maleCheckBox.CheckedChanged += new System.EventHandler(this.maleCheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Chocolate;
            this.label5.Location = new System.Drawing.Point(378, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bio:";
            // 
            // bioTextBox
            // 
            this.bioTextBox.Location = new System.Drawing.Point(411, 33);
            this.bioTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.bioTextBox.MaxLength = 1000;
            this.bioTextBox.Multiline = true;
            this.bioTextBox.Name = "bioTextBox";
            this.bioTextBox.Size = new System.Drawing.Size(181, 229);
            this.bioTextBox.TabIndex = 13;
            // 
            // registerSubmitBtn
            // 
            this.registerSubmitBtn.Location = new System.Drawing.Point(266, 260);
            this.registerSubmitBtn.Name = "registerSubmitBtn";
            this.registerSubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.registerSubmitBtn.TabIndex = 14;
            this.registerSubmitBtn.Text = "Submit";
            this.registerSubmitBtn.UseVisualStyleBackColor = true;
            this.registerSubmitBtn.Click += new System.EventHandler(this.registerSubmitBtn_Click);
            // 
            // usernameRegTextBox
            // 
            this.usernameRegTextBox.Location = new System.Drawing.Point(128, 33);
            this.usernameRegTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.usernameRegTextBox.MaxLength = 50;
            this.usernameRegTextBox.Name = "usernameRegTextBox";
            this.usernameRegTextBox.Size = new System.Drawing.Size(202, 20);
            this.usernameRegTextBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(62, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(62, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Password:";
            // 
            // passRegTextBox
            // 
            this.passRegTextBox.Location = new System.Drawing.Point(126, 83);
            this.passRegTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.passRegTextBox.MaxLength = 50;
            this.passRegTextBox.Name = "passRegTextBox";
            this.passRegTextBox.Size = new System.Drawing.Size(202, 20);
            this.passRegTextBox.TabIndex = 18;
            // 
            // RegisterClick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usernameRegTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passRegTextBox);
            this.Controls.Add(this.registerSubmitBtn);
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
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox femaleCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox maleCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox bioTextBox;
        private System.Windows.Forms.Button registerSubmitBtn;
        private System.Windows.Forms.TextBox usernameRegTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passRegTextBox;
    }
}
