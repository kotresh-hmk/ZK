namespace ZKTQavi
{
    partial class EnrollForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollForm));
            this.label2 = new System.Windows.Forms.Label();
            this.UserIDBox = new System.Windows.Forms.TextBox();
            this.DeleteFPButton = new System.Windows.Forms.Button();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DeleteFaceButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteBioButton = new System.Windows.Forms.Button();
            this.AddBioButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.AdminCheckBox = new System.Windows.Forms.CheckBox();
            this.FaceInfoButton = new System.Windows.Forms.Button();
            this.FingerInfoButton = new System.Windows.Forms.Button();
            this.IDInfoButton = new System.Windows.Forms.Button();
            this.DevicesListBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // UserIDBox
            // 
            resources.ApplyResources(this.UserIDBox, "UserIDBox");
            this.UserIDBox.Name = "UserIDBox";
            // 
            // DeleteFPButton
            // 
            this.DeleteFPButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.DeleteFPButton, "DeleteFPButton");
            this.DeleteFPButton.Name = "DeleteFPButton";
            this.DeleteFPButton.UseVisualStyleBackColor = false;
            this.DeleteFPButton.Click += new System.EventHandler(this.DeleteAllFPButton_Click);
            // 
            // UsernameBox
            // 
            resources.ApplyResources(this.UsernameBox, "UsernameBox");
            this.UsernameBox.Name = "UsernameBox";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // DeleteFaceButton
            // 
            this.DeleteFaceButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.DeleteFaceButton, "DeleteFaceButton");
            this.DeleteFaceButton.Name = "DeleteFaceButton";
            this.DeleteFaceButton.UseVisualStyleBackColor = false;
            this.DeleteFaceButton.Click += new System.EventHandler(this.DeleteFaceButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox8);
            this.panel1.Controls.Add(this.BackButton);
            this.panel1.Controls.Add(this.DeleteFPButton);
            this.panel1.Controls.Add(this.DeleteFaceButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteBioButton);
            this.groupBox1.Controls.Add(this.AddBioButton);
            this.groupBox1.Controls.Add(this.listBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // DeleteBioButton
            // 
            this.DeleteBioButton.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.DeleteBioButton, "DeleteBioButton");
            this.DeleteBioButton.Image = global::ZKTQavi.Properties.Resources.minus;
            this.DeleteBioButton.Name = "DeleteBioButton";
            this.DeleteBioButton.UseVisualStyleBackColor = false;
            this.DeleteBioButton.Click += new System.EventHandler(this.DeleteBioButton_Click);
            // 
            // AddBioButton
            // 
            this.AddBioButton.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.AddBioButton, "AddBioButton");
            this.AddBioButton.Image = global::ZKTQavi.Properties.Resources.plus;
            this.AddBioButton.Name = "AddBioButton";
            this.AddBioButton.UseVisualStyleBackColor = false;
            this.AddBioButton.Click += new System.EventHandler(this.AddBioButton_Click);
            // 
            // listBox1
            // 
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Name = "listBox1";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.AdminCheckBox);
            this.groupBox8.Controls.Add(this.FaceInfoButton);
            this.groupBox8.Controls.Add(this.FingerInfoButton);
            this.groupBox8.Controls.Add(this.IDInfoButton);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.UserIDBox);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.UsernameBox);
            this.groupBox8.Controls.Add(this.DevicesListBox);
            this.groupBox8.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // AdminCheckBox
            // 
            resources.ApplyResources(this.AdminCheckBox, "AdminCheckBox");
            this.AdminCheckBox.Name = "AdminCheckBox";
            this.AdminCheckBox.UseVisualStyleBackColor = true;
            this.AdminCheckBox.CheckedChanged += new System.EventHandler(this.AdminCheckBox_CheckedChanged);
            // 
            // FaceInfoButton
            // 
            this.FaceInfoButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FaceInfoButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.FaceInfoButton, "FaceInfoButton");
            this.FaceInfoButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FaceInfoButton.Image = global::ZKTQavi.Properties.Resources.face_b;
            this.FaceInfoButton.Name = "FaceInfoButton";
            this.FaceInfoButton.UseVisualStyleBackColor = false;
            this.FaceInfoButton.Click += new System.EventHandler(this.FaceInfoButton_Click);
            // 
            // FingerInfoButton
            // 
            this.FingerInfoButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FingerInfoButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.FingerInfoButton, "FingerInfoButton");
            this.FingerInfoButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FingerInfoButton.Image = global::ZKTQavi.Properties.Resources.finger_b;
            this.FingerInfoButton.Name = "FingerInfoButton";
            this.FingerInfoButton.UseVisualStyleBackColor = false;
            this.FingerInfoButton.Click += new System.EventHandler(this.FingerInfoButton_Click);
            // 
            // IDInfoButton
            // 
            this.IDInfoButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.IDInfoButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.IDInfoButton, "IDInfoButton");
            this.IDInfoButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.IDInfoButton.Image = global::ZKTQavi.Properties.Resources.card_b;
            this.IDInfoButton.Name = "IDInfoButton";
            this.IDInfoButton.UseVisualStyleBackColor = false;
            this.IDInfoButton.Click += new System.EventHandler(this.IDInfoButton_Click);
            // 
            // DevicesListBox
            // 
            resources.ApplyResources(this.DevicesListBox, "DevicesListBox");
            this.DevicesListBox.FormattingEnabled = true;
            this.DevicesListBox.Name = "DevicesListBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.BackButton, "BackButton");
            this.BackButton.Name = "BackButton";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // EnrollForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnrollForm";
            this.Load += new System.EventHandler(this.EnrollForm_Load);
            this.Resize += new System.EventHandler(this.EnrollForm_Resize);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserIDBox;
        private System.Windows.Forms.Button DeleteFPButton;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DeleteFaceButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox DevicesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FaceInfoButton;
        private System.Windows.Forms.Button FingerInfoButton;
        private System.Windows.Forms.Button IDInfoButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button DeleteBioButton;
        private System.Windows.Forms.Button AddBioButton;
        private System.Windows.Forms.CheckBox AdminCheckBox;
    }
}