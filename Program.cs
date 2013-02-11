using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealTemp4RTSS
{
    static class Program
    {
        static readonly Version MINIMUM_SUPPORTED_OS_VERSION = new Version(6, 0);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Functionality-wise the only thing that requires Vista or later is the task scheduling stuff
            // but XP is ancient now and continuing to release software for it only perpetuates the problem...
            // ... this is just my personal preference and if you don't agree, feel free to remove the check.
            if (Environment.OSVersion.Version.CompareTo(MINIMUM_SUPPORTED_OS_VERSION) < 0)
            {
                MessageBox.Show("You must have Windows Vista or higher to run RealTemp4RTSS.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            string[] args = Environment.GetCommandLineArgs();
            if (args != null && args.Length > 1 && string.Equals(args[1], "task", StringComparison.InvariantCultureIgnoreCase))
            {
                if (System.Diagnostics.Process.GetProcessesByName(Application.ExecutablePath).Length >= 2)
                {
                    // There should never be more than two of us running...
                    Environment.Exit(-1);
                    return;
                }
                bool startAtLogon = (args.Length > 2 && string.Equals(args[2], "save", StringComparison.InvariantCultureIgnoreCase));
                bool startForAllUsers = (args.Length > 3 && string.Equals(args[3], "all", StringComparison.InvariantCultureIgnoreCase));

                if (TaskPersistance.PersistTask(startAtLogon, startForAllUsers))
                    Environment.Exit(0);
                else
                    Environment.Exit(1);
            }
            else
            {
                Version installedVersion;
                if (string.IsNullOrEmpty(Properties.Settings.Default.CurrentVersion) || !Version.TryParse(Properties.Settings.Default.CurrentVersion, out installedVersion) ||
                    installedVersion.CompareTo(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version) < 0)
                {
                    // New version; try to carry over any settings from the previous version (if installed).
                    Properties.Settings.Default.Upgrade();
                    // Remember the current version so we don't overwrite the users settings again
                    Properties.Settings.Default.CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    Properties.Settings.Default.Save();
                }
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

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            // Handle embedded assemblies... see the docs for LoadEmbededAssembly for details.
            switch (new AssemblyName(e.Name).Name)
            {
                case "Microsoft.Win32.TaskScheduler":
                    return Assembly.GetExecutingAssembly().LoadEmbeddedAssembly(e.Name);
                default:
                    return null;
            }
        }
    }
}
