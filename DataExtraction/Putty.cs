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
    //this is the abstract class that forms the basis for all putty interactions with the firewall. 
    //what strings that will passed into Putty depend on which dervied class is called
     public abstract class Putty
     {
        public static bool configSuccess, OSPFSuccess;
        public static string consoleOutput, errorLogOutput, errorOutput, firewallIPAddr, internalIPAddr, chatGW, extRouterIP, extFWIP, extFWMask, selectedIP, externalIP;
        public abstract string interfaceCommand
        {
            get;
        }
        public abstract string netObjCommand
        {
            get;
        }
        public abstract string interfaceStatusCommand
        {
            get;
        }

        public void Configure()
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

            //ping BNAU for 3 counts
            inputWriter.WriteLine("ping -c 2 " + internalIPAddr);
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
        public void Configure_OSPF()
        {
            string networkIDCommand = ("router-id " + firewallIPAddr);
            string networkCommand = ("network  " + internalIPAddr + "/24 area 0");

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
}