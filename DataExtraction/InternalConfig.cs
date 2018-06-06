using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace LDGManagementApplication
{
    public partial class InternalConfig : Form
    {
        public InternalConfig()
        {
            InitializeComponent();
            BNAUWizard.TabPages.Clear();
            BNAUWizard.TabPages.Add(Network);
        }

        public static string BNAUSubnetIP, firewallIPAddr;
        public static bool pingBNAUResult;
        string  internalIPAddr;
        bool BNAUPlugged;

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

            //call the putty internal class
            Internal internalConfig = new Internal();
            internalConfig.Internal_Config(internalIPAddr, firewallIPAddr);

            progressIntNetwork.Value = 80;

            //get the ping success result
            if (Internal.consoleOutput.Contains("bytes from " + internalIPAddr))
            {
                pingBNAUResult = true;
            }
            else
            {
                pingBNAUResult = false;
            }

            //determine whether cable is connected from ifconfig status
            if (Internal.consoleOutput.Contains("status: active"))
            {
                BNAUPlugged = true;
            }
            else
            {
                BNAUPlugged = false;
            }
            progressIntNetwork.Value = 85;
            //write log file
            WriteLog writeLog = new InternalLog();
            writeLog.WriteLogFile();
            progressIntNetwork.Value = 90;

            //go to next page if it succeeded
            if (Internal.configSuccess == true)
            {
                progressIntNetwork.Value = 100;
                //Hide current tab and show next
                BNAUWizard.TabPages.Clear();
                BNAUWizard.TabPages.Add(OSPF);
            }
            else
            {
                progressIntNetwork.Value = 0;
                return;
            }
        }

        //
        //OSPF
        //

        private void OSPFConfig_Click(object sender, EventArgs e)
        {
            Internal internalOSPF = new Internal();
            internalOSPF.OSPF_Config(internalIPAddr, firewallIPAddr);

            //go to next page if it succeeded
            if (Internal.OSPFSuccess == true)
            {
                //Hide current tab and show next
                BNAUWizard.TabPages.Clear();
                BNAUWizard.TabPages.Add(networkTest);
            }
            else
            {
                return;
            }
        }

        //return to network config page from OSPF page
        private void returnNetworkTest_Click(object sender, EventArgs e)
        {
            BNAUWizard.TabPages.Clear();
            BNAUWizard.TabPages.Add(Network);
        }

        //return to config tab from test tab
        private void returnConfig_Click(object sender, EventArgs e)
        {
            BNAUWizard.TabPages.Clear();
            BNAUWizard.TabPages.Remove(Network);
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