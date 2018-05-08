using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DataExtraction
{
    public partial class DMZConfig : Form
    {
        public DMZConfig()
        {
            InitializeComponent();
            DMZWizard.TabPages.Remove(OSPF);
            DMZWizard.TabPages.Remove(networkTest);
        }
        
        string username, password, DMZIPAddr, chatGWSubnet, errorOutput, logPath, DMZchatGW, DMZBQSIP, DMZFirewallExt, DMZFirewallExtWMS, DMZFirewallMIP;
        public static bool DMZPingable;
        bool DMZPlugged, configSuccess;

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            progressDMZNetwork.Value = 3;
            //call the extract data class, saying that this isn't the LDG plana and get the list 
            ExtractData extractDMZData = new ExtractData();
            extractDMZData.Extract_Data(true);
            List<string> internalExtractedData = extractDMZData.GetLDGList();
            string path = ExtractData.DMZBecFilePath;
            if (path == null)
            {
                return;
            }

            //produce the subnet IP & the firewall IP from the internal IP
            DMZchatGW = internalExtractedData[2];
            string[] chatGWArray = DMZchatGW.Split('.');
            chatGWSubnet = chatGWArray[0] + "." + chatGWArray[1] + "." + chatGWArray[2];
            ConfigDMZSubnetBox.Text = chatGWSubnet;

            //produce every other IP
            DMZIPAddr = chatGWSubnet + ".0";
            DMZBQSIP = chatGWSubnet + ".1";
            DMZFirewallExt = chatGWSubnet + ".17";
            DMZFirewallMIP = chatGWSubnet + ".100";
            DMZFirewallExtWMS = chatGWSubnet + ".18";

            //commands to modify network objects
            string DMZNetObjChatGW = ("cf ipaddr modify name=\"DMZ BCIP Chat Gateway\" ipaddr=" + DMZchatGW);
            string DMZNetObjFWBqs = ("cf ipaddr modify name=\"DMZ BCIP Firewall BQS\" ipaddr=" + DMZBQSIP);
            string DMZNetObjFWExt1 = ("cf ipaddr modify name=\"DMZ BCIP Firewall External 1\" ipaddr=" + DMZFirewallExt);
            string DMZNetObjFWMip = ("cf ipaddr modify name=\"DMZ BCIP Firewall MIP\" ipaddr=" + DMZFirewallMIP);
            //NOT COMMONLY USED BUT IN USER GUIDE:
            //string DMZNetObjFWExtWMS = ("cf ipaddr modify name=\"DMZ BCIP Firewall External WMS\" ipaddr=" + DMZFirewallExtWMS);


            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;
            progressDMZNetwork.Value = 8;
            
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
            inputWriter.WriteLine(@" ""C:\Program FIles (x86) (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(1000);

            //give admin rights
            inputWriter.WriteLine("srole");
            progressDMZNetwork.Value = 20;
            Thread.Sleep(1000);

            //See if interfaces are connected. Dont think this checks if cable is plugged
            inputWriter.WriteLine("cf interface status name=\"DMZ BCIP\"");
            progressDMZNetwork.Value = 30;

            //Modify the network interface
            inputWriter.WriteLine("cf interface modify name=\"DMZ BCIP\" addresses=" + DMZBQSIP + "/24," + DMZFirewallExt + "/24," + DMZFirewallExtWMS + "/24," + DMZFirewallMIP + "/24");
            progressDMZNetwork.Value = 50;
            Thread.Sleep(3000);

            //modify network objects for DMZ
            //Best to put them all in one command to minimise the amount of thread.sleeps
            progressDMZNetwork.Value = 70;
            inputWriter.WriteLine(DMZNetObjChatGW + " & " + DMZNetObjFWBqs + " & " + DMZNetObjFWExt1 + " & " + DMZNetObjFWMip);
            Thread.Sleep(3000);

            //exit
            inputWriter.WriteLine("exit");
            inputWriter.WriteLine("exit");
            progressDMZNetwork.Value = 90;

            //Do i repeat for all of the services too?

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();

                string loginError = errorReader.ReadToEnd().ToString();
                errorOutput = DateTime.Now.ToString() + System.Environment.NewLine + " Error Output:  " + System.Environment.NewLine + loginError;

                //access denied will pop up if connected to the firewall and wrong username/pw info. FATAL ERROR is if not connected to firewall
                if (loginError.Contains("Access denied") || loginError.Contains("FATAL ERROR"))
                {
                    //If Plink connection fails throw error and return
                    MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    progressDMZNetwork.Value = 0;
                }
                else
                {
                    //Confirmation 
                    progressDMZNetwork.Value = 100;
                    MessageBox.Show("Interfaces and Network Objects configured for DMZ", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    configSuccess = true;
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressDMZNetwork.Value = 0;
            }

            string internalBNAUStatus = outputReader.ToString();
            if (internalBNAUStatus.Contains("Conn"))
            {
                DMZPlugged = true;
            }
            else
            {
                DMZPlugged = false;
            }

            //write error output to add to log file
            string lineBreak = "\n" + "------------------------------------------------------------";
            logPath = @"C:\Program FIles (x86) (x86)\General Dynamics UK\LDG Management Application\LMA_DMZConfig_Log.txt";

            try
            {
                //if file doesn't exist create it
                if (!File.Exists(logPath))
                {
                    File.Create(logPath).Dispose();
                    using (StreamWriter sw = File.CreateText(logPath))
                    {
                        sw.Write(errorOutput + System.Environment.NewLine + lineBreak);
                    }
                }
                //append to existing file
                else
                {
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        sw.Write(System.Environment.NewLine + errorOutput + System.Environment.NewLine + lineBreak);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Access to " + logPath + " denied. Log File not created.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (configSuccess == true)
            {
                //Hide current tab and show next
                DMZWizard.TabPages.Remove(networkTest);             
                DMZWizard.TabPages.Add(OSPF);
                DMZWizard.TabPages.Remove(NetworkConfig);
            }
            else
            {
                return;
            }
        }
        
        //
        //OSPF
        //

        private void returnNetworkConfig_Click(object sender, EventArgs e)
        {
            
            DMZWizard.TabPages.Remove(OSPF);
            DMZWizard.TabPages.Remove(networkTest);
            DMZWizard.TabPages.Add(NetworkConfig);
        }

        private void OSPFConfig_Click(object sender, EventArgs e)
        {
            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;

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
            StreamWriter inputWriter = plinkOSPFProcess.StandardInput;
            StreamReader outputReader = plinkOSPFProcess.StandardOutput;
            StreamReader errorReader = plinkOSPFProcess.StandardError;

            //this is the command to log in to the firewall
            inputWriter.WriteLine(@" ""C:\Program FIles (x86) (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 10;

            //If Plink connection fails throw error and return
            if (plinkOSPFProcess.HasExited)
            {
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Could try ping to firewall
                return;
            }

            //give admin rights
            inputWriter.WriteLine("srole");
            Thread.Sleep(500);
            progressDMZOSPF.Value = 10;

            //Telnet into the firewall OSPF Routing Server
            inputWriter.WriteLine("telnet localhost ospfd");
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 20;

            //Password is zebra
            inputWriter.WriteLine("zebra");
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 30;

            //Enable the full command set
            inputWriter.WriteLine("en");
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 40;

            //Enter Configuration mode
            inputWriter.WriteLine("conf t");
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 50;

            //Enable routing server
            inputWriter.WriteLine("router ospf");
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 60;

            //Edit the 2nd network to be the DMZ IP.
            inputWriter.WriteLine("network  " + DMZIPAddr + "/24 area 0");
            Thread.Sleep(1000);
            progressDMZOSPF.Value = 80;

            //Save the OSPF config file
            inputWriter.WriteLine("write");
            progressDMZOSPF.Value = 90;

            //exit srole
            inputWriter.WriteLine("exit");

            //exit putty
            inputWriter.WriteLine("exit");

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkOSPFProcess.Kill();
                progressDMZOSPF.Value = 100;
                MessageBox.Show("OSPF Routing configured for DMZ interface", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Show next tab
                
                DMZWizard.TabPages.Remove(OSPF);
                DMZWizard.TabPages.Add(networkTest);
                DMZWizard.TabPages.Remove(NetworkConfig);
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressDMZOSPF.Value = 0;
                return;
            }

        }

        //
        //Network Test
        //
        private void returnOSPF_Click(object sender, EventArgs e)
        {
            //Show next tab
            
            DMZWizard.TabPages.Add(OSPF);
            DMZWizard.TabPages.Remove(networkTest);
            DMZWizard.TabPages.Remove(NetworkConfig);
        }
        private void testButton_Click(object sender, EventArgs e)
        {
            Ping_ pingOnTime = new Ping_();
            //call the ping class, passing in the subnet
            pingOnTime.Ping_BNAU(chatGWSubnet, true);

            //get the results from the ping class
            Ping_ result_ = new Ping_();
            bool pingDMZResult = Ping_.BNAUPingable;

            //change BNAU Ping button
            if (pingDMZResult == true)
            {
                DMZPingSignal.FillColor = Color.Green;
                DMZPingable = true;
            }
            else
            {
                DMZPingSignal.FillColor = Color.Red;
            }

            //if BNAU is unplugged put color red
            if (DMZPlugged == true)
            {
                DMZInterfaceSignal.FillColor = Color.Green;
            }
            else
            {
                DMZInterfaceSignal.FillColor = Color.Red;
            }

            //universal error messages:
            //forst check connection is present
            if (DMZPlugged == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(false);
                return;
            }
            else if (pingDMZResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
            }
        }
    }
}
