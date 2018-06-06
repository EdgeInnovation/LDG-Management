namespace LDGManagementApplication
{
    partial class MainGUI
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
            this.components = new System.ComponentModel.Container();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.Configuration = new System.Windows.Forms.TabPage();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.externalButton = new System.Windows.Forms.Button();
            this.DMZConfigButton = new System.Windows.Forms.Button();
            this.serviceConfigButton = new System.Windows.Forms.Button();
            this.BNAUConfigButton = new System.Windows.Forms.Button();
            this.Monitoring = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.MonitorBNAUSubnetBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.firewallPingControl = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.BNAUPingControl = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.pingTimer = new System.Windows.Forms.Timer(this.components);
            this.TabControl.SuspendLayout();
            this.Configuration.SuspendLayout();
            this.Monitoring.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.Configuration);
            this.TabControl.Controls.Add(this.Monitoring);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(365, 241);
            this.TabControl.TabIndex = 2;
            // 
            // Configuration
            // 
            this.Configuration.Controls.Add(this.usernameLabel);
            this.Configuration.Controls.Add(this.passwordBox);
            this.Configuration.Controls.Add(this.usernameBox);
            this.Configuration.Controls.Add(this.label1);
            this.Configuration.Controls.Add(this.label2);
            this.Configuration.Controls.Add(this.externalButton);
            this.Configuration.Controls.Add(this.DMZConfigButton);
            this.Configuration.Controls.Add(this.serviceConfigButton);
            this.Configuration.Controls.Add(this.BNAUConfigButton);
            this.Configuration.Location = new System.Drawing.Point(4, 22);
            this.Configuration.Name = "Configuration";
            this.Configuration.Padding = new System.Windows.Forms.Padding(3);
            this.Configuration.Size = new System.Drawing.Size(357, 215);
            this.Configuration.TabIndex = 0;
            this.Configuration.Text = "Configuration";
            this.Configuration.UseVisualStyleBackColor = true;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(35, 26);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(270, 13);
            this.usernameLabel.TabIndex = 18;
            this.usernameLabel.Text = "Please enter a Username and Password for the Firewall:";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(154, 96);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(97, 20);
            this.passwordBox.TabIndex = 17;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(154, 70);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(97, 20);
            this.usernameBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Username:";
            // 
            // externalButton
            // 
            this.externalButton.Location = new System.Drawing.Point(182, 160);
            this.externalButton.Name = "externalButton";
            this.externalButton.Size = new System.Drawing.Size(81, 45);
            this.externalButton.TabIndex = 13;
            this.externalButton.Text = "External 1 Configuration";
            this.externalButton.UseVisualStyleBackColor = true;
            this.externalButton.Click += new System.EventHandler(this.externalButton_Click);
            // 
            // DMZConfigButton
            // 
            this.DMZConfigButton.Location = new System.Drawing.Point(95, 160);
            this.DMZConfigButton.Name = "DMZConfigButton";
            this.DMZConfigButton.Size = new System.Drawing.Size(81, 45);
            this.DMZConfigButton.TabIndex = 12;
            this.DMZConfigButton.Text = "DMZ Configuration";
            this.DMZConfigButton.UseVisualStyleBackColor = true;
            this.DMZConfigButton.Click += new System.EventHandler(this.DMZConfigButton_Click);
            // 
            // serviceConfigButton
            // 
            this.serviceConfigButton.Location = new System.Drawing.Point(269, 160);
            this.serviceConfigButton.Name = "serviceConfigButton";
            this.serviceConfigButton.Size = new System.Drawing.Size(81, 45);
            this.serviceConfigButton.TabIndex = 11;
            this.serviceConfigButton.Text = "Service Configuration";
            this.serviceConfigButton.UseVisualStyleBackColor = true;
            this.serviceConfigButton.Click += new System.EventHandler(this.serviceConfigButton_Click);
            // 
            // BNAUConfigButton
            // 
            this.BNAUConfigButton.Location = new System.Drawing.Point(8, 160);
            this.BNAUConfigButton.Name = "BNAUConfigButton";
            this.BNAUConfigButton.Size = new System.Drawing.Size(81, 45);
            this.BNAUConfigButton.TabIndex = 9;
            this.BNAUConfigButton.Text = "Internal Configuration";
            this.BNAUConfigButton.UseVisualStyleBackColor = true;
            this.BNAUConfigButton.Click += new System.EventHandler(this.BNAUConfigButton_Click);
            // 
            // Monitoring
            // 
            this.Monitoring.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Monitoring.Controls.Add(this.label5);
            this.Monitoring.Controls.Add(this.MonitorBNAUSubnetBox);
            this.Monitoring.Controls.Add(this.label4);
            this.Monitoring.Controls.Add(this.label3);
            this.Monitoring.Controls.Add(this.shapeContainer1);
            this.Monitoring.Location = new System.Drawing.Point(4, 22);
            this.Monitoring.Name = "Monitoring";
            this.Monitoring.Padding = new System.Windows.Forms.Padding(3);
            this.Monitoring.Size = new System.Drawing.Size(357, 215);
            this.Monitoring.TabIndex = 1;
            this.Monitoring.Text = "Monitoring";
            this.Monitoring.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "BNAU Subnet:";
            // 
            // MonitorBNAUSubnetBox
            // 
            this.MonitorBNAUSubnetBox.Location = new System.Drawing.Point(168, 139);
            this.MonitorBNAUSubnetBox.Name = "MonitorBNAUSubnetBox";
            this.MonitorBNAUSubnetBox.Size = new System.Drawing.Size(97, 20);
            this.MonitorBNAUSubnetBox.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ping Internal Firewall Interface";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ping BNAU";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 3);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.firewallPingControl,
            this.BNAUPingControl});
            this.shapeContainer1.Size = new System.Drawing.Size(351, 209);
            this.shapeContainer1.TabIndex = 1;
            this.shapeContainer1.TabStop = false;
            // 
            // firewallPingControl
            // 
            this.firewallPingControl.BackColor = System.Drawing.Color.Red;
            this.firewallPingControl.FillColor = System.Drawing.Color.DarkGray;
            this.firewallPingControl.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.firewallPingControl.Location = new System.Drawing.Point(69, 80);
            this.firewallPingControl.Name = "firewallPingControl";
            this.firewallPingControl.Size = new System.Drawing.Size(25, 26);
            // 
            // BNAUPingControl
            // 
            this.BNAUPingControl.BackColor = System.Drawing.Color.Red;
            this.BNAUPingControl.FillColor = System.Drawing.Color.DarkGray;
            this.BNAUPingControl.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid;
            this.BNAUPingControl.Location = new System.Drawing.Point(70, 33);
            this.BNAUPingControl.Name = "BNAUPingControl";
            this.BNAUPingControl.Size = new System.Drawing.Size(25, 26);
            // 
            // pingTimer
            // 
            this.pingTimer.Interval = 5000;
            this.pingTimer.Tick += new System.EventHandler(this.pingTimer_Tick);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 260);
            this.Controls.Add(this.TabControl);
            this.Name = "MainGUI";
            this.Text = "LDG Management";
            this.TabControl.ResumeLayout(false);
            this.Configuration.ResumeLayout(false);
            this.Configuration.PerformLayout();
            this.Monitoring.ResumeLayout(false);
            this.Monitoring.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage Configuration;
        private System.Windows.Forms.TabPage Monitoring;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button BNAUConfigButton;
        private Microsoft.VisualBasic.PowerPacks.OvalShape firewallPingControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox MonitorBNAUSubnetBox;
        private System.Windows.Forms.Timer pingTimer;
        public Microsoft.VisualBasic.PowerPacks.OvalShape BNAUPingControl;
        private System.Windows.Forms.Button serviceConfigButton;
        private System.Windows.Forms.Button DMZConfigButton;
        private System.Windows.Forms.Button externalButton;
        private System.Windows.Forms.Label usernameLabel;
        public System.Windows.Forms.TextBox passwordBox;
        public System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

