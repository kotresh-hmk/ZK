using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Threading;

namespace ZKTQavi
{
    public partial class EnrollForm : Form
    {
        List<string> Devices = new List<string>();

        string language = "";

        int selectedBioType = 0;

        EnrollDialog currentDialog;

        public EnrollForm(string userID="", string name="")
        {
            try
            {
            }
            catch (Exception)
            {
            }

            InitializeComponent();
            UserIDBox.Text = userID;
            UsernameBox.Text = name;

            if (userID.Length <= 0)
                UserIDBox.Enabled = true;
        }
        //**************************************************************************//
        private void EnrollForm_Load(object sender, EventArgs e)
        {
            //this.WindowState = Program.windowState;
            foreach (string deviceIP in MainForm.isConnected.Keys)
            {
                if (MainForm.isConnected[deviceIP])
                    Devices.Add(MainForm.DevicesInfo[deviceIP].Name + " - " + deviceIP);
            }

            if (Devices.Count > 0)
            {
                DevicesListBox.DataSource = Devices;
                DevicesListBox.SelectedIndex = 0;

                UserIDBox.Enabled = true;
                //FingerIndexBox.Enabled = true;
            }

            FingerInfoButton_Click(null, null);
        }
        //**************************************************************************//
        private void EnrollFPButton_Click(object sender, EventArgs e)
        {
            

            //lock (MainForm.deviceLock)
            //{

            //    //-----original
            //    string message = "No device connected, please check your device.";

            //    if (language.ToLower().Contains("th"))
            //        message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            //    if (Devices.Count <= 0)
            //    {
            //        MessageBox.Show(message);
            //        return;
            //    }

            //    string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            //    lock (MainForm.deviceLock)
            //    {
            //        bool temp = MainForm.FPReaders[deviceIP].StartEnrollEx(UserIDBox.Text, (int)FingerIndexBox.Value, 1);
            //        //bool temp =  MainForm.FPReaders[deviceIP].StartEnroll(Convert.ToInt32(UserIDBox.Text), (int)FingerIndexBox.Value);

            //        if (temp)
            //        {
            //            MessageBox.Show("Please enroll fingerprint on device");
            //            MainForm.FPReaders[deviceIP].RegEvent(MainForm.DevicesInfo[deviceIP].DeviceID, (1 << 3));
            //            MainForm.FPReaders[deviceIP].OnEnrollFingerEx += EnrollForm_OnEnrollFingerEx;
            //            //MainForm.FPReaders[deviceIP].OnEnrollFinger += EnrollForm_OnEnrollFinger;
            //        }
            //        else
            //            MessageBox.Show("Duplicate Fingerprint! Please change finger index");
            //        MainForm.FPReaders[deviceIP].StartIdentify();
            //    }
            //}
        }
        //**************************************************************************//
        //
        //axCZKEM1.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
            //if (axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
        //
        //verify style: 135 FP/RF, 133 FP&RF
        //**************************************************************************//
        void EnrollForm_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            //string deviceIP = "";
            //this.Invoke(new Action(() =>
            //{
            //    deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            //}));
            //MainForm.FPReaders[deviceIP].OnEnrollFingerEx -= EnrollForm_OnEnrollFingerEx;

            //if (ActionResult == 0)
            //{
            //    MessageBox.Show("Enrolled successfully");

            //    int privilege = 0;
            //    if (AdminCheck.Checked)
            //        privilege = 3;

            //    bool temp = MainForm.FPReaders[deviceIP].SSR_SetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
            //                                                EnrollNumber,
            //                                                UsernameBox.Text,
            //                                                null,
            //                                                privilege,
            //                                                true);
            //}
            //else
            //    MessageBox.Show("Failed to enroll");
        }
        //**************************************************************************//
        private void EnrollFaceButton_Click(object sender, EventArgs e)
        {
            string message = "No device connected, please check your device.";

            if (language.ToLower().Contains("th"))
                message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            if (Devices.Count <= 0)
            {
                MessageBox.Show(message);
                return;
            }

            string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");

            lock (MainForm.deviceLock)
            {
                bool temp = MainForm.FPReaders[deviceIP].StartEnrollEx(UserIDBox.Text, 111, 1);

                if (temp)
                {
                    MessageBox.Show("Please enroll face on device");
                    MainForm.FPReaders[deviceIP].RegEvent(MainForm.DevicesInfo[deviceIP].DeviceID, (1 << 3));
                    MainForm.FPReaders[deviceIP].OnEnrollFingerEx += EnrollForm_OnEnrollFingerEx;
                }
                MainForm.FPReaders[deviceIP].StartIdentify();
            }
        }
        //**************************************************************************//
        private void BackButton_Click(object sender, EventArgs e)
        {
            //MainForm.UpdateStatusInDevice();
            this.Close();
        }
        //**************************************************************************//
        private void DeleteAllFPButton_Click(object sender, EventArgs e)
        {
            string message = "No device connected, please check your device.";

            if (language.ToLower().Contains("th"))
                message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            if (Devices.Count <= 0)
            {
                MessageBox.Show(message);
                return;
            }

            string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            DialogResult result = MessageBox.Show("This cannot be reversed. Are you sure?", "WARNING!", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                bool temp = MainForm.FPReaders[deviceIP].SSR_DeleteEnrollDataExt(MainForm.DevicesInfo[deviceIP].DeviceID, UserIDBox.Text, 12);//11);
            }
            //Console.WriteLine("");
        }
        //**************************************************************************//
        private void DeleteFaceButton_Click(object sender, EventArgs e)
        {
            string message = "No device connected, please check your device.";

            if (language.ToLower().Contains("th"))
                message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            if (Devices.Count <= 0)
            {
                MessageBox.Show(message);
                return;
            }

            string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");

            lock (MainForm.deviceLock)
            {
                MainForm.FPReaders[deviceIP].DelUserFace(MainForm.DevicesInfo[deviceIP].DeviceID, UserIDBox.Text, 50);
            }
        }
        //**************************************************************************//
        private void DisableUserButton_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("This cannot be reversed. Are you sure?", "WARNING!", MessageBoxButtons.YesNo);
            //if (result == System.Windows.Forms.DialogResult.Yes)
            lock (MainForm.deviceLock)
            {
                //bool temp = MainForm.FPReader.SSR_DeleteEnrollDataExt(Properties.Settings.Default.DeviceID, UserIDBox.Text, 12);
                
                //this disables access to settings on BGT devices
                //MainForm.FPReader.SSR_EnableUser(Properties.Settings.Default.DeviceID,
                //                                UserIDBox.Text,
                //                                false);

                //MainForm.FPReader.EnableUser(Properties.Settings.Default.DeviceID,
                //                                    Convert.ToInt32(UserIDBox.Text),
                //                                    0, 0,
                //                                    false);
            }
        }
        //**************************************************************************//
        private void EnableUserButton_Click(object sender, EventArgs e)
        {
            string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            lock (MainForm.deviceLock)
            {
                //this disables access to settings on BGT devices
                //MainForm.FPReader.SSR_EnableUser(Properties.Settings.Default.DeviceID,
                //                                    UserIDBox.Text,
                //                                    true);

                //MainForm.FPReader.EnableUser(Properties.Settings.Default.DeviceID,
                //                                    Convert.ToInt32(UserIDBox.Text),
                //                                    0, 0,
                //                                    true);

                MainForm.FPReaders[deviceIP].StartIdentify();
            }
        }
        //**************************************************************************//
        private void EnrollForm_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                                         this.ClientSize.Width / 2 - panel1.Size.Width / 2,
                                         this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
            //Program.windowState = this.WindowState;
        }
        //**************************************************************************//
        private void GetEnrollButton_Click(object sender, EventArgs e)
        {
            //string message = "No device connected, please check your device.";

            //if (language.ToLower().Contains("th"))
            //    message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            //if (Devices.Count <= 0)
            //{
            //    MessageBox.Show(message);
            //    return;
            //}

            //EnrolledFingersBox.Text = "";
            //faceLabel.Text = "Face: ";
            //string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            //bool temp = false;
            //int machinePriv = 0;
            //string fpTemplate = string.Empty;
            //int password = 0;

            //temp = MainForm.FPReaders[deviceIP].EnableDevice(MainForm.DevicesInfo[deviceIP].DeviceID, false);
            //temp = MainForm.FPReaders[deviceIP].ReadAllUserID(MainForm.DevicesInfo[deviceIP].DeviceID);
            //temp = MainForm.FPReaders[deviceIP].ReadAllTemplate(MainForm.DevicesInfo[deviceIP].DeviceID);
            //for (int i = 0; i <= 9; i++)
            //{
                

            //    temp = MainForm.FPReaders[deviceIP].GetUserTmpExStr(MainForm.DevicesInfo[deviceIP].DeviceID,
            //                                                        UserIDBox.Text,
            //                                                        i,
            //                                                        out machinePriv,
            //                                                        out fpTemplate,
            //                                                        out password);

            //    if (temp)
            //    {
            //        EnrolledFingersBox.Text += i.ToString() + ", ";
            //    }

            //    Console.WriteLine("");
            //}

            //temp = MainForm.FPReaders[deviceIP].GetUserTmpExStr(MainForm.DevicesInfo[deviceIP].DeviceID,
            //                                                        UserIDBox.Text,
            //                                                        111,
            //                                                        out machinePriv,
            //                                                        out fpTemplate,
            //                                                        out password);

            //if (temp)
            //    faceLabel.Text = "Face: Enrolled";
            //else
            //    faceLabel.Text = "Face: Not Enrolled";

            //temp = MainForm.FPReaders[deviceIP].EnableDevice(MainForm.DevicesInfo[deviceIP].DeviceID, true);
            //temp = MainForm.FPReaders[deviceIP].StartIdentify();
        }
        //**************************************************************************//
        private void AdminCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            }));

            int privilege = 3;

            bool temp = false;

            string name, password, cardNumber;
            bool enabled;
            SetUserName();
            temp = MainForm.FPReaders[deviceIP].SSR_GetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                    UserIDBox.Text, out name, out password, out privilege, out enabled);
            if (temp)
            {
                temp = MainForm.FPReaders[deviceIP].GetStrCardNumber(out cardNumber);

                if (AdminCheckBox.Checked)
                    privilege = 3;
                else
                    privilege = 0;
                if (cardNumber.Length > 0)
                    temp = MainForm.FPReaders[deviceIP].SetStrCardNumber(cardNumber);

                temp = MainForm.FPReaders[deviceIP].SSR_SetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                            UserIDBox.Text,
                                                            UsernameBox.Text,
                                                            "0",
                                                            privilege,
                                                            true);

            }
        }
        //**************************************************************************//
        private void IDInfoButton_Click(object sender, EventArgs e)
        {
            ValidateControls(BioType.Card);
        }
        //**************************************************************************//
        private void FingerInfoButton_Click(object sender, EventArgs e)
        {
            ValidateControls(BioType.Finger);
        }
        //**************************************************************************//
        private void FaceInfoButton_Click(object sender, EventArgs e)
        {
            ValidateControls(BioType.Face);
        }
        //**************************************************************************//
        private void ValidateControls(int bioType)
        {
            selectedBioType = bioType;

            if (bioType == BioType.Card)
            {
                groupBox1.Text = "Manage ID Card";

                IDInfoButton.BackColor = SystemColors.ControlDarkDark;
                FingerInfoButton.BackColor = SystemColors.ControlLight;
                FaceInfoButton.BackColor = SystemColors.ControlLight;

                IDInfoButton.ForeColor = SystemColors.ControlLightLight;
                FingerInfoButton.ForeColor = SystemColors.ActiveCaptionText;
                FaceInfoButton.ForeColor = SystemColors.ActiveCaptionText;

                IDInfoButton.Image = Properties.Resources.card_w;
                FingerInfoButton.Image = Properties.Resources.finger_b;
                FaceInfoButton.Image = Properties.Resources.face_b;

                LoadCardInfo();
            }
            else if (bioType == BioType.Finger)
            {
                groupBox1.Text = "Manage Fingerprints";

                IDInfoButton.BackColor = SystemColors.ControlLight;
                FingerInfoButton.BackColor = SystemColors.ControlDarkDark;
                FaceInfoButton.BackColor = SystemColors.ControlLight;

                IDInfoButton.ForeColor = SystemColors.ActiveCaptionText;
                FingerInfoButton.ForeColor = SystemColors.ControlLightLight;
                FaceInfoButton.ForeColor = SystemColors.ActiveCaptionText;

                IDInfoButton.Image = Properties.Resources.card_b;
                FingerInfoButton.Image = Properties.Resources.finger_w;
                FaceInfoButton.Image = Properties.Resources.face_b;

                LoadFingerInfo();
            }
            else if (bioType == BioType.Face)
            {
                groupBox1.Text = "Manage Face ID";

                IDInfoButton.BackColor = SystemColors.ControlLight;
                FingerInfoButton.BackColor = SystemColors.ControlLight;
                FaceInfoButton.BackColor = SystemColors.ControlDarkDark;

                IDInfoButton.ForeColor = SystemColors.ActiveCaptionText;
                FingerInfoButton.ForeColor = SystemColors.ActiveCaptionText;
                FaceInfoButton.ForeColor = SystemColors.ControlLightLight;

                IDInfoButton.Image = Properties.Resources.card_b;
                FingerInfoButton.Image = Properties.Resources.finger_b;
                FaceInfoButton.Image = Properties.Resources.face_w;

                LoadFaceInfo();
            }

            LoadUsername();
        }
        //**************************************************************************//
        private void LoadUsername()
        {
            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                try
                {
                    deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
                }
                catch (Exception)
                {
                }
            }));


            string name, password;
            int privilege;
            bool enabled;

            bool temp = false;

            temp = MainForm.FPReaders[deviceIP].SSR_GetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                    UserIDBox.Text, out name, out password, out privilege, out enabled);
            if (temp)
            {
                if (name.Length > 0)
                    UsernameBox.Text = name;
            }
        }
        //**************************************************************************//
        private void LoadCardInfo()
        {
            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                try
                {
                    deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
                }
                catch (Exception)
                {
                }
            }));

            listBox1.Items.Clear();

            string name, password, cardNumber;
            int privilege;
            bool enabled;

            bool temp = false;

            temp = MainForm.FPReaders[deviceIP].SSR_GetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                    UserIDBox.Text, out name, out password, out privilege, out enabled);
            if (temp)
            {
                MainForm.FPReaders[deviceIP].GetStrCardNumber(out cardNumber);

                if (cardNumber.Length > 0)
                    if (cardNumber != "0")
                        listBox1.Items.Add(cardNumber);
                if (name.Length > 0)
                    UsernameBox.Text = name;
            }
            listBox1.Refresh();
        }
        //**************************************************************************//
        private void LoadFingerInfo()
        {
            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                try
                {
                    deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
                }
                catch (Exception)
                {
                }
            }));

            listBox1.Items.Clear();
            if (language.ToLower().Contains("th"))
                listBox1.Items.Add("กำลังโหลด");
            else
                listBox1.Items.Add("Loading...");
            List<object> fingerPrints = new List<object>();
            //if (MainForm.FPReaders[deviceIP].ReadAllTemplate(MainForm.DevicesInfo[deviceIP].DeviceID))
            {

                bool temp = false;
                int machinePriv = 0;
                string fpTemplate = string.Empty;
                int password = 0;

                string userID = UserIDBox.Text;

                for (int i = 0; i <= 9; i++)
                {
                    temp = false;
                    machinePriv = 0;
                    fpTemplate = string.Empty;
                    password = 0;

                    temp = MainForm.FPReaders[deviceIP].GetUserTmpExStr(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                    userID,
                                                    i,
                                                    out machinePriv,
                                                    out fpTemplate,
                                                    out password);

                    if (temp)
                        if (fpTemplate.Length > 0)
                        {
                            fingerPrints.Add("Fingerprint " + i.ToString());
                        }
                }
            }
            listBox1.Items.Clear();
            if(fingerPrints.Count > 0)
                listBox1.Items.AddRange(fingerPrints.ToArray());
            listBox1.Refresh();
        }
        //**************************************************************************//
        private void LoadFaceInfo()
        {
            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                try
                {
                    deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
                }
                catch (Exception)
                {
                }
            }));

            listBox1.Items.Clear();

            bool temp = false;
            int machinePriv = 0;
            string fpTemplate = string.Empty;
            int password = 0;

            string userID = UserIDBox.Text;

            temp = MainForm.FPReaders[deviceIP].GetUserTmpExStr(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                                    UserIDBox.Text,
                                                                    111,
                                                                    out machinePriv,
                                                                    out fpTemplate,
                                                                    out password);

            if (temp)
            {
                if (fpTemplate.Length > 0)
                {
                    listBox1.Items.Add("Face data");
                }
            }

            listBox1.Refresh();
        }
        //**************************************************************************//
        private void AddBioButton_Click(object sender, EventArgs e)
        {
            #region card
            if (selectedBioType == BioType.Card)
            {
                EnrollCard();
            }
            #endregion

            else if (selectedBioType == BioType.Finger)
            {
                EnrollFinger();
                //EnrollDialog dialog = new EnrollDialog(BioType.Finger);
                //if (dialog.DialogResult == DialogResult.OK)
                //{
                    
                //}
            }
            else if (selectedBioType == BioType.Face)
            {
                EnrollFace();
                //EnrollDialog dialog = new EnrollDialog(BioType.Face);
                //if (dialog.DialogResult == DialogResult.OK)
                //{

                //}
            }
        }
        //**************************************************************************//
        private void EnrollCard()
        {
            EnrollDialog dialog = new EnrollDialog(BioType.Card);
            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                string deviceIP = "";
                this.Invoke(new Action(() =>
                {
                    deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
                }));

                lock (MainForm.deviceLock)
                {
                    int privilege = 0;

                    bool temp = false;

                    string name, password;
                    bool enabled;
                    SetUserName();
                    temp = MainForm.FPReaders[deviceIP].SSR_GetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                            UserIDBox.Text, out name, out password, out privilege, out enabled);
                    if (temp)
                    {
                        if (dialog.returnVal.Length > 0)
                        {
                            temp = MainForm.FPReaders[deviceIP].SetStrCardNumber(dialog.returnVal);
                            temp = MainForm.FPReaders[deviceIP].SSR_SetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                                        UserIDBox.Text,
                                                                        UsernameBox.Text,
                                                                        "0",
                                                                        privilege,
                                                                        true);

                            this.Invoke(new Action(() =>
                            {
                                LoadCardInfo();
                            }));
                        }
                    }
                }
            }
        }
        //**************************************************************************//
        private void EnrollFace()
        {
            string message = "No device connected, please check your device.";

            if (language.ToLower().Contains("th"))
                message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            if (Devices.Count <= 0)
            {
                MessageBox.Show(message);
                return;
            }

            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            }));

            lock (MainForm.deviceLock)
            {
                bool temp = MainForm.FPReaders[deviceIP].StartEnrollEx(UserIDBox.Text, 111, 1);

                if (temp)
                {
                    //MainForm.FPReaders[deviceIP].RegEvent(MainForm.DevicesInfo[deviceIP].DeviceID, (1 << 3));

                    currentDialog = new EnrollDialog(BioType.Face);
                    MainForm.FPReaders[deviceIP].OnEnrollFingerEx += OnEnrollFingerEx;
                    currentDialog.FormClosed += currentDialog_FormClosed;
                    //MainForm.FPReaders[deviceIP].OnEnrollFingerEx += (enroll, action, result, length) =>
                    //{
                    //    MainForm.FPReaders[deviceIP].OnEnrollFingerEx -= (e, a, r, l) =>
                    //    {
                    //        dialog.Close();
                    //        SetUserName();
                    //    };
                    //    dialog.Close();
                    //    SetUserName();
                    //};
                    currentDialog.Show();
                }
                MainForm.FPReaders[deviceIP].StartIdentify();
            }
        }
        //**************************************************************************//
        private void EnrollFinger()
        {
            string message = "No device connected, please check your device.";

            if (language.ToLower().Contains("th"))
                message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            if (Devices.Count <= 0)
            {
                MessageBox.Show(message);
                return;
            }

            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            }));

            lock (MainForm.deviceLock)
            {
                int indexToEnroll = -1;

                for (int i = 0; i <= 9; i++)
                {
                    bool useThisIndex = true;
                    foreach (string fp in listBox1.Items)
                    {
                        if (fp.Contains(i.ToString()))
                        {
                            useThisIndex = false;
                            break;
                        }
                    }

                    if (useThisIndex)
                    {
                        indexToEnroll = i;
                        break;
                    }
                }

                if (indexToEnroll < 0)
                {
                    message = "All fingers enrolled!";

                    MessageBox.Show(message);
                }

                //bool temp = MainForm.FPReaders[deviceIP].EnableDevice(MainForm.DevicesInfo[deviceIP].DeviceID, false);
                bool temp = MainForm.FPReaders[deviceIP].StartEnrollEx(UserIDBox.Text, indexToEnroll, 1);
                //bool temp = MainForm.FPReaders[deviceIP].StartEnroll(Convert.ToInt32(UserIDBox.Text), indexToEnroll);

                if (temp)
                {
                    //MainForm.FPReaders[deviceIP].RegEvent(MainForm.DevicesInfo[deviceIP].DeviceID, (1 << 3));

                    currentDialog = new EnrollDialog(BioType.Finger);
                    MainForm.FPReaders[deviceIP].OnEnrollFingerEx += OnEnrollFingerEx;
                    currentDialog.FormClosed += currentDialog_FormClosed;
                    currentDialog.Show();
                }
                //else
                //    MessageBox.Show("Enroll Failed");
                //temp = MainForm.FPReaders[deviceIP].EnableDevice(MainForm.DevicesInfo[deviceIP].DeviceID, true);
                MainForm.FPReaders[deviceIP].StartIdentify();
                
            }
        }
        //**************************************************************************//
        void currentDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            if (currentDialog.DialogResult == DialogResult.Abort)
                MainForm.FPReaders[deviceIP].CancelOperation();
        }
        //**************************************************************************//
        void OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            this.Invoke(new Action(() =>
            {
                string deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
                MainForm.FPReaders[deviceIP].OnEnrollFingerEx -= OnEnrollFingerEx;


                currentDialog.Close();
                FingerInfoButton_Click(null, null);
                SetUserName();
            }));
        }
        //**************************************************************************//
        private void SetUserName()
        {
            string message = "No device connected, please check your device.";

            if (language.ToLower().Contains("th"))
                message = "ไม่มีการเชื่อมต่ออุปกรณ์ กรุณาตรวจสอบและลองใหม่อีกครั้ง";

            if (Devices.Count <= 0)
            {
                MessageBox.Show(message);
                return;
            }

            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            }));

            lock (MainForm.deviceLock)
            {
                bool temp = false;
                int privilege = 0;
                string name, password, cardNumber;
                bool enabled;
                temp = MainForm.FPReaders[deviceIP].SSR_GetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                        UserIDBox.Text, out name, out password, out privilege, out enabled);
                //if (temp)
                {
                    temp = MainForm.FPReaders[deviceIP].GetStrCardNumber(out cardNumber);

                    if (cardNumber.Length > 0)
                        temp = MainForm.FPReaders[deviceIP].SetStrCardNumber(cardNumber);

                    temp = MainForm.FPReaders[deviceIP].SSR_SetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                                UserIDBox.Text,
                                                                UsernameBox.Text,
                                                                "0",
                                                                privilege,
                                                                true);

                }
            }
        }
        //**************************************************************************//
        private void DeleteBioButton_Click(object sender, EventArgs e)
        {
            string deviceIP = "";
            this.Invoke(new Action(() =>
            {
                deviceIP = DevicesListBox.SelectedItem.ToString().Split('-')[1].Replace(" ", "");
            }));
            #region card
            if (selectedBioType == BioType.Card)
            {
                int privilege = 3;

                bool temp = false;

                string name, password, cardNumber;
                bool enabled;
                temp = MainForm.FPReaders[deviceIP].SSR_GetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                        UserIDBox.Text, out name, out password, out privilege, out enabled);
                if (temp)
                {
                    temp = MainForm.FPReaders[deviceIP].GetStrCardNumber(out cardNumber);

                    temp = MainForm.FPReaders[deviceIP].SetStrCardNumber("");
                    temp = MainForm.FPReaders[deviceIP].SSR_SetUserInfo(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                                UserIDBox.Text,
                                                                name,
                                                                password,
                                                                privilege,
                                                                enabled);

                    IDInfoButton_Click(null, null);
                }
            }
            #endregion

            else if (selectedBioType == BioType.Finger)
            {
                //get index from selected item

                string selectedItem = listBox1.SelectedItem.ToString();

                System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("[^0-9]");

                selectedItem = rgx.Replace(selectedItem, "");

                int selectedIndex = Convert.ToInt32(selectedItem);

                if (selectedIndex >= 0 && selectedIndex <= 9)
                {
                    bool temp = MainForm.FPReaders[deviceIP].SSR_DeleteEnrollDataExt(MainForm.DevicesInfo[deviceIP].DeviceID,
                                                                                UserIDBox.Text, selectedIndex);
                    if (temp)
                        listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            else if (selectedBioType == BioType.Face)
            {
                bool temp = MainForm.FPReaders[deviceIP].DelUserFace(MainForm.DevicesInfo[deviceIP].DeviceID, UserIDBox.Text, 50);
                FaceInfoButton_Click(null, null);
            }
        }
        //**************************************************************************//
    }

    public static class BioType
    {
        public const int Card = 0;
        public const int Finger = 1;
        public const int Face = 2;
    }
}
