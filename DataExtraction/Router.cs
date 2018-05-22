using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDGMangementApplication
{
    public partial class Router : Form
    {
        public Router()
        {
            InitializeComponent();
        }
        string username, password, statusOutput;

        private void routerStatusButton_Click(object sender, EventArgs e)
        {
            //retrieve information from userinput
            username = routerUsernameBox.Text;
            password = routerPasswordBox.Text;

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

            //router commands...

            //get status:
            inputWriter.WriteLine("sh diag");

            //kill process
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();
                //output to box
                statusOutput = outputReader.ReadToEnd().ToString();
                routerStatusBox.Text = statusOutput;
            }
            catch
            {
                throw;
            }
        }
    }
}
