using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DataExtraction
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            //event handler for changing tabs in form
            TabControl.SelectedIndexChanged += new EventHandler(TabControl_SelectedIndexChanged);
        }

        //set the public username and password for firewall
        public static string username, password;
        
        //public method used by all netowrk tests. Bool determines whether it is a ping test or not (connection down)
        public void errorDialog(bool ping)
        {
            if (ping == true)
            {
                //public standard error message for failed ping test:
                DialogResult errorDialog = MessageBox.Show("Ping failed. Please ensure you have selected the correct plan or the IP address is correct.", "Network Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ping == false)
            {
                //public standard error message for failed connection test:
                DialogResult errorDialog = MessageBox.Show("Network connection failed. Please make sure the network cable is plugged in to the correct ports.", "Connection not Present", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        //
        //DATA EXTRACTION
        //

        private void BNAUConfigButton_Click(object sender, EventArgs e)
        {
            //if username or password is empty dont continue
            if (usernameBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please enter a Username or Password before continuing", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                username = usernameBox.Text;
                password = passwordBox.Text;
                //show the BNAU 'wizard'
                InternalConfig BNAUForm = new InternalConfig();
                BNAUForm.Show();
            }
        }
        private void DMZConfigButton_Click(object sender, EventArgs e)
        {
            //if username or password is empty dont continue
            if (usernameBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please enter a Username or Password before continuing", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                username = usernameBox.Text;
                password = passwordBox.Text;
                //show the DMZ 'wizard'
                DMZConfig DMZForm = new DMZConfig();
                DMZForm.Show();
            }
        }
        private void externalButton_Click(object sender, EventArgs e)
        {
            //if username or password is empty dont continue
            if (usernameBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please enter a Username or Password before continuing", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                username = usernameBox.Text;
                password = passwordBox.Text;
                //show the External 'wizard'
                ExternalConfig externalForm = new ExternalConfig();
                externalForm.Show();
            }

        }

        private void serviceConfigButton_Click(object sender, EventArgs e)
        {
            //if username or password is empty dont continue
            if (usernameBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please enter a Username or Password before continuing", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                DialogResult dialogBox = MessageBox.Show("Have you initialised the virtual machines you wish to configure?" 
                    + System.Environment.NewLine + "Press Yes to continue with service configuration or No to cancel and initialise the VM's." 
                    + System.Environment.NewLine + "The plan files are copied to the shared virtual disk (E:) as part of the internal configuration",
                    "Initialise Virtual Machines Before Continuing", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogBox == DialogResult.Yes)
                {
                    username = usernameBox.Text;
                    password = passwordBox.Text;
                    //show the Services 'wizard'
                    ServiceConfig servicesForm = new ServiceConfig();
                    servicesForm.Show();
                }
                else if (dialogBox == DialogResult.No)
                {
                    return;
                }
            }
        }
        //
        //MONITORING TAB
        //

        //starts the timer when monitoring tab is selected, and stops when configuration tab is selected
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                //configuration tab
                case 0:
                    pingTimer.Stop();
                    break;
                //Monitoring Tab
                case 1:
                    //Add in the subnet from the config then start timer
                    MonitorBNAUSubnetBox.Text = InternalConfig.BNAUSubnetIP;
                    pingTimer.Start();
                    break;
            }
        }
            
        //timer that is set up in design time to ping
        public void pingTimer_Tick(object sender, EventArgs e)
        {
            string BNAUSubnetIP = MonitorBNAUSubnetBox.Text;
            if (BNAUSubnetIP == "")
            {
                pingTimer.Stop();
                MessageBox.Show("Please enter the BNAU subnet IP Address to Monitor", "Error");                
                return;
            }
            
            Ping_ pingOnTime = new Ping_();
            //call the ping class, passing in the subnet
            pingOnTime.Ping_BNAU(BNAUSubnetIP, false);

            //get the results from the ping class
            bool pingBNAUResult = Ping_.BNAUPingable;
            bool pingFirewallResult = Ping_.firewallPingable;

            //change BNAU Ping button
            if (pingBNAUResult == true)
            {
                BNAUPingControl.FillColor = Color.Green;
            }
            else
            {
                BNAUPingControl.FillColor = Color.Red;
            }

            //change firewall ping button
            if (pingFirewallResult == true)
            {
                firewallPingControl.FillColor = Color.Green;
            }
            else
            {
                firewallPingControl.FillColor = Color.Red;
            }

            //for demo just stop the timer to stop it lagging
            pingTimer.Stop();

            //standard error:
            if (pingBNAUResult == false || pingFirewallResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
            }
        }
    }
}


