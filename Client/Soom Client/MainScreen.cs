using Soom_Client.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace Soom_Client
{
    public partial class MainScreen : Form
    {
        public Socket Socket { get; set; }
        public int ID { get; set; }
        
        public MainScreen(Socket socket, int id)
        {
            Socket = socket;
            ID = id;
            InitializeComponent();
        }

        #region ButtonsHoverSettings
        private void createMeetingButton_MouseEnter(object sender, EventArgs e)
        {
            createMeetingButton.ForeColor = Color.FromArgb(227,220,50);
            createMeetingButton.Font = new Font(createMeetingButton.Font.Name, createMeetingButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void createMeetingButton_MouseLeave(object sender, EventArgs e)
        {
            createMeetingButton.ForeColor = Color.FromArgb(110, 0, 17);
            createMeetingButton.Font = new Font(createMeetingButton.Font.Name, createMeetingButton.Font.SizeInPoints, FontStyle.Regular);
        }
        private void joinMeetingButton_MouseEnter(object sender, EventArgs e)
        {
            joinMeetingButton.ForeColor = Color.FromArgb(227, 220, 50);
            joinMeetingButton.Font = new Font(joinMeetingButton.Font.Name, joinMeetingButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void joinMeetingButton_MouseLeave(object sender, EventArgs e)
        {
            joinMeetingButton.ForeColor = Color.FromArgb(110, 0, 17);
            joinMeetingButton.Font = new Font(joinMeetingButton.Font.Name, joinMeetingButton.Font.SizeInPoints, FontStyle.Regular);
        }
        private void addFriendButton_MouseEnter(object sender, EventArgs e)
        {
            addFriendButton.ForeColor = Color.FromArgb(227, 220, 50);
            addFriendButton.Font = new Font(addFriendButton.Font.Name, addFriendButton.Font.SizeInPoints, FontStyle.Underline);
        }
        private void addFriendButton_MouseLeave(object sender, EventArgs e)
        {
            addFriendButton.ForeColor = Color.FromArgb(110, 0, 17);
            addFriendButton.Font = new Font(addFriendButton.Font.Name, addFriendButton.Font.SizeInPoints, FontStyle.Regular);
        }
        private void settingsWheelButton_MouseEnter(object sender, EventArgs e)
        {
            settingsWheelButton.Image = Resources.HoverredSettingsGear;
        }
        private void settingsWheelButton_MouseLeave(object sender, EventArgs e)
        {
            settingsWheelButton.Image = Resources.SettingsGear;
        }

        #endregion

        #region ButtonsClick
        private void settingsWheelButton_Click(object sender, EventArgs e)
        {
            HideAllComponents();
            SettingsScreen settingsScreen = new SettingsScreen(Socket, ID);
            settingsScreen.Location = new Point(0, 0);
            settingsScreen.Name = "settingsScreen";
            settingsScreen.Size = new Size(this.Size.Width-16, this.Size.Height-39);
            this.Controls.Add(settingsScreen);
            settingsScreen.Event += ReturnToMainScreen_Event;

        }

        private void ReturnToMainScreen_Event(object sender, ExitEventArgs e)
        {
            ShowAllComponents();
            if(e.Name == "settingsScreen")
            {
                SettingsScreen screen = e.Screen as SettingsScreen;
                this.Controls.Remove(screen);
                screen.Dispose();
            }
            else if(e.Name == "friendsScreen")
            {
                FriendsScreen screen = e.Screen as FriendsScreen;
                this.Controls.Remove(screen);
                screen.Dispose();
            }
            if (e.Screen.IsFinished == true)
                this.Close();

        }

        private void createMeetingButton_Click(object sender, EventArgs e)
        {
            HideAllComponents(settingsWheelButton);
        }
        private void joinMeetingButton_Click(object sender, EventArgs e)
        {
            HideAllComponents(settingsWheelButton);
        }
        private void addFriendButton_Click(object sender, EventArgs e)
        {
            HideAllComponents(settingsWheelButton);
        }
        #endregion

        private void HideAllComponents(Component button = null)
        {
            title.Hide();
            if (button == null)
            {
                settingsWheelButton.Hide();
                createMeetingButton.Hide();
                joinMeetingButton.Hide();
                addFriendButton.Hide();
            }
            else
            {
                if (button != settingsWheelButton) settingsWheelButton.Hide();
                if (button != createMeetingButton) createMeetingButton.Hide();
                if (button != joinMeetingButton) joinMeetingButton.Hide();
                if (button != addFriendButton) addFriendButton.Hide();
            }
        }
        private void ShowAllComponents()
        {
            title.Show();
            settingsWheelButton.Show();
            createMeetingButton.Show();
            joinMeetingButton.Show();
            addFriendButton.Show();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                var settingsScreen = (SettingsScreen)this.Controls.Find("settingsScreen", false)[0];
            }
            catch (IndexOutOfRangeException)
            {
                ;// Do Nothing Since the Screen Isn't Exist Anymore.
            }
        }
    }
    public class ExitEventArgs : EventArgs
    {
        public IMainScreenComponents Screen { get; private set; }
        public string Name { get;private set; }

        public ExitEventArgs(IMainScreenComponents screen, string name)
        {
            Screen = screen;
            Name = name;
        }
    }
    public delegate void FinishedEvent(object sender, ExitEventArgs e);
}
