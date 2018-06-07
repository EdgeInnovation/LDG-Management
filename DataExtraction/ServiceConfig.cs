using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LDGManagementApplication
{
    public partial class ServiceConfig : Form
    {
        public ServiceConfig()
        {
            InitializeComponent();
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(homeTab);

            //grab the bools from each other form to set the lights on the home page
            //INTERNAL
            if (InternalConfig.pingBNAUResult == true)
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
        string firstDNS;
        bool pingIntTracksResult, pingExtTracksResult, pingIntChatResult, pingExtChatResult, pingIntMailResult, pingExtMailResult, pingIntOSWResult, pingExtOSWResult;
        //
        // Home Tab
        //

        private void nextToChoose_Click(object sender, EventArgs e)
        {
            //only advance if all are green
            if (InternalConfig.pingBNAUResult == true && DMZConfig.DMZConnected == true && ExternalConfig.extRouterPingable == true)
            {
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(chooseServicesTab);
            }
            else
            {
                //show standard error/help
                //for now put it yes or no dialog but this can be removed
                //MessageBox.Show("Please Configure the Internal, DMZ and External Systems succesfully before continuing", "Configure all other systems first");

                DialogResult dialogResult = MessageBox.Show("Internal, DMZ and External systems have not been successfully configured. Continue anyway?", "Configure all other systems first", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(chooseServicesTab);
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
                MessageBox.Show("Please Select a Service to Configure", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Show the terminals for the tracks and chat listviews:
            //call the extract data class, and get the list 
            ExtractData extractList = new ExtractData();
            extractList.Extract_LDG_Data();
            List<string> serviceRolesList = extractList.GetServiceList();

            //get the first dns from the bec file to compare against user selection (second in list)
            List<string> LDGList = extractList.GetLDGList();

            //if list returned empty (user canceled dialog) then return
            if (LDGList.Count == 0)
            {
                return;
            }

            //find primary DNS
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
            ColumnHeader mailHeader = new ColumnHeader();
            ColumnHeader OSWHeader = new ColumnHeader();

            tracksHeader.Text = chatHeader.Text = mailHeader.Text = OSWHeader.Text = "Terminals";
            tracksHeader.Name = chatHeader.Name = mailHeader.Name = OSWHeader.Name = "Terminals";
            chatListView.Columns.Add(chatHeader);
            chatHeader.Width = chatListView.Width;
            tracksListView.Columns.Add(tracksHeader);
            tracksHeader.Width = tracksListView.Width;
            mailListView.Columns.Add(mailHeader);
            chatHeader.Width = chatListView.Width;
            OSWListView.Columns.Add(OSWHeader);
            OSWHeader.Width = OSWListView.Width;

            tracksListView.View = View.Details;
            chatListView.View = View.Details;
            mailListView.View = View.Details;
            OSWListView.View = View.Details;

            //resize the colomuns
            tracksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            chatListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            mailListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            OSWListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            tracksListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            chatListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            mailListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            OSWListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Populates the listviews with the terminals for user to select
            foreach (string terminal in serviceRolesList)
            {
                chatListView.Items.Add(terminal);
                tracksListView.Items.Add(terminal);
                mailListView.Items.Add(terminal);
                OSWListView.Items.Add(terminal);
            }

            //go to relative tabs based on selection of check boxes
            if (tracksCheckBox.Checked)
            {
                //if tracks is selected go to tracks tab etc..
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(tracksTab);
            }
            else if (chatCheckBox.Checked)
            {
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(chatTab);
            }
            else if (mailCheckBox.Checked)
            {
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(mailTab);
            }
            else if (OSWCheckBox.Checked)
            {
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(OSWTab);
            }
        }
        
        private void backToHome_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(homeTab);
        }
        
        //
        // Tracks Tab
        //

        private void chooseFromTracks_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(chooseServicesTab);
        }

        private void configureTracks_Click(object sender, EventArgs e)
        {
            trackProgress.Value = 5;
            ListView.SelectedListViewItemCollection selectedItems = new ListView.SelectedListViewItemCollection(tracksListView);
            string externalTracksIP = externalTracksBox.Text;

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
            string tracksSelectedTerminalFull = selectedItems[0].Text;
            //get the ip from the fuill line
            string[] tracksSelectedIPArray = tracksSelectedTerminalFull.Split('"');
            string tracksSelectedIP = tracksSelectedIPArray[2];
            trackProgress.Value = 15;
            
            //call the putty tracks class
            Tracks tracksConfig = new Tracks();
            tracksConfig.Tracks_Config(tracksSelectedIP, externalTracksIP);
            trackProgress.Value = 75;

            //get the ping success result
            if (Tracks.consoleOutput.Contains("bytes from " + tracksSelectedIP))
            {
                pingIntTracksResult = true;
            }
            else
            {
                pingIntTracksResult = false;
            }

            //get the ping success result
            if (Tracks.consoleOutput.Contains("bytes from " + externalTracksIP))
            {
                pingExtTracksResult = true;
            }
            else
            {
                pingExtTracksResult = false;
            }

            //go to next page if it succeeded
            if (Tracks.configSuccess == true)
            {
                trackProgress.Value = 100;
                //Hide tabs and show next
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(tracksNetworkTab);
            }
            else
            {
                trackProgress.Value = 0;
                return;
            }
        }

        //
        // Tracks Net test Tab
        //

        //back to tracks from tracks net test
        private void backFromTracksNet_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(tracksTab);
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
                if (errorDialog == DialogResult.Yes)
                {
                    //go to next tab
                    if (chatCheckBox.Checked)
                    {
                        servicesWizard.TabPages.Clear();
                        servicesWizard.TabPages.Add(chatTab);
                    }
                    else if (mailCheckBox.Checked)
                    {
                        servicesWizard.TabPages.Clear();
                        servicesWizard.TabPages.Add(mailTab);
                    }
                    else if (OSWCheckBox.Checked)
                    {
                        servicesWizard.TabPages.Clear();
                        servicesWizard.TabPages.Add(OSWTab);
                    }
                    else
                    {
                        MessageBox.Show("Service configuration complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                //go to next tab other than chat when created
                else if (errorDialog == DialogResult.No)
                {
                    return;
                }
            }

            //if success move on
            if (pingIntTracksResult == true && pingExtTracksResult == true)
            {
                //go to next tab
                if (chatCheckBox.Checked)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(chatTab);
                }
                else if (mailCheckBox.Checked)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(mailTab);
                }
                else if (OSWCheckBox.Checked)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(OSWTab);
                }
                else
                {
                    MessageBox.Show("Service configuration complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
        
        //
        // Chat Tab
        //

        //back to choose from chat
        private void chooseFromChat_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(chooseServicesTab);
        }
        private void nextFromChat_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection chatSelectedItems = new ListView.SelectedListViewItemCollection(chatListView);
            string externalChatIP = externalChatBox.Text;

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
            string chatSelectedTerminalFull = chatSelectedItems[0].Text;

            //get the ip from the full line
            string[] chatSelectedIPArray = chatSelectedTerminalFull.Split('"');
            string chatSelectedIP = chatSelectedIPArray[2];
            
            //if the first dns isnt the chat selected terminal throw an error
            if (firstDNS != chatSelectedIP)
            {
                MessageBox.Show("The Chat Terminal selected does not match the Primary DNS for this Platform. Please initialise the Chat Terminal as the Primary DNS: " + firstDNS, "Internal Chat Gateway must match Primary DNS", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //call the putty chat class
            Chat chatConfig = new Chat();
            chatConfig.Chat_Config(chatSelectedIP, externalChatIP);

            //get the ping success result
            if (Chat.consoleOutput.Contains("bytes from " + chatSelectedIP))
            {
                pingIntChatResult = true;
            }
            else
            {
                pingIntChatResult = false;
            }

            //get the ping success result
            if (Chat.consoleOutput.Contains("bytes from " + externalChatIP))
            {
                pingExtChatResult = true;
            }
            else
            {
                pingExtChatResult = false;
            }

            //go to next page if it succeeded
            if (Chat.configSuccess == true)
            {
                //Hide tabs and show next
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(chatNetworkTab);
            }
            else
            {
                return;
            }
        }

        //
        // Chat Net Test Tab
        //

        //back to chat from chat net test
        private void backFromChatNet_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(chatTab);
        }

        //chat net test button
        private void chatNetTestButton_Click(object sender, EventArgs e)
        {
            if (pingIntChatResult == true)
            {
                IntChatPingSignal.FillColor = Color.Green;
            }
            else
            {
                IntChatPingSignal.FillColor = Color.Red;
            }
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
                DialogResult errorDialog = MessageBox.Show("Ping failed. Please ensure you have selected the correct plan or the IP address is correct."
                    + System.Environment.NewLine + "Press Yes to Continue to the next Service Config or No to continue with Current Config", "Network Test Failed. Continue Anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (errorDialog == DialogResult.Yes)
                {
                    //go to next tab
                    if (mailCheckBox.Checked)
                    {
                        servicesWizard.TabPages.Clear();
                        servicesWizard.TabPages.Add(mailTab);
                    }
                    else if (OSWCheckBox.Checked)
                    {
                        servicesWizard.TabPages.Clear();
                        servicesWizard.TabPages.Add(OSWTab);
                    }
                    else
                    {
                        MessageBox.Show("Service configuration complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else if (errorDialog == DialogResult.No)
                {
                    return;
                }
            }

            //if success move on
            if (pingIntChatResult == true && pingExtChatResult == true)
            {
                //go to next tab
                if (mailCheckBox.Checked)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(mailTab);
                }
                else if (OSWCheckBox.Checked)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(OSWTab);
                }
                else
                {
                    MessageBox.Show("Service configuration complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        //
        // Mail Tab
        //

        private void chooseFromMail_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(chooseServicesTab);
        }
        private void configureMail_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection mailSelectedItems = new ListView.SelectedListViewItemCollection(mailListView);
            string externalMailIP = externalMailBox.Text;

            //3 requirements before allowing to configure:
            //if no terminal is selected throw error
            if (mailSelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Terminal", "No terminal selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if more than one item is Selected throw error
            else if (mailSelectedItems.Count > 1)
            {
                MessageBox.Show("Please Only Select One Terminal", "Too many terminals selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if external box is empty dont allow configure
            else if (externalMailIP == "")
            {
                MessageBox.Show("Please enter the External Tracks Server IP Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //otherwise use the selected item
            string mailSelectedTerminalFull = mailSelectedItems[0].Text;

            //get the ip from the full line
            string[] mailSelectedIPArray = mailSelectedTerminalFull.Split('"');
            string mailSelectedIP = mailSelectedIPArray[2];

            //call the putty mail class
            Mail mailConfig = new Mail();
            mailConfig.Mail_Config(mailSelectedIP, externalMailIP);

            //get the ping success result
            if (Mail.consoleOutput.Contains("bytes from " + mailSelectedIP))
            {
                pingIntMailResult = true;
            }
            else
            {
                pingIntMailResult = false;
            }

            //get the ping success result
            if (Mail.consoleOutput.Contains("bytes from " + externalMailIP))
            {
                pingExtMailResult = true;
            }
            else
            {
                pingExtMailResult = false;
            }

            //go to next page if it succeeded
            if (Mail.configSuccess == true)
            {
                //Hide tabs and show next
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(mailNetworkTab);
            }
            else
            {
                return;
            }
        }
        //
        // Mail Network Tab
        //
        private void backFromMailNet_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(mailTab);
        }
        private void mailNetTestButton_Click(object sender, EventArgs e)
        {
            if (pingIntMailResult == true)
            {
                IntMailPingSignal.FillColor = Color.Green;
            }
            else
            {
                IntMailPingSignal.FillColor = Color.Red;
            }
            //change BNAU Ping button
            if (pingExtMailResult == true)
            {
                ExtMailPingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtMailPingSignal.FillColor = Color.Red;
            }

            //universal error
            if (pingIntMailResult == false || pingExtMailResult == false)
            {
                DialogResult errorDialog = MessageBox.Show("Ping failed. Please ensure you have selected the correct plan or the IP address is correct."
                    + System.Environment.NewLine + "Press Yes to Continue to the next Service Config or No to continue with Current Config", "Network Test Failed. Continue Anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (errorDialog == DialogResult.Yes)
                {
                    //go to next tab
                    if (OSWCheckBox.Checked)
                    {
                        servicesWizard.TabPages.Clear();
                        servicesWizard.TabPages.Add(OSWTab);
                    }
                    else//if no other button are checked
                    {
                        MessageBox.Show("Service configuration complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                else if (errorDialog == DialogResult.No)
                {
                    return;
                }
            }

            //if success move on
            if (pingIntMailResult == true && pingExtMailResult == true)
            {
                //go to next tab
                if (OSWCheckBox.Checked)
                {
                    servicesWizard.TabPages.Clear();
                    servicesWizard.TabPages.Add(OSWTab);
                }
                else
                {
                    MessageBox.Show("Service configuration complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }

        //
        // OSW Tab
        //

        private void chooseFromOSW_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(chooseServicesTab);
        }
        private void configureOSW_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection OSWSelectedItems = new ListView.SelectedListViewItemCollection(OSWListView);
            string externalOSWIP = externalOSWBox.Text;

            //3 requirements before allowing to configure:
            //if no terminal is selected throw error
            if (OSWSelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Terminal", "No terminal selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if more than one item is Selected throw error
            else if (OSWSelectedItems.Count > 1)
            {
                MessageBox.Show("Please Only Select One Terminal", "Too many terminals selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if external box is empty dont allow configure
            else if (externalOSWIP == "")
            {
                MessageBox.Show("Please enter the External Tracks Server IP Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //otherwise use the selected item
            string OSWSelectedTerminalFull = OSWSelectedItems[0].Text;

            //get the ip from the full line
            string[] OSWSelectedIPArray = OSWSelectedTerminalFull.Split('"');
            string OSWSelectedIP = OSWSelectedIPArray[2];

            //call the putty mail class
            OSW OSWConfig = new OSW();
            OSWConfig.OSW_Config(OSWSelectedIP, externalOSWIP);

            //get the ping success result
            if (OSW.consoleOutput.Contains("bytes from " + OSWSelectedIP))
            {
                pingIntOSWResult = true;
            }
            else
            {
                pingIntOSWResult = false;
            }

            //get the ping success result
            if (OSW.consoleOutput.Contains("bytes from " + externalOSWIP))
            {
                pingExtOSWResult = true;
            }
            else
            {
                pingExtOSWResult = false;
            }

            //go to next page if it succeeded
            if (OSW.configSuccess == true)
            {
                //Hide tabs and show next
                servicesWizard.TabPages.Clear();
                servicesWizard.TabPages.Add(OSWNetworkTab);
            }
            else
            {
                return;
            }
        }

        //
        // OSW Network Tab
        //
        private void backFromOSWNet_Click(object sender, EventArgs e)
        {
            servicesWizard.TabPages.Clear();
            servicesWizard.TabPages.Add(OSWTab);
        }
        private void OSWNetTestButton_Click(object sender, EventArgs e)
        {
            if (pingIntOSWResult == true)
            {
                IntOSWPingSignal.FillColor = Color.Green;
            }
            else
            {
                IntOSWPingSignal.FillColor = Color.Red;
            }
            //change BNAU Ping button
            if (pingExtOSWResult == true)
            {
                ExtOSWPingSignal.FillColor = Color.Green;
            }
            else
            {
                ExtOSWPingSignal.FillColor = Color.Red;
            }

            //universal error
            if (pingIntOSWResult == false || pingExtOSWResult == false)
            {
                DialogResult errorDialog = MessageBox.Show("Ping failed. Please ensure you have selected the correct plan or the IP address is correct."
                    + System.Environment.NewLine + "Press Yes to Continue to the next Service Config or No to continue with Current Config", "Network Test Failed. Continue Anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (errorDialog == DialogResult.Yes)
                {
                    MessageBox.Show("Service Configuration Complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                //go to next tab other than chat when created
                else if (errorDialog == DialogResult.No)
                {
                    return;
                }
            }

            //if success finish service config
            if (pingIntOSWResult == true && pingExtOSWResult == true)
            {
                MessageBox.Show("Service Configuration Complete", "Configuration Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
