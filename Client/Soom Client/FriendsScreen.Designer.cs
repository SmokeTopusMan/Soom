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
            this.panel1 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.addFriendButton = new System.Windows.Forms.Label();
            this.friendsListButton = new System.Windows.Forms.Label();
            this.pendingRequestsButton = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.requestsListBox = new System.Windows.Forms.ListBox();
            this.title = new System.Windows.Forms.Label();
            this.boxesLabel = new System.Windows.Forms.Label();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.searchUserBtn = new System.Windows.Forms.Button();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.declineBtn = new System.Windows.Forms.Button();
            this.showUserInfoUserControl = new Soom_Client.ShowFriendUserControl();
            this.addFriendUserControl = new Soom_Client.AddFriendUserControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.backButton.MouseEnter += new System.EventHandler(this.backButton_MouseEnter);
            this.backButton.MouseLeave += new System.EventHandler(this.backButton_MouseLeave);
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
            this.addFriendButton.Click += new System.EventHandler(this.addFriendButton_Click);
            this.addFriendButton.MouseEnter += new System.EventHandler(this.addFriendButton_MouseEnter);
            this.addFriendButton.MouseLeave += new System.EventHandler(this.addFriendButton_MouseLeave);
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
            this.friendsListButton.Click += new System.EventHandler(this.friendsListButton_Click);
            this.friendsListButton.MouseEnter += new System.EventHandler(this.friendsListButton_MouseEnter);
            this.friendsListButton.MouseLeave += new System.EventHandler(this.friendsListButton_MouseLeave);
            // 
            // pendingRequestsButton
            // 
            this.pendingRequestsButton.AutoSize = true;
            this.pendingRequestsButton.Font = new System.Drawing.Font("Microsoft JhengHei Light", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pendingRequestsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(0)))), ((int)(((byte)(19)))));
            this.pendingRequestsButton.Location = new System.Drawing.Point(3, 216);
            this.pendingRequestsButton.Name = "pendingRequestsButton";
            this.pendingRequestsButton.Size = new System.Drawing.Size(187, 25);
            this.pendingRequestsButton.TabIndex = 5;
            this.pendingRequestsButton.Text = "Pending Requests";
            this.pendingRequestsButton.Click += new System.EventHandler(this.pendingRequestsButton_Click);
            this.pendingRequestsButton.MouseEnter += new System.EventHandler(this.pendingRequestsButton_MouseEnter);
            this.pendingRequestsButton.MouseLeave += new System.EventHandler(this.pendingRequestsButton_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(143)))), ((int)(((byte)(210)))));
            this.panel2.Controls.Add(this.declineBtn);
            this.panel2.Controls.Add(this.acceptBtn);
            this.panel2.Controls.Add(this.requestsListBox);
            this.panel2.Controls.Add(this.title);
            this.panel2.Controls.Add(this.boxesLabel);
            this.panel2.Controls.Add(this.friendsListBox);
            this.panel2.Controls.Add(this.showUserInfoUserControl);
            this.panel2.Controls.Add(this.searchUserBtn);
            this.panel2.Controls.Add(this.addFriendUserControl);
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 461);
            this.panel2.TabIndex = 45;
            // 
            // requestsListBox
            // 
            this.requestsListBox.FormattingEnabled = true;
            this.requestsListBox.HorizontalScrollbar = true;
            this.requestsListBox.Location = new System.Drawing.Point(20, 153);
            this.requestsListBox.Name = "requestsListBox";
            this.requestsListBox.Size = new System.Drawing.Size(147, 290);
            this.requestsListBox.TabIndex = 59;
            this.requestsListBox.SelectedIndexChanged += new System.EventHandler(this.requestsListBox_SelectedIndexChanged);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(143)))), ((int)(((byte)(210)))));
            this.title.Font = new System.Drawing.Font("Matura MT Script Capitals", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(64)))), ((int)(((byte)(181)))));
            this.title.Location = new System.Drawing.Point(138, 14);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(353, 89);
            this.title.TabIndex = 43;
            this.title.Text = "SOOM";
            // 
            // boxesLabel
            // 
            this.boxesLabel.AutoSize = true;
            this.boxesLabel.BackColor = System.Drawing.Color.Chocolate;
            this.boxesLabel.Location = new System.Drawing.Point(20, 137);
            this.boxesLabel.Name = "boxesLabel";
            this.boxesLabel.Size = new System.Drawing.Size(29, 13);
            this.boxesLabel.TabIndex = 57;
            this.boxesLabel.Text = "label";
            // 
            // friendsListBox
            // 
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.HorizontalScrollbar = true;
            this.friendsListBox.Location = new System.Drawing.Point(20, 153);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(147, 290);
            this.friendsListBox.TabIndex = 56;
            // 
            // searchUserBtn
            // 
            this.searchUserBtn.Location = new System.Drawing.Point(416, 201);
            this.searchUserBtn.Name = "searchUserBtn";
            this.searchUserBtn.Size = new System.Drawing.Size(75, 23);
            this.searchUserBtn.TabIndex = 4;
            this.searchUserBtn.Text = "Search";
            this.searchUserBtn.UseVisualStyleBackColor = true;
            this.searchUserBtn.Click += new System.EventHandler(this.searchUserBtn_Click);
            // 
            // acceptBtn
            // 
            this.acceptBtn.Location = new System.Drawing.Point(537, 420);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 60;
            this.acceptBtn.Text = "Accept";
            this.acceptBtn.UseVisualStyleBackColor = true;
            // 
            // declineBtn
            // 
            this.declineBtn.Location = new System.Drawing.Point(537, 391);
            this.declineBtn.Name = "declineBtn";
            this.declineBtn.Size = new System.Drawing.Size(75, 23);
            this.declineBtn.TabIndex = 61;
            this.declineBtn.Text = "Decline";
            this.declineBtn.UseVisualStyleBackColor = true;
            // 
            // showUserInfoUserControl
            // 
            this.showUserInfoUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(143)))), ((int)(((byte)(210)))));
            this.showUserInfoUserControl.Location = new System.Drawing.Point(-3, 230);
            this.showUserInfoUserControl.Name = "showUserInfoUserControl";
            this.showUserInfoUserControl.Size = new System.Drawing.Size(634, 461);
            this.showUserInfoUserControl.TabIndex = 44;
            // 
            // addFriendUserControl
            // 
            this.addFriendUserControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(143)))), ((int)(((byte)(210)))));
            this.addFriendUserControl.Location = new System.Drawing.Point(0, 0);
            this.addFriendUserControl.Name = "addFriendUserControl";
            this.addFriendUserControl.Size = new System.Drawing.Size(634, 461);
            this.addFriendUserControl.TabIndex = 0;
            // 
            // FriendsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(232)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FriendsScreen";
            this.Size = new System.Drawing.Size(834, 461);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label addFriendButton;
        private System.Windows.Forms.Label friendsListButton;
        private System.Windows.Forms.Label pendingRequestsButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button searchUserBtn;
        private AddFriendUserControl addFriendUserControl;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ListBox friendsListBox;
        private ShowFriendUserControl showUserInfoUserControl;
        private System.Windows.Forms.Label boxesLabel;
        private System.Windows.Forms.ListBox requestsListBox;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button declineBtn;
    }
}
