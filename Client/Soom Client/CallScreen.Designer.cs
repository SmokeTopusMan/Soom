namespace Soom_Client
{
    partial class CallScreen
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
            this.callsNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.callsPasswordBox = new System.Windows.Forms.TextBox();
            this.generateInfoBtn = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.startMeetingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // callsNameBox
            // 
            this.callsNameBox.Location = new System.Drawing.Point(352, 220);
            this.callsNameBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.callsNameBox.MaxLength = 10;
            this.callsNameBox.Name = "callsNameBox";
            this.callsNameBox.Size = new System.Drawing.Size(208, 20);
            this.callsNameBox.TabIndex = 39;
            this.callsNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RestrictedTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(226, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Enter Your Call\'s Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(226, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Enter Your Call\'s Password:";
            // 
            // callsPasswordBox
            // 
            this.callsPasswordBox.Location = new System.Drawing.Point(370, 252);
            this.callsPasswordBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 10);
            this.callsPasswordBox.MaxLength = 10;
            this.callsPasswordBox.Name = "callsPasswordBox";
            this.callsPasswordBox.Size = new System.Drawing.Size(190, 20);
            this.callsPasswordBox.TabIndex = 37;
            this.callsPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RestrictedTextBox_KeyPress);
            // 
            // generateInfoBtn
            // 
            this.generateInfoBtn.Location = new System.Drawing.Point(578, 233);
            this.generateInfoBtn.Name = "generateInfoBtn";
            this.generateInfoBtn.Size = new System.Drawing.Size(103, 23);
            this.generateInfoBtn.TabIndex = 42;
            this.generateInfoBtn.Text = "Generate Random";
            this.generateInfoBtn.UseVisualStyleBackColor = true;
            this.generateInfoBtn.Click += new System.EventHandler(this.generateInfoBtn_Click);
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = global::Soom_Client.Properties.Resources.backButton;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(41, 41);
            this.backButton.TabIndex = 43;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(248, 59);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(353, 89);
            this.title.TabIndex = 44;
            this.title.Text = "SOOM";
            // 
            // startMeetingBtn
            // 
            this.startMeetingBtn.Location = new System.Drawing.Point(352, 315);
            this.startMeetingBtn.Name = "startMeetingBtn";
            this.startMeetingBtn.Size = new System.Drawing.Size(94, 23);
            this.startMeetingBtn.TabIndex = 45;
            this.startMeetingBtn.Text = "Start a Meeting";
            this.startMeetingBtn.UseVisualStyleBackColor = true;
            this.startMeetingBtn.Click += new System.EventHandler(this.startMeetingBtn_Click);
            // 
            // CreateCallScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.startMeetingBtn);
            this.Controls.Add(this.title);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.generateInfoBtn);
            this.Controls.Add(this.callsNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.callsPasswordBox);
            this.Name = "CreateCallScreen";
            this.Size = new System.Drawing.Size(834, 461);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox callsNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox callsPasswordBox;
        private System.Windows.Forms.Button generateInfoBtn;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button startMeetingBtn;
    }
}
