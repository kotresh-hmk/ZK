using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ZKTQavi
{
    static class Program
    {
        internal static Mutex mutex = new Mutex(true, "{D66B2C22-138A-414B-871C-6DFDE14C3B04}");
        internal static string programPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Replace("file:\\", "");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Settings.LoadSettings();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.Run(new MainForm());
            }
            else
            {
                if (MessageBox.Show("Only one instance should run at a time!\r\nClose running instance?", "ZKT Attendance Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        ProcessStartInfo info = new ProcessStartInfo("Taskkill", "/IM ZKTQavi.exe /F");
                        info.CreateNoWindow = true;
                        info.UseShellExecute = false;
                        Process.Start(info);

                        Environment.Exit(0);
                        Application.Exit();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
