namespace SparkCore_Init
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lbDevices = new System.Windows.Forms.ListBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbConnect = new System.Windows.Forms.CheckBox();
            this.gbWifi = new System.Windows.Forms.GroupBox();
            this.btnSaveSecurity = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.comboSecurity = new System.Windows.Forms.ComboBox();
            this.tbSSID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbID = new System.Windows.Forms.GroupBox();
            this.btnGetID = new System.Windows.Forms.Button();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnDriver = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbInfPath = new System.Windows.Forms.TextBox();
            this.lbInstallation = new System.Windows.Forms.Label();
            this.gbWifi.SuspendLayout();
            this.gbID.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDevices
            // 
            this.lbDevices.DisplayMember = "Description";
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(16, 70);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(266, 95);
            this.lbDevices.TabIndex = 0;
            this.lbDevices.ValueMember = "DeviceID";
            this.lbDevices.SelectedIndexChanged += new System.EventHandler(this.lbDevices_SelectedIndexChanged);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(51, 174);
            this.tbPort.Name = "tbPort";
            this.tbPort.ReadOnly = true;
            this.tbPort.Size = new System.Drawing.Size(104, 20);
            this.tbPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serial port devices ( refresh every 3s )";
            // 
            // cbConnect
            // 
            this.cbConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbConnect.Location = new System.Drawing.Point(178, 172);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(104, 24);
            this.cbConnect.TabIndex = 4;
            this.cbConnect.Text = "Connect";
            this.cbConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbConnect.UseVisualStyleBackColor = true;
            this.cbConnect.CheckedChanged += new System.EventHandler(this.cbConnect_CheckedChanged);
            // 
            // gbWifi
            // 
            this.gbWifi.Controls.Add(this.btnSaveSecurity);
            this.gbWifi.Controls.Add(this.tbPassword);
            this.gbWifi.Controls.Add(this.comboSecurity);
            this.gbWifi.Controls.Add(this.tbSSID);
            this.gbWifi.Controls.Add(this.label6);
            this.gbWifi.Controls.Add(this.label5);
            this.gbWifi.Controls.Add(this.label4);
            this.gbWifi.Enabled = false;
            this.gbWifi.Location = new System.Drawing.Point(16, 333);
            this.gbWifi.Name = "gbWifi";
            this.gbWifi.Size = new System.Drawing.Size(487, 126);
            this.gbWifi.TabIndex = 5;
            this.gbWifi.TabStop = false;
            this.gbWifi.Text = "2) WiFi";
            // 
            // btnSaveSecurity
            // 
            this.btnSaveSecurity.Location = new System.Drawing.Point(397, 68);
            this.btnSaveSecurity.Name = "btnSaveSecurity";
            this.btnSaveSecurity.Size = new System.Drawing.Size(75, 32);
            this.btnSaveSecurity.TabIndex = 6;
            this.btnSaveSecurity.Text = "Save";
            this.btnSaveSecurity.UseVisualStyleBackColor = true;
            this.btnSaveSecurity.Click += new System.EventHandler(this.btnSaveSecurity_Click);
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(120, 90);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = 'X';
            this.tbPassword.Size = new System.Drawing.Size(249, 20);
            this.tbPassword.TabIndex = 5;
            // 
            // comboSecurity
            // 
            this.comboSecurity.DisplayMember = "SecurityName";
            this.comboSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSecurity.FormattingEnabled = true;
            this.comboSecurity.Location = new System.Drawing.Point(120, 57);
            this.comboSecurity.Name = "comboSecurity";
            this.comboSecurity.Size = new System.Drawing.Size(249, 21);
            this.comboSecurity.TabIndex = 4;
            this.comboSecurity.ValueMember = "SecurityID";
            this.comboSecurity.SelectedIndexChanged += new System.EventHandler(this.comboSecurity_SelectedIndexChanged);
            // 
            // tbSSID
            // 
            this.tbSSID.Location = new System.Drawing.Point(120, 23);
            this.tbSSID.Name = "tbSSID";
            this.tbSSID.Size = new System.Drawing.Size(249, 20);
            this.tbSSID.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Security:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Site name (SSID):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Core have to be in the Listening mode  ( hold MODE button )";
            // 
            // gbID
            // 
            this.gbID.Controls.Add(this.btnGetID);
            this.gbID.Controls.Add(this.tbID);
            this.gbID.Controls.Add(this.label7);
            this.gbID.Enabled = false;
            this.gbID.Location = new System.Drawing.Point(16, 247);
            this.gbID.Name = "gbID";
            this.gbID.Size = new System.Drawing.Size(487, 64);
            this.gbID.TabIndex = 5;
            this.gbID.TabStop = false;
            this.gbID.Text = "1) Identification";
            // 
            // btnGetID
            // 
            this.btnGetID.Location = new System.Drawing.Point(357, 20);
            this.btnGetID.Name = "btnGetID";
            this.btnGetID.Size = new System.Drawing.Size(115, 32);
            this.btnGetID.TabIndex = 6;
            this.btnGetID.Text = "Get ID";
            this.btnGetID.UseVisualStyleBackColor = true;
            this.btnGetID.Click += new System.EventHandler(this.btnGetID_Click);
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(61, 27);
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(268, 20);
            this.tbID.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "ID:";
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // btnDriver
            // 
            this.btnDriver.Location = new System.Drawing.Point(333, 112);
            this.btnDriver.Name = "btnDriver";
            this.btnDriver.Size = new System.Drawing.Size(130, 34);
            this.btnDriver.TabIndex = 7;
            this.btnDriver.Text = "Install driver";
            this.btnDriver.UseVisualStyleBackColor = true;
            this.btnDriver.Click += new System.EventHandler(this.btnDriver_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(313, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "A required device is not on the list?";
            // 
            // tbInfPath
            // 
            this.tbInfPath.Location = new System.Drawing.Point(316, 153);
            this.tbInfPath.Name = "tbInfPath";
            this.tbInfPath.Size = new System.Drawing.Size(160, 20);
            this.tbInfPath.TabIndex = 9;
            this.tbInfPath.Text = "Driver\\spark_core.inf";
            // 
            // lbInstallation
            // 
            this.lbInstallation.AutoSize = true;
            this.lbInstallation.Location = new System.Drawing.Point(340, 181);
            this.lbInstallation.Name = "lbInstallation";
            this.lbInstallation.Size = new System.Drawing.Size(120, 13);
            this.lbInstallation.TabIndex = 10;
            this.lbInstallation.Text = "Installation in progress...";
            this.lbInstallation.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 478);
            this.Controls.Add(this.lbInstallation);
            this.Controls.Add(this.tbInfPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDriver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbID);
            this.Controls.Add(this.gbWifi);
            this.Controls.Add(this.cbConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lbDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SparkCore - basic settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.gbWifi.ResumeLayout(false);
            this.gbWifi.PerformLayout();
            this.gbID.ResumeLayout(false);
            this.gbID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbDevices;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbConnect;
        private System.Windows.Forms.GroupBox gbWifi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ComboBox comboSecurity;
        private System.Windows.Forms.TextBox tbSSID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSaveSecurity;
        private System.Windows.Forms.Button btnGetID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label7;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button btnDriver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbInfPath;
        private System.Windows.Forms.Label lbInstallation;
    }
}

