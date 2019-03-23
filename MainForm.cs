using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using System.Media;

using MySql.Data.MySqlClient;


using zkemkeeper;

namespace ZKTQavi
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;

        public static MainForm window;
        //static CZKEM FPReader = new CZKEM();
        bool isRunning = false;
        //bool isConnected = false;

        Thread MainDataThread;
        public static Dictionary<string, DeviceParams> DevicesInfo = new Dictionary<string, DeviceParams>();
        public static Dictionary<string, CZKEM> FPReaders = new Dictionary<string, CZKEM>();
        public static Dictionary<string, bool> isConnected = new Dictionary<string, bool>();

        string mySQLConnString = @"Server={0};Database={1};Uid={2};Pwd={3};";

        public static object deviceLock = new object();

        public MainForm()
        {
            InitializeComponent();
        }
        //**************************************************************************//
        private void MainForm_Load(object sender, EventArgs e)
        {
            window = this;

            //LoadTrayOptions();


            Task.Factory.StartNew(() =>
                {

                    Thread.Sleep(3000);
                    UpdateLogBox("Starting...");
                    LoadDevices();
                    Start();
                });
        }
        //**************************************************************************//
        #region Tray Icon stuff
        private void LoadTrayOptions()
        {
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Show", OnShow);
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "ZKT";
            //trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Icon = new Icon(this.Icon, 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if (WindowState == FormWindowState.Minimized)
            //{
            //    Visible = false; // Hide form window.
            //    ShowInTaskbar = false; // Remove from taskbar.
            //    trayIcon.Visible = true;
            //}
        }

        private void OnShow(object sender, EventArgs e)
        {
            Visible = true; // Hide form window.
            ShowInTaskbar = true; // Remove from taskbar.
            trayIcon.Visible = false;
            WindowState = FormWindowState.Normal;
            BringToFront();
        }

        private void OnExit(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this application?", "WARNING: Closing Sync Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                trayIcon.Visible = false;
                Application.Exit();
            }
        }
        #endregion
        //**************************************************************************//
        private void LoadDevices()
        {
            string[] deviceLines = Settings.CurrentSettings.Devices.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            UpdateLogBox(String.Format("{0} devices found from config", deviceLines.Length));
            foreach (string device in deviceLines)
            {
                try
                {
                    DeviceParams deviceParam = new DeviceParams(device);
                    DevicesInfo.Add(deviceParam.IPAddress, deviceParam);
                    FPReaders.Add(deviceParam.IPAddress, new CZKEM());
                    isConnected.Add(deviceParam.IPAddress, false);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Retrieving the COM class factory for component with CLSID"))
                    {
                        SettingsForm.RegisterSDK();
                        MessageBox.Show("Done Installing SDK\r\nPlease restart application");
                        this.FormClosing -= MainForm_FormClosing;
                        //exitMenuItem_Click(null, null);
                    }

                    UpdateLogBox(String.Format("while loading devices info: {0}", ex.Message));
                }
            }
        }
        //**************************************************************************//
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormClosing -= MainForm_FormClosing;
            DialogResult result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                isRunning = false;
                Environment.Exit(0);
                System.Diagnostics.Process.Start("Taskkill", "/IM ZKTQavi.exe /F");
                Application.Exit();
            }
            this.FormClosing += MainForm_FormClosing;
        }
        //**************************************************************************//
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.FormClosing -= MainForm_FormClosing;
            DialogResult result = MessageBox.Show("Are you sure?", "Exit", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                isRunning = false;
                Environment.Exit(0);
                System.Diagnostics.Process.Start("Taskkill", "/IM ZKTMySql.exe /F");
                Application.Exit();
            }
            else
                e.Cancel = true;
            this.FormClosing += MainForm_FormClosing;
        }
        //**************************************************************************//
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //**************************************************************************//
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }
        //**************************************************************************//
        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }
        //**************************************************************************//
        private void ClearButton_Click(object sender, EventArgs e)
        {
            LogBox.Text = "";
        }
        //**************************************************************************//
        public void UpdateLogBox(string Message, bool OverWrite = false)
        {
            try
            {
                if (OverWrite)
                    this.Invoke(new Action(() => { this.LogBox.Text = "> " + Message + Environment.NewLine; }));
                else
                    this.Invoke(new Action(() => { this.LogBox.Text += "> " + Message + Environment.NewLine; }));


                Message = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss") + "> " + Message;
                string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\logs";
                string FileName = DateTime.Now.ToString("MM-dd-yyyy");

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                filePath = filePath + "\\Log " + FileName + ".txt";

                if (File.Exists(filePath))
                {
                    File.AppendAllText(filePath, Message + Environment.NewLine + Environment.NewLine);
                }
                else
                    File.WriteAllText(filePath, Message + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception)
            {
            }
        }
        //**************************************************************************//
        public void Start()
        {
            if (isRunning)
            {
                isRunning = false;

                foreach (string deviceIP in FPReaders.Keys)
                {
                    FPReaders[deviceIP].Disconnect();
                }

                UpdateLogBox("Disconnected");
            }
            else
            {

                bool anyConnected = false;
                foreach (string deviceIP in FPReaders.Keys)
                {
                    //UpdateLogBox(String.Format("Trying to connect device at IP {0} .....", deviceIP));
                    FPReaders[deviceIP].SetCommPassword(DevicesInfo[deviceIP].Password);
                    isConnected[deviceIP] = FPReaders[deviceIP].Connect_Net(deviceIP, DevicesInfo[deviceIP].Port);

                    if (isConnected[deviceIP])
                    {
                        anyConnected = true;
                        string ReaderMAC = "";
                        FPReaders[deviceIP].GetDeviceMAC(DevicesInfo[deviceIP].DeviceID, ref ReaderMAC);
                        FPReaders[deviceIP].SetDeviceTime(DevicesInfo[deviceIP].DeviceID);
                        UpdateLogBox(String.Format("Connected device at IP {0}, MAC is {1}", deviceIP, ReaderMAC));


                        //FPReaders[deviceIP].OnVerify += FPReader_OnVerify;
                    }
                }

                if (anyConnected)
                {
                    isRunning = true;

                    MainDataThread = new Thread(MainDataThreadFunction);
                    MainDataThread.Start();
                }
            }
        }
        //**************************************************************************//
        void FPReader_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            UpdateLogBox(String.Format("User {0} verified", EnrollNumber));
        }
        //**************************************************************************//
        void FPReader_OnVerify(int UserID)
        {
            //this one works on X628
            UpdateLogBox(String.Format("User checked-in {0}", UserID));
        }
        //**************************************************************************//
        private void MainDataThreadFunction()
        {
            int sleepSeconds = 1;
            while (isRunning)
            {
                foreach (string deviceIP in FPReaders.Keys)
                {
                    if (isConnected[deviceIP])
                    {
                        try
                        {
                            string enrollNumber;
                            int verifyMode, inOutMode;
                            int year, month, day, hour, minute, second;
                            int workCode = 0;
                            if (FPReaders[deviceIP].ReadAllGLogData(DevicesInfo[deviceIP].DeviceID))
                            {
                                List<Record> records = new List<Record>();
                                while (FPReaders[deviceIP].SSR_GetGeneralLogData(DevicesInfo[deviceIP].DeviceID, out enrollNumber, out verifyMode, out inOutMode,
                                    out year, out month, out day, out hour, out minute, out second, ref workCode))
                                {
                                    //found a record
                                    //details are in variables above
                                    Record record = new Record();
                                    record.timeStamp = new DateTime(year, month, day, hour, minute, second);
                                    record.enrollNumber = enrollNumber;
                                    record.IPAddress = deviceIP;
                                    records.Add(record);
                                }

                                SaveRecordToDB(records);
                                UpdateLogBox(String.Format("Found {0} records on device {1} . Saved!", records.Count, deviceIP));

                                //if (Properties.Settings.Default.DeleteOnSave)
                                FPReaders[deviceIP].ClearGLog(DevicesInfo[deviceIP].DeviceID);
                                        //UpdateLogBox(String.Format("Records cleared from device {0}", deviceIP));
                            }
                        }
                        catch (Exception ex)
                        {
                            UpdateLogBox(ex.Message);
                        }
                    }
                }
                Thread.Sleep(sleepSeconds * 1000);
            }
        }
        //**************************************************************************//
        private void SaveRecordToDB(List<Record> records)
        {
            //string data = enrollNumber + "," + timeStamp.ToString("yyyy:MM:dd hh:mm:ss") + "," + verifyMode + "," + inOutMode + "," + workCode;
            //File.AppendAllText("Records " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", data + Environment.NewLine);
            string conString = String.Format(mySQLConnString, Settings.CurrentSettings.DBServer,
                                                                Settings.CurrentSettings.DBName,
                                                                Settings.CurrentSettings.DBUsername,
                                                                Settings.CurrentSettings.DBPassword);
            using (MySqlConnection DBConnection = new MySqlConnection(conString))
            {
                DBConnection.Open();

                foreach (Record record in records)
                {
                    //remove in final
                    //if (record.timeStamp.DayOfYear >= 90)
                    //isRunning = false;
                    //
#if DEBUG

                    UpdateLogBox(String.Format("userID: {0}, TimeStamp: ", record.enrollNumber, record.timeStamp));
#endif

                    #region create new entry as checkin
                    {
                        //create an entry in tbl_attendance
                        string checkinQuery = "INSERT INTO punch_time (`member_id`,`branch_id`,`date`,`punch_time`,`status`) VALUES ({0},1,'{1}','{2}','p')";
                        checkinQuery = String.Format(checkinQuery,
                                                        record.enrollNumber,
                                                        record.timeStamp.ToString("yyyy-MM-dd"),
                                                        record.timeStamp.ToString("HH:mm:ss"));
                        using (MySqlCommand checkoutCmd = new MySqlCommand(checkinQuery, DBConnection))
                        {
                            checkoutCmd.ExecuteNonQuery();
                        }

                        FPReaders[record.IPAddress].PlayVoiceByIndex(10);
                        //if (File.Exists("checkin.wav"))
                        //{
                        //    SoundPlayer simpleSound = new SoundPlayer("checkin.wav");
                        //    simpleSound.PlaySync();
                        //}
                    }
                    #endregion
                }

                DBConnection.Close();
            }
        }
        //**************************************************************************//
        private void EnrollButton_Click(object sender, EventArgs e)
        {
            if (FPReaders.Count > 0)
            {
                EnrollForm enroll = new EnrollForm();
                enroll.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please connect a device first!");
            }
        }
        //**************************************************************************//
    }
}
