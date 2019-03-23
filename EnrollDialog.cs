using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Globalization;

namespace ZKTQavi
{
    public partial class EnrollDialog : Form
    {
        public string returnVal { get; set; }

        public EnrollDialog(int bioType)
        {
            try
            {
            }
            catch (Exception)
            {
            }

            InitializeComponent();


            if (bioType == BioType.Card)
            {
                pictureBox1.Image = Properties.Resources.users;
                bioTypeText.Text = "ID CARD";
                InputBox.Visible = true;
                DoneButton.Visible = true;
                idLbl.Visible = true;

            }

            else if (bioType == BioType.Finger)
            {
                pictureBox1.Image = Properties.Resources.fingerprint;
                bioTypeText.Text = "FINGERPRINT";
                guideText.Text = "Please enroll fingerprint at device selected";
                guideText.Visible = true;

            }

            else if (bioType == BioType.Face)
            {
                pictureBox1.Image = Properties.Resources.face;
                bioTypeText.Text = "FACE";
                guideText.Text = "Please scan user face at device selected";
                guideText.Visible = true;

            }

        }
        //**************************************************************************//
        private void EnrollDialog_Load(object sender, EventArgs e)
        {

        }
        //**************************************************************************//
        private void DoneButton_Click(object sender, EventArgs e)
        {
            returnVal = InputBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //**************************************************************************//
        private void AbortButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        //**************************************************************************//
    }
}
