namespace Soom_Client
{
    partial class FriendsScreen
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
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.addFriendButton = new System.Windows.Forms.Label();
            this.friendsListButton = new System.Windows.Forms.Label();
            this.pendingRequestsButton = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(330, 50);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(353, 89);
            this.title.TabIndex = 43;
            this.title.Text = "SOOM";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.addFriendButton);
            this.panel1.Controls.Add(this.friendsListButton);
            this.panel1.Controls.Add(this.pendingRequestsButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 461);
            this.panel1.TabIndex = 44;
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
            // 
            // addFriendButton
            // 
            this.addFriendButton.AutoSize = true;
            this.addFriendButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addFriendButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.addFriendButton.Location = new System.Drawing.Point(20, 107);
            this.addFriendButton.Name = "addFriendButton";
            this.addFriendButton.Size = new System.Drawing.Size(161, 32);
            this.addFriendButton.TabIndex = 4;
            this.addFriendButton.Text = "Add Friends";
            // 
            // friendsListButton
            // 
            this.friendsListButton.AutoSize = true;
            this.friendsListButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.friendsListButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.friendsListButton.Location = new System.Drawing.Point(20, 322);
            this.friendsListButton.Name = "friendsListButton";
            this.friendsListButton.Size = new System.Drawing.Size(156, 32);
            this.friendsListButton.TabIndex = 7;
            this.friendsListButton.Text = "Friends List";
            // 
            // pendingRequestsButton
            // 
            this.pendingRequestsButton.AutoSize = true;
            this.pendingRequestsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pendingRequestsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.pendingRequestsButton.Location = new System.Drawing.Point(1, 214);
            this.pendingRequestsButton.Name = "pendingRequestsButton";
            this.pendingRequestsButton.Size = new System.Drawing.Size(196, 26);
            this.pendingRequestsButton.TabIndex = 5;
            this.pendingRequestsButton.Text = "Pending Requests";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(401, 221);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(5, 15, 45, 15);
            this.usernameBox.MaxLength = 35;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(238, 20);
            this.usernameBox.TabIndex = 45;
            // 
            // FriendsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.title);
            this.Name = "FriendsScreen";
            this.Size = new System.Drawing.Size(834, 461);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label addFriendButton;
        private System.Windows.Forms.Label friendsListButton;
        private System.Windows.Forms.Label pendingRequestsButton;
        private System.Windows.Forms.TextBox usernameBox;
    }
}
