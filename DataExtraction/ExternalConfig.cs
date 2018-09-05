using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LDGManagementApplication
{
    public partial class ExternalConfig : Form
    {
        public ExternalConfig()
        {
            InitializeComponent();
            externalWizard.TabPages.Remove(testNetwork);
        }
        string extFWIP, extRouterIP,  extFWMask, extRouterMask;
        public static bool  extRouterPingable, configSuccess;
        bool extPlugged, pingRouterResult;

        //updates the second mask box to be the same as the first
        private void UpdateMaskBox(object sender, EventArgs e)
        {
            extFWMask = extFirewallMaskBox.Text;
            extRouterMaskBox.Text = extFWMask;
        }

        //next to net start from start
        private void nextButton_Click(object sender, EventArgs e)
        {
            progressExtNetwork.Value = 5;
            extFWIP = externalFWBox.Text;
            extRouterIP = externalRouterBox.Text;
            extFWMask = extFirewallMaskBox.Text;
            extRouterMask = extRouterMaskBox.Text;
            progressExtNetwork.Value = 3;
            string[] extFWIPArray = extFWIP.Split('.');
            string[] extRouterIPArray = extRouterIP.Split('.');

            //Make sure IP Addresses are in the correct format
            if (extFWIPArray.Length != 4 || extRouterIPArray.Length != 4)
            {
                MessageBox.Show("Please enter a valid IP address", "Incorrect IP Address Format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string extFWIPNet = extFWIPArray[0] + extFWIPArray[1] + extFWIPArray[2];
            string extRouterIPNet = extRouterIPArray[0] + extRouterIPArray[1] + extRouterIPArray[2];
            //make sure router and firewall both exist in same subnet
            if (extFWIPNet != extRouterIPNet)
            {
                MessageBox.Show("Ensure the External Firewall IP and the External Router IP both exist on the same net", "Error entering IP Addresses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //make sure boxes arent blank
            if (externalFWBox.Text == "" || externalRouterBox.Text == "")
            {
                MessageBox.Show("Please enter both IP addresses", "Error inputting values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            progressExtNetwork.Value = 15;
            Putty externalConfig = new ExternalPutty(extRouterIP, extFWIP, extFWMask);
            externalConfig.Configure();

            //get the ping success result
            if (Putty.consoleOutput.Contains("bytes from " + extRouterIP))
            {
                pingRouterResult = true;
            }
            else
            {
                pingRouterResult = false;
            }

            //determine whether cable is connected from ifconfig status
            if (Putty.consoleOutput.Contains("status: active"))
            {
                extPlugged = true;
            }
            else
            {
                extPlugged = false;
            }
            progressExtNetwork.Value = 15;
            //write log file
            WriteLog writeLog = new ExternalLog();
            writeLog.WriteLogFile();
            progressExtNetwork.Value = 80;

            //go to next page if it succeeded
            if (Putty.configSuccess == true)
            {
                progressExtNetwork.Value = 100;
                //Hide current tab and show next
                externalWizard.TabPages.Clear();
                externalWizard.TabPages.Add(testNetwork);
            }
            else
            {
                progressExtNetwork.Value = 0;
                return;
            }
        }

        //back to start page from net test 
        private void backToStart_Click(object sender, EventArgs e)
        {
            externalWizard.TabPages.Clear();
            externalWizard.TabPages.Add(inputInfo);
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (extPlugged == true)
            {
                ExtInterfaceSignal.FillColor = Color.Green;
            }
            else
            {
                ExtInterfaceSignal.FillColor = Color.Red;
            }

            //change BNAU Ping button
            if (pingRouterResult == true)
            {
                ExtRouterPingSignal.FillColor = Color.Green;
                extRouterPingable = true;
            }
            else
            {
                ExtRouterPingSignal.FillColor = Color.Red;
            }

            //universal error messages:
            //first check connection is present
            if (extPlugged == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(false);
                return;
            }
            else if (pingRouterResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
            }
        }            
    }    
}