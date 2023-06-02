namespace Soom_Client
{
    partial class MeetingScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.sponsorLabel = new System.Windows.Forms.Label();
            this.videoBtn = new System.Windows.Forms.Button();
            this.muteBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vladimir Script", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(719, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Meeting\'s Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(797, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 567);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Location = new System.Drawing.Point(321, 281);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(320, 240);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Location = new System.Drawing.Point(0, 281);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(320, 240);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(321, 41);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(1, 41);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 240);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // sponsorLabel
            // 
            this.sponsorLabel.AutoSize = true;
            this.sponsorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sponsorLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 6F, System.Drawing.FontStyle.Bold);
            this.sponsorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(0)))), ((int)(((byte)(17)))));
            this.sponsorLabel.Location = new System.Drawing.Point(0, 581);
            this.sponsorLabel.Name = "sponsorLabel";
            this.sponsorLabel.Size = new System.Drawing.Size(115, 10);
            this.sponsorLabel.TabIndex = 9;
            this.sponsorLabel.Text = "Sponsored By SP Online";
            // 
            // videoBtn
            // 
            this.videoBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.videoBtn.FlatAppearance.BorderSize = 0;
            this.videoBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.videoBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(224)))));
            this.videoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoBtn.Image = global::Soom_Client.Properties.Resources.Video_Button;
            this.videoBtn.Location = new System.Drawing.Point(826, 185);
            this.videoBtn.Name = "videoBtn";
            this.videoBtn.Size = new System.Drawing.Size(51, 51);
            this.videoBtn.TabIndex = 8;
            this.videoBtn.UseVisualStyleBackColor = true;
            this.videoBtn.Click += new System.EventHandler(this.videoBtn_Click);
            this.videoBtn.MouseEnter += new System.EventHandler(this.videoBtn_MouseEnter);
            this.videoBtn.MouseLeave += new System.EventHandler(this.videoBtn_MouseLeave);
            // 
            // muteBtn
            // 
            this.muteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.muteBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.muteBtn.FlatAppearance.BorderSize = 0;
            this.muteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.muteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(224)))));
            this.muteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.muteBtn.Image = global::Soom_Client.Properties.Resources.Mute_Button;
            this.muteBtn.Location = new System.Drawing.Point(781, 190);
            this.muteBtn.Name = "muteBtn";
            this.muteBtn.Size = new System.Drawing.Size(41, 41);
            this.muteBtn.TabIndex = 7;
            this.muteBtn.UseVisualStyleBackColor = true;
            this.muteBtn.Click += new System.EventHandler(this.muteBtn_Click);
            this.muteBtn.MouseEnter += new System.EventHandler(this.muteBtn_MouseEnter);
            this.muteBtn.MouseLeave += new System.EventHandler(this.muteBtn_MouseLeave);
            // 
            // MeetingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(199)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.sponsorLabel);
            this.Controls.Add(this.videoBtn);
            this.Controls.Add(this.muteBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MeetingScreen";
            this.Text = "Meeting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Meeting_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button muteBtn;
        private System.Windows.Forms.Button videoBtn;
        private System.Windows.Forms.Label sponsorLabel;
    }
}