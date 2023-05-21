namespace Soom_Client
{
    partial class SettingsScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoSettingsButton = new System.Windows.Forms.Label();
            this.audioSettingsButton = new System.Windows.Forms.Label();
            this.generalSettingsButton = new System.Windows.Forms.Label();
            this.profileSettingsButton = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.audioUserControl = new Soom_Client.AudioUserControl();
            this.videoUserControl = new Soom_Client.VideoUserControl();
            this.profileUserControl = new Soom_Client.ProfileUserControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // videoSettingsButton
            // 
            this.videoSettingsButton.AutoSize = true;
            this.videoSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.videoSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.videoSettingsButton.Location = new System.Drawing.Point(59, 252);
            this.videoSettingsButton.Name = "videoSettingsButton";
            this.videoSettingsButton.Size = new System.Drawing.Size(82, 32);
            this.videoSettingsButton.TabIndex = 7;
            this.videoSettingsButton.Text = "Video";
            this.videoSettingsButton.Click += new System.EventHandler(this.videoSettingsButton_Click);
            this.videoSettingsButton.MouseEnter += new System.EventHandler(this.videoSettingsButton_MouseEnter);
            this.videoSettingsButton.MouseLeave += new System.EventHandler(this.videoSettingsButton_MouseLeave);
            // 
            // audioSettingsButton
            // 
            this.audioSettingsButton.AutoSize = true;
            this.audioSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.audioSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.audioSettingsButton.Location = new System.Drawing.Point(59, 352);
            this.audioSettingsButton.Name = "audioSettingsButton";
            this.audioSettingsButton.Size = new System.Drawing.Size(83, 32);
            this.audioSettingsButton.TabIndex = 6;
            this.audioSettingsButton.Text = "Audio";
            this.audioSettingsButton.Click += new System.EventHandler(this.audioSettingsButton_Click);
            this.audioSettingsButton.MouseEnter += new System.EventHandler(this.audioSettingsButton_MouseEnter);
            this.audioSettingsButton.MouseLeave += new System.EventHandler(this.audioSettingsButton_MouseLeave);
            // 
            // generalSettingsButton
            // 
            this.generalSettingsButton.AutoSize = true;
            this.generalSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.generalSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.generalSettingsButton.Location = new System.Drawing.Point(45, 151);
            this.generalSettingsButton.Name = "generalSettingsButton";
            this.generalSettingsButton.Size = new System.Drawing.Size(110, 32);
            this.generalSettingsButton.TabIndex = 5;
            this.generalSettingsButton.Text = "General";
            this.generalSettingsButton.MouseEnter += new System.EventHandler(this.generalSettingsButton_MouseEnter);
            this.generalSettingsButton.MouseLeave += new System.EventHandler(this.generalSettingsButton_MouseLeave);
            // 
            // profileSettingsButton
            // 
            this.profileSettingsButton.AutoSize = true;
            this.profileSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.profileSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.profileSettingsButton.Location = new System.Drawing.Point(59, 51);
            this.profileSettingsButton.Name = "profileSettingsButton";
            this.profileSettingsButton.Size = new System.Drawing.Size(89, 32);
            this.profileSettingsButton.TabIndex = 4;
            this.profileSettingsButton.Text = "Profile";
            this.profileSettingsButton.Click += new System.EventHandler(this.profileSettingsButton_Click);
            this.profileSettingsButton.MouseEnter += new System.EventHandler(this.profileSettingsButton_MouseEnter);
            this.profileSettingsButton.MouseLeave += new System.EventHandler(this.profileSettingsButton_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.profileSettingsButton);
            this.panel1.Controls.Add(this.videoSettingsButton);
            this.panel1.Controls.Add(this.generalSettingsButton);
            this.panel1.Controls.Add(this.audioSettingsButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 461);
            this.panel1.TabIndex = 8;
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = global::Soom_Client.Properties.Resources.backButton;
            this.backButton.Location = new System.Drawing.Point(3, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(41, 41);
            this.backButton.TabIndex = 8;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
            // 
            // applyBtn
            // 
            this.applyBtn.Location = new System.Drawing.Point(62, 392);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Size = new System.Drawing.Size(75, 23);
            this.applyBtn.TabIndex = 10;
            this.applyBtn.Text = "Apply";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.applyBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.title);
            this.panel2.Controls.Add(this.applyBtn);
            this.panel2.Controls.Add(this.audioUserControl);
            this.panel2.Controls.Add(this.videoUserControl);
            this.panel2.Controls.Add(this.profileUserControl);
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 461);
            this.panel2.TabIndex = 11;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(140, 27);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(353, 89);
            this.title.TabIndex = 42;
            this.title.Text = "SOOM";
            // 
            // audioUserControl
            // 
            this.audioUserControl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.audioUserControl.Location = new System.Drawing.Point(-2, -2);
            this.audioUserControl.Name = "audioUserControl";
            this.audioUserControl.Size = new System.Drawing.Size(634, 461);
            this.audioUserControl.TabIndex = 44;
            // 
            // videoUserControl
            // 
            this.videoUserControl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.videoUserControl.Location = new System.Drawing.Point(-2, -2);
            this.videoUserControl.Name = "videoUserControl";
            this.videoUserControl.Size = new System.Drawing.Size(634, 461);
            this.videoUserControl.TabIndex = 43;
            // 
            // profileUserControl
            // 
            this.profileUserControl.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.profileUserControl.Location = new System.Drawing.Point(-2, -2);
            this.profileUserControl.Name = "profileUserControl";
            this.profileUserControl.Size = new System.Drawing.Size(634, 461);
            this.profileUserControl.TabIndex = 9;
            // 
            // SettingsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SettingsScreen";
            this.Size = new System.Drawing.Size(834, 461);
            this.Load += new System.EventHandler(this.SettingsScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label videoSettingsButton;
        private System.Windows.Forms.Label audioSettingsButton;
        private System.Windows.Forms.Label generalSettingsButton;
        private System.Windows.Forms.Label profileSettingsButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backButton;
        private ProfileUserControl profileUserControl;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label title;
        private AudioUserControl audioUserControl;
        private VideoUserControl videoUserControl;
    }
}