namespace LDGManagementApplication
{
    partial class ExternalConfig
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
            this.externalWizard = new System.Windows.Forms.TabControl();
            this.inputInfo = new System.Windows.Forms.TabPage();
            this.extRouterMaskBox = new System.Windows.Forms.TextBox();
            this.extFirewallMaskBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.externalStatusLabal = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressExtNetwork = new System.Windows.Forms.ToolStripProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.externalRouterBox = new System.Windows.Forms.TextBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.externalFWLabel = new System.Windows.Forms.Label();
            this.externalFWBox = new System.Windows.Forms.TextBox();
            this.testNetwork = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.backToStart = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.ExtInterfaceSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.ExtRouterPingSignal = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.externalWizard.SuspendLayout();
            this.inputInfo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.testNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // externalWizard
            // 
            this.externalWizard.Controls.Add(this.inputInfo);
            this.externalWizard.Controls.Add(this.testNetwork);
            this.externalWizard.Location = new System.Drawing.Point(12, 12);
            this.externalWizard.Name = "externalWizard";
            this.externalWizard.SelectedIndex = 0;
            this.externalWizard.Size = new System.Drawing.Size(335, 313);
            this.externalWizard.TabIndex = 0;
            // 
            // inputInfo
            // 
            this.inputInfo.Controls.Add(this.extRouterMaskBox);
            this.inputInfo.Controls.Add(this.extFirewallMaskBox);
            this.inputInfo.Controls.Add(this.label5);
            this.inputInfo.Controls.Add(this.label4);
            this.inputInfo.Controls.Add(this.statusStrip1);
            this.inputInfo.Controls.Add(this.label3);
            this.inputInfo.Controls.Add(this.externalRouterBox);
            this.inputInfo.Controls.Add(this.nextButton);
            this.inputInfo.Controls.Add(this.externalFWLabel);
            this.inputInfo.Controls.Add(this.externalFWBox);
            this.inputInfo.Location = new System.Drawing.Point(4, 22);
            this.inputInfo.Name = "inputInfo";
            this.inputInfo.Padding = new System.Windows.Forms.Padding(3);
            this.inputInfo.Size = new System.Drawing.Size(327, 287);
            this.inputInfo.TabIndex = 0;
            this.inputInfo.Text = "Input Information";
            this.inputInfo.UseVisualStyleBackColor = true;
            // 
            // extRouterMaskBox
            // 
            this.extRouterMaskBox.Location = new System.Drawing.Point(274, 121);
            this.extRouterMaskBox.MaxLength = 2;
            this.extRouterMaskBox.Name = "extRouterMaskBox";
            this.extRouterMaskBox.Size = new System.Drawing.Size(19, 20);
            this.extRouterMaskBox.TabIndex = 9;
            // 
            // extFirewallMaskBox
            // 
            this.extFirewallMaskBox.Location = new System.Drawing.Point(274, 98);
            this.extFirewallMaskBox.MaxLength = 2;
            this.extFirewallMaskBox.Name = "extFirewallMaskBox";
            this.extFirewallMaskBox.Size = new System.Drawing.Size(19, 20);
            this.extFirewallMaskBox.TabIndex = 8;
            this.extFirewallMaskBox.TextChanged += new System.EventHandler(this.UpdateMaskBox);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "/";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.externalStatusLabal,
            this.progressExtNetwork});
            this.statusStrip1.Location = new System.Drawing.Point(3, 262);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(321, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // externalStatusLabal
            // 
            this.externalStatusLabal.Name = "externalStatusLabal";
            this.externalStatusLabal.Size = new System.Drawing.Size(55, 17);
            this.externalStatusLabal.Text = "Progress:";
            // 
            // progressExtNetwork
            // 
            this.progressExtNetwork.Name = "progressExtNetwork";
            this.progressExtNetwork.Size = new System.Drawing.Size(100, 16);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "External Router IP Address:";
            // 
            // externalRouterBox
            // 
            this.externalRouterBox.Location = new System.Drawing.Point(150, 121);
            this.externalRouterBox.Name = "externalRouterBox";
            this.externalRouterBox.Size = new System.Drawing.Size(100, 20);
            this.externalRouterBox.TabIndex = 3;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(233, 235);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(88, 24);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "Configure";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // externalFWLabel
            // 
            this.externalFWLabel.AutoSize = true;
            this.externalFWLabel.Location = new System.Drawing.Point(13, 98);
            this.externalFWLabel.Name = "externalFWLabel";
            this.externalFWLabel.Size = new System.Drawing.Size(131, 13);
            this.externalFWLabel.TabIndex = 1;
            this.externalFWLabel.Text = "External Firewall Interface:";
            // 
            // externalFWBox
            // 
            this.externalFWBox.Location = new System.Drawing.Point(150, 98);
            this.externalFWBox.Name = "externalFWBox";
            this.externalFWBox.Size = new System.Drawing.Size(100, 20);
            this.externalFWBox.TabIndex = 0;
            // 
            // testNetwork
            // 
            this.testNetwork.Controls.Add(this.label2);
            this.testNetwork.Controls.Add(this.label1);
            this.testNetwork.Controls.Add(this.testButton);
            this.testNetwork.Controls.Add(this.backToStart);
            this.testNetwork.Controls.Add(this.shapeContainer1);
            this.testNetwork.Location = new System.Drawing.Point(4, 22);
            this.testNetwork.Name = "testNetwork";
            this.testNetwork.Padding = new System.Windows.Forms.Padding(3);
            this.testNetwork.Size = new System.Drawing.Size(327, 287);
            this.testNetwork.TabIndex = 1;
            this.testNetwork.Text = "Network Test";
            this.testNetwork.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "External Interface Connected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "External Router Pingable";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(233, 250);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(88, 31);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // backToStart
            // 
            this.backToStart.Location = new System.Drawing.Point(6, 250);
            this.backToStart.Name = "backToStart";
            this.backToStart.Size = new System.Drawing.Size(88, 31);
            this.backToStart.TabIndex = 0;
            this.backToStart.Text = "Back";
            this.backToStart.UseVisualStyleBackColor = true;
            this.backToStart.Click += new System.EventHandler(this.backToStart_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.ExtInterfaceSignal,
            this.ExtRouterPingSignal});
            this.shapeContainer1.Size = new System.Drawing.Size(321, 281);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // ExtInterfaceSignal
            // 
            this.ExtInterfaceSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtInterfaceSignal.FillColor = System.Drawing.SystemColors.ControlDark;
            this.ExtInterfaceSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtInterfaceSignal.Location = new System.Drawing.Point(53, 66);
            this.ExtInterfaceSignal.Name = "ExtInterfaceSignal";
            this.ExtInterfaceSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // ExtRouterPingSignal
            // 
            this.ExtRouterPingSignal.BackColor = System.Drawing.Color.DarkGray;
            this.ExtRouterPingSignal.FillColor = System.Drawing.SystemColors.ButtonShadow;
            this.ExtRouterPingSignal.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.ExtRouterPingSignal.Location = new System.Drawing.Point(52, 105);
            this.ExtRouterPingSignal.Name = "ExtRouterPingSignal";
            this.ExtRouterPingSignal.Size = new System.Drawing.Size(24, 22);
            // 
            // serviceWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 337);
            this.Controls.Add(this.externalWizard);
            this.Name = "serviceWizard";
            this.Text = "External 1 Config";
            this.externalWizard.ResumeLayout(false);
            this.inputInfo.ResumeLayout(false);
            this.inputInfo.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.testNetwork.ResumeLayout(false);
            this.testNetwork.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl externalWizard;
        private System.Windows.Forms.TabPage inputInfo;
        private System.Windows.Forms.TabPage testNetwork;
        private System.Windows.Forms.Label externalFWLabel;
        private System.Windows.Forms.TextBox externalFWBox;
        private System.Windows.Forms.Button backToStart;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Button nextButton;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtInterfaceSignal;
        private Microsoft.VisualBasic.PowerPacks.OvalShape ExtRouterPingSignal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox externalRouterBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel externalStatusLabal;
        private System.Windows.Forms.ToolStripProgressBar progressExtNetwork;
        private System.Windows.Forms.TextBox extRouterMaskBox;
        private System.Windows.Forms.TextBox extFirewallMaskBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}