using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soom_Client
{
    public partial class Form1 : Form
    {
        Queue<string> info= new Queue<string>();
        public Form1()
        {
            InitializeComponent();
            registerClick.Hide();
            loginClick.Hide();
            //getInfo();
        }

        private void register_Click(object sender, EventArgs e)
        {
            registerClick.Show();
            loginClick.Hide();
        }

        private void login_Click(object sender, EventArgs e)
        {
            loginClick.Show();
            registerClick.Hide();
        }
/*
        private void getInfo()
        {
            Thread log = new Thread(new ThreadStart(() => loginClick.IsInfo(this.info)));
            Thread reg = new Thread(new ThreadStart(() => registerClick.IsInfo(this.info)));
            reg.Start();
            log.Start();
            while (log.IsAlive || reg.IsAlive) 
            {
                if (!log.IsAlive)
                    reg.Abort();
                else if(!reg.IsAlive)
                    log.Abort();
            }
            MessageBox.Show("Yay Works!");
        }
*/
    }
}
