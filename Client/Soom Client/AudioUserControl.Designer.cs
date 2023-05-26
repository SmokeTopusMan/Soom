using NAudio.Wave;

namespace Soom_Client
{
    partial class AudioUserControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.outputCboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputCboBox = new System.Windows.Forms.ComboBox();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.volumeNumberBox = new System.Windows.Forms.TextBox();
            this.enterCallBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(130, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Output Device:";
            // 
            // outputCboBox
            // 
            this.outputCboBox.FormattingEnabled = true;
            this.outputCboBox.Location = new System.Drawing.Point(215, 201);
            this.outputCboBox.Name = "outputCboBox";
            this.outputCboBox.Size = new System.Drawing.Size(281, 21);
            this.outputCboBox.TabIndex = 38;
            this.outputCboBox.SelectedIndexChanged += new System.EventHandler(this.outputCboBox_SelectedIndexChanged);
            this.outputCboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.outputCboBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(138, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Input Device:";
            // 
            // inputCboBox
            // 
            this.inputCboBox.FormattingEnabled = true;
            this.inputCboBox.Location = new System.Drawing.Point(215, 160);
            this.inputCboBox.Name = "inputCboBox";
            this.inputCboBox.Size = new System.Drawing.Size(281, 21);
            this.inputCboBox.TabIndex = 40;
            this.inputCboBox.SelectedIndexChanged += new System.EventHandler(this.inputCboBox_SelectedIndexChanged);
            this.inputCboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.inputCboBox_KeyPress);
            // 
            // volumeBar
            // 
            this.volumeBar.BackColor = System.Drawing.SystemColors.Window;
            this.volumeBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeBar.LargeChange = 10;
            this.volumeBar.Location = new System.Drawing.Point(215, 237);
            this.volumeBar.Maximum = 100;
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(290, 45);
            this.volumeBar.TabIndex = 42;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeBar.Scroll += new System.EventHandler(this.volumeBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(164, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Volume:";
            // 
            // volumeNumberBox
            // 
            this.volumeNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.volumeNumberBox.Location = new System.Drawing.Point(511, 237);
            this.volumeNumberBox.MaxLength = 3;
            this.volumeNumberBox.Name = "volumeNumberBox";
            this.volumeNumberBox.ReadOnly = true;
            this.volumeNumberBox.Size = new System.Drawing.Size(37, 29);
            this.volumeNumberBox.TabIndex = 44;
            // 
            // enterCallBox
            // 
            this.enterCallBox.AutoSize = true;
            this.enterCallBox.BackColor = System.Drawing.Color.Chocolate;
            this.enterCallBox.Location = new System.Drawing.Point(133, 298);
            this.enterCallBox.Name = "enterCallBox";
            this.enterCallBox.Size = new System.Drawing.Size(233, 17);
            this.enterCallBox.TabIndex = 45;
            this.enterCallBox.Text = "Turn Off Microphone When Joining Meeting";
            this.enterCallBox.UseVisualStyleBackColor = false;
            this.enterCallBox.CheckedChanged += new System.EventHandler(this.enterCallBox_CheckedChanged);
            // 
            // AudioUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.enterCallBox);
            this.Controls.Add(this.volumeNumberBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputCboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputCboBox);
            this.Name = "AudioUserControl";
            this.Size = new System.Drawing.Size(634, 461);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox outputCboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox inputCboBox;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox volumeNumberBox;
        private System.Windows.Forms.CheckBox enterCallBox;
    }
}
