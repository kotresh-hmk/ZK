namespace ZKTQavi
{
    partial class EnrollDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnrollDialog));
            this.DoneButton = new System.Windows.Forms.Button();
            this.AbortButton = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.bioTypeText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guideText = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DoneButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.DoneButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DoneButton.Location = new System.Drawing.Point(183, 152);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(135, 38);
            this.DoneButton.TabIndex = 1;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Visible = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // AbortButton
            // 
            this.AbortButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AbortButton.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.AbortButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.AbortButton.Location = new System.Drawing.Point(333, 152);
            this.AbortButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AbortButton.Name = "AbortButton";
            this.AbortButton.Size = new System.Drawing.Size(135, 38);
            this.AbortButton.TabIndex = 2;
            this.AbortButton.Text = "Abort";
            this.AbortButton.UseVisualStyleBackColor = false;
            this.AbortButton.Click += new System.EventHandler(this.AbortButton_Click);
            // 
            // InputBox
            // 
            this.InputBox.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.InputBox.Location = new System.Drawing.Point(117, 105);
            this.InputBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InputBox.MaxLength = 15;
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(439, 29);
            this.InputBox.TabIndex = 0;
            this.InputBox.Visible = false;
            // 
            // bioTypeText
            // 
            this.bioTypeText.AutoSize = true;
            this.bioTypeText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.bioTypeText.Location = new System.Drawing.Point(266, 32);
            this.bioTypeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bioTypeText.Name = "bioTypeText";
            this.bioTypeText.Size = new System.Drawing.Size(55, 23);
            this.bioTypeText.TabIndex = 13;
            this.bioTypeText.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(183, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // guideText
            // 
            this.guideText.AutoSize = true;
            this.guideText.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.guideText.Location = new System.Drawing.Point(126, 109);
            this.guideText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.guideText.Name = "guideText";
            this.guideText.Size = new System.Drawing.Size(55, 23);
            this.guideText.TabIndex = 13;
            this.guideText.Text = "label1";
            this.guideText.Visible = false;
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.idLbl.Location = new System.Drawing.Point(112, 80);
            this.idLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(231, 23);
            this.idLbl.TabIndex = 15;
            this.idLbl.Text = "Please enter ID Card number";
            this.idLbl.Visible = false;
            // 
            // EnrollDialog
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(642, 183);
            this.Controls.Add(this.idLbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.guideText);
            this.Controls.Add(this.bioTypeText);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.AbortButton);
            this.Controls.Add(this.DoneButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 239);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(664, 239);
            this.Name = "EnrollDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enroll";
            this.Load += new System.EventHandler(this.EnrollDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button AbortButton;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Label bioTypeText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label guideText;
        private System.Windows.Forms.Label idLbl;
    }
}