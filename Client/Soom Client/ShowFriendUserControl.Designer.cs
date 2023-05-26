namespace Soom_Client
{
    partial class ShowFriendUserControl
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
            this.pointsBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.bio = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pointsBox
            // 
            this.pointsBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsBox.Location = new System.Drawing.Point(248, 374);
            this.pointsBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 10);
            this.pointsBox.MaxLength = 5;
            this.pointsBox.Name = "pointsBox";
            this.pointsBox.ReadOnly = true;
            this.pointsBox.Size = new System.Drawing.Size(44, 28);
            this.pointsBox.TabIndex = 50;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Chocolate;
            this.label6.Location = new System.Drawing.Point(201, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Points:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(201, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Chocolate;
            this.label5.Location = new System.Drawing.Point(351, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Bio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(201, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Sex:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(201, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Age:";
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Location = new System.Drawing.Point(265, 124);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(35, 13);
            this.username.TabIndex = 51;
            this.username.Text = "label2";
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Location = new System.Drawing.Point(236, 217);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(35, 13);
            this.age.TabIndex = 52;
            this.age.Text = "label7";
            // 
            // sex
            // 
            this.sex.AutoSize = true;
            this.sex.Location = new System.Drawing.Point(235, 306);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(35, 13);
            this.sex.TabIndex = 53;
            this.sex.Text = "label8";
            // 
            // bio
            // 
            this.bio.AutoSize = true;
            this.bio.Location = new System.Drawing.Point(382, 178);
            this.bio.Name = "bio";
            this.bio.Size = new System.Drawing.Size(35, 13);
            this.bio.TabIndex = 54;
            this.bio.Text = "label9";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(27, 99);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(147, 329);
            this.listBox1.TabIndex = 55;
            // 
            // ShowFriendUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bio);
            this.Controls.Add(this.sex);
            this.Controls.Add(this.age);
            this.Controls.Add(this.username);
            this.Controls.Add(this.pointsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "ShowFriendUserControl";
            this.Size = new System.Drawing.Size(634, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pointsBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.Label sex;
        private System.Windows.Forms.Label bio;
        private System.Windows.Forms.ListBox listBox1;
    }
}
