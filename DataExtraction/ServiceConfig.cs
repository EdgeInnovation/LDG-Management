using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DataExtraction
{
    public partial class ServiceConfig : Form
    {
        public ServiceConfig()
        {
            InitializeComponent();
            ExternalWizard.TabPages.Remove(chatTab);
            ExternalWizard.TabPages.Remove(chooseServicesTab);
            ExternalWizard.TabPages.Remove(tracksTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);

            //grab the bools from each other form to set the lights on the home page
            //INTERNAL
            if (InternalConfig.intBNAUPingable == true)
            {
                BNAUPingSignal.FillColor = Color.Green;
            }
            else
            {
                BNAUPingSignal.FillColor = Color.Red;
            }

            if (InternalConfig.intFWPingable == true)
            {
                FWPingSignal.FillColor = Color.Green;
            }
            else
            {
                FWPingSignal.FillColor = Color.Red;
            }

            //DMZ
            if (DMZConfig.DMZPingable == true)
            {
                DMZPingSignal.FillColor = Color.Green;
            }
            else
            {
                DMZPingSignal.FillColor = Color.Red;
            }

            //EXTERNAL
            if (ExternalConfig.extFirewallPingable == true)
            {
                ExtInterfacePingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtInterfacePingSignal.FillColor = Color.Red;
            }

            if (ExternalConfig.extRouterPingable == true)
            {
                ExtRouterPingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtRouterPingSignal.FillColor = Color.Red;
            }                     
        }
        string username, password, tracksSelectedTerminalFull, tracksSelectedIP, loginError, externalTracksIP;
        //
        // Home Tab
        //

        private void nextToChoose_Click(object sender, EventArgs e)
        {
            //only advance if all are green
            if (InternalConfig.intBNAUPingable == true && InternalConfig.intFWPingable == true && DMZConfig.DMZPingable == true && ExternalConfig.extFirewallPingable && ExternalConfig.extRouterPingable == true)
            {
                ExternalWizard.TabPages.Add(chooseServicesTab);
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
            }
            else
            {
                //show standard error/help
                //for now put it yes or no dialog but this can be removed
                //MessageBox.Show("Please Configure the Internal, DMZ and External Systems succesfully before continuing", "Configure all other systems first");

                DialogResult dialogResult = MessageBox.Show("Internal, DMZ and External systems have not been successfully configured. Continue anyway?", "Configure all other systems first", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    ExternalWizard.TabPages.Add(chooseServicesTab);
                    ExternalWizard.TabPages.Remove(chatTab);
                    ExternalWizard.TabPages.Remove(homeTab);
                    ExternalWizard.TabPages.Remove(tracksTab);
                    ExternalWizard.TabPages.Remove(tracksNetworkTab);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }


        //
        // Choose Services Tab
        //

        //Next button on choose page
        private void nextFromChoose_Click(object sender, EventArgs e)
        {
            //if no services are selected throw error
            if (!chatCheckBox.Checked && !mailCheckBox.Checked && !OSWCheckBox.Checked && !tracksCheckBox.Checked)
            {
                MessageBox.Show("Please select a service to configure", "Error");
            }

            if (tracksCheckBox.Checked)
            {
                //if tracks is selected go to tracks tab etc..
                ExternalWizard.TabPages.Add(tracksTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);

                //Show the terminals for the tracks tab:
                //call the extract data class, saying that this isn't the LDG plan and get the list 
                ExtractData extractList = new ExtractData();
                extractList.Extract_Data(true);
                List<string> serviceRolesList = extractList.GetServiceList();

                tracksListView.Scrollable = true;
                tracksListView.View = View.Details;
                tracksListView.HeaderStyle = ColumnHeaderStyle.None;

                ColumnHeader header = new ColumnHeader();
                header.Text = "Terminals";
                header.Name = "Terminals";
                tracksListView.Columns.Add(header);
                header.Width = tracksListView.Width;

                //Display the services for user to select
                foreach (string service in serviceRolesList)
                {
                    tracksListView.Items.Add(service);
                }

            }
            else if (chatCheckBox.Checked)
            {
                ExternalWizard.TabPages.Add(chatTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
            }
            else if (OSWCheckBox.Checked)
            {
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
            }
            else if (mailCheckBox.Checked)
            {
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
            }
        }
        
        private void backToHome_Click(object sender, EventArgs e)
        {
            ExternalWizard.TabPages.Add(homeTab);
            ExternalWizard.TabPages.Remove(chatTab);
            ExternalWizard.TabPages.Remove(chooseServicesTab);
            ExternalWizard.TabPages.Remove(tracksTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);
        }
        
        //
        // Tracks Tab
        //

        private void chooseFromTracks_Click(object sender, EventArgs e)
        {
            ExternalWizard.TabPages.Add(chooseServicesTab);
            ExternalWizard.TabPages.Remove(chatTab);
            ExternalWizard.TabPages.Remove(homeTab);
            ExternalWizard.TabPages.Remove(tracksTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);
        }

        //next page from tracks
        private void configureTracks_Click(object sender, EventArgs e)
        {            
            ListView.SelectedListViewItemCollection selectedItems = new ListView.SelectedListViewItemCollection(tracksListView);
            externalTracksIP = externalTracksBox.Text;

            //3 requirements before allowing to configure:
            //if no terminal is selected throw error
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Terminal", "No terminal selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if more than one item is Selected throw error
            else if (selectedItems.Count > 1)
            {
                MessageBox.Show("Please Only Select One Terminal", "Too many terminals selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if external box is empty dont allow configure
            else if (externalTracksIP == "")
            {
                MessageBox.Show("Please enter the External Tracks Server IP Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //otherwise use the selected item
            tracksSelectedTerminalFull = selectedItems[0].Text;

            //get the ip from the fuill line
            string[] tracksSelectedIPArray = tracksSelectedTerminalFull.Split('"');
            tracksSelectedIP = tracksSelectedIPArray[2];
            trackProgress.Value = 5;

            //retrieve information from userinput
            username = MainGUI.username;
            password = MainGUI.password;
            trackProgress.Value = 8;
       
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
            inputWriter.WriteLine(@" ""C:\Program FIles (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(1000);

            //give admin rights
            inputWriter.WriteLine("srole");
            trackProgress.Value = 20; 
            tracksProgressLabel.Text = "Modifying Tracks Network Object...";
            Thread.Sleep(1000);

            //modify network object for internal tracks server
            inputWriter.WriteLine("cf ipaddr modify name=\"DMZ BCIP Tracks Gateway\" ipaddr=" + tracksSelectedIP);
            trackProgress.Value = 50;
            Thread.Sleep(1000);
            
            //modify network object for external tracks server
            inputWriter.WriteLine("cf ipaddr modify name=\"External 1 Tracks Server\" ipaddr=" + externalTracksIP);
            trackProgress.Value = 60;
            Thread.Sleep(1000);

            //enable the tracks rules:
            tracksProgressLabel.Text = "Configuring Tracks Policy Rules...";
            inputWriter.WriteLine("cf policy modify name=\"Tracks to External 1\" disable=no");
            trackProgress.Value = 70;
            Thread.Sleep(1000);

            inputWriter.WriteLine("cf policy modify name=\"Tracks from External 1\" disable=no");
            trackProgress.Value = 80;
            Thread.Sleep(1000);

            //exit
            inputWriter.WriteLine("exit");
            inputWriter.WriteLine("exit");
            trackProgress.Value = 90;

            //Do i repeat for all of the services too?

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();
                
                loginError = errorReader.ReadToEnd().ToString();
               
                //access denied will pop up if connected to the firewall and wrong username/pw info. FATAL ERROR is if not connected to firewall
                if (loginError.Contains("Access denied") || loginError.Contains("FATAL ERROR"))
                {
                    //If Plink connection fails throw error and return
                    MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    trackProgress.Value = 0;
                    tracksProgressLabel.Text = "Error";
                }
                else
                {
                    //Confirmation 
                    trackProgress.Value = 100;
                    MessageBox.Show("Network Objects and Access Control Rules configured for Tracks", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tracksProgressLabel.Text = "Job Complete";

                    //go to chat tab if its selected
                    if (chatCheckBox.Checked)
                    {
                        ExternalWizard.TabPages.Add(tracksNetworkTab);
                        ExternalWizard.TabPages.Remove(chooseServicesTab);
                        ExternalWizard.TabPages.Remove(chatTab);
                        ExternalWizard.TabPages.Remove(homeTab);
                        ExternalWizard.TabPages.Remove(tracksTab);
                    }
                    else
                    {
                        //put next tab here when made
                        return;
                    }
                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trackProgress.Value = 0;
                tracksProgressLabel.Text = "Error";
            }
        }

        //
        // Tracks Net test Tab
        //

        //back to tracks from tracks net test
        private void backFromTracksNet_Click(object sender, EventArgs e)
        {
            ExternalWizard.TabPages.Remove(chooseServicesTab);
            ExternalWizard.TabPages.Remove(chatTab);
            ExternalWizard.TabPages.Remove(homeTab);
            ExternalWizard.TabPages.Add(tracksTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);
        }
        private void tracksNetTestButton_Click(object sender, EventArgs e)
        {
            //Ping the ext firewall intercae
            Ping_ pingIntTracks = new Ping_();
            pingIntTracks.Ping_External(tracksSelectedIP);
            bool pingIntTracksResult = Ping_.externalPingable;

            if (pingIntTracksResult == true)
            {
                IntTracksPingSignal.FillColor = Color.Green;
            }
            else
            {
                IntTracksPingSignal.FillColor = Color.Red;
            }

            //Ping the ext router
            Ping_ pingExtTracks = new Ping_();
            pingExtTracks.Ping_External(externalTracksIP);
            bool pingExtTracksResult = Ping_.externalPingable;

            //change BNAU Ping button
            if (pingExtTracksResult == true)
            {
                ExtTracksPingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtTracksPingSignal.FillColor = Color.Red;
            }

            //universal error
            if (pingIntTracksResult == false || pingExtTracksResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
                return;
            }
        }

        //
        // Chat Tab
        //

        //back to choose from chat
        private void chooseFromChat_Click(object sender, EventArgs e)
        {
            ExternalWizard.TabPages.Add(chooseServicesTab);
            ExternalWizard.TabPages.Remove(chatTab);
            ExternalWizard.TabPages.Remove(homeTab);
            ExternalWizard.TabPages.Remove(tracksTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);
        }
    }
}
