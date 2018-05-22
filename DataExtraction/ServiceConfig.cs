using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LDGMangementApplication
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
            ExternalWizard.TabPages.Remove(chatNetworkTab);

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

            //DMZ
            if (DMZConfig.DMZConnected == true)
            {
                DMZInterfaceSignal.FillColor = Color.Green;
            }
            else
            {
                DMZInterfaceSignal.FillColor = Color.Red;
            }

            //EXTERNAL
            if (ExternalConfig.extRouterPingable == true)
            {
                ExtRouterPingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtRouterPingSignal.FillColor = Color.Red;
            }                     
        }
        string username, password, tracksSelectedTerminalFull, tracksSelectedIP, loginError, externalTracksIP, consoleOutput;
        bool pingIntTracksResult, pingExtTracksResult;
        //
        // Home Tab
        //

        private void nextToChoose_Click(object sender, EventArgs e)
        {
            //only advance if all are green
            if (InternalConfig.intBNAUPingable == true && DMZConfig.DMZConnected == true && ExternalConfig.extRouterPingable == true)
            {
                ExternalWizard.TabPages.Add(chooseServicesTab);
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
                ExternalWizard.TabPages.Remove(chatNetworkTab);
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
                    ExternalWizard.TabPages.Remove(chatNetworkTab);
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
                MessageBox.Show("Please select a service to configure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Show the terminals for the tracks and chat listviews:
            //call the extract data class, and get the list 
            ExtractData extractList = new ExtractData();
            extractList.Extract_LDG_Data();
            List<string> serviceRolesList = extractList.GetServiceList();

            //get the first dns from the bec file to compare against user selection (second in list)
            List<string> LDGList = extractList.GetLDGList();

            //check path isnt null
            string path = ExtractData.DMZBecFilePath;
            if (path == null)
            {
                return;
            }

            firstDNS = LDGList[2];

            chatListView.Scrollable = true;
            chatListView.View = View.Details;
            chatListView.HeaderStyle = ColumnHeaderStyle.None;
            tracksListView.Scrollable = true;
            tracksListView.View = View.Details;
            tracksListView.HeaderStyle = ColumnHeaderStyle.None;

            //create the headers
            ColumnHeader tracksHeader = new ColumnHeader();
            ColumnHeader chatHeader = new ColumnHeader();

            tracksHeader.Text = "Terminals";
            tracksHeader.Name = "Terminals";
            chatHeader.Text = "Terminals";
            chatHeader.Name = "Terminals";
            chatListView.Columns.Add(chatHeader);
            chatHeader.Width = chatListView.Width;
            tracksListView.Columns.Add(tracksHeader);
            tracksHeader.Width = tracksListView.Width;

            //Populates the listviews with the terminals for user to select
            foreach (string terminal in serviceRolesList)
            {
                chatListView.Items.Add(terminal);
                tracksListView.Items.Add(terminal);
            }
            
            //go to relative tabs based on selection of check boxes
            if (tracksCheckBox.Checked)
            {
                //if tracks is selected go to tracks tab etc..
                ExternalWizard.TabPages.Add(tracksTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
                ExternalWizard.TabPages.Remove(chatNetworkTab);

            }
            else if (chatCheckBox.Checked)
            {
                ExternalWizard.TabPages.Add(chatTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(chatNetworkTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
            }
            else if (OSWCheckBox.Checked)
            {
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(chatNetworkTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
            }
            else if (mailCheckBox.Checked)
            {
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(chatNetworkTab);
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
            ExternalWizard.TabPages.Remove(chatNetworkTab);
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
            ExternalWizard.TabPages.Remove(chatNetworkTab);
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
            inputWriter.WriteLine(@" ""C:\Program Files (x86)\PuTTY\plink.exe"" -ssh 192.168.150.1 -l " + username + " -pw " + password);
            Thread.Sleep(1000);

            //give admin rights
            inputWriter.WriteLine("srole");
            trackProgress.Value = 20; 
            tracksProgressLabel.Text = "Modifying Tracks Network Object...";
            Thread.Sleep(1000);

            //modify network object for internal tracks server
            inputWriter.WriteLine("cf ipaddr modify name=\"DMZ BCIP Tracks Gateway\" ipaddr=" + tracksSelectedIP);
            trackProgress.Value = 30;
            Thread.Sleep(1000);
            
            //modify network object for external tracks server
            inputWriter.WriteLine("cf ipaddr modify name=\"External 1 Tracks Server\" ipaddr=" + externalTracksIP);
            trackProgress.Value = 40;
            Thread.Sleep(1000);

            //enable the tracks rules:
            tracksProgressLabel.Text = "Configuring Tracks Policy Rules...";
            inputWriter.WriteLine("cf policy modify name=\"Tracks to External 1\" disable=no");
            trackProgress.Value = 50;
            Thread.Sleep(1000);

            inputWriter.WriteLine("cf policy modify name=\"Tracks from External 1\" disable=no");
            trackProgress.Value = 60;
            Thread.Sleep(1000);

            //ping tracks server internal for 3 counts
            inputWriter.WriteLine("ping -c 3 " + tracksSelectedIP);
            Thread.Sleep(3000);
            trackProgress.Value = 70;

            //ping tracks server external for 3 counts
            inputWriter.WriteLine("ping -c 3 " + externalTracksIP);
            Thread.Sleep(3000);
            trackProgress.Value = 80;

            //exit
            inputWriter.WriteLine("exit");
            inputWriter.WriteLine("exit");
            trackProgress.Value = 90;

            //kill process;
            try
            {
                //do not add any non-putty code in before killing the process, it will crash
                plinkProcess.Kill();
                
                loginError = errorReader.ReadToEnd().ToString();
                consoleOutput = outputReader.ReadToEnd().ToString();
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

                    ExternalWizard.TabPages.Add(tracksNetworkTab);
                    ExternalWizard.TabPages.Remove(chooseServicesTab);
                    ExternalWizard.TabPages.Remove(chatTab);
                    ExternalWizard.TabPages.Remove(homeTab);
                    ExternalWizard.TabPages.Remove(tracksTab);
                    ExternalWizard.TabPages.Remove(chatNetworkTab);

                }
            }
            catch (Exception)
            {
                //error message
                MessageBox.Show("Connection to Firewall has exited. Please check logon credentials and connection to Firewall.", "Connection Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trackProgress.Value = 0;
                tracksProgressLabel.Text = "Error";
            }

            //get the ping success result
            if (consoleOutput.Contains("bytes from " + tracksSelectedIP))
            {
                pingIntTracksResult = true;
            }
            else
            {
                pingIntTracksResult = false;
            }

            //get the ping success result
            if (consoleOutput.Contains("bytes from " + externalTracksIP))
            {
                pingExtTracksResult = true;
            }
            else
            {
                pingExtTracksResult = false;
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
            ExternalWizard.TabPages.Remove(chatNetworkTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);
        }

        private void tracksNetTestButton_Click(object sender, EventArgs e)
        {
            if (pingIntTracksResult == true)
            {
                IntTracksPingSignal.FillColor = Color.Green;
            }
            else
            {
                IntTracksPingSignal.FillColor = Color.Red;
            }
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
                //MainGUI error = new MainGUI();
                //error.errorDialog(true);
                DialogResult errorDialog = MessageBox.Show("Ping failed. Please ensure you have selected the correct plan or the IP address is correct."
                    + System.Environment.NewLine + "Press Yes to Continue to the next Service Config or No to continue with Tracks Config", "Network Test Failed. Continue Anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (errorDialog == DialogResult.Yes && chatCheckBox.Checked)
                {
                    //progress to chat tab
                    ExternalWizard.TabPages.Remove(chooseServicesTab);
                    ExternalWizard.TabPages.Add(chatTab);
                    ExternalWizard.TabPages.Remove(homeTab);
                    ExternalWizard.TabPages.Remove(tracksTab);
                    ExternalWizard.TabPages.Remove(tracksNetworkTab);
                    ExternalWizard.TabPages.Remove(chatNetworkTab);
                }
                //go to next tab other than chat when created
                else if ((errorDialog == DialogResult.Yes && !chatCheckBox.Checked) || errorDialog == DialogResult.No)
                {
                    return;
                }
            }

            //if success move on
            if (pingIntTracksResult == true && pingExtTracksResult == true && chatCheckBox.Checked)
            {
                //progress to chat tab
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Add(chatTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
                ExternalWizard.TabPages.Remove(chatNetworkTab);
            }
            //go to next tab other than chat when created
            else if (pingIntTracksResult == true && pingExtTracksResult == true && !chatCheckBox.Checked)
            {
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
            ExternalWizard.TabPages.Remove(chatNetworkTab);
        }

        string externalChatIP, chatSelectedTerminalFull, chatSelectedIP, firstDNS;
        private void nextFromChat_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection chatSelectedItems = new ListView.SelectedListViewItemCollection(chatListView);
            externalChatIP = externalChatBox.Text;

            //3 requirements before allowing to configure:
            //if no terminal is selected throw error
            if (chatSelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Terminal", "No terminal selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if more than one item is Selected throw error
            else if (chatSelectedItems.Count > 1)
            {
                MessageBox.Show("Please Only Select One Terminal", "Too many terminals selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if external box is empty dont allow configure
            else if (externalChatIP == "")
            {
                MessageBox.Show("Please enter the External Tracks Server IP Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //otherwise use the selected item
            chatSelectedTerminalFull = chatSelectedItems[0].Text;

            //get the ip from the full line
            string[] chatSelectedIPArray = chatSelectedTerminalFull.Split('"');
            chatSelectedIP = chatSelectedIPArray[2];
            
            //if the first dns isnt the chat selected terminal throw an error
            if (firstDNS != chatSelectedIP)
            {
                MessageBox.Show("The Chat Terminal selected does not match the Primary DNS for this Platform. Please re-select the Chat Terminal", "Internal Chat Gateway must match Primary DNS", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ExternalWizard.TabPages.Remove(chooseServicesTab);
                ExternalWizard.TabPages.Remove(chatTab);
                ExternalWizard.TabPages.Remove(homeTab);
                ExternalWizard.TabPages.Remove(tracksTab);
                ExternalWizard.TabPages.Remove(tracksNetworkTab);
                ExternalWizard.TabPages.Add(chatNetworkTab);
            }
        }

        //
        // Chat Net Test Tab
        //

        //back to chat from chat net test
        private void backFromChatNet_Click(object sender, EventArgs e)
        {
            ExternalWizard.TabPages.Remove(chooseServicesTab);
            ExternalWizard.TabPages.Add(chatTab);
            ExternalWizard.TabPages.Remove(homeTab);
            ExternalWizard.TabPages.Remove(tracksTab);
            ExternalWizard.TabPages.Remove(tracksNetworkTab);
            ExternalWizard.TabPages.Remove(chatNetworkTab);
        }

        //chat net test button
        private void chatNetTestButton_Click(object sender, EventArgs e)
        {
            //Ping the chat internal 
            Ping_ pingIntChat = new Ping_();
            pingIntChat.Ping_From_FW(chatSelectedIP);
            bool pingIntChatResult = Ping_.firewallPingResult;

            if (pingIntChatResult == true)
            {
                IntChatPingSignal.FillColor = Color.Green;
            }
            else
            {
                IntChatPingSignal.FillColor = Color.Red;
            }

            //Ping the ext router
            Ping_ pingExtChat = new Ping_();
            pingExtChat.Ping_From_FW(externalChatIP);
            bool pingExtChatResult = Ping_.firewallPingResult;

            //change BNAU Ping button
            if (pingExtChatResult == true)
            {
                ExtChatPingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtChatPingSignal.FillColor = Color.Red;
            }

            //universal error
            if (pingIntChatResult == false || pingExtChatResult == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(true);
            }        
        }
    }
}
