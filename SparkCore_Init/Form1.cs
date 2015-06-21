using System;
using System.Windows.Forms;

using System.Management;
using Threading = System.Threading;
using System.IO.Ports;

namespace SparkCore_Init
{
    public partial class Form1 : Form
    {
        // updating COM devices list
        Threading.Timer refreshDevListTimer;
        // is it refreshDevListTimer first tick? 
        bool firstRun = true;        
        // fill port name textbox if device's name contains this string
        string automPortForDevice = "DWGROUP";
        // waiting for answer from Core
        string waitingFor = null;

        public Form1()
        {
            InitializeComponent();
            // set correct newline for communication
            serialPort.NewLine = "\r\n";

            // security types
            comboSecurity.Items.AddRange(new object[]{
            new {
                    SecurityName = "No security",
                    SecurityIDType = 0
            },
            new {
                    SecurityName = "WEP",
                    SecurityIDType = 1
            },
            new {
                    SecurityName = "WPA",
                    SecurityIDType = 2
            },
            new {
                    SecurityName = "WPA2",
                    SecurityIDType = 3
            }
            });
            comboSecurity.SelectedIndex = 0;

            // refresh dev list now and every 3s - in other thread
            refreshDevListTimer = new Threading.Timer(refreshDevList, firstRun, 0, 3000);
        }

        // fill dev list
        void refreshDevList(Object state)
        {
            // select COM devices
            SelectQuery Sq = new SelectQuery("Win32_SerialPort");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();

            if (InvokeRequired)
            {
                BeginInvoke(new Action(delegate
                {                  
                    // beginUpdate and endUpdate prevents flashing
                    lbDevices.BeginUpdate();
                    lbDevices.Items.Clear();
                    foreach (ManagementObject mo in osDetailsCollection)
                    {
                        // add device to dev list
                        lbDevices.Items.Add(new
                        {
                            DeviceID = mo["DeviceID"],
                            Description = mo["DeviceID"] + " - " + mo["Description"]
                        });

                        if (firstRun)
                        {
                            // fill port name textbox with suggested COM port
                            if (mo["Description"].ToString().Contains(automPortForDevice))
                                tbPort.Text = mo["DeviceID"].ToString();
                        }
                    }
                    firstRun = false;
                    lbDevices.EndUpdate();                  
                }));
            }
        }

        private void lbDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            // fill port name according to the selected device
            if (lbDevices.SelectedItem != null)
                tbPort.Text = ((dynamic)lbDevices.SelectedItem).DeviceID.ToString();
        }

        private void cbConnect_CheckedChanged(object sender, EventArgs e)
        {
            // connection
            CheckBox cb = (CheckBox)sender;            
            if (cb.Checked)
            {                
                try
                {
                    serialPort.PortName = tbPort.Text;
                    serialPort.Open();
                    cb.Text = "Disconnect";
                    gbID.Enabled = gbWifi.Enabled = true;
                }
                catch (Exception ex)
                {
                    cb.Checked = false;
                    MessageBox.Show(ex.Message, "Problem during connection");                    
                }
            }
            // disconnection
            else
            {
                try
                {
                    if (serialPort != null && serialPort.IsOpen)
                        serialPort.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Problem during disconnection");
                }
                cb.Text = "Connect";
                gbID.Enabled = gbWifi.Enabled = false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // try to disconnect
            try
            {
                if (serialPort != null && serialPort.IsOpen)
                    serialPort.Close();
            }
            catch { }
        }

        private void btnGetID_Click(object sender, EventArgs e)
        {
            // waiting for identification data
            waitingFor = "i";
            try
            {
                serialPort.WriteLine("i");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Communication problem");
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {            
            SerialPort sp = (SerialPort)sender;

            string s = string.Empty;
            try
            {                
                switch (waitingFor)
                {
                    // waiting for identification data
                    case "i":
                        s = sp.ReadLine();
                        break;

                    // waiting for answers after/during wifi setup
                    case "w":
                        s = sp.ReadExisting();
                        break;
                }            
            
                if (InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate
                    {
                        switch (waitingFor)
                        {
                            case "i":
                                Console.WriteLine(s);
                                // get only ID from Core answer
                                tbID.Text = s.Substring(16);
                                // select all text for possible copying by user
                                tbID.Select();
                                tbID.SelectAll();
                                waitingFor = null;
                                break;

                            case "w":
                                Console.Write(s);
                                break;
                        }
                    });
                }
            }
            catch { }
        }

        private void btnSaveSecurity_Click(object sender, EventArgs e)
        {
            // waiting for answers after/during wifi setup
            waitingFor = "w";
            int securityID = ((dynamic)comboSecurity.SelectedItem).SecurityIDType;

            try
            {
                // send required wifi settings to Core
                serialPort.Write("w");
                serialPort.WriteLine(tbSSID.Text);
                serialPort.WriteLine(securityID.ToString());
                if (securityID != 0)
                    serialPort.WriteLine(tbPassword.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Communication problem");
            }
        }

        private void comboSecurity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enable password textbox if security is not "no security"
            tbPassword.Enabled = ((dynamic)comboSecurity.SelectedItem).SecurityIDType != 0;
        }

        private void btnDriver_Click(object sender, EventArgs e)
        {
            // show and redraw label "installation in progress..."
            lbInstallation.Show();
            lbInstallation.Update();
            try
            {
                // install driver and scan for hardware changes
                DriverMgmt.InstallDriver(tbInfPath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Installation failed");
            }
            lbInstallation.Hide();
        }
    }
}
