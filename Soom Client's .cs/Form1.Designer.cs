namespace Soom_Client
{
    partial class Form1
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
            this.title = new System.Windows.Forms.Label();
            this.register = new System.Windows.Forms.Button();
            this.login = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.registerClick = new Soom_Client.RegisterClick();
            this.loginClick = new Soom_Client.LoginClick();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AllowDrop = true;
            this.title.Font = new System.Drawing.Font("Bernard MT Condensed", 30F);
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.title.Location = new System.Drawing.Point(365, 69);
            this.title.Margin = new System.Windows.Forms.Padding(300, 300, 300, 200);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(297, 50);
            this.title.TabIndex = 2;
            this.title.Text = "Welcome To SOOM";
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.Color.Yellow;
            this.register.Font = new System.Drawing.Font("Bernard MT Condensed", 14F);
            this.register.ForeColor = System.Drawing.Color.DarkCyan;
            this.register.Location = new System.Drawing.Point(40, 109);
            this.register.Margin = new System.Windows.Forms.Padding(10, 100, 10, 10);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(90, 40);
            this.register.TabIndex = 3;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.Yellow;
            this.login.Font = new System.Drawing.Font("Bernard MT Condensed", 14F);
            this.login.ForeColor = System.Drawing.Color.DarkCyan;
            this.login.Location = new System.Drawing.Point(40, 312);
            this.login.Margin = new System.Windows.Forms.Padding(10, 10, 10, 100);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(90, 40);
            this.login.TabIndex = 4;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = false;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.register);
            this.panel1.Controls.Add(this.login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 461);
            this.panel1.TabIndex = 5;
            // 
            // registerClick
            // 
            this.registerClick.Location = new System.Drawing.Point(200, 137);
            this.registerClick.Name = "registerClick";
            this.registerClick.Size = new System.Drawing.Size(622, 312);
            this.registerClick.TabIndex = 7;
            // 
            // loginClick
            // 
            this.loginClick.Location = new System.Drawing.Point(200, 137);
            this.loginClick.Name = "loginClick";
            this.loginClick.Size = new System.Drawing.Size(622, 312);
            this.loginClick.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.registerClick);
            this.Controls.Add(this.loginClick);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Panel panel1;
        private LoginClick loginClick;
        private RegisterClick registerClick;
    }
}

