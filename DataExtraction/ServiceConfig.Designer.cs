namespace DataExtraction
{
    partial class ServiceConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExternalWizard = new System.Windows.Forms.TabControl();
            this.chooseServicesTab = new System.Windows.Forms.TabPage();
            this.backToHome = new System.Windows.Forms.Button();
            this.nextFromChoose = new System.Windows.Forms.Button();
            this.tracksCheckBox = new System.Windows.Forms.CheckBox();
            this.OSWCheckBox = new System.Windows.Forms.CheckBox();
            this.mailCheckBox = new System.Windows.Forms.CheckBox();
            this.chatCheckBox = new System.Windows.Forms.CheckBox();
            this.ChooseServices = new System.Windows.Forms.Label();
            this.chatTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.chatListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.externalChatBox = new System.Windows.Forms.TextBox();
            this.chooseFromChat = new System.Windows.Forms.Button();
            this.nextFromChat = new System.Windows.Forms.Button();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.BNAUPing = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nextToChoose = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ExtRouterPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.DMZInterfaceSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.BNAUPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.tracksTab = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.externalTracksBox = new System.Windows.Forms.TextBox();
            this.tracksStatusStrip = new System.Windows.Forms.StatusStrip();
            this.tracksTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tracksStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tracksProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewLabel = new System.Windows.Forms.Label();
            this.tracksListView = new System.Windows.Forms.ListView();
            this.chooseFromTracks = new System.Windows.Forms.Button();
            this.configureTracks = new System.Windows.Forms.Button();
            this.tracksNetworkTab = new System.Windows.Forms.TabPage();
            this.backFromTracksNet = new System.Windows.Forms.Button();
            this.tracksNetTestButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.IntTracksPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ExtTracksPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.chatNetworkTab = new System.Windows.Forms.TabPage();
            this.backFromChatNet = new System.Windows.Forms.Button();
            this.chatNetTestButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.IntChatPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ExtChatPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ExternalWizard.SuspendLayout();
            this.chooseServicesTab.SuspendLayout();
            this.chatTab.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.tracksTab.SuspendLayout();
            this.tracksStatusStrip.SuspendLayout();
            this.tracksNetworkTab.SuspendLayout();
            this.chatNetworkTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExternalWizard
            // 
            this.ExternalWizard.Controls.Add(this.chooseServicesTab);
            this.ExternalWizard.Controls.Add(this.chatTab);
            this.ExternalWizard.Controls.Add(this.homeTab);
            this.ExternalWizard.Controls.Add(this.tracksTab);
            this.ExternalWizard.Controls.Add(this.tracksNetworkTab);
            this.ExternalWizard.Controls.Add(this.chatNetworkTab);
            this.ExternalWizard.Location = new System.Drawing.Point(12, 12);
            this.ExternalWizard.Name = "ExternalWizard";
            this.ExternalWizard.SelectedIndex = 0;
            this.ExternalWizard.Size = new System.Drawing.Size(335, 314);
            this.ExternalWizard.TabIndex = 0;
            // 
            // chooseServicesTab
            // 
            this.chooseServicesTab.Controls.Add(this.backToHome);
            this.chooseServicesTab.Controls.Add(this.nextFromChoose);
            this.chooseServicesTab.Controls.Add(this.tracksCheckBox);
            this.chooseServicesTab.Controls.Add(this.OSWCheckBox);
            this.chooseServicesTab.Controls.Add(this.mailCheckBox);
            this.chooseServicesTab.Controls.Add(this.chatCheckBox);
            this.chooseServicesTab.Controls.Add(this.ChooseServices);
            this.chooseServicesTab.Location = new System.Drawing.Point(4, 22);
            this.chooseServicesTab.Name = "chooseServicesTab";
            this.chooseServicesTab.Padding = new System.Windows.Forms.Padding(3);
            this.chooseServicesTab.Size = new System.Drawing.Size(327, 288);
            this.chooseServicesTab.TabIndex = 0;
            this.chooseServicesTab.Text = "Choose Services";
            this.chooseServicesTab.UseVisualStyleBackColor = true;
            // 
            // backToHome
            // 
            this.backToHome.Location = new System.Drawing.Point(6, 259);
            this.backToHome.Name = "backToHome";
            this.backToHome.Size = new System.Drawing.Size(75, 23);
            this.backToHome.TabIndex = 8;
            this.backToHome.Text = "Back";
            this.backToHome.UseVisualStyleBackColor = true;
            this.backToHome.Click += new System.EventHandler(this.backToHome_Click);
            // 
            // nextFromChoose
            // 
            this.nextFromChoose.Location = new System.Drawing.Point(246, 259);
            this.nextFromChoose.Name = "nextFromChoose";
            this.nextFromChoose.Size = new System.Drawing.Size(75, 23);
            this.nextFromChoose.TabIndex = 5;
            this.nextFromChoose.Text = "Next";
            this.nextFromChoose.UseVisualStyleBackColor = true;
            this.nextFromChoose.Click += new System.EventHandler(this.nextFromChoose_Click);
            // 
            // tracksCheckBox
            // 
            this.tracksCheckBox.AutoSize = true;
            this.tracksCheckBox.Location = new System.Drawing.Point(69, 89);
            this.tracksCheckBox.Name = "tracksCheckBox";
            this.tracksCheckBox.Size = new System.Drawing.Size(59, 17);
            this.tracksCheckBox.TabIndex = 4;
            this.tracksCheckBox.Text = "Tracks";
            this.tracksCheckBox.UseVisualStyleBackColor = true;
            // 
            // OSWCheckBox
            // 
            this.OSWCheckBox.AutoSize = true;
            this.OSWCheckBox.Location = new System.Drawing.Point(69, 135);
            this.OSWCheckBox.Name = "OSWCheckBox";
            this.OSWCheckBox.Size = new System.Drawing.Size(52, 17);
            this.OSWCheckBox.TabIndex = 3;
            this.OSWCheckBox.Text = "OSW";
            this.OSWCheckBox.UseVisualStyleBackColor = true;
            // 
            // mailCheckBox
            // 
            this.mailCheckBox.AutoSize = true;
            this.mailCheckBox.Location = new System.Drawing.Point(69, 158);
            this.mailCheckBox.Name = "mailCheckBox";
            this.mailCheckBox.Size = new System.Drawing.Size(45, 17);
            this.mailCheckBox.TabIndex = 2;
            this.mailCheckBox.Text = "Mail";
            this.mailCheckBox.UseVisualStyleBackColor = true;
            // 
            // chatCheckBox
            // 
            this.chatCheckBox.AutoSize = true;
            this.chatCheckBox.Location = new System.Drawing.Point(69, 112);
            this.chatCheckBox.Name = "chatCheckBox";
            this.chatCheckBox.Size = new System.Drawing.Size(48, 17);
            this.chatCheckBox.TabIndex = 1;
            this.chatCheckBox.Text = "Chat";
            this.chatCheckBox.UseVisualStyleBackColor = true;
            // 
            // ChooseServices
            // 
            this.ChooseServices.AutoSize = true;
            this.ChooseServices.Location = new System.Drawing.Point(66, 56);
            this.ChooseServices.Name = "ChooseServices";
            this.ChooseServices.Size = new System.Drawing.Size(195, 13);
            this.ChooseServices.TabIndex = 0;
            this.ChooseServices.Text = "Please choose the services you require:";
            // 
            // chatTab
            // 
            this.chatTab.Controls.Add(this.label8);
            this.chatTab.Controls.Add(this.chatListView);
            this.chatTab.Controls.Add(this.label1);
            this.chatTab.Controls.Add(this.externalChatBox);
            this.chatTab.Controls.Add(this.chooseFromChat);
            this.chatTab.Controls.Add(this.nextFromChat);
            this.chatTab.Location = new System.Drawing.Point(4, 22);
            this.chatTab.Name = "chatTab";
            this.chatTab.Padding = new System.Windows.Forms.Padding(3);
            this.chatTab.Size = new System.Drawing.Size(327, 288);
            this.chatTab.TabIndex = 1;
            this.chatTab.Text = "Chat";
            this.chatTab.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Select the Internal Chat Server Terminal:";
            // 
            // chatListView
            // 
            this.chatListView.Location = new System.Drawing.Point(6, 23);
            this.chatListView.Name = "chatListView";
            this.chatListView.Size = new System.Drawing.Size(315, 104);
            this.chatListView.TabIndex = 13;
            this.chatListView.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "External Chat GW:";
            // 
            // externalChatBox
            // 
            this.externalChatBox.Location = new System.Drawing.Point(164, 183);
            this.externalChatBox.Name = "externalChatBox";
            this.externalChatBox.Size = new System.Drawing.Size(100, 20);
            this.externalChatBox.TabIndex = 8;
            // 
            // chooseFromChat
            // 
            this.chooseFromChat.Location = new System.Drawing.Point(6, 259);
            this.chooseFromChat.Name = "chooseFromChat";
            this.chooseFromChat.Size = new System.Drawing.Size(75, 23);
            this.chooseFromChat.TabIndex = 7;
            this.chooseFromChat.Text = "Back";
            this.chooseFromChat.UseVisualStyleBackColor = true;
            this.chooseFromChat.Click += new System.EventHandler(this.chooseFromChat_Click);
            // 
            // nextFromChat
            // 
            this.nextFromChat.Location = new System.Drawing.Point(246, 259);
            this.nextFromChat.Name = "nextFromChat";
            this.nextFromChat.Size = new System.Drawing.Size(75, 23);
            this.nextFromChat.TabIndex = 6;
            this.nextFromChat.Text = "Next";
            this.nextFromChat.UseVisualStyleBackColor = true;
            this.nextFromChat.Click += new System.EventHandler(this.nextFromChat_Click);
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.label4);
            this.homeTab.Controls.Add(this.BNAUPing);
            this.homeTab.Controls.Add(this.label3);
            this.homeTab.Controls.Add(this.nextToChoose);
            this.homeTab.Controls.Add(this.shapeContainer1);
            this.homeTab.Location = new System.Drawing.Point(4, 22);
            this.homeTab.Name = "homeTab";
            this.homeTab.Padding = new System.Windows.Forms.Padding(3);
            this.homeTab.Size = new System.Drawing.Size(327, 288);
            this.homeTab.TabIndex = 2;
            this.homeTab.Text = "Home";
            this.homeTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "DMZ Interface Connected";
            // 
            // BNAUPing
            // 
            this.BNAUPing.AutoSize = true;
            this.BNAUPing.Location = new System.Drawing.Point(127, 56);
            this.BNAUPing.Name = "BNAUPing";
            this.BNAUPing.Size = new System.Drawing.Size(81, 13);
            this.BNAUPing.TabIndex = 10;
            this.BNAUPing.Text = "BNAU Pingable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "External Router Pingable";
            // 
            // nextToChoose
            // 
            this.nextToChoose.Location = new System.Drawing.Point(246, 259);
            this.nextToChoose.Name = "nextToChoose";
            this.nextToChoose.Size = new System.Drawing.Size(75, 23);
            this.nextToChoose.TabIndex = 6;
            this.nextToChoose.Text = "Continue";
            this.nextToChoose.UseVisualStyleBackColor = true;
            this.nextToChoose.Click += new System.EventHandler(this.nextToChoose_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ExtRouterPingSignal,
            this.DMZInterfaceSignal,
            this.BNAUPingSignal});
            this.shapeContainer1.Size = new System.Drawing.Size(321, 282);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // ExtRouterPingSignal
            // 
            this.ExtRouterPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtRouterPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.ExtRouterPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtRouterPingSignal.Location = new System.Drawing.Point(76, 140);
            this.ExtRouterPingSignal.Name = "ExtRouterPingSignal";
            this.ExtRouterPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // DMZInterfaceSignal
            // 
            this.DMZInterfaceSignal.BackColor = System.Drawing.Color.DarkGray;
            this.DMZInterfaceSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.DMZInterfaceSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.DMZInterfaceSignal.Location = new System.Drawing.Point(77, 93);
            this.DMZInterfaceSignal.Name = "DMZInterfaceSignal";
            this.DMZInterfaceSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // BNAUPingSignal
            // 
            this.BNAUPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.BNAUPingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.BNAUPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.BNAUPingSignal.Location = new System.Drawing.Point(77, 46);
            this.BNAUPingSignal.Name = "BNAUPingSignal";
            this.BNAUPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // tracksTab
            // 
            this.tracksTab.Controls.Add(this.label5);
            this.tracksTab.Controls.Add(this.externalTracksBox);
            this.tracksTab.Controls.Add(this.tracksStatusStrip);
            this.tracksTab.Controls.Add(this.listViewLabel);
            this.tracksTab.Controls.Add(this.tracksListView);
            this.tracksTab.Controls.Add(this.chooseFromTracks);
            this.tracksTab.Controls.Add(this.configureTracks);
            this.tracksTab.Location = new System.Drawing.Point(4, 22);
            this.tracksTab.Name = "tracksTab";
            this.tracksTab.Padding = new System.Windows.Forms.Padding(3);
            this.tracksTab.Size = new System.Drawing.Size(327, 288);
            this.tracksTab.TabIndex = 3;
            this.tracksTab.Text = "Tracks";
            this.tracksTab.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "External 1 Tracks Server IP:";
            // 
            // externalTracksBox
            // 
            this.externalTracksBox.Location = new System.Drawing.Point(173, 173);
            this.externalTracksBox.Name = "externalTracksBox";
            this.externalTracksBox.Size = new System.Drawing.Size(100, 20);
            this.externalTracksBox.TabIndex = 16;
            // 
            // tracksStatusStrip
            // 
            this.tracksStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tracksTitleLabel,
            this.trackProgress,
            this.tracksStatusLabel,
            this.tracksProgressLabel});
            this.tracksStatusStrip.Location = new System.Drawing.Point(3, 263);
            this.tracksStatusStrip.Name = "tracksStatusStrip";
            this.tracksStatusStrip.Size = new System.Drawing.Size(321, 22);
            this.tracksStatusStrip.TabIndex = 15;
            this.tracksStatusStrip.Text = "statusStrip1";
            // 
            // tracksTitleLabel
            // 
            this.tracksTitleLabel.Name = "tracksTitleLabel";
            this.tracksTitleLabel.Size = new System.Drawing.Size(55, 17);
            this.tracksTitleLabel.Text = "Progress:";
            // 
            // trackProgress
            // 
            this.trackProgress.Name = "trackProgress";
            this.trackProgress.Size = new System.Drawing.Size(100, 16);
            // 
            // tracksStatusLabel
            // 
            this.tracksStatusLabel.Name = "tracksStatusLabel";
            this.tracksStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tracksProgressLabel
            // 
            this.tracksProgressLabel.Name = "tracksProgressLabel";
            this.tracksProgressLabel.Size = new System.Drawing.Size(96, 17);
            this.tracksProgressLabel.Text = "Select a Terminal";
            // 
            // listViewLabel
            // 
            this.listViewLabel.AutoSize = true;
            this.listViewLabel.Location = new System.Drawing.Point(7, 7);
            this.listViewLabel.Name = "listViewLabel";
            this.listViewLabel.Size = new System.Drawing.Size(209, 13);
            this.listViewLabel.TabIndex = 12;
            this.listViewLabel.Text = "Select the Internal Tracks Server Terminal:";
            // 
            // tracksListView
            // 
            this.tracksListView.Location = new System.Drawing.Point(6, 24);
            this.tracksListView.Name = "tracksListView";
            this.tracksListView.Size = new System.Drawing.Size(315, 104);
            this.tracksListView.TabIndex = 11;
            this.tracksListView.UseCompatibleStateImageBehavior = false;
            // 
            // chooseFromTracks
            // 
            this.chooseFromTracks.Location = new System.Drawing.Point(10, 237);
            this.chooseFromTracks.Name = "chooseFromTracks";
            this.chooseFromTracks.Size = new System.Drawing.Size(75, 23);
            this.chooseFromTracks.TabIndex = 10;
            this.chooseFromTracks.Text = "Back";
            this.chooseFromTracks.UseVisualStyleBackColor = true;
            this.chooseFromTracks.Click += new System.EventHandler(this.chooseFromTracks_Click);
            // 
            // configureTracks
            // 
            this.configureTracks.Location = new System.Drawing.Point(246, 237);
            this.configureTracks.Name = "configureTracks";
            this.configureTracks.Size = new System.Drawing.Size(75, 23);
            this.configureTracks.TabIndex = 9;
            this.configureTracks.Text = "Configure";
            this.configureTracks.UseVisualStyleBackColor = true;
            this.configureTracks.Click += new System.EventHandler(this.configureTracks_Click);
            // 
            // tracksNetworkTab
            // 
            this.tracksNetworkTab.Controls.Add(this.backFromTracksNet);
            this.tracksNetworkTab.Controls.Add(this.tracksNetTestButton);
            this.tracksNetworkTab.Controls.Add(this.label6);
            this.tracksNetworkTab.Controls.Add(this.label7);
            this.tracksNetworkTab.Controls.Add(this.shapeContainer2);
            this.tracksNetworkTab.Location = new System.Drawing.Point(4, 22);
            this.tracksNetworkTab.Name = "tracksNetworkTab";
            this.tracksNetworkTab.Padding = new System.Windows.Forms.Padding(3);
            this.tracksNetworkTab.Size = new System.Drawing.Size(327, 288);
            this.tracksNetworkTab.TabIndex = 4;
            this.tracksNetworkTab.Text = "Tracks Network Test";
            this.tracksNetworkTab.UseVisualStyleBackColor = true;
            // 
            // backFromTracksNet
            // 
            this.backFromTracksNet.Location = new System.Drawing.Point(6, 259);
            this.backFromTracksNet.Name = "backFromTracksNet";
            this.backFromTracksNet.Size = new System.Drawing.Size(75, 23);
            this.backFromTracksNet.TabIndex = 12;
            this.backFromTracksNet.Text = "Back";
            this.backFromTracksNet.UseVisualStyleBackColor = true;
            this.backFromTracksNet.Click += new System.EventHandler(this.backFromTracksNet_Click);
            // 
            // tracksNetTestButton
            // 
            this.tracksNetTestButton.Location = new System.Drawing.Point(246, 259);
            this.tracksNetTestButton.Name = "tracksNetTestButton";
            this.tracksNetTestButton.Size = new System.Drawing.Size(75, 23);
            this.tracksNetTestButton.TabIndex = 11;
            this.tracksNetTestButton.Text = "Test";
            this.tracksNetTestButton.UseVisualStyleBackColor = true;
            this.tracksNetTestButton.Click += new System.EventHandler(this.tracksNetTestButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Internal Tracks Terminal Pingable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "External Tracks Server Pingable";
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.IntTracksPingSignal,
            this.ExtTracksPingSignal});
            this.shapeContainer2.Size = new System.Drawing.Size(321, 282);
            this.shapeContainer2.TabIndex = 0;
            this.shapeContainer2.TabStop = false;
            // 
            // IntTracksPingSignal
            // 
            this.IntTracksPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.IntTracksPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.IntTracksPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.IntTracksPingSignal.Location = new System.Drawing.Point(52, 77);
            this.IntTracksPingSignal.Name = "IntTracksPingSignal";
            this.IntTracksPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // ExtTracksPingSignal
            // 
            this.ExtTracksPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtTracksPingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.ExtTracksPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtTracksPingSignal.Location = new System.Drawing.Point(51, 115);
            this.ExtTracksPingSignal.Name = "ExtTracksPingSignal";
            this.ExtTracksPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // chatNetworkTab
            // 
            this.chatNetworkTab.Controls.Add(this.backFromChatNet);
            this.chatNetworkTab.Controls.Add(this.chatNetTestButton);
            this.chatNetworkTab.Controls.Add(this.label9);
            this.chatNetworkTab.Controls.Add(this.label10);
            this.chatNetworkTab.Controls.Add(this.shapeContainer3);
            this.chatNetworkTab.Location = new System.Drawing.Point(4, 22);
            this.chatNetworkTab.Name = "chatNetworkTab";
            this.chatNetworkTab.Padding = new System.Windows.Forms.Padding(3);
            this.chatNetworkTab.Size = new System.Drawing.Size(327, 288);
            this.chatNetworkTab.TabIndex = 5;
            this.chatNetworkTab.Text = "Chat Network Test";
            this.chatNetworkTab.UseVisualStyleBackColor = true;
            // 
            // backFromChatNet
            // 
            this.backFromChatNet.Location = new System.Drawing.Point(6, 259);
            this.backFromChatNet.Name = "backFromChatNet";
            this.backFromChatNet.Size = new System.Drawing.Size(75, 23);
            this.backFromChatNet.TabIndex = 14;
            this.backFromChatNet.Text = "Back";
            this.backFromChatNet.UseVisualStyleBackColor = true;
            this.backFromChatNet.Click += new System.EventHandler(this.backFromChatNet_Click);
            // 
            // chatNetTestButton
            // 
            this.chatNetTestButton.Location = new System.Drawing.Point(246, 259);
            this.chatNetTestButton.Name = "chatNetTestButton";
            this.chatNetTestButton.Size = new System.Drawing.Size(75, 23);
            this.chatNetTestButton.TabIndex = 13;
            this.chatNetTestButton.Text = "Test";
            this.chatNetTestButton.UseVisualStyleBackColor = true;
            this.chatNetTestButton.Click += new System.EventHandler(this.chatNetTestButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(115, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Internal Chat Terminal Pingable";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(115, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "External Chat Server Pingable";
            // 
            // shapeContainer3
            // 
            this.shapeContainer3.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer3.Name = "shapeContainer3";
            this.shapeContainer3.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.IntChatPingSignal,
            this.ExtChatPingSignal});
            this.shapeContainer3.Size = new System.Drawing.Size(321, 282);
            this.shapeContainer3.TabIndex = 0;
            this.shapeContainer3.TabStop = false;
            // 
            // IntChatPingSignal
            // 
            this.IntChatPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.IntChatPingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.IntChatPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.IntChatPingSignal.Location = new System.Drawing.Point(63, 87);
            this.IntChatPingSignal.Name = "IntChatPingSignal";
            this.IntChatPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // ExtChatPingSignal
            // 
            this.ExtChatPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtChatPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.ExtChatPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtChatPingSignal.Location = new System.Drawing.Point(62, 126);
            this.ExtChatPingSignal.Name = "ExtChatPingSignal";
            this.ExtChatPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // ServiceConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 338);
            this.Controls.Add(this.ExternalWizard);
            this.Name = "ServiceConfig";
            this.Text = "ServiceConfig";
            this.ExternalWizard.ResumeLayout(false);
            this.chooseServicesTab.ResumeLayout(false);
            this.chooseServicesTab.PerformLayout();
            this.chatTab.ResumeLayout(false);
            this.chatTab.PerformLayout();
            this.homeTab.ResumeLayout(false);
            this.homeTab.PerformLayout();
            this.tracksTab.ResumeLayout(false);
            this.tracksTab.PerformLayout();
            this.tracksStatusStrip.ResumeLayout(false);
            this.tracksStatusStrip.PerformLayout();
            this.tracksNetworkTab.ResumeLayout(false);
            this.tracksNetworkTab.PerformLayout();
            this.chatNetworkTab.ResumeLayout(false);
            this.chatNetworkTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ExternalWizard;
        private System.Windows.Forms.TabPage chooseServicesTab;
        private System.Windows.Forms.TabPage chatTab;
        private System.Windows.Forms.Button nextFromChoose;
        private System.Windows.Forms.CheckBox tracksCheckBox;
        private System.Windows.Forms.CheckBox OSWCheckBox;
        private System.Windows.Forms.CheckBox mailCheckBox;
        private System.Windows.Forms.CheckBox chatCheckBox;
        private System.Windows.Forms.Label ChooseServices;
        private System.Windows.Forms.Button chooseFromChat;
        private System.Windows.Forms.Button nextFromChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox externalChatBox;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.Button backToHome;
        private System.Windows.Forms.Button nextToChoose;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtRouterPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape DMZInterfaceSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape BNAUPingSignal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label BNAUPing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tracksTab;
        private System.Windows.Forms.Button chooseFromTracks;
        private System.Windows.Forms.Button configureTracks;
        private System.Windows.Forms.ListView tracksListView;
        private System.Windows.Forms.Label listViewLabel;
        private System.Windows.Forms.StatusStrip tracksStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tracksTitleLabel;
        private System.Windows.Forms.ToolStripProgressBar trackProgress;
        private System.Windows.Forms.ToolStripStatusLabel tracksStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tracksProgressLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox externalTracksBox;
        private System.Windows.Forms.TabPage tracksNetworkTab;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.OvalShape IntTracksPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtTracksPingSignal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backFromTracksNet;
        private System.Windows.Forms.Button tracksNetTestButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView chatListView;
        private System.Windows.Forms.TabPage chatNetworkTab;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        private Microsoft.VisualBasic.PowerPacks.OvalShape IntChatPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtChatPingSignal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button backFromChatNet;
        private System.Windows.Forms.Button chatNetTestButton;
    }
}