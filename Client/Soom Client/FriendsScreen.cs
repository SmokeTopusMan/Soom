using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class FriendsScreen : UserControl, IMainScreenComponents
    {
        private Socket _socket;
        private int _id;
        public event FinishedEvent Event;
        public bool IsFinished { get; private set; }


        public FriendsScreen(Socket socket, int id)
        {
            InitializeComponent();
            _socket = socket;
            IsFinished = false;
            _id = id;

        }
        #region Buttons Hoverred settings
        private void addFriendButton_MouseEnter(object sender, EventArgs e)
        {
            addFriendButton.ForeColor = Color.FromArgb(195, 42, 196);
            addFriendButton.Font = new Font("Microsoft JhengHei Light", 20F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void addFriendButton_MouseLeave(object sender, EventArgs e)
        {
            addFriendButton.ForeColor = Color.FromArgb(125, 0, 19);
            addFriendButton.Font = new Font("Microsoft JhengHei Light", addFriendButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void pendingRequestsButton_MouseEnter(object sender, EventArgs e)
        {
            pendingRequestsButton.ForeColor = Color.FromArgb(195, 42, 196);
            pendingRequestsButton.Font = new Font("Microsoft JhengHei Light", 20F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void pendingRequestsButton_MouseLeave(object sender, EventArgs e)
        {
            pendingRequestsButton.ForeColor = Color.FromArgb(125, 0, 19);
            pendingRequestsButton.Font = new Font("Microsoft JhengHei Light", pendingRequestsButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void friendsListButton_MouseEnter(object sender, EventArgs e)
        {
            friendsListButton.ForeColor = Color.FromArgb(195, 42, 196);
            friendsListButton.Font = new Font("Microsoft JhengHei Light", 20F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
            this.Cursor = Cursors.Hand;
        }
        private void friendsListButton_MouseLeave(object sender, EventArgs e)
        {
            friendsListButton.ForeColor = Color.FromArgb(125, 0, 19);
            friendsListButton.Font = new Font("Microsoft JhengHei Light", friendsListButton.Font.SizeInPoints, FontStyle.Bold);
            this.Cursor = Cursors.Arrow;
        }
        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            backButton.Image = Resources.HoverredbackButton;
            this.Cursor = Cursors.Hand;
        }
        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            backButton.Image = Resources.backButton;
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region Back Button Press
        private void backButton_Click(object sender, EventArgs e)
        {
            Finished();
        }
        public void Finished()
        {
            // Raise the event with custom EventArgs
            if (Event != null)
            {
                Event(this, new ExitEventArgs(this, Name));
            }
        }
        #endregion

        private void friendsListButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
