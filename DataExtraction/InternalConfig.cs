using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DataExtraction
{
    public partial class InternalConfig : Form
    {
        public InternalConfig()
        {
            InitializeComponent();
            BNAUWizard.TabPages.Remove(networkTest);
            BNAUWizard.TabPages.Remove(OSPF);
        }

        public static string BNAUSubnetIP;
        public static bool intBNAUPingable;
        string username, password, errorLogOutput, logPath, firewallIPAddr, internalIPAddr, consoleOutput, errorOutput;
        bool BNAUPlugged, configSuccess, pingBNAUResult;

        //
        //Internal Config
        //
        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            //call the extract data class, saying that this isn't the LDG plana and get the list 
            ExtractData extractInternalData = new ExtractData();
            extractInternalData.Extract_Internal_Data();
            List<string> internalExtractedData = extractInternalData.GetInternalList();
            string path = ExtractData.internalBecFilePath;
            if (path == null)
            {
                return;
            }

            //produce the subnet IP & the firewall IP from the internal IP
            internalIPAddr = internalExtractedData[0];
            string[] internalIPArray = internalIPAddr.Split('.');
            BNAUSubnetIP = internalIPArray[0] + "." + internalIPArray[1] + "." + internalIPArray[2];
            firewallIPAddr = BNAUSubnetIP + ".17";
            ConfigBNAUSubnetBox.Text = BNAUSubnetIP;

            progressIntNetwork.Value = 10;

            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;
            progressIntNetwork.Value = 5;

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

            //Modify the network interfaces
            inputWriter.WriteLine("cf interface modify name=\"Internal BCIP\" addresses=" + firewallIPAddr + "/24");
            progressIntNetwork.Value = 30;
            Thread.Sleep(2000);

            //modify network objects for BNAU and firewall
            inputWriter.WriteLine("cf ipaddr modify name=\"Internal BCIP BNAU\" ipaddr=" + internalIPAddr);
            Thread.Sleep(3000);
            inputWriter.WriteLine("cf ipaddr modify name=\"Internal BCIP Firewall\" ipaddr=" + firewallIPAddr);
            Thread.Sleep(3000);
            progressIntNetwork.Value = 50;        
           
            //NOTE: if user selects same plan as DMZ it will throw an error and not work, but it will look like it did

            //ping BNAU for 3 counts
            inputWriter.WriteLine("ping -c 2 " + internalIPAddr);
            Thread.Sleep(3000);

            //check if interface is up, search for "status: active" 
            inputWriter.WriteLine("ifconfig 1-6");
            Thread.Sleep(1000);

            progressIntNetwork.Value = 90;

            //exit
            inputWriter.WriteLine("exit");
            inputWriter.WriteLine("exit");

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();
                consoleOutput = outputReader.ReadToEnd().ToString();
                errorOutput = errorReader.ReadToEnd().ToString();
                errorLogOutput = DateTime.Now.ToString() + System.Environment.NewLine + " Error Output:  " + System.Environment.NewLine + errorOutput;

                //access denied will pop up if connected to the firewall and wrong username/pw info. FATAL ERROR is if not connected to firewall
                if (errorOutput.Contains("Access denied") || errorOutput.Contains("FATAL ERROR"))
                {
                    //If Plink connection fails throw error and return
                    MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressIntNetwork.Value = 0;
                }
                else
                {
                    //Confirmation 
                    progressIntNetwork.Value = 100;
                    MessageBox.Show("Interface and Network Objects configured for Internal System", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    configSuccess = true;
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressIntNetwork.Value = 0;
                return;
            }

            //get the ping success result
            if (consoleOutput.Contains("bytes from " + internalIPAddr))
            {
                pingBNAUResult = true;
            }
            else
            {
                pingBNAUResult = false;
            }

            //determine whether cable is connected from ifconfig status
            if (consoleOutput.Contains("status: active"))
            {
                BNAUPlugged = true;
            }
            else
            {
                BNAUPlugged = false;
            }

            //write error output to add to log file
            string lineBreak = "\n" + "------------------------------------------------------------";

            //Log the output to a text file:
            logPath = @"C:\Program Files\General Dynamics UK\LDG Management Application\LMA_InternalConfig_Log.txt";
            
            try
            {
                //if file doesn't exist create it
                if (!File.Exists(logPath))
                {
                    File.Create(logPath).Dispose();
                    using (StreamWriter sw = File.CreateText(logPath))
                    {
                        sw.Write(errorLogOutput + System.Environment.NewLine + lineBreak);
                    }
                }
                //append to existing file
                else
                {
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        sw.Write(System.Environment.NewLine + errorLogOutput + System.Environment.NewLine + lineBreak);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Access to " + logPath + " denied. Log File not created.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //go to next page if it succeeded
            if (configSuccess == true)
            {
                //Hide current tab and show next
                BNAUWizard.TabPages.Remove(networkTest);
                BNAUWizard.TabPages.Remove(Network);
                
                BNAUWizard.TabPages.Add(OSPF);
            }
            else
            {
                return;
            }
        }

        //
        //OSPF
        //

        private void OSPFConfig_Click(object sender, EventArgs e)
        {
            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;
            progressIntOSPF.Value = 5;

            //Set up another connection with Putty to configure OSPF//
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
            Process plinkOSPFProcess = Process.Start(psi);
            StreamWriter inputOSPFWriter = plinkOSPFProcess.StandardInput;
            StreamReader outputOSPFReader = plinkOSPFProcess.StandardOutput;
            StreamReader errorOSPFReader = plinkOSPFProcess.StandardError;

            //this is the command to log in to the firewall
            inputOSPFWriter.WriteLine(@" ""C:\Program Files (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(2000);

            //If Plink connection fails throw error and return
            if (plinkOSPFProcess.HasExited)
            {
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Could try ping to firewall
                return;
            }

            //give admin rights
            inputOSPFWriter.WriteLine("srole");
            Thread.Sleep(500);
            progressIntOSPF.Value = 10;

            //Telnet into the firewall OSPF Routing Server
            inputOSPFWriter.WriteLine("telnet localhost ospfd");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 20;

            //Password is zebra
            inputOSPFWriter.WriteLine("zebra");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 30;

            //Enable the full command set
            inputOSPFWriter.WriteLine("en");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 40;

            //Enter Configuration mode
            inputOSPFWriter.WriteLine("conf t");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 50;

            //Enable routing server
            inputOSPFWriter.WriteLine("router ospf");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 60;

            //Enable routing server
            inputOSPFWriter.WriteLine("router ospf");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 70;

            //remove default IPs, check if correct
            inputOSPFWriter.WriteLine("no network 1.1.1.1/24 area 0");
            Thread.Sleep(500);
            inputOSPFWriter.WriteLine("no network 2.2.2.2/24 area 0");
            Thread.Sleep(500);

            //Edit the router-id to be the firewallIP
            inputOSPFWriter.WriteLine("router-id " + firewallIPAddr);
            Thread.Sleep(1000);
            progressIntOSPF.Value = 80;

            //Edit the 1st network to be the internal BCIP IP
            inputOSPFWriter.WriteLine("network  " + internalIPAddr + "/24 area 0");
            Thread.Sleep(1000);
            progressIntOSPF.Value = 90;

            //Save the OSPF config file
            inputOSPFWriter.WriteLine("write");
            Thread.Sleep(1000);

            //exit srole then putty
            inputOSPFWriter.WriteLine("exit");
            inputOSPFWriter.WriteLine("exit");

            // area 0 shorthand for 0.0.0.0?

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkOSPFProcess.Kill();
                progressIntOSPF.Value = 100;
                MessageBox.Show("OSPF Routing configured for Internal interface", "Firewall Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Show next tab
                
                BNAUWizard.TabPages.Remove(OSPF);
                BNAUWizard.TabPages.Add(networkTest);
                BNAUWizard.TabPages.Remove(Network);
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressIntOSPF.Value = 0;
                return;
            }

        }
        //return to network config page from OSPF page
        private void returnNetworkTest_Click(object sender, EventArgs e)
        {
            //Hide current tab and show next
            BNAUWizard.TabPages.Remove(networkTest);
            
            BNAUWizard.TabPages.Add(Network);
            BNAUWizard.TabPages.Remove(OSPF);
        }

        //return to config tab from test tab
        private void returnConfig_Click(object sender, EventArgs e)
        {
            //Hide current tab and show next
            BNAUWizard.TabPages.Remove(networkTest);

            BNAUWizard.TabPages.Add(Network);
            BNAUWizard.TabPages.Remove(OSPF);
        }
        private void testButton_Click(object sender, EventArgs e)
        {
           //if BNAU is unplugged put color red
            if (BNAUPlugged == true)
            {
                BNAUInterfaceSignal.FillColor = Color.Green;
            }
            else if (BNAUPlugged == false)
            {
                BNAUInterfaceSignal.FillColor = Color.Red;
            }

            //change BNAU Ping button
            if (pingBNAUResult == true)
            {
                BNAUPingSignal.FillColor = Color.Green;
                intBNAUPingable = true;
            }
            else
            {
                BNAUPingSignal.FillColor = Color.Red;
            }

            //universal error messages:
            //first check if connection is present
            if (BNAUPlugged == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(false);
                return;
            }
            else if (pingBNAUResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
            }
        }        
    } 
}