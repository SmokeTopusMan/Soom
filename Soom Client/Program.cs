using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OpeningScreen form1 = new OpeningScreen();
            Application.Run(form1);
            if (form1.HasUserInfo())
                Application.Run(new MainScreen());
        }
    }
}
