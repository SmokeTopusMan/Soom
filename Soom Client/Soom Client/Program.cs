using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Soom_Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("10.0.0.15"), 13000);
            try
            {
                sock.Connect(iPEndPoint);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                OpenningScreen openningScreen = new OpenningScreen(sock);
                Application.Run(openningScreen);
                if (openningScreen.HasUserInfo())
                    Application.Run(new MainScreen(sock));
            }
            catch (SocketException)
            {
                MessageBox.Show("Oh No... Something went wrong, Try again later!");
            }
        }
    }
}
