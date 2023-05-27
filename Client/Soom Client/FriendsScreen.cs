using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Soom_Client
{
    public partial class FriendsScreen : UserControl, IMainScreenComponents
    {
        private Socket _socket;
        private int _id;
        public event FinishedEvent Event;
        private List<string> _friendsList = new List<string>();
        private List<string> _pendingRequestList = new List<string>();

        public bool IsFinished { get; private set; }


        public FriendsScreen(Socket socket, int id)
        {
            InitializeComponent();
            _socket = socket;
            IsFinished = false;
            _id = id;
            GetDataFromServer("FRD", _friendsList);
            GetDataFromServer("PND", _pendingRequestList);
            EnterDataToListBoxes();

            this.addFriendUserControl.Hide();
            this.showUserInfoUserControl.Hide();
            this.searchUserBtn.Hide();
            this.title.Hide();
            this.friendsListBox.Hide();
            this.requestsListBox.Hide();
            this.boxesLabel.Hide();
            this.acceptBtn.Hide();
            this.acceptBtn.Enabled = false;
            this.declineBtn.Hide();
            this.declineBtn.Enabled = false;
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
            pendingRequestsButton.Font = new Font("Microsoft JhengHei Light", 16.5F, (FontStyle.Bold | FontStyle.Underline), GraphicsUnit.Point, ((byte)(177)));
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
            if (friendsListBox.Visible)
            {
                MessageBox.Show("Need to do here: the action u did are not saved. click apply to save them.");
                this.boxesLabel.Hide();
                this.title.Hide();
                this.friendsListBox.Hide();
                if (showUserInfoUserControl.Visible)
                {
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }
            }
            else
            {
                HideAllComponents(this.showUserInfoUserControl);
                this.boxesLabel.Text = "Here Are Your Friends!";
                this.boxesLabel.Show();
                this.title.Show();
                this.friendsListBox.Show();
            }
        }
        private void pendingRequestsButton_Click(object sender, EventArgs e)
        {
            if (requestsListBox.Visible)
            {
                MessageBox.Show("Need to do here: the action u did are not saved. click apply to save them.");
                this.acceptBtn.Hide();
                this.acceptBtn.Enabled = false;
                this.declineBtn.Hide();
                this.declineBtn.Enabled = false;
                this.boxesLabel.Hide();
                this.title.Hide();
                this.requestsListBox.Hide();
                if (showUserInfoUserControl.Visible)
                {
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }
            }
            else
            {
                HideAllComponents(this.showUserInfoUserControl);
                if (requestsListBox.Items.Count > 0)
                    this.boxesLabel.Text = "You Have New Friend Requests!";
                else
                    this.boxesLabel.Text = "There Are No Fresh Requests!";
                this.acceptBtn.Show();
                this.declineBtn.Show();
                this.boxesLabel.Show();
                this.title.Show();
                this.requestsListBox.Show();
            }
        }
        private void addFriendButton_Click(object sender, EventArgs e)
        {
            if (addFriendUserControl.Visible)
            {
                MessageBox.Show("Need to do here: the action u did are not saved. click apply to save them.");
                this.title.Hide();
                this.searchUserBtn.Hide();
                this.addFriendUserControl.Hide();
                this.addFriendUserControl.ClearUsername();
            }
            else
            {
                HideAllComponents(this.addFriendUserControl);
                this.title.Show();
                this.searchUserBtn.Show();
                this.addFriendUserControl.Show();
            }
        }
        private void HideAllComponents(IFriendsComponents component)
        {
            if (component != this.addFriendUserControl && this.addFriendUserControl.Visible)
            {
                this.searchUserBtn.Hide();
                this.addFriendUserControl.Hide();
                this.addFriendUserControl.ClearUsername();
            }
            else if (this.friendsListBox.Visible)
            {
                this.boxesLabel.Hide();
                this.friendsListBox.Hide();
                if (this.showUserInfoUserControl.Visible)
                {
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }
            }
            else if (this.requestsListBox.Visible)
            {
                this.boxesLabel.Hide();
                this.requestsListBox.Hide();
                this.acceptBtn.Hide();
                this.acceptBtn.Enabled = false;
                this.declineBtn.Hide();
                this.declineBtn.Enabled = false;
                if (this.showUserInfoUserControl.Visible)
                {
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }
            }
            
        }
        private void GetDataFromServer(string command, List<string> list)
        {
            try
            {
                byte[] idbytes = SymmetricEncryption.EncryptStringToBytesAES(_id.ToString());
                _socket.Send(Encoding.UTF8.GetBytes($"{command}{idbytes.Length.ToString("00")}").Concat(idbytes).ToArray()); //ToDo: Fix the exception, i close the socket and then try to access it again.
                byte[] data = new byte[2];
                _socket.Receive(data, 2, SocketFlags.None);
                if (Encoding.UTF8.GetString(data) == "OK")
                {
                    data = new byte[4];
                    _socket.Receive(data, 4, SocketFlags.None);
                    int length = int.Parse(Encoding.UTF8.GetString(data));
                    data = new byte[length];
                    _socket.Receive(data, length, SocketFlags.None);
                     string[] msg = SymmetricEncryption.DecryptBytesToStringAES(data).Split('#');
                    foreach (string s in msg)
                    {
                        if (s.Length > 0)
                            list.Add(s);
                    }
                    _socket.Send(Encoding.UTF8.GetBytes("OK"));
                }
            }
            catch (SocketException)
            {
                this._socket.Close();
                MessageBox.Show("The Server is Having Some Technical Difficulties...\r\n Try Again Later <3");
                IsFinished = true;
                Finished();//todo: doesnt work because nobody is subscribed to the event
            }
        }
        private void EnterDataToListBoxes()
        {
            this.friendsListBox.DataSource = _friendsList;
            this.requestsListBox.DataSource = _pendingRequestList;
        }
        private void requestsListBox_SelectedIndexChanged(object sender, EventArgs e) //Todo: Change it, everytime we add to list box it enters, maybe use it to store the data of the users.
        {
            string userInfo = GetSelectedUser(requestsListBox.SelectedItem.ToString());
            if (userInfo != "#")
            {
                PresentUser(userInfo.Split('#'));
            }
            else
                this.requestsListBox.Items.Remove(requestsListBox.SelectedItem);
        }
        private string GetSelectedUser(string username)
        {
            try
            {
                byte[] idbytes = SymmetricEncryption.EncryptStringToBytesAES(_id.ToString());
                byte[] msg = Encoding.UTF8.GetBytes($"USR{idbytes.Length.ToString("00")}").Concat(idbytes).ToArray();
                byte[] usernameBytes = SymmetricEncryption.EncryptStringToBytesAES(username);
                msg = msg.Concat(Encoding.UTF8.GetBytes(usernameBytes.Length.ToString()).Concat(usernameBytes)).ToArray();
                _socket.Send(msg);
                byte[] data = new byte[2];
                _socket.Receive(data, 2, SocketFlags.None);
                if (Encoding.UTF8.GetString(data) == "OK")
                {
                    data = new byte[4];
                    _socket.Receive(data, 4, SocketFlags.None);
                    int length = int.Parse(Encoding.UTF8.GetString(data));
                    data = new byte[length];
                    _socket.Receive(data, length, SocketFlags.None);
                    _socket.Send(Encoding.UTF8.GetBytes("OK"));
                    return SymmetricEncryption.DecryptBytesToStringAES(data);
                }
            }
            catch (SocketException)
            {
                this._socket.Close();
                MessageBox.Show("The Server is Having Some Technical Difficulties...\r\n Try Again Later <3");
                IsFinished = true;
                Finished();
            }
            return "";
        }
        private void PresentUser(string[] userDetails)
        {
            if (!showUserInfoUserControl.Visible)
            {
                showUserInfoUserControl.Show();
            }
            showUserInfoUserControl.SetUsername(userDetails[0]);
            showUserInfoUserControl.SetAge(userDetails[1]);
            showUserInfoUserControl.SetSex(userDetails[2]);
            showUserInfoUserControl.SetBio(userDetails[3]);
            showUserInfoUserControl.SetPoints(userDetails[4]);
        }
        private void searchUserBtn_Click(object sender, EventArgs e)
        {
            if (this.addFriendUserControl.UserName.Length >= 4)
            {
                try
                {
                    byte[] idbytes = SymmetricEncryption.EncryptStringToBytesAES(_id.ToString());
                    byte[] msg = Encoding.UTF8.GetBytes($"REQ{idbytes.Length.ToString("00")}").Concat(idbytes).ToArray();
                    byte[] usernameBytes = SymmetricEncryption.EncryptStringToBytesAES(addFriendUserControl.UserName);
                    msg = msg.Concat(Encoding.UTF8.GetBytes(usernameBytes.Length.ToString()).Concat(usernameBytes)).ToArray();
                    _socket.Send(msg);
                    byte[] data = new byte[2];
                    _socket.Receive(data, 2, SocketFlags.None);
                    if (Encoding.UTF8.GetString(data) == "OK")
                    {
                        MessageBox.Show("The Request Has Been Sent Successfully");
                    }
                    else
                    {
                        byte[] temp = new byte[1];
                        _socket.Receive(temp, 1, SocketFlags.None);
                        data = data.Concat(temp).ToArray();
                        if (Encoding.UTF8.GetString(data) == "BYE")
                        {
                            IsFinished = true;
                            Finished();
                        }
                        else
                        {
                            int errNum = int.Parse(Encoding.UTF8.GetString(data)[2].ToString());
                            OpenningScreen.ServerErrorsHandler((ServerErrors)errNum);
                        }
                    }
                    _socket.Send(Encoding.UTF8.GetBytes("OK"));
                }
                catch
                {
                    this._socket.Close();
                    MessageBox.Show("The Server is Having Some Technical Difficulties...\r\n Try Again Later <3");
                    IsFinished = true;
                    Finished();
                }
            }
            else
            {
                MessageBox.Show("The Username Is Too Short!");
            }
        }
            
    }
}
