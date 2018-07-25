using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace LDGManagementApplication
{
    class Putty
    {
        public static bool configSuccess, OSPFSuccess;
        public static string consoleOutput, errorLogOutput, errorOutput;

        public virtual string interfaceCommand
        {//placeholder to be overwritteen
            get
            {
                string interfaceCommand = "general";
                return interfaceCommand;
            }
        }

        public virtual string netObjCommand
        {//placeholder to be overwritteen
            get
            {
                string netObjCommand = "general";
                return netObjCommand;
            }
        }

        public virtual string interfaceStatusCommand
        {//placeholder to be overwritteen
            get
            {
                string interfaceStatusCommand = "general";
                return interfaceStatusCommand;
            }
        }
        public virtual string IPAddr
        {//placeholder to be overwritteen
            get
            {
                string IPAddr = "general";
                return IPAddr;
            }
        }

        public virtual string networkIDCommand
        {//placeholder to be overwritteen
            get
            {
                string networkIDCommand = "general";
                return networkIDCommand;
            }
        }

        public virtual string networkCommand
        {//placeholder to be overwritteen
            get
            {
                string networkCommand = "general";
                return networkCommand;
            }
        }
        public void Configure(string interfaceCommand, string netObjCommand, string IPAddr, string interfaceStatusCommand)
        {
            //retrieve information from userinput
            string username = MainGUI.username;
            string password = MainGUI.password;

            //start the command line process
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Windows\System32\cmd")
            {
                ErrorDialog = false,
                UseShellExecute = false,

                //hide the command window
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,

                //redirect the input and output
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            //start plink process
            Process plinkProcess = Process.Start(psi);
            StreamWriter inputWriter = plinkProcess.StandardInput;
            StreamReader outputReader = plinkProcess.StandardOutput;
            StreamReader errorReader = plinkProcess.StandardError;

            //get the connection ip from the config file
            string connectionIP = ConfigurationManager.AppSettings.Get("ConnectionIP");

            //this is the command to log in to the firewall
            inputWriter.WriteLine(@" ""C:\Program Files (x86)\PuTTY\plink.exe"" " + connectionIP + " -l " + username + " -pw " + password);
            Thread.Sleep(1500);

            //If Plink connection fails throw error and return
            if (plinkProcess.HasExited)
            {
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure");
                //Could try ping to firewall
                return;
            }

            //give admin rights
            inputWriter.WriteLine("srole");
            Thread.Sleep(200);

            inputWriter.WriteLine(interfaceCommand);
            Thread.Sleep(1000);

            inputWriter.WriteLine(netObjCommand);
            Thread.Sleep(1000);

            //ping BNAU for 2 counts
            inputWriter.WriteLine("ping -c 2 " + IPAddr);
            Thread.Sleep(1000);

            //check if interface is up, search for "status: active" 
            inputWriter.WriteLine(interfaceStatusCommand);
            Thread.Sleep(1000);

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
                errorLogOutput = DateTime.Now.ToString() + System.Environment.NewLine + errorOutput;

                //access denied will pop up if connected to the firewall and wrong username/pw info. FATAL ERROR is if not connected to firewall
                if (errorOutput.Contains("Access denied") || errorOutput.Contains("FATAL ERROR"))
                {
                    //If Plink connection fails throw error and return
                    MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    configSuccess = false;
                    return;
                }
                else
                {
                    //Confirmation 
                    MessageBox.Show("Interface and Network Objects configured for Internal System", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    configSuccess = true;
                    return;
                }
            }
            catch (Exception)
            {               
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                configSuccess = false;
                return;
            }
        }

        //Set up another connection with Putty to configure OSPF//
        public void Configure_OSPF(string networkIDCommand, string networkCommand)
        {
            //retrieve information from userinput
            string username = MainGUI.username;
            string password = MainGUI.password;
                        
            //start the command line process
            ProcessStartInfo psi = new ProcessStartInfo(@"C:\Windows\System32\cmd")
            {
                ErrorDialog = false,
                UseShellExecute = false,

                //hide the command window
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,

                //redirect the input and output and error
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true
            };

            //start plink process
            Process plinkOSPFProcess = Process.Start(psi);
            StreamWriter inputOSPFWriter = plinkOSPFProcess.StandardInput;
            StreamReader outputOSPFReader = plinkOSPFProcess.StandardOutput;
            StreamReader errorOSPFReader = plinkOSPFProcess.StandardError;

            //get the connection ip from the config file
            string connectionIP = ConfigurationManager.AppSettings.Get("ConnectionIP");

            //this is the command to log in to the firewall
            inputOSPFWriter.WriteLine(@" ""C:\Program Files (x86)\PuTTY\plink.exe"" " + connectionIP + " -l " + username + " -pw " + password);
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

            //Telnet into the firewall OSPF Routing Server
            inputOSPFWriter.WriteLine("telnet localhost ospfd");
            Thread.Sleep(1000);

            //Password is zebra
            inputOSPFWriter.WriteLine("zebra");
            Thread.Sleep(500);

            //Enable the full command set
            inputOSPFWriter.WriteLine("en");
            Thread.Sleep(500);

            //Enter Configuration mode
            inputOSPFWriter.WriteLine("conf t");
            Thread.Sleep(500);

            //Enable routing server
            inputOSPFWriter.WriteLine("router ospf");
            Thread.Sleep(1000);

            //remove default IPs
            inputOSPFWriter.WriteLine("no network 1.1.1.1/24 area 0");
            Thread.Sleep(500);
            inputOSPFWriter.WriteLine("no network 2.2.2.2/24 area 0");
            Thread.Sleep(500);

            //Edit the router-id to be the firewallIP
            inputOSPFWriter.WriteLine(networkIDCommand);
            Thread.Sleep(1000);

            //Edit the netowrk IPs
            inputOSPFWriter.WriteLine(networkCommand);
            Thread.Sleep(1000);

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
                MessageBox.Show("OSPF Routing configured for Internal interface", "Firewall Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OSPFSuccess = true;
                return;
                //Show next tab

            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OSPFSuccess = false;
                return;
            }        
        }
    }

    class Internal : Putty
    {
        //public override string interfaceCommand
        //{
        //    //get
        //    //{
        //    //    string interfaceCommand = ("cf interface modify name=\"Internal BCIP\" addresses=" + firewallIPAddr + "/24");
        //    //    return interfaceCommand;
        //    //}
        //}
        public void Internal_Config(string internalIPAddr, string firewallIPAddr)
        {
            //define the internal commands
            string internalInterfaceCommand = ("cf interface modify name=\"Internal BCIP\" addresses=" + firewallIPAddr + "/24");
            string internalObjectsCommand = ("cf ipaddr modify name=\"Internal BCIP BNAU\" ipaddr=" + internalIPAddr +
                " & " + "cf ipaddr modify name=\"Internal BCIP Firewall\" ipaddr=" + firewallIPAddr);
            string interfaceStatusCommand = "ifconfig 1-6";

            //call putty passing in the internal commands
            Putty configureInternalFW = new Putty();
            configureInternalFW.Configure(internalInterfaceCommand, internalObjectsCommand, internalIPAddr, interfaceStatusCommand);
        }

        public void OSPF_Config(string internalIPAddr, string firewallIPAddr)
        {
            string networkIDCommand = ("router-id " + firewallIPAddr);
            string networkCommand = ("network  " + internalIPAddr + "/24 area 0");

            Putty configureInternalOSPF = new Putty();
            configureInternalOSPF.Configure_OSPF(networkIDCommand, networkCommand);
        }                     
    }

    class DMZ : Putty
    {
        public void DMZ_Config(string DMZchatGW)
        {
            //produce the other IPs
            string[] chatGWArray = DMZchatGW.Split('.');
            string chatGWSubnet = chatGWArray[0] + "." + chatGWArray[1] + "." + chatGWArray[2];

            //retrieve fourth octets of IP's from config file
            string DMZIP_FO = ConfigurationManager.AppSettings.Get("DMZIP");
            string DMZBQSIP_FO = ConfigurationManager.AppSettings.Get("BNAUIP");
            string DMZFirewallExt_FO = ConfigurationManager.AppSettings.Get("FirewallIP");
            string DMZFirewallMIP_FO = ConfigurationManager.AppSettings.Get("DMZFirewallMIP");
            string DMZFirewallExtWMS_FO = ConfigurationManager.AppSettings.Get("DMZFirewallExtWMS");

            //produce every other IP from the subnet and the fourth octets
            string DMZIPAddr = chatGWSubnet + DMZIP_FO;
            string DMZBQSIP = chatGWSubnet + DMZBQSIP_FO;
            string DMZFirewallExt = chatGWSubnet + DMZFirewallExt_FO;
            string DMZFirewallMIP = chatGWSubnet + DMZFirewallMIP_FO;
            string DMZFirewallExtWMS = chatGWSubnet + DMZFirewallExtWMS_FO;

            //sub commands for netowrk objects
            string DMZNetObjChatGW = ("cf ipaddr modify name=\"DMZ BCIP Chat Gateway\" ipaddr=" + DMZchatGW);
            string DMZNetObjFWBqs = ("cf ipaddr modify name=\"DMZ BCIP Firewall BQS\" ipaddr=" + DMZBQSIP);
            string DMZNetObjFWExt1 = ("cf ipaddr modify name=\"DMZ BCIP Firewall External 1\" ipaddr=" + DMZFirewallExt);
            string DMZNetObjFWMip = ("cf ipaddr modify name=\"DMZ BCIP Firewall MIP\" ipaddr=" + DMZFirewallMIP);

            //define the DMZ commands
            string DMZInterfaceCommand = ("cf interface modify name=\"DMZ BCIP\" addresses=" + DMZBQSIP + "/24," + DMZFirewallExt + "/24," + DMZFirewallExtWMS + "/24," + DMZFirewallMIP + "/24");
            string DMZObjectsCommand = (DMZNetObjChatGW + " & " + DMZNetObjFWBqs + " & " + DMZNetObjFWExt1 + " & " + DMZNetObjFWMip);
            string interfaceStatusCommand = "ifconfig 1-1";

            Putty runPutty = new Putty();
            runPutty.Configure(DMZInterfaceCommand, DMZObjectsCommand, DMZIPAddr, interfaceStatusCommand);
        }
        public void OSPF_Config(string DMZIPAddr)
        {
            string networkIDCommand = ("");//dont want to change network id
            string networkCommand = ("network  " + DMZIPAddr + "/24 area 0");

            Putty configureInternalOSPF = new Putty();
            configureInternalOSPF.Configure_OSPF(networkIDCommand, networkCommand);
        }
    }

    class External : Putty
    {
        public void External_Config(string extRouterIP, string extFWIP, string extFWMask)
        {
            string externalInterfaceCommand = ("cf interface modify name=\"External System 1\" addresses=" + extFWIP + "/" + extFWMask);
            string externalObjectsCommand = "";
            string externalStatusCommand = ("ifconfig 2-0");

            Putty runPutty = new Putty();
            runPutty.Configure(externalInterfaceCommand, externalObjectsCommand, extRouterIP, externalStatusCommand);
        }
    }

    class Tracks : Putty
    {
        public void Tracks_Config(string tracksSelectedIP, string externalTracksIP)
        {
            //frig it so that the interface command is actually tracks rules set up
            string tracksRulesCommand = ("cf policy modify name=\"Tracks to External 1\" disable=no & cf policy modify name =\"Tracks from External 1\" disable=no");
            string tracksObjectsCommand = ("cf ipaddr modify name=\"DMZ BCIP Tracks Gateway\" ipaddr=" + tracksSelectedIP +
                " & cf ipaddr modify name=\"External 1 Tracks Server\" ipaddr=" + externalTracksIP);

            //dont have an interface for tracks, instead we want to ping the external server
            string interfaceStatusCommand = "ping -c 2 " + externalTracksIP;

            //call putty passing in the internal commands
            Putty configureInternalFW = new Putty();
            configureInternalFW.Configure(tracksRulesCommand, tracksObjectsCommand, tracksSelectedIP, interfaceStatusCommand);
        }
    }

    class Mail : Putty
    {
        public void Mail_Config(string mailSelectedIP, string externalMailIP)
        {
            //frig it so that the interface command is actually tracks rules set up
            string mailRulesCommand = ("cf policy modify name=\"Email to External 1\" disable=no & cf policy modify name =\"Email from External 1\" disable=no");
            string mailObjectsCommand = ("cf ipaddr modify name=\"DMZ BCIP Email Gateway - External\" ipaddr=" + mailSelectedIP +
                " & cf ipaddr modify name=\"External 1 Email Server\" ipaddr=" + externalMailIP);

            //dont have an interface for tracks, instead we want to ping the external server
            string interfaceStatusCommand = "ping -c 2 " + externalMailIP;

            //call putty passing in the internal commands
            Putty configureInternalFW = new Putty();
            configureInternalFW.Configure(mailRulesCommand, mailObjectsCommand, mailSelectedIP, interfaceStatusCommand);
        }
    }

    class Chat : Putty
    {
        public void Chat_Config(string mailSelectedIP, string externalMailIP)
        {
            //frig it so that the interface command is actually tracks rules set up
            string mailRulesCommand = ("cf policy modify name=\"Chat to External 1\" disable=no & cf policy modify name =\"Chat from External 1\" disable=no");
            string mailObjectsCommand = ("cf ipaddr modify name=\"External 1 Chat Server\" ipaddr=" + externalMailIP);

            //dont have an interface for tracks, instead we want to ping the external server
            string interfaceStatusCommand = "ping -c 2 " + externalMailIP;

            //call putty passing in the internal commands
            Putty configureInternalFW = new Putty();
            configureInternalFW.Configure(mailRulesCommand, mailObjectsCommand, mailSelectedIP, interfaceStatusCommand);
        }
    }

    class OSW : Putty
    {
        public void OSW_Config(string mailSelectedIP, string externalMailIP)
        {
            //frig it so that the interface command is actually tracks rules set up
            string mailRulesCommand = ("cf policy modify name=\"OSW WMS External 1\" disable=no");
            string mailObjectsCommand = ("cf ipaddr modify name=\"DMZ BCIP OSW Gateway\" ipaddr=" + mailSelectedIP +
                " & cf ipaddr modify name=\"External 1 Sharepoint Server\" ipaddr=" + externalMailIP);
            //and sharepoint URL??

            //dont have an interface for tracks, instead we want to ping the external server
            string interfaceStatusCommand = "ping -c 2 " + externalMailIP;

            //call putty passing in the internal commands
            Putty configureInternalFW = new Putty();
            configureInternalFW.Configure(mailRulesCommand, mailObjectsCommand, mailSelectedIP, interfaceStatusCommand);
        }
    }
}