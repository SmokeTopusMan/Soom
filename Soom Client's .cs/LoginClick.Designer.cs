namespace Soom_Client
{
    partial class LoginClick
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
            this.loginSubmitBtn = new System.Windows.Forms.Button();
            this.usernameLogTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passLogTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginSubmitBtn
            // 
            this.loginSubmitBtn.Location = new System.Drawing.Point(266, 260);
            this.loginSubmitBtn.Name = "loginSubmitBtn";
            this.loginSubmitBtn.Size = new System.Drawing.Size(75, 23);
            this.loginSubmitBtn.TabIndex = 15;
            this.loginSubmitBtn.Text = "Submit";
            this.loginSubmitBtn.UseVisualStyleBackColor = true;
            this.loginSubmitBtn.Click += new System.EventHandler(this.loginSubmitBtn_Click);
            // 
            // usernameLogTextBox
            // 
            this.usernameLogTextBox.Location = new System.Drawing.Point(217, 157);
            this.usernameLogTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.usernameLogTextBox.MaxLength = 50;
            this.usernameLogTextBox.Name = "usernameLogTextBox";
            this.usernameLogTextBox.Size = new System.Drawing.Size(202, 20);
            this.usernameLogTextBox.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(151, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(151, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // passLogTextBox
            // 
            this.passLogTextBox.Location = new System.Drawing.Point(217, 207);
            this.passLogTextBox.Margin = new System.Windows.Forms.Padding(5, 15, 15, 15);
            this.passLogTextBox.MaxLength = 50;
            this.passLogTextBox.Name = "passLogTextBox";
            this.passLogTextBox.Size = new System.Drawing.Size(202, 20);
            this.passLogTextBox.TabIndex = 9;
            // 
            // LoginClick
            // 
            this.Controls.Add(this.loginSubmitBtn);
            this.Controls.Add(this.usernameLogTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passLogTextBox);
            this.Name = "LoginClick";
            this.Size = new System.Drawing.Size(622, 312);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginSubmitBtn;
        private System.Windows.Forms.TextBox usernameLogTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passLogTextBox;
    }
}
