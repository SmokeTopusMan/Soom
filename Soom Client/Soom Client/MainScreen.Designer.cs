namespace Soom_Client
{
    partial class MainScreen
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
            this.settingsWheel = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsWheel
            // 
            this.settingsWheel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsWheel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.settingsWheel.FlatAppearance.BorderSize = 0;
            this.settingsWheel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.settingsWheel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(224)))));
            this.settingsWheel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsWheel.Image = global::Soom_Client.Properties.Resources.SettingsGear;
            this.settingsWheel.Location = new System.Drawing.Point(12, 12);
            this.settingsWheel.Name = "settingsWheel";
            this.settingsWheel.Size = new System.Drawing.Size(57, 57);
            this.settingsWheel.TabIndex = 0;
            this.settingsWheel.UseVisualStyleBackColor = true;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 47.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(302, 59);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(286, 84);
            this.title.TabIndex = 1;
            this.title.Text = "Soranify";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(874, 511);
            this.Controls.Add(this.title);
            this.Controls.Add(this.settingsWheel);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button settingsWheel;
        private System.Windows.Forms.Label title;
    }
}