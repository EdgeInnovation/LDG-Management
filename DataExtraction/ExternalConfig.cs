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
        string extFWIP, extRouterIP, username, password, extFWMask, extRouterMask, consoleOutput;
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
            inputWriter.WriteLine(@" ""C:\Program Files (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(2000);

            //give admin rights
            inputWriter.WriteLine("srole");
            Thread.Sleep(200);
            progressExtNetwork.Value = 20;

            //Modify the network interface
            inputWriter.WriteLine("cf interface modify name=\"External System 1\" addresses=" + extFWIP + "/" + extFWMask);
            progressExtNetwork.Value = 50;
            Thread.Sleep(1000);

            //ping router for 3 counts
            inputWriter.WriteLine("ping -c 2 " + extRouterIP);
            Thread.Sleep(3000);

            //check if interface is up, search for "status: active" 
            inputWriter.WriteLine("ifconfig 2-0");
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
                consoleOutput = outputReader.ReadToEnd().ToString();

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
                    MessageBox.Show("Interface configured for External 1 System", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }

            //get the ping success result
            if (consoleOutput.Contains("bytes from " + extRouterIP))
            {
                pingRouterResult = true;
            }
            else
            {
                pingRouterResult = false;
            }

            //determine whether cable is connected from ifconfig status
            if (consoleOutput.Contains("status: active"))
            {
                extPlugged = true;
            }
            else
            {
                extPlugged = false;
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