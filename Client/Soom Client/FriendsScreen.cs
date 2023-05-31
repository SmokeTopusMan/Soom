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
        #region Properties
        private Socket _socket;
        private int _id;
        public event FinishedEvent Event;
        private List<string> _friendsList = new List<string>();
        private List<string> _pendingRequestList = new List<string>();
        public bool IsFinished { get; private set; }
        #endregion

        #region CTor
        public FriendsScreen(Socket socket, int id)
        {
            InitializeComponent();
            this.addFriendUserControl.Hide();
            this.showUserInfoUserControl.Hide();
            this.searchUserBtn.Hide();
            this.title.Hide();
            this.friendsListBox.Hide();
            this.requestsListBox.Hide();
            this.boxesLabel.Hide();
            this.refreshBtn.Hide();
            this.acceptBtn.Hide();
            this.acceptBtn.Enabled = false;
            this.declineBtn.Hide();
            this.declineBtn.Enabled = false;
            _socket = socket;
            IsFinished = false;
            _id = id;
            EnterDataToListBoxes();
        }
        #endregion

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
        private void refreshBtn_MouseEnter(object sender, EventArgs e)
        {
            refreshBtn.Image = Resources.Hoverred_refresh_Button;
            this.Cursor = Cursors.Hand;
        }
        private void refreshBtn_MouseLeave(object sender, EventArgs e)
        {
            refreshBtn.Image = Resources.refresh_Button;
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

        #region Buttons Click
        private void friendsListButton_Click(object sender, EventArgs e)
        {
            if (friendsListBox.Visible)
            {
                this.boxesLabel.Hide();
                this.title.Hide();
                this.friendsListBox.Hide();
                this.refreshBtn.Hide();
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
                this.refreshBtn.Show();
            }
        }
        private void pendingRequestsButton_Click(object sender, EventArgs e)
        {
            if (requestsListBox.Visible)
            {
                this.acceptBtn.Hide();
                this.acceptBtn.Enabled = false;
                this.declineBtn.Hide();
                this.declineBtn.Enabled = false;
                this.boxesLabel.Hide();
                this.title.Hide();
                this.requestsListBox.Hide();
                this.refreshBtn.Hide();
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
                this.refreshBtn.Show();
            }
        }
        private void addFriendButton_Click(object sender, EventArgs e)
        {
            if (addFriendUserControl.Visible)
            {
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
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            string username = requestsListBox.SelectedItem.ToString();
            string answer = GetDataFromServer("ANS", username + "#YE");
            this.showUserInfoUserControl.ClearLabels();
            this.showUserInfoUserControl.Hide();
            if (answer == "OK")
            {
                AddToListBox(friendsListBox, username);
                RemoveFromListBox(requestsListBox, username);
            }
            else
            {
                byte[] temp = new byte[1];
                _socket.Receive(temp);
                answer += Encoding.UTF8.GetString(temp);
                if (answer == "BYE")
                {
                    IsFinished = true;
                    Finished();
                }
                else
                {
                    RemoveFromListBox(requestsListBox, username);
                }
            }
            if (requestsListBox.Items.Count == 0)
            {
                this.boxesLabel.Text = "There Are No Fresh Requests!";
                acceptBtn.Enabled = false;
                declineBtn.Enabled = false;
            }
        }
        private void declineBtn_Click(object sender, EventArgs e)
        {
            string username = requestsListBox.SelectedItem.ToString();
            string answer = GetDataFromServer("ANS", username + "#NO");
            this.showUserInfoUserControl.ClearLabels();
            this.showUserInfoUserControl.Hide();
            if (answer == "OK")
            {
                RemoveFromListBox(requestsListBox, username);
            }
            else
            {
                byte[] temp = new byte[1];
                _socket.Receive(temp);
                answer += Encoding.UTF8.GetString(temp);
                if (answer == "BYE")
                {
                    IsFinished = true;
                    Finished();
                }
                else
                {
                    RemoveFromListBox(requestsListBox, username);
                }
            }
            if (requestsListBox.Items.Count == 0)
            {
                this.boxesLabel.Text = "There Are No Fresh Requests!";
                acceptBtn.Enabled = false;
                declineBtn.Enabled = false;
            }
        }
        private void searchUserBtn_Click(object sender, EventArgs e)
        {
            if (this.addFriendUserControl.UserName.Length >= 4)
            {
                try
                {
                    string answer = GetDataFromServer("REQ", addFriendUserControl.UserName);
                    if (answer == "OK")
                    {
                        MessageBox.Show("The Request Has Been Sent Successfully");
                    }
                    else
                    {
                        byte[] temp = new byte[1];
                        _socket.Receive(temp, 1, SocketFlags.None);
                        answer += Encoding.UTF8.GetString(temp);
                        if (answer == "BYE")
                        {
                            IsFinished = true;
                            Finished();
                        }
                        else
                        {
                            int errNum = int.Parse(answer[2].ToString());
                            OpenningScreen.ServerErrorsHandler((ServerErrors)errNum);
                        }
                        _socket.Send(Encoding.UTF8.GetBytes("OK"));
                        addFriendUserControl.ClearUsername();
                    }
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
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            _pendingRequestList.Clear();
            _friendsList.Clear();
            EnterDataToListBoxes();
        }
        private void requestsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (requestsListBox.Visible && requestsListBox.DataSource != null)
            {
                if (requestsListBox.SelectedItem.ToString() == this.showUserInfoUserControl.GetUsername())
                {
                    this.acceptBtn.Enabled = false;
                    this.declineBtn.Enabled = false;
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }
                else
                {
                    string userInfo = GetDataFromServer("USR", requestsListBox.SelectedItem.ToString());
                    if (userInfo != "#")
                    {
                        PresentUser(userInfo.Split('#'));
                        this.acceptBtn.Enabled = true;
                        this.declineBtn.Enabled = true;
                    }
                    else
                        this.requestsListBox.Items.Remove(requestsListBox.SelectedItem);
                }
            }
        }
        private void friendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (friendsListBox.Visible && friendsListBox.DataSource != null)
            {
                if (friendsListBox.SelectedItem.ToString() != this.showUserInfoUserControl.GetUsername())
                {
                    string userInfo = GetDataFromServer("USR", friendsListBox.SelectedItem.ToString());
                    if (userInfo != "#")
                    {
                        PresentUser(userInfo.Split('#'));
                    }
                    else
                        this.requestsListBox.Items.Remove(requestsListBox.SelectedItem);
                }
                else
                {
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }

            }
        }
        #endregion

        #region Private Functions
        private string GetDataFromServer(string command, string data = null)
        {
            try
            {
                byte[] msg;
                if (command != "USR")
                {
                    byte[] idbytes = SymmetricEncryption.EncryptStringToBytesAES(_id.ToString());
                    msg = Encoding.UTF8.GetBytes($"{command}{idbytes.Length.ToString("00")}").Concat(idbytes).ToArray();
                }
                else
                    msg = Encoding.UTF8.GetBytes(command);
                if (data != null)
                {
                    byte[] usernameBytes = SymmetricEncryption.EncryptStringToBytesAES(data);
                    msg = msg.Concat(Encoding.UTF8.GetBytes(usernameBytes.Length.ToString()).Concat(usernameBytes)).ToArray();
                }
                _socket.Send(msg);
                byte[] byteData = new byte[2];
                _socket.Receive(byteData, 2, SocketFlags.None);
                if (Encoding.UTF8.GetString(byteData) == "OK")
                {
                    string answer;
                    if (command != "REQ" && command != "ANS")
                    {
                        byteData = new byte[4];
                        _socket.Receive(byteData, 4, SocketFlags.None);
                        int length = int.Parse(Encoding.UTF8.GetString(byteData));
                        byteData = new byte[length];
                        _socket.Receive(byteData, length, SocketFlags.None);
                        answer = SymmetricEncryption.DecryptBytesToStringAES(byteData);
                    }
                    else
                        answer = Encoding.UTF8.GetString(byteData);
                    _socket.Send(Encoding.UTF8.GetBytes("OK"));
                    return answer;
                }
                return Encoding.UTF8.GetString(byteData);
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
                this.refreshBtn.Hide();
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
                this.refreshBtn.Hide();
                if (this.showUserInfoUserControl.Visible)
                {
                    this.showUserInfoUserControl.Hide();
                    this.showUserInfoUserControl.ClearLabels();
                }
            }
        }
        private void EnterDataToListBoxes()
        {
            this.friendsListBox.DataSource = null;
            this.requestsListBox.DataSource = null;
            string[] friends = GetDataFromServer("FRD").Split('#');
            foreach (string s in friends)
            {
                if (s.Length > 0)
                    _friendsList.Add(s);
            }
            string[] pending = GetDataFromServer("PND").Split('#');
            foreach (string s in pending)
            {
                if (s.Length > 0)
                    _pendingRequestList.Add(s);
            }

            this.friendsListBox.DataSource = _friendsList;
            this.requestsListBox.DataSource = _pendingRequestList;
        }
        private void RemoveFromListBox(ListBox listbox, string name)
        {
            List<string> dataSource = (List<string>)listbox.DataSource;
            dataSource.Remove(name);
            if (listbox.Visible)
            {
                listbox.Hide();
                listbox.DataSource = null;
                listbox.DataSource = dataSource;
                listbox.Show();
            }
            else
            {
                listbox.DataSource = null;
                listbox.DataSource = dataSource;
            }
        }
        private void AddToListBox(ListBox listbox, string name)
        {
            List<string> dataSource = (List<string>)listbox.DataSource;
            dataSource.Add(name);
            if (listbox.Visible)
            {
                listbox.Hide();
                listbox.DataSource = null;
                listbox.DataSource = dataSource;
                listbox.Show();
            }
            else
            {
                listbox.DataSource = null;
                listbox.DataSource = dataSource;
            }
        }
        #endregion
    }
}
