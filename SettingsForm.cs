using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Win32;

namespace ZKTQavi
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }
        //*****************************************************************//
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            DevicesBox.Text = Settings.CurrentSettings.Devices;
            DBServerBox.Text = Settings.CurrentSettings.DBServer;
            DBUsernameBox.Text = Settings.CurrentSettings.DBUsername;
            DBPasswordBox.Text = Settings.CurrentSettings.DBPassword;
            DBNameBox.Text = Settings.CurrentSettings.DBName;

            AutoStartCheck.Checked = Settings.CurrentSettings.AutoStart;
        }
        //*****************************************************************//
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //*****************************************************************//
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Settings.CurrentSettings.Devices = DevicesBox.Text;
            Settings.CurrentSettings.DBServer = DBServerBox.Text;
            Settings.CurrentSettings.DBUsername = DBUsernameBox.Text;
            Settings.CurrentSettings.DBPassword = DBPasswordBox.Text;
            Settings.CurrentSettings.DBName = DBNameBox.Text;
            Settings.CurrentSettings.AutoStart = AutoStartCheck.Checked;

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            try
            {
                if (AutoStartCheck.Checked)
                {
                    string currentPath = Application.ExecutablePath.ToString();
                    rk.SetValue("ZKTQavi", currentPath);
                }
                else
                {
                    rk.DeleteValue("ZKTQavi");
                }
            }
            catch (Exception)
            {
            }
            Settings.SaveSettings();
            this.Close();
        }
        //*****************************************************************//
        private void TestButton_Click(object sender, EventArgs e)
        {
            string connString = @"Server={0};Database={1};Uid={2};Pwd={3};SslMode=none;Port=3300";
            connString = String.Format(connString,
                                    DBServerBox.Text,
                                    DBNameBox.Text,
                                    DBUsernameBox.Text,
                                    DBPasswordBox.Text);

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Successful");
                        //SaveButton_Click(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //****************************************************************//
        internal static void RegisterSDK()
        {
            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                //startInfo.Arguments = "/C regsvr32 \"" + Program.programPath + "\\SDK\\zkemkeeper.dll\"";
                startInfo.Arguments = "/C \"" + Program.programPath + "\\Register_SDK_x86.bat\"";

                process.StartInfo = startInfo;
                process.Start();

            }
            catch (Exception)
            {
            }
        }
        //*****************************************************************//
        private void SampleDeviceButton_Click(object sender, EventArgs e)
        {
            DevicesBox.Text = "192.168.3.33,4370,0,Test Device" + Environment.NewLine + DevicesBox.Text;
        }
        //*****************************************************************//
    }

    public class DeviceParams
    {
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int DeviceID { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }

        public DeviceParams(string paramsRow)
        {
            string[] param = paramsRow.Split(new [] { "," }, StringSplitOptions.RemoveEmptyEntries);

            IPAddress = param[0].Replace(" ", "");
            Port = Convert.ToInt32(param[1].Replace(" ", ""));
            Password = Convert.ToInt32(param[2].Replace(" ", ""));
            Name = param[3];
        }
    }
}
