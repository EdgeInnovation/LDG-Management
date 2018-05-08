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
            this.label1 = new System.Windows.Forms.Label();
            this.extChatGWBox = new System.Windows.Forms.TextBox();
            this.chooseFromChat = new System.Windows.Forms.Button();
            this.nextToMail = new System.Windows.Forms.Button();
            this.homeTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.FirewallPing = new System.Windows.Forms.Label();
            this.BNAUPing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nextToChoose = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ExtRouterPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ExtInterfacePingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.DMZPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.FWPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
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
            this.ExtTracksPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.IntTracksPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backFromTracksNet = new System.Windows.Forms.Button();
            this.tracksNetTestButton = new System.Windows.Forms.Button();
            this.ExternalWizard.SuspendLayout();
            this.chooseServicesTab.SuspendLayout();
            this.chatTab.SuspendLayout();
            this.homeTab.SuspendLayout();
            this.tracksTab.SuspendLayout();
            this.tracksStatusStrip.SuspendLayout();
            this.tracksNetworkTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExternalWizard
            // 
            this.ExternalWizard.Controls.Add(this.chooseServicesTab);
            this.ExternalWizard.Controls.Add(this.chatTab);
            this.ExternalWizard.Controls.Add(this.homeTab);
            this.ExternalWizard.Controls.Add(this.tracksTab);
            this.ExternalWizard.Controls.Add(this.tracksNetworkTab);
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
            this.ChooseServices.Location = new System.Drawing.Point(3, 31);
            this.ChooseServices.Name = "ChooseServices";
            this.ChooseServices.Size = new System.Drawing.Size(195, 13);
            this.ChooseServices.TabIndex = 0;
            this.ChooseServices.Text = "Please choose the services you require:";
            // 
            // chatTab
            // 
            this.chatTab.Controls.Add(this.label1);
            this.chatTab.Controls.Add(this.extChatGWBox);
            this.chatTab.Controls.Add(this.chooseFromChat);
            this.chatTab.Controls.Add(this.nextToMail);
            this.chatTab.Location = new System.Drawing.Point(4, 22);
            this.chatTab.Name = "chatTab";
            this.chatTab.Padding = new System.Windows.Forms.Padding(3);
            this.chatTab.Size = new System.Drawing.Size(327, 288);
            this.chatTab.TabIndex = 1;
            this.chatTab.Text = "Chat";
            this.chatTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "External Chat GW:";
            // 
            // extChatGWBox
            // 
            this.extChatGWBox.Location = new System.Drawing.Point(155, 94);
            this.extChatGWBox.Name = "extChatGWBox";
            this.extChatGWBox.Size = new System.Drawing.Size(100, 20);
            this.extChatGWBox.TabIndex = 8;
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
            // nextToMail
            // 
            this.nextToMail.Location = new System.Drawing.Point(246, 259);
            this.nextToMail.Name = "nextToMail";
            this.nextToMail.Size = new System.Drawing.Size(75, 23);
            this.nextToMail.TabIndex = 6;
            this.nextToMail.Text = "Next";
            this.nextToMail.UseVisualStyleBackColor = true;
            // 
            // homeTab
            // 
            this.homeTab.Controls.Add(this.label4);
            this.homeTab.Controls.Add(this.FirewallPing);
            this.homeTab.Controls.Add(this.BNAUPing);
            this.homeTab.Controls.Add(this.label2);
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
            this.label4.Location = new System.Drawing.Point(62, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "DMZ Pingable";
            // 
            // FirewallPing
            // 
            this.FirewallPing.AutoSize = true;
            this.FirewallPing.Location = new System.Drawing.Point(62, 64);
            this.FirewallPing.Name = "FirewallPing";
            this.FirewallPing.Size = new System.Drawing.Size(131, 13);
            this.FirewallPing.TabIndex = 11;
            this.FirewallPing.Text = "Firewall Interface Pingable";
            // 
            // BNAUPing
            // 
            this.BNAUPing.AutoSize = true;
            this.BNAUPing.Location = new System.Drawing.Point(62, 27);
            this.BNAUPing.Name = "BNAUPing";
            this.BNAUPing.Size = new System.Drawing.Size(81, 13);
            this.BNAUPing.TabIndex = 10;
            this.BNAUPing.Text = "BNAU Pingable";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "External Interface Pingable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 181);
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
            this.nextToChoose.Text = "Next";
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
            this.ExtInterfacePingSignal,
            this.DMZPingSignal,
            this.FWPingSignal,
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
            this.ExtRouterPingSignal.Location = new System.Drawing.Point(20, 171);
            this.ExtRouterPingSignal.Name = "ExtRouterPingSignal";
            this.ExtRouterPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // ExtInterfacePingSignal
            // 
            this.ExtInterfacePingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtInterfacePingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.ExtInterfacePingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtInterfacePingSignal.Location = new System.Drawing.Point(20, 134);
            this.ExtInterfacePingSignal.Name = "ExtInterfacePingSignal";
            this.ExtInterfacePingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // DMZPingSignal
            // 
            this.DMZPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.DMZPingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.DMZPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.DMZPingSignal.Location = new System.Drawing.Point(21, 93);
            this.DMZPingSignal.Name = "DMZPingSignal";
            this.DMZPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // FWPingSignal
            // 
            this.FWPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.FWPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.FWPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.FWPingSignal.Location = new System.Drawing.Point(21, 56);
            this.FWPingSignal.Name = "FWPingSignal";
            this.FWPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // BNAUPingSignal
            // 
            this.BNAUPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.BNAUPingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.BNAUPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.BNAUPingSignal.Location = new System.Drawing.Point(22, 17);
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
            // ExtTracksPingSignal
            // 
            this.ExtTracksPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtTracksPingSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.ExtTracksPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtTracksPingSignal.Location = new System.Drawing.Point(42, 77);
            this.ExtTracksPingSignal.Name = "ExtTracksPingSignal";
            this.ExtTracksPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // IntTracksPingSignal
            // 
            this.IntTracksPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.IntTracksPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.IntTracksPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.IntTracksPingSignal.Location = new System.Drawing.Point(41, 116);
            this.IntTracksPingSignal.Name = "IntTracksPingSignal";
            this.IntTracksPingSignal.Size = new System.Drawing.Size(24, 22);
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
        private System.Windows.Forms.Button nextToMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox extChatGWBox;
        private System.Windows.Forms.TabPage homeTab;
        private System.Windows.Forms.Button backToHome;
        private System.Windows.Forms.Button nextToChoose;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtRouterPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtInterfacePingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape DMZPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape FWPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape BNAUPingSignal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label FirewallPing;
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
    }
}