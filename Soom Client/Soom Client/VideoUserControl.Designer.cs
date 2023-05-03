namespace Soom_Client
{
    partial class VideoUserControl
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
            this.cameraCboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.enterCallBox = new System.Windows.Forms.CheckBox();
            this.mirrorBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraCboBox
            // 
            this.cameraCboBox.FormattingEnabled = true;
            this.cameraCboBox.Location = new System.Drawing.Point(206, 165);
            this.cameraCboBox.Name = "cameraCboBox";
            this.cameraCboBox.Size = new System.Drawing.Size(281, 21);
            this.cameraCboBox.TabIndex = 0;
            this.cameraCboBox.SelectedIndexChanged += new System.EventHandler(this.cameraCboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(130, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Camera:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(134, 12);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(353, 89);
            this.title.TabIndex = 42;
            this.title.Text = "SOOM";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enterCallBox);
            this.panel1.Controls.Add(this.mirrorBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(44, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 252);
            this.panel1.TabIndex = 43;
            // 
            // enterCallBox
            // 
            this.enterCallBox.AutoSize = true;
            this.enterCallBox.BackColor = System.Drawing.Color.Chocolate;
            this.enterCallBox.Location = new System.Drawing.Point(302, 30);
            this.enterCallBox.Name = "enterCallBox";
            this.enterCallBox.Size = new System.Drawing.Size(221, 17);
            this.enterCallBox.TabIndex = 41;
            this.enterCallBox.Text = "Turn Off My Video When Joining Meeting";
            this.enterCallBox.UseVisualStyleBackColor = false;
            this.enterCallBox.CheckedChanged += new System.EventHandler(this.enterCallBox_CheckedChanged);
            // 
            // mirrorBox
            // 
            this.mirrorBox.AutoSize = true;
            this.mirrorBox.BackColor = System.Drawing.Color.Chocolate;
            this.mirrorBox.Location = new System.Drawing.Point(25, 30);
            this.mirrorBox.Name = "mirrorBox";
            this.mirrorBox.Size = new System.Drawing.Size(111, 17);
            this.mirrorBox.TabIndex = 40;
            this.mirrorBox.Text = "Mirror The Screen";
            this.mirrorBox.UseVisualStyleBackColor = false;
            this.mirrorBox.CheckedChanged += new System.EventHandler(this.mirrorBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(51, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 39;
            // 
            // VideoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cameraCboBox);
            this.Name = "VideoUserControl";
            this.Size = new System.Drawing.Size(634, 461);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cameraCboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox enterCallBox;
        private System.Windows.Forms.CheckBox mirrorBox;
        private System.Windows.Forms.Label label3;
    }
}
