namespace Soom_Client
{
    partial class ProfileUserControl
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.bioBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maleCheckBox = new System.Windows.Forms.CheckBox();
            this.femaleCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ageBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pointsBox = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(117, 146);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.usernameBox.MaxLength = 35;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(202, 20);
            this.usernameBox.TabIndex = 35;
            this.usernameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(51, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(51, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Password:";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(115, 196);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.passwordBox.MaxLength = 35;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(202, 20);
            this.passwordBox.TabIndex = 38;
            this.passwordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordBox_KeyPress);
            // 
            // bioBox
            // 
            this.bioBox.Location = new System.Drawing.Point(400, 146);
            this.bioBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.bioBox.MaxLength = 1000;
            this.bioBox.Multiline = true;
            this.bioBox.Name = "bioBox";
            this.bioBox.Size = new System.Drawing.Size(181, 229);
            this.bioBox.TabIndex = 34;
            this.bioBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bioBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Chocolate;
            this.label5.Location = new System.Drawing.Point(367, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Bio:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.maleCheckBox);
            this.panel1.Controls.Add(this.femaleCheckBox);
            this.panel1.Location = new System.Drawing.Point(47, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 40);
            this.panel1.TabIndex = 32;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(51, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Sex:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(51, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Age:";
            // 
            // ageBox
            // 
            this.ageBox.Location = new System.Drawing.Point(88, 246);
            this.ageBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 10);
            this.ageBox.MaxLength = 3;
            this.ageBox.Name = "ageBox";
            this.ageBox.Size = new System.Drawing.Size(31, 20);
            this.ageBox.TabIndex = 29;
            this.ageBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ageBox_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Chocolate;
            this.label6.Location = new System.Drawing.Point(367, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Points:";
            // 
            // pointsBox
            // 
            this.pointsBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsBox.Location = new System.Drawing.Point(414, 399);
            this.pointsBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 10);
            this.pointsBox.MaxLength = 5;
            this.pointsBox.Name = "pointsBox";
            this.pointsBox.ReadOnly = true;
            this.pointsBox.Size = new System.Drawing.Size(44, 28);
            this.pointsBox.TabIndex = 40;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(134, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(353, 89);
            this.title.TabIndex = 41;
            this.title.Text = "SOOM";
            // 
            // ProfilePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.title);
            this.Controls.Add(this.pointsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.bioBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ageBox);
            this.Name = "ProfilePanel";
            this.Size = new System.Drawing.Size(634, 461);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox bioBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox maleCheckBox;
        private System.Windows.Forms.CheckBox femaleCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ageBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pointsBox;
        private System.Windows.Forms.Label title;
    }
}
