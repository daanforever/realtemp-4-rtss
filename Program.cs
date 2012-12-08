using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTemp4RTSS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RealTemp4RTSS mainForm = new RealTemp4RTSS();

            if (Properties.Settings.Default.StartMinimised)
            {
                mainForm.StartMinimised();
            }
            else
                mainForm.Show();

            Application.Run();
        }
    }
}
