using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DataExtraction
{
    public partial class ExternalConfig : Form
    {
        public ExternalConfig()
        {
            InitializeComponent();
            externalWizard.TabPages.Remove(testNetwork);
        }
        string extFWIP, extRouterIP, username, password, extFWMask, extRouterMask;
        public static bool extFirewallPingable, extRouterPingable, configSuccess;

        //updates the second mask box to be the same as the first
        private void UpdateMaskBox(object sender, EventArgs e)
        {
            extFWMask = extFirewallMaskBox.Text;
            extRouterMaskBox.Text = extFWMask;
        }

        //next to net start from start
        private void nextButton_Click(object sender, EventArgs e)
        {
            extFWIP = externalFWBox.Text;
            extRouterIP = externalRouterBox.Text;
            extFWMask = extFirewallMaskBox.Text;
            extRouterMask = extRouterMaskBox.Text;

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

            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;
            progressExtNetwork.Value = 5;

            //start the command line process
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Windows\System32\cmd");
            psi.ErrorDialog = false;
            psi.UseShellExecute = false;

            //hide the command window
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Hidden;

            //redirect the input and output
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;

            //start plink process
            Process plinkProcess = Process.Start(psi);
            StreamWriter inputWriter = plinkProcess.StandardInput;
            StreamReader outputReader = plinkProcess.StandardOutput;
            StreamReader errorReader = plinkProcess.StandardError;

            //command to log in to the firewall
            inputWriter.WriteLine(@" ""C:\Program FIles (x86) (x86) (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(2000);

            //give admin rights
            inputWriter.WriteLine("srole");
            Thread.Sleep(200);
            progressExtNetwork.Value = 20;

            //Modify the network interface
            inputWriter.WriteLine("cf interface modify name=\"External System 1\" addresses=" + extFWIP + "/" + extFWMask);
            progressExtNetwork.Value = 50;
            Thread.Sleep(1000);
            
            progressExtNetwork.Value = 90;
            //exit
            inputWriter.WriteLine("exit");
            inputWriter.WriteLine("exit");

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();
                string loginError = errorReader.ReadToEnd().ToString();
                
                //access denied will pop up if connected to the firewall and wrong username/pw info. FATAL ERROR is if not connected to firewall
                if (loginError.Contains("Access denied") || loginError.Contains("FATAL ERROR"))
                {
                    //If Plink connection fails throw error and return
                    MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressExtNetwork.Value = 0;
                }
                else
                {
                    //Confirmation 
                    progressExtNetwork.Value = 100;
                    MessageBox.Show("Interface and Network Objects configured for External System", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    configSuccess = true;
                    externalWizard.TabPages.Remove(inputInfo);
                    externalWizard.TabPages.Add(testNetwork);
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressExtNetwork.Value = 0;
                return;
            }
        }

        //back to start page from net test 
        private void backToStart_Click(object sender, EventArgs e)
        {
            externalWizard.TabPages.Add(inputInfo);
            externalWizard.TabPages.Remove(testNetwork);
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //Ping the internal tracks server
            Ping_ pingFW = new Ping_();
            pingFW.Ping_External(extFWIP);
            bool pingFWResult = Ping_.externalPingable;

            if (pingFWResult == true)
            {
                ExtFWPingSignal.FillColor = Color.Green;
                extFirewallPingable = true;
            }
            else
            {
                ExtFWPingSignal.FillColor = Color.Red;
            }

            //Ping the ext tracks server
            Ping_ pingRouter = new Ping_();
            pingRouter.Ping_External(extRouterIP);
            bool pingRouterResult = Ping_.externalPingable;

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

            //call universal error
            if (pingRouterResult == false || pingFWResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
                return;
            }
        }            
    }    
}