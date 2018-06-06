using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace LDGManagementApplication
{
    class Ping_
    {
        //these are the public bools that will be used in the main class
        public static bool pingResult;        
        string username, password, consoleOutput;
        public void Ping_From_FW(string ipAddress)
        {
            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;
           
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
            Thread.Sleep(1000);

            //give admin rights
            inputWriter.WriteLine("srole");
            Thread.Sleep(1000);

            //ping
            inputWriter.WriteLine("ping -c 2 " + ipAddress);
            Thread.Sleep(1000);

            //exit
            inputWriter.WriteLine("exit");
            inputWriter.WriteLine("exit");
            
            //Do i repeat for all of the services too?

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();
                consoleOutput = outputReader.ReadToEnd().ToString();
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //get the ping success result
            if (consoleOutput.Contains("bytes from " + ipAddress))
            {
                pingResult = true;
            }
            else
            {
                pingResult = false;
            }

        }
    }
}
