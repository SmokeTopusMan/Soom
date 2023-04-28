namespace Soom_Client
{
    partial class LoginPanel
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
            this.usernameLogTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passLogTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // usernameLogTextBox
            // 
            this.usernameLogTextBox.Location = new System.Drawing.Point(199, 60);
            this.usernameLogTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.usernameLogTextBox.MaxLength = 35;
            this.usernameLogTextBox.Name = "usernameLogTextBox";
            this.usernameLogTextBox.Size = new System.Drawing.Size(202, 20);
            this.usernameLogTextBox.TabIndex = 14;
            this.usernameLogTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usernameLogTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(133, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(133, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password:";
            // 
            // passLogTextBox
            // 
            this.passLogTextBox.Location = new System.Drawing.Point(199, 86);
            this.passLogTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.passLogTextBox.MaxLength = 35;
            this.passLogTextBox.Name = "passLogTextBox";
            this.passLogTextBox.Size = new System.Drawing.Size(202, 20);
            this.passLogTextBox.TabIndex = 17;
            this.passLogTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passLogTextBox_KeyPress);
            // 
            // LoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.usernameLogTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passLogTextBox);
            this.Name = "LoginPanel";
            this.Size = new System.Drawing.Size(622, 218);
            this.Load += new System.EventHandler(this.LoginPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameLogTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passLogTextBox;
    }
}
