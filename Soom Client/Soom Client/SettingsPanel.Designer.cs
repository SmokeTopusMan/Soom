namespace Soom_Client
{
    partial class SettingsPanel
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
            this.profileSettingsButton = new System.Windows.Forms.Label();
            this.generalSettingsButton = new System.Windows.Forms.Label();
            this.audioSettingsButton = new System.Windows.Forms.Label();
            this.videoSettingsButton = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // profileSettingsButton
            // 
            this.profileSettingsButton.AutoSize = true;
            this.profileSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.profileSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.profileSettingsButton.Location = new System.Drawing.Point(66, 105);
            this.profileSettingsButton.Name = "profileSettingsButton";
            this.profileSettingsButton.Size = new System.Drawing.Size(89, 32);
            this.profileSettingsButton.TabIndex = 0;
            this.profileSettingsButton.Text = "Profile";
            this.profileSettingsButton.MouseEnter += new System.EventHandler(this.profileSettingsButton_MouseEnter);
            this.profileSettingsButton.MouseLeave += new System.EventHandler(this.profileSettingsButton_MouseLeave);
            // 
            // generalSettingsButton
            // 
            this.generalSettingsButton.AutoSize = true;
            this.generalSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.generalSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.generalSettingsButton.Location = new System.Drawing.Point(55, 208);
            this.generalSettingsButton.Name = "generalSettingsButton";
            this.generalSettingsButton.Size = new System.Drawing.Size(110, 32);
            this.generalSettingsButton.TabIndex = 1;
            this.generalSettingsButton.Text = "General";
            this.generalSettingsButton.MouseEnter += new System.EventHandler(this.generalSettingsButton_MouseEnter);
            this.generalSettingsButton.MouseLeave += new System.EventHandler(this.generalSettingsButton_MouseLeave);
            // 
            // audioSettingsButton
            // 
            this.audioSettingsButton.AutoSize = true;
            this.audioSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.audioSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.audioSettingsButton.Location = new System.Drawing.Point(69, 310);
            this.audioSettingsButton.Name = "audioSettingsButton";
            this.audioSettingsButton.Size = new System.Drawing.Size(83, 32);
            this.audioSettingsButton.TabIndex = 2;
            this.audioSettingsButton.Text = "Audio";
            this.audioSettingsButton.MouseEnter += new System.EventHandler(this.audioSettingsButton_MouseEnter);
            this.audioSettingsButton.MouseLeave += new System.EventHandler(this.audioSettingsButton_MouseLeave);
            // 
            // videoSettingsButton
            // 
            this.videoSettingsButton.AutoSize = true;
            this.videoSettingsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.videoSettingsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.videoSettingsButton.Location = new System.Drawing.Point(69, 413);
            this.videoSettingsButton.Name = "videoSettingsButton";
            this.videoSettingsButton.Size = new System.Drawing.Size(82, 32);
            this.videoSettingsButton.TabIndex = 3;
            this.videoSettingsButton.Text = "Video";
            this.videoSettingsButton.MouseEnter += new System.EventHandler(this.videoSettingsButton_MouseEnter);
            this.videoSettingsButton.MouseLeave += new System.EventHandler(this.videoSettingsButton_MouseLeave);
            // 
            // SettingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.videoSettingsButton);
            this.Controls.Add(this.audioSettingsButton);
            this.Controls.Add(this.generalSettingsButton);
            this.Controls.Add(this.profileSettingsButton);
            this.Name = "SettingsPanel";
            this.Size = new System.Drawing.Size(220, 550);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label profileSettingsButton;
        private System.Windows.Forms.Label generalSettingsButton;
        private System.Windows.Forms.Label audioSettingsButton;
        private System.Windows.Forms.Label videoSettingsButton;
    }
}
