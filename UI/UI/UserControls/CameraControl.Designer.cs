namespace UI.UserControls
{
    partial class CameraControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCameraDevices = new System.Windows.Forms.ComboBox();
            this.cmdCameraResolutions = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCameraDevices);
            this.panel1.Controls.Add(this.cmdCameraResolutions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 112);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.button1.Location = new System.Drawing.Point(533, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(217, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Camera devices";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(34, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Resolutions";
            // 
            // cmbCameraDevices
            // 
            this.cmbCameraDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.cmbCameraDevices.ForeColor = System.Drawing.SystemColors.Control;
            this.cmbCameraDevices.FormattingEnabled = true;
            this.cmbCameraDevices.Location = new System.Drawing.Point(230, 64);
            this.cmbCameraDevices.Name = "cmbCameraDevices";
            this.cmbCameraDevices.Size = new System.Drawing.Size(153, 24);
            this.cmbCameraDevices.TabIndex = 1;
            this.cmbCameraDevices.SelectedIndexChanged += new System.EventHandler(this.cmbCameraDevices_SelectedIndexChanged_1);
            // 
            // cmdCameraResolutions
            // 
            this.cmdCameraResolutions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.cmdCameraResolutions.ForeColor = System.Drawing.SystemColors.Control;
            this.cmdCameraResolutions.FormattingEnabled = true;
            this.cmdCameraResolutions.Location = new System.Drawing.Point(14, 64);
            this.cmdCameraResolutions.Name = "cmdCameraResolutions";
            this.cmdCameraResolutions.Size = new System.Drawing.Size(153, 24);
            this.cmdCameraResolutions.TabIndex = 0;
            this.cmdCameraResolutions.SelectedIndexChanged += new System.EventHandler(this.cmdCameraResolutions_SelectedIndexChanged_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 482);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CameraControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "CameraControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(804, 594);
            this.VisibleChanged += new System.EventHandler(this.CameraControl_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCameraDevices;
        private System.Windows.Forms.ComboBox cmdCameraResolutions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
