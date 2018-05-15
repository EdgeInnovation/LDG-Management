namespace DataExtraction
{
    partial class InternalConfig
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
            this.BNAUWizard = new System.Windows.Forms.TabControl();
            this.Network = new System.Windows.Forms.TabPage();
            this.internalStatusStrip = new System.Windows.Forms.StatusStrip();
            this.internalTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressIntNetwork = new System.Windows.Forms.ToolStripProgressBar();
            this.ConfigureButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigBNAUSubnetBox = new System.Windows.Forms.TextBox();
            this.networkTest = new System.Windows.Forms.TabPage();
            this.BNAUPing = new System.Windows.Forms.Label();
            this.BNAUInterface = new System.Windows.Forms.Label();
            this.returnConfig = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.BNAUPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.BNAUInterfaceSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.OSPF = new System.Windows.Forms.TabPage();
            this.internalOSPFStatusStrip = new System.Windows.Forms.StatusStrip();
            this.intOSPFTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressIntOSPF = new System.Windows.Forms.ToolStripProgressBar();
            this.OSPFConfig = new System.Windows.Forms.Button();
            this.returnNetworkTest = new System.Windows.Forms.Button();
            this.BNAUWizard.SuspendLayout();
            this.Network.SuspendLayout();
            this.internalStatusStrip.SuspendLayout();
            this.networkTest.SuspendLayout();
            this.OSPF.SuspendLayout();
            this.internalOSPFStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // BNAUWizard
            // 
            this.BNAUWizard.Controls.Add(this.Network);
            this.BNAUWizard.Controls.Add(this.networkTest);
            this.BNAUWizard.Controls.Add(this.OSPF);
            this.BNAUWizard.Location = new System.Drawing.Point(12, 12);
            this.BNAUWizard.Name = "BNAUWizard";
            this.BNAUWizard.SelectedIndex = 0;
            this.BNAUWizard.Size = new System.Drawing.Size(336, 315);
            this.BNAUWizard.TabIndex = 0;
            // 
            // Network
            // 
            this.Network.Controls.Add(this.internalStatusStrip);
            this.Network.Controls.Add(this.ConfigureButton);
            this.Network.Controls.Add(this.label1);
            this.Network.Controls.Add(this.ConfigBNAUSubnetBox);
            this.Network.Location = new System.Drawing.Point(4, 22);
            this.Network.Name = "Network";
            this.Network.Padding = new System.Windows.Forms.Padding(3);
            this.Network.Size = new System.Drawing.Size(328, 289);
            this.Network.TabIndex = 1;
            this.Network.Text = "Set up Network Objects";
            this.Network.UseVisualStyleBackColor = true;
            // 
            // internalStatusStrip
            // 
            this.internalStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.internalTitleLabel,
            this.progressIntNetwork});
            this.internalStatusStrip.Location = new System.Drawing.Point(3, 264);
            this.internalStatusStrip.Name = "internalStatusStrip";
            this.internalStatusStrip.Size = new System.Drawing.Size(322, 22);
            this.internalStatusStrip.TabIndex = 27;
            this.internalStatusStrip.Text = "statusStrip1";
            // 
            // internalTitleLabel
            // 
            this.internalTitleLabel.Name = "internalTitleLabel";
            this.internalTitleLabel.Size = new System.Drawing.Size(55, 17);
            this.internalTitleLabel.Text = "Progress:";
            // 
            // progressIntNetwork
            // 
            this.progressIntNetwork.Name = "progressIntNetwork";
            this.progressIntNetwork.Size = new System.Drawing.Size(100, 16);
            // 
            // ConfigureButton
            // 
            this.ConfigureButton.Location = new System.Drawing.Point(244, 227);
            this.ConfigureButton.Name = "ConfigureButton";
            this.ConfigureButton.Size = new System.Drawing.Size(78, 34);
            this.ConfigureButton.TabIndex = 8;
            this.ConfigureButton.Text = "Configure";
            this.ConfigureButton.UseVisualStyleBackColor = true;
            this.ConfigureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Internal BNAU Subnet IP:";
            // 
            // ConfigBNAUSubnetBox
            // 
            this.ConfigBNAUSubnetBox.Location = new System.Drawing.Point(188, 99);
            this.ConfigBNAUSubnetBox.Name = "ConfigBNAUSubnetBox";
            this.ConfigBNAUSubnetBox.ReadOnly = true;
            this.ConfigBNAUSubnetBox.Size = new System.Drawing.Size(97, 20);
            this.ConfigBNAUSubnetBox.TabIndex = 6;
            // 
            // networkTest
            // 
            this.networkTest.Controls.Add(this.BNAUPing);
            this.networkTest.Controls.Add(this.BNAUInterface);
            this.networkTest.Controls.Add(this.returnConfig);
            this.networkTest.Controls.Add(this.testButton);
            this.networkTest.Controls.Add(this.shapeContainer1);
            this.networkTest.Location = new System.Drawing.Point(4, 22);
            this.networkTest.Name = "networkTest";
            this.networkTest.Padding = new System.Windows.Forms.Padding(3);
            this.networkTest.Size = new System.Drawing.Size(328, 289);
            this.networkTest.TabIndex = 2;
            this.networkTest.Text = "Network Test";
            this.networkTest.UseVisualStyleBackColor = true;
            // 
            // BNAUPing
            // 
            this.BNAUPing.AutoSize = true;
            this.BNAUPing.Location = new System.Drawing.Point(124, 128);
            this.BNAUPing.Name = "BNAUPing";
            this.BNAUPing.Size = new System.Drawing.Size(81, 13);
            this.BNAUPing.TabIndex = 5;
            this.BNAUPing.Text = "BNAU Pingable";
            // 
            // BNAUInterface
            // 
            this.BNAUInterface.AutoSize = true;
            this.BNAUInterface.Location = new System.Drawing.Point(124, 90);
            this.BNAUInterface.Name = "BNAUInterface";
            this.BNAUInterface.Size = new System.Drawing.Size(92, 13);
            this.BNAUInterface.TabIndex = 3;
            this.BNAUInterface.Text = "BNAU Connected";
            // 
            // returnConfig
            // 
            this.returnConfig.Location = new System.Drawing.Point(6, 244);
            this.returnConfig.Name = "returnConfig";
            this.returnConfig.Size = new System.Drawing.Size(93, 39);
            this.returnConfig.TabIndex = 1;
            this.returnConfig.Text = "Return to Set up";
            this.returnConfig.UseVisualStyleBackColor = true;
            this.returnConfig.Click += new System.EventHandler(this.returnConfig_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(217, 243);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(105, 40);
            this.testButton.TabIndex = 0;
            this.testButton.Text = "Test Connection";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.BNAUPingSignal,
            this.BNAUInterfaceSignal});
            this.shapeContainer1.Size = new System.Drawing.Size(322, 283);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // BNAUPingSignal
            // 
            this.BNAUPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.BNAUPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.BNAUPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.BNAUPingSignal.Location = new System.Drawing.Point(45, 115);
            this.BNAUPingSignal.Name = "BNAUPingSignal";
            this.BNAUPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // BNAUInterfaceSignal
            // 
            this.BNAUInterfaceSignal.BackColor = System.Drawing.Color.DarkGray;
            this.BNAUInterfaceSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.BNAUInterfaceSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.BNAUInterfaceSignal.Location = new System.Drawing.Point(46, 77);
            this.BNAUInterfaceSignal.Name = "BNAUInterfaceSignal";
            this.BNAUInterfaceSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // OSPF
            // 
            this.OSPF.Controls.Add(this.internalOSPFStatusStrip);
            this.OSPF.Controls.Add(this.OSPFConfig);
            this.OSPF.Controls.Add(this.returnNetworkTest);
            this.OSPF.Location = new System.Drawing.Point(4, 22);
            this.OSPF.Name = "OSPF";
            this.OSPF.Padding = new System.Windows.Forms.Padding(3);
            this.OSPF.Size = new System.Drawing.Size(328, 289);
            this.OSPF.TabIndex = 3;
            this.OSPF.Text = "Configure OSPF Routing";
            this.OSPF.UseVisualStyleBackColor = true;
            // 
            // internalOSPFStatusStrip
            // 
            this.internalOSPFStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intOSPFTitleLabel,
            this.progressIntOSPF});
            this.internalOSPFStatusStrip.Location = new System.Drawing.Point(3, 264);
            this.internalOSPFStatusStrip.Name = "internalOSPFStatusStrip";
            this.internalOSPFStatusStrip.Size = new System.Drawing.Size(322, 22);
            this.internalOSPFStatusStrip.TabIndex = 27;
            this.internalOSPFStatusStrip.Text = "statusStrip1";
            // 
            // intOSPFTitleLabel
            // 
            this.intOSPFTitleLabel.Name = "intOSPFTitleLabel";
            this.intOSPFTitleLabel.Size = new System.Drawing.Size(55, 17);
            this.intOSPFTitleLabel.Text = "Progress:";
            // 
            // progressIntOSPF
            // 
            this.progressIntOSPF.Name = "progressIntOSPF";
            this.progressIntOSPF.Size = new System.Drawing.Size(100, 16);
            // 
            // OSPFConfig
            // 
            this.OSPFConfig.Location = new System.Drawing.Point(229, 222);
            this.OSPFConfig.Name = "OSPFConfig";
            this.OSPFConfig.Size = new System.Drawing.Size(93, 39);
            this.OSPFConfig.TabIndex = 3;
            this.OSPFConfig.Text = "Configure OSPF";
            this.OSPFConfig.UseVisualStyleBackColor = true;
            this.OSPFConfig.Click += new System.EventHandler(this.OSPFConfig_Click);
            // 
            // returnNetworkTest
            // 
            this.returnNetworkTest.Location = new System.Drawing.Point(6, 222);
            this.returnNetworkTest.Name = "returnNetworkTest";
            this.returnNetworkTest.Size = new System.Drawing.Size(93, 39);
            this.returnNetworkTest.TabIndex = 2;
            this.returnNetworkTest.Text = "Return to Network Config";
            this.returnNetworkTest.UseVisualStyleBackColor = true;
            this.returnNetworkTest.Click += new System.EventHandler(this.returnNetworkTest_Click);
            // 
            // InternalConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 339);
            this.Controls.Add(this.BNAUWizard);
            this.Name = "InternalConfig";
            this.Text = "Configure BNAU";
            this.BNAUWizard.ResumeLayout(false);
            this.Network.ResumeLayout(false);
            this.Network.PerformLayout();
            this.internalStatusStrip.ResumeLayout(false);
            this.internalStatusStrip.PerformLayout();
            this.networkTest.ResumeLayout(false);
            this.networkTest.PerformLayout();
            this.OSPF.ResumeLayout(false);
            this.OSPF.PerformLayout();
            this.internalOSPFStatusStrip.ResumeLayout(false);
            this.internalOSPFStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl BNAUWizard;
        private System.Windows.Forms.TabPage Network;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConfigBNAUSubnetBox;
        private System.Windows.Forms.Button ConfigureButton;
        private System.Windows.Forms.TabPage networkTest;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TabPage OSPF;
        private System.Windows.Forms.Button returnConfig;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape BNAUPingSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape BNAUInterfaceSignal;
        private System.Windows.Forms.Label BNAUInterface;
        private System.Windows.Forms.Label BNAUPing;
        private System.Windows.Forms.Button returnNetworkTest;
        private System.Windows.Forms.Button OSPFConfig;
        private System.Windows.Forms.StatusStrip internalStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel internalTitleLabel;
        private System.Windows.Forms.ToolStripProgressBar progressIntNetwork;
        private System.Windows.Forms.StatusStrip internalOSPFStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel intOSPFTitleLabel;
        private System.Windows.Forms.ToolStripProgressBar progressIntOSPF;
    }
}