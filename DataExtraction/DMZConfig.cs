using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace LDGManagementApplication
{
    public partial class DMZConfig : Form
    {
        public DMZConfig()
        {
            InitializeComponent();
            DMZWizard.TabPages.Clear();
            DMZWizard.TabPages.Add(NetworkConfig);
        }
        
        string DMZchatGW, planSourcePath, becFilePath;
        public static bool DMZConnected;
        bool DMZPlugged;

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            progressDMZNetwork.Value = 5;
            //call the extract data class, saying that this is the LDG plan and get the list 
            ExtractData extractDMZData = new ExtractData();
            extractDMZData.Extract_LDG_Data();
            List<string> externalExtractedData = extractDMZData.GetLDGList();
            becFilePath = ExtractData.DMZBecFilePath;
            if (becFilePath == null)
            {
                return;
            }

            //Share plan to virtual disk
            string sharedFolderPath = @"E:\Plan Files";

            //check if shared disk exists
            if (Directory.Exists(@"E:\"))
            {
                //get the directory of the plan from the becfilepath
                string[] becFilePathArray = becFilePath.Split('\\');
                Array.Resize(ref becFilePathArray, becFilePathArray.Length - 3);
                planSourcePath = String.Join("\\", becFilePathArray);

                //if folder doesn't exist create it
                if (!Directory.Exists(sharedFolderPath))
                {
                    Directory.CreateDirectory(sharedFolderPath);
                }

                //copy the files from plan to shared folder
                try
                {
                    //create the folders
                    foreach (string dirPath in Directory.GetDirectories(planSourcePath, "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(planSourcePath, sharedFolderPath));
                    }
                    //copy all files and replace any withsame name
                    foreach (string newPath in Directory.GetFiles(planSourcePath, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(newPath, newPath.Replace(planSourcePath, sharedFolderPath), true);
                    }
                    MessageBox.Show("Plan successfully copied to shared disk: " + Environment.NewLine + sharedFolderPath, "Plan Copied to Shared Disk", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error copying file to " + sharedFolderPath + ". Plan not copied to shared Disk.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Shared Disk not found, Plan not copied to shared Disk.", "Shared Disk not present", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            progressDMZNetwork.Value = 15;

            //produce the subnet IP & the firewall IP from the internal IP
            DMZchatGW = externalExtractedData[2];

            //call the configure via putty class
            Putty DMZ_Config = new DMZPutty(DMZchatGW);
            DMZ_Config.Configure();

            progressDMZNetwork.Value = 80;

            //determine whether cable is connected from ifconfig status
            if (DMZPutty.consoleOutput.Contains("status: active"))
            {
                DMZPlugged = true;
            }
            else
            {
                DMZPlugged = false;
            }

            progressDMZNetwork.Value = 85;

            //write log file
            WriteLog writeLog = new DMZLog();
            writeLog.WriteLogFile();
            progressDMZNetwork.Value = 90;

            //go to next page if it succeeded
            if (Putty.configSuccess == true)
            {
                progressDMZNetwork.Value = 100;
                DMZWizard.TabPages.Clear();
                DMZWizard.TabPages.Add(OSPF);
            }
            else
            {
                progressDMZNetwork.Value = 0;
                return;
            }
        }
        
        //
        //OSPF
        //

        private void returnNetworkConfig_Click(object sender, EventArgs e)
        {
            DMZWizard.TabPages.Clear();
            DMZWizard.TabPages.Add(NetworkConfig);
        }
        private void OSPFConfig_Click(object sender, EventArgs e)
        {
            progressDMZOSPF.Value = 5;
            Putty OSPF_DMZ = new DMZPutty(DMZchatGW);
            OSPF_DMZ.Configure_OSPF();
            progressDMZOSPF.Value = 65;

            //go to next page if it succeeded
            if (Putty.OSPFSuccess == true)
            {
                progressDMZOSPF.Value = 100;
                DMZWizard.TabPages.Clear();
                DMZWizard.TabPages.Add(networkTest);
            }
            else
            {
                progressDMZOSPF.Value = 0;
                return;
            }
        }

        //
        //Network Test
        //
        private void returnOSPF_Click(object sender, EventArgs e)
        {
            DMZWizard.TabPages.Clear();
            DMZWizard.TabPages.Add(OSPF);
        }
        private void testButton_Click(object sender, EventArgs e)
        {
            //if BNAU is unplugged put color red
            if (DMZPlugged == true)
            {
                DMZInterfaceSignal.FillColor = Color.Green;
                DMZConnected = true;
            }
            else
            {
                DMZInterfaceSignal.FillColor = Color.Red;
            }

            //universal error messages:
            //forst check connection is present
            if (DMZPlugged == false)
            {
                MainGUI error = new MainGUI();
                error.errorDialog(false);
                return;
            }
        }
    }
}
