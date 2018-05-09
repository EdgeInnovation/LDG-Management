using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace DataExtraction
{
    class Putty
     //NOT SURE IF THIS CAN BE DONE BY CALLING AS A CLASS
    {
        string errorOutput, logPath;
        
        public void ConfigureButton_Click(string internalIPAddr, string firewallIPAddr, string username, string password)
        {
            bool BNAUPlugged;
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

            //this is the command to log in to the firewall
            inputWriter.WriteLine(@" ""C:\Program Files (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(2000);

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

            //modify network objects for BNAU and firewall
            inputWriter.WriteLine("cf ipaddr modify name=\"Internal BCIP BNAU\" ipaddr=" + internalIPAddr);
            Thread.Sleep(1000);
            inputWriter.WriteLine("cf ipaddr modify name=\"Internal BCIP Firewall\" ipaddr=" + firewallIPAddr);//currently 10.17.0.17
            Thread.Sleep(1000);

            //Modify the network interfaces
            inputWriter.WriteLine("cf interface modify name=\"Internal BCIP\" addresses=" + internalIPAddr + "/24");
            Thread.Sleep(1000);
            //inputWriter.WriteLine("cf interface modify name=\"Internal BCIP Firewall\" addresses=" + firewallIPAddr + "/24");//check if this is right
            //Thread.Sleep(1000);

            //See if interfaces are connected
            inputWriter.WriteLine("cf interface status name=\"Internal BCIP\"");

            string internalBNAUStatus = outputReader.ToString();
            if (!internalBNAUStatus.Contains("Disc"))
            {
                BNAUPlugged = true;
            }
            else
            {
                BNAUPlugged = false;
            }

            //exit
            inputWriter.WriteLine("exit");
            Thread.Sleep(200);
            inputWriter.WriteLine("exit");

            //write error output to add to log file
            errorOutput = DateTime.Now.ToString() + ":  " + errorReader.ReadToEnd().ToString();
            string lineBreak = "\n" + "------------------------------------------------------------";

            //kill process;
            try
            {
                plinkProcess.Kill();
                //Confirmation
                MessageBox.Show("Network interfaces and Network Objects configured for BNAU and BCIP Firewall interface", "Firewall Configuration Complete");
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure");
            }

            //Log the output to a text file:
            logPath = @"C:\Program Files\General Dynamics UK\LDG Management Application\LMA_Log.txt";

            //if file doesn't exist create it
            if (!File.Exists(logPath))
            {
                File.Create(logPath).Dispose();
                using (StreamWriter sw = File.CreateText(logPath))
                {
                    sw.Write(errorOutput + lineBreak);
                }
            }
            //append to existing file
            else
            {

                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.Write(System.Environment.NewLine + errorOutput + lineBreak);
                }
            }
        }
    }
}
