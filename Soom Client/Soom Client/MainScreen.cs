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
    public partial class MainScreen : Form
    {
        private Socket _socket;
        public MainScreen(Socket socket)
        {
            _socket = socket;
            InitializeComponent();
        }
        //ToDo: start working on the MainScreen GUI.
    }
}
