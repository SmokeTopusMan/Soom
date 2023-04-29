namespace MediaTransferTest
{
    partial class Media
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCamera = new System.Windows.Forms.ComboBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.mic = new System.Windows.Forms.Label();
            this.cboMicrophone = new System.Windows.Forms.ComboBox();
            this.headphones = new System.Windows.Forms.Label();
            this.cboHeadphones = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera:";
            // 
            // cboCamera
            // 
            this.cboCamera.Cursor = System.Windows.Forms.Cursors.Help;
            this.cboCamera.FormattingEnabled = true;
            this.cboCamera.Location = new System.Drawing.Point(100, 25);
            this.cboCamera.Name = "cboCamera";
            this.cboCamera.Size = new System.Drawing.Size(273, 21);
            this.cboCamera.TabIndex = 1;
            this.cboCamera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboCamera_KeyPress);
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Location = new System.Drawing.Point(12, 52);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(555, 376);
            this.pic.TabIndex = 2;
            this.pic.TabStop = false;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(203, 473);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 3;
            this.StartBtn.Text = "&Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // mic
            // 
            this.mic.AutoSize = true;
            this.mic.Location = new System.Drawing.Point(625, 28);
            this.mic.Name = "mic";
            this.mic.Size = new System.Drawing.Size(66, 13);
            this.mic.TabIndex = 4;
            this.mic.Text = "Microphone:";
            // 
            // cboMicrophone
            // 
            this.cboMicrophone.FormattingEnabled = true;
            this.cboMicrophone.Location = new System.Drawing.Point(697, 25);
            this.cboMicrophone.Name = "cboMicrophone";
            this.cboMicrophone.Size = new System.Drawing.Size(273, 21);
            this.cboMicrophone.TabIndex = 5;
            this.cboMicrophone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMicrophone_KeyPress);
            // 
            // headphones
            // 
            this.headphones.AutoSize = true;
            this.headphones.Location = new System.Drawing.Point(620, 72);
            this.headphones.Name = "headphones";
            this.headphones.Size = new System.Drawing.Size(71, 13);
            this.headphones.TabIndex = 6;
            this.headphones.Text = "Headphones:";
            // 
            // cboHeadphones
            // 
            this.cboHeadphones.FormattingEnabled = true;
            this.cboHeadphones.Location = new System.Drawing.Point(697, 72);
            this.cboHeadphones.Name = "cboHeadphones";
            this.cboHeadphones.Size = new System.Drawing.Size(273, 21);
            this.cboHeadphones.TabIndex = 7;
            this.cboHeadphones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboHeadphones_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Media
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 541);
            this.Controls.Add(this.cboHeadphones);
            this.Controls.Add(this.headphones);
            this.Controls.Add(this.cboMicrophone);
            this.Controls.Add(this.mic);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.cboCamera);
            this.Controls.Add(this.label1);
            this.Name = "Media";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebCam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCamera;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label mic;
        private System.Windows.Forms.ComboBox cboMicrophone;
        private System.Windows.Forms.Label headphones;
        private System.Windows.Forms.ComboBox cboHeadphones;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

