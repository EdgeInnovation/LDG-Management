namespace LDGManagementApplication
{
    partial class DMZConfig
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
            this.DMZWizard = new System.Windows.Forms.TabControl();
            this.NetworkConfig = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.DMZTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressDMZNetwork = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigDMZSubnetBox = new System.Windows.Forms.TextBox();
            this.ConfigureButton = new System.Windows.Forms.Button();
            this.OSPF = new System.Windows.Forms.TabPage();
            this.DMZOSPFStatusStrip = new System.Windows.Forms.StatusStrip();
            this.DMZOSPFTitleLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressDMZOSPF = new System.Windows.Forms.ToolStripProgressBar();
            this.OSPFConfig = new System.Windows.Forms.Button();
            this.returnNetworkConfig = new System.Windows.Forms.Button();
            this.networkTest = new System.Windows.Forms.TabPage();
            this.returnOSPF = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.BNAUInterface = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.DMZInterfaceSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.DMZWizard.SuspendLayout();
            this.NetworkConfig.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.OSPF.SuspendLayout();
            this.DMZOSPFStatusStrip.SuspendLayout();
            this.networkTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // DMZWizard
            // 
            this.DMZWizard.Controls.Add(this.NetworkConfig);
            this.DMZWizard.Controls.Add(this.OSPF);
            this.DMZWizard.Controls.Add(this.networkTest);
            this.DMZWizard.Location = new System.Drawing.Point(12, 12);
            this.DMZWizard.Name = "DMZWizard";
            this.DMZWizard.SelectedIndex = 0;
            this.DMZWizard.Size = new System.Drawing.Size(336, 315);
            this.DMZWizard.TabIndex = 0;
            // 
            // NetworkConfig
            // 
            this.NetworkConfig.Controls.Add(this.statusStrip1);
            this.NetworkConfig.Controls.Add(this.label1);
            this.NetworkConfig.Controls.Add(this.ConfigDMZSubnetBox);
            this.NetworkConfig.Controls.Add(this.ConfigureButton);
            this.NetworkConfig.Location = new System.Drawing.Point(4, 22);
            this.NetworkConfig.Name = "NetworkConfig";
            this.NetworkConfig.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkConfig.Size = new System.Drawing.Size(328, 289);
            this.NetworkConfig.TabIndex = 1;
            this.NetworkConfig.Text = "Network Configuration";
            this.NetworkConfig.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DMZTitleLabel,
            this.progressDMZNetwork});
            this.statusStrip1.Location = new System.Drawing.Point(3, 264);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(322, 22);
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // DMZTitleLabel
            // 
            this.DMZTitleLabel.Name = "DMZTitleLabel";
            this.DMZTitleLabel.Size = new System.Drawing.Size(55, 17);
            this.DMZTitleLabel.Text = "Progress:";
            // 
            // progressDMZNetwork
            // 
            this.progressDMZNetwork.Name = "progressDMZNetwork";
            this.progressDMZNetwork.Size = new System.Drawing.Size(100, 16);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "DMZ Subnet IP:";
            // 
            // ConfigDMZSubnetBox
            // 
            this.ConfigDMZSubnetBox.Location = new System.Drawing.Point(162, 116);
            this.ConfigDMZSubnetBox.Name = "ConfigDMZSubnetBox";
            this.ConfigDMZSubnetBox.ReadOnly = true;
            this.ConfigDMZSubnetBox.Size = new System.Drawing.Size(97, 20);
            this.ConfigDMZSubnetBox.TabIndex = 21;
            // 
            // ConfigureButton
            // 
            this.ConfigureButton.Location = new System.Drawing.Point(244, 227);
            this.ConfigureButton.Name = "ConfigureButton";
            this.ConfigureButton.Size = new System.Drawing.Size(78, 34);
            this.ConfigureButton.TabIndex = 19;
            this.ConfigureButton.Text = "Configure";
            this.ConfigureButton.UseVisualStyleBackColor = true;
            this.ConfigureButton.Click += new System.EventHandler(this.ConfigureButton_Click);
            // 
            // OSPF
            // 
            this.OSPF.Controls.Add(this.DMZOSPFStatusStrip);
            this.OSPF.Controls.Add(this.OSPFConfig);
            this.OSPF.Controls.Add(this.returnNetworkConfig);
            this.OSPF.Location = new System.Drawing.Point(4, 22);
            this.OSPF.Name = "OSPF";
            this.OSPF.Padding = new System.Windows.Forms.Padding(3);
            this.OSPF.Size = new System.Drawing.Size(328, 289);
            this.OSPF.TabIndex = 2;
            this.OSPF.Text = "Configure OSPF Routing";
            this.OSPF.UseVisualStyleBackColor = true;
            // 
            // DMZOSPFStatusStrip
            // 
            this.DMZOSPFStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DMZOSPFTitleLabel,
            this.progressDMZOSPF});
            this.DMZOSPFStatusStrip.Location = new System.Drawing.Point(3, 264);
            this.DMZOSPFStatusStrip.Name = "DMZOSPFStatusStrip";
            this.DMZOSPFStatusStrip.Size = new System.Drawing.Size(322, 22);
            this.DMZOSPFStatusStrip.TabIndex = 27;
            this.DMZOSPFStatusStrip.Text = "statusStrip2";
            // 
            // DMZOSPFTitleLabel
            // 
            this.DMZOSPFTitleLabel.Name = "DMZOSPFTitleLabel";
            this.DMZOSPFTitleLabel.Size = new System.Drawing.Size(55, 17);
            this.DMZOSPFTitleLabel.Text = "Progress:";
            // 
            // progressDMZOSPF
            // 
            this.progressDMZOSPF.Name = "progressDMZOSPF";
            this.progressDMZOSPF.Size = new System.Drawing.Size(100, 16);
            // 
            // OSPFConfig
            // 
            this.OSPFConfig.Location = new System.Drawing.Point(229, 222);
            this.OSPFConfig.Name = "OSPFConfig";
            this.OSPFConfig.Size = new System.Drawing.Size(93, 39);
            this.OSPFConfig.TabIndex = 5;
            this.OSPFConfig.Text = "Configure OSPF";
            this.OSPFConfig.UseVisualStyleBackColor = true;
            this.OSPFConfig.Click += new System.EventHandler(this.OSPFConfig_Click);
            // 
            // returnNetworkConfig
            // 
            this.returnNetworkConfig.Location = new System.Drawing.Point(6, 222);
            this.returnNetworkConfig.Name = "returnNetworkConfig";
            this.returnNetworkConfig.Size = new System.Drawing.Size(93, 39);
            this.returnNetworkConfig.TabIndex = 4;
            this.returnNetworkConfig.Text = "Return to Network Config";
            this.returnNetworkConfig.UseVisualStyleBackColor = true;
            this.returnNetworkConfig.Click += new System.EventHandler(this.returnNetworkConfig_Click);
            // 
            // networkTest
            // 
            this.networkTest.Controls.Add(this.returnOSPF);
            this.networkTest.Controls.Add(this.testButton);
            this.networkTest.Controls.Add(this.BNAUInterface);
            this.networkTest.Controls.Add(this.shapeContainer1);
            this.networkTest.Location = new System.Drawing.Point(4, 22);
            this.networkTest.Name = "networkTest";
            this.networkTest.Padding = new System.Windows.Forms.Padding(3);
            this.networkTest.Size = new System.Drawing.Size(328, 289);
            this.networkTest.TabIndex = 3;
            this.networkTest.Text = "Network Test";
            this.networkTest.UseVisualStyleBackColor = true;
            // 
            // returnOSPF
            // 
            this.returnOSPF.Location = new System.Drawing.Point(6, 243);
            this.returnOSPF.Name = "returnOSPF";
            this.returnOSPF.Size = new System.Drawing.Size(93, 39);
            this.returnOSPF.TabIndex = 10;
            this.returnOSPF.Text = "Return to Set up";
            this.returnOSPF.UseVisualStyleBackColor = true;
            this.returnOSPF.Click += new System.EventHandler(this.returnOSPF_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(217, 243);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(105, 40);
            this.testButton.TabIndex = 9;
            this.testButton.Text = "Test Connection";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // BNAUInterface
            // 
            this.BNAUInterface.AutoSize = true;
            this.BNAUInterface.Location = new System.Drawing.Point(121, 118);
            this.BNAUInterface.Name = "BNAUInterface";
            this.BNAUInterface.Size = new System.Drawing.Size(86, 13);
            this.BNAUInterface.TabIndex = 7;
            this.BNAUInterface.Text = "DMZ Connected";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.DMZInterfaceSignal});
            this.shapeContainer1.Size = new System.Drawing.Size(322, 283);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // DMZInterfaceSignal
            // 
            this.DMZInterfaceSignal.BackColor = System.Drawing.Color.DarkGray;
            this.DMZInterfaceSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.DMZInterfaceSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.DMZInterfaceSignal.Location = new System.Drawing.Point(73, 109);
            this.DMZInterfaceSignal.Name = "DMZInterfaceSignal";
            this.DMZInterfaceSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // DMZConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 339);
            this.Controls.Add(this.DMZWizard);
            this.Name = "DMZConfig";
            this.Text = "DMZConfig";
            this.DMZWizard.ResumeLayout(false);
            this.NetworkConfig.ResumeLayout(false);
            this.NetworkConfig.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.OSPF.ResumeLayout(false);
            this.OSPF.PerformLayout();
            this.DMZOSPFStatusStrip.ResumeLayout(false);
            this.DMZOSPFStatusStrip.PerformLayout();
            this.networkTest.ResumeLayout(false);
            this.networkTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl DMZWizard;
        private System.Windows.Forms.TabPage NetworkConfig;
        private System.Windows.Forms.Button ConfigureButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConfigDMZSubnetBox;
        private System.Windows.Forms.TabPage OSPF;
        private System.Windows.Forms.TabPage networkTest;
        private System.Windows.Forms.Button OSPFConfig;
        private System.Windows.Forms.Button returnNetworkConfig;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape DMZInterfaceSignal;
        private System.Windows.Forms.Label BNAUInterface;
        private System.Windows.Forms.Button returnOSPF;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DMZTitleLabel;
        private System.Windows.Forms.ToolStripProgressBar progressDMZNetwork;
        private System.Windows.Forms.StatusStrip DMZOSPFStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel DMZOSPFTitleLabel;
        private System.Windows.Forms.ToolStripProgressBar progressDMZOSPF;
    }
}