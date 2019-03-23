namespace ZKTQavi
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SampleDeviceButton = new System.Windows.Forms.Button();
            this.DevicesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TestButton = new System.Windows.Forms.Button();
            this.DBNameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DBPasswordBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DBUsernameBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DBServerBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AutoStartCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SampleDeviceButton);
            this.groupBox1.Controls.Add(this.DevicesBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(652, 289);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device Settings";
            // 
            // SampleDeviceButton
            // 
            this.SampleDeviceButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SampleDeviceButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.SampleDeviceButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.SampleDeviceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SampleDeviceButton.Location = new System.Drawing.Point(507, 41);
            this.SampleDeviceButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SampleDeviceButton.Name = "SampleDeviceButton";
            this.SampleDeviceButton.Size = new System.Drawing.Size(134, 42);
            this.SampleDeviceButton.TabIndex = 3;
            this.SampleDeviceButton.Text = "Sample";
            this.SampleDeviceButton.UseVisualStyleBackColor = false;
            this.SampleDeviceButton.Click += new System.EventHandler(this.SampleDeviceButton_Click);
            // 
            // DevicesBox
            // 
            this.DevicesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevicesBox.ForeColor = System.Drawing.Color.Black;
            this.DevicesBox.Location = new System.Drawing.Point(9, 88);
            this.DevicesBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DevicesBox.Multiline = true;
            this.DevicesBox.Name = "DevicesBox";
            this.DevicesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DevicesBox.Size = new System.Drawing.Size(632, 190);
            this.DevicesBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address, Port, Password, Device Name\r\n(separated by comma. one device per line" +
    ")";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TestButton);
            this.groupBox2.Controls.Add(this.DBNameBox);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.DBPasswordBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.DBUsernameBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.DBServerBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(18, 317);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(652, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database Settings";
            // 
            // TestButton
            // 
            this.TestButton.Location = new System.Drawing.Point(460, 102);
            this.TestButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(154, 43);
            this.TestButton.TabIndex = 10;
            this.TestButton.Text = "Test Connection";
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // DBNameBox
            // 
            this.DBNameBox.Location = new System.Drawing.Point(394, 54);
            this.DBNameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBNameBox.Name = "DBNameBox";
            this.DBNameBox.Size = new System.Drawing.Size(218, 26);
            this.DBNameBox.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Database Name";
            // 
            // DBPasswordBox
            // 
            this.DBPasswordBox.Location = new System.Drawing.Point(102, 109);
            this.DBPasswordBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBPasswordBox.Name = "DBPasswordBox";
            this.DBPasswordBox.PasswordChar = '•';
            this.DBPasswordBox.Size = new System.Drawing.Size(218, 26);
            this.DBPasswordBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Password";
            // 
            // DBUsernameBox
            // 
            this.DBUsernameBox.Location = new System.Drawing.Point(102, 69);
            this.DBUsernameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBUsernameBox.Name = "DBUsernameBox";
            this.DBUsernameBox.Size = new System.Drawing.Size(218, 26);
            this.DBUsernameBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Username";
            // 
            // DBServerBox
            // 
            this.DBServerBox.Location = new System.Drawing.Point(102, 29);
            this.DBServerBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DBServerBox.Name = "DBServerBox";
            this.DBServerBox.Size = new System.Drawing.Size(218, 26);
            this.DBServerBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "DB Server";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(436, 481);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(112, 43);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(558, 481);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(112, 43);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AutoStartCheck
            // 
            this.AutoStartCheck.AutoSize = true;
            this.AutoStartCheck.Location = new System.Drawing.Point(18, 481);
            this.AutoStartCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AutoStartCheck.Name = "AutoStartCheck";
            this.AutoStartCheck.Size = new System.Drawing.Size(167, 24);
            this.AutoStartCheck.TabIndex = 10;
            this.AutoStartCheck.Text = "Launch on Startup";
            this.AutoStartCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(680, 529);
            this.Controls.Add(this.AutoStartCheck);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(702, 585);
            this.MinimumSize = new System.Drawing.Size(702, 585);
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings - ZKTQavi";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox DevicesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DBNameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DBPasswordBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DBUsernameBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DBServerBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.CheckBox AutoStartCheck;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button SampleDeviceButton;
    }
}