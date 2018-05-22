namespace LDGMangementApplication
{
    partial class Router
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
            this.routerPasswordBox = new System.Windows.Forms.TextBox();
            this.routerUsernameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.routerStatusButton = new System.Windows.Forms.Button();
            this.routerStatusBox = new System.Windows.Forms.TextBox();
            this.routerInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // routerPasswordBox
            // 
            this.routerPasswordBox.Location = new System.Drawing.Point(142, 77);
            this.routerPasswordBox.Name = "routerPasswordBox";
            this.routerPasswordBox.PasswordChar = '*';
            this.routerPasswordBox.Size = new System.Drawing.Size(97, 20);
            this.routerPasswordBox.TabIndex = 21;
            // 
            // routerUsernameBox
            // 
            this.routerUsernameBox.Location = new System.Drawing.Point(142, 51);
            this.routerUsernameBox.Name = "routerUsernameBox";
            this.routerUsernameBox.Size = new System.Drawing.Size(97, 20);
            this.routerUsernameBox.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Username:";
            // 
            // routerStatusButton
            // 
            this.routerStatusButton.Location = new System.Drawing.Point(220, 304);
            this.routerStatusButton.Name = "routerStatusButton";
            this.routerStatusButton.Size = new System.Drawing.Size(88, 30);
            this.routerStatusButton.TabIndex = 22;
            this.routerStatusButton.Text = "Router Status";
            this.routerStatusButton.UseVisualStyleBackColor = true;
            this.routerStatusButton.Click += new System.EventHandler(this.routerStatusButton_Click);
            // 
            // routerStatusBox
            // 
            this.routerStatusBox.Location = new System.Drawing.Point(12, 103);
            this.routerStatusBox.Multiline = true;
            this.routerStatusBox.Name = "routerStatusBox";
            this.routerStatusBox.Size = new System.Drawing.Size(296, 195);
            this.routerStatusBox.TabIndex = 23;
            // 
            // routerInfoLabel
            // 
            this.routerInfoLabel.AutoSize = true;
            this.routerInfoLabel.Location = new System.Drawing.Point(3, 20);
            this.routerInfoLabel.Name = "routerInfoLabel";
            this.routerInfoLabel.Size = new System.Drawing.Size(305, 13);
            this.routerInfoLabel.TabIndex = 24;
            this.routerInfoLabel.Text = "Please enter the Username and Password for the Cisco Router:";
            // 
            // Router
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 346);
            this.Controls.Add(this.routerInfoLabel);
            this.Controls.Add(this.routerStatusBox);
            this.Controls.Add(this.routerStatusButton);
            this.Controls.Add(this.routerPasswordBox);
            this.Controls.Add(this.routerUsernameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Router";
            this.Text = "Router";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox routerPasswordBox;
        public System.Windows.Forms.TextBox routerUsernameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button routerStatusButton;
        private System.Windows.Forms.TextBox routerStatusBox;
        private System.Windows.Forms.Label routerInfoLabel;
    }
}