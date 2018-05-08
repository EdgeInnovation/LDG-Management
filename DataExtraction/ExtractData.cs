﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DataExtraction
{
    class ExtractData
    {
        string line, IPAddress, Subnet, chatGW, fullLine;
        public static string internalBecFilePath;
        public static string DMZBecFilePath;

        //create lists to store the extracted data
        private List<string> internalExtractedData = new List<string>();
        private List<string> LDGExtractedData = new List<string>();
        private List<string> terminalNames = new List<string>();

        //methods to allow lists to be accessed from other classes
        public List<string> GetInternalList()
        {
            return internalExtractedData;
        }
        public List<string> GetLDGList()
        {
            return LDGExtractedData;
        }
        //bool is whether you want the terminal name or the IP address
        public List<string> GetServiceList()
        { 
            return terminalNames;           
        }

        public void Extract_Data(bool LDG)
            {
            //LDG
            if (LDG == true)
            {
                //user chooses bec file for correct terminal
                OpenFileDialog FileDialog = new OpenFileDialog
                {
                    Filter = "bec files|bec.txt",
                    Title = "Select the bec File for the LDG platform you are using"
                };
                if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Assign filePath variable to the selected name.  
                    DMZBecFilePath = FileDialog.FileName;
                }
                else
                {
                    DMZBecFilePath = null;
                }
                //read the internal file
                using (System.IO.StreamReader sr = new System.IO.StreamReader(DMZBecFilePath))
                {
                    line = sr.ReadLine();
                    //Loop through each line that has data
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Split each line into an array seperated by a space and extract each bit of necessary data.
                        string[] becFileData = line.Split(' ');
                        if (becFileData[0] == "IPAddress")
                        {
                           IPAddress = becFileData[1];
                           LDGExtractedData.Add(IPAddress);//0
                        }
                        else if (becFileData[0] == "Subnet")
                        {
                            Subnet = becFileData[1];
                            LDGExtractedData.Add(Subnet);//1
                        }
                        //presuming chat is the primary dns
                        else if (becFileData[0] == "FirstDns")
                        {
                            chatGW = becFileData[1];
                            LDGExtractedData.Add(chatGW);//2
                        }

                        //sort through the services roles and add them to a list. Dont want the radio ports
                        else if (!becFileData[0].Contains("CNR") && !becFileData[0].Contains("HCDR") && !becFileData[0].Contains("BNAU") && !becFileData[0].Contains("PCIDM") && becFileData[0].Contains("\"")) 
                        {
                            fullLine = becFileData[0] + becFileData[1];
                            terminalNames.Add(fullLine);
                        }
                    }
                }
            }

            //internal data
            else if(LDG == false)
            {
                //user chooses bec file for correct terminal
                OpenFileDialog FileDialog = new OpenFileDialog
                {
                    Filter = "bec files|bec.txt",
                    Title = "Select the bec File for the internal system you are using"
                };
                if (FileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Assign filePath variable to the selected name.  
                    internalBecFilePath = FileDialog.FileName;
                }
                else
                {
                    internalBecFilePath = null;
                }
                //read the internal file
                using (System.IO.StreamReader sr = new System.IO.StreamReader(internalBecFilePath))
                {
                    line = sr.ReadLine();
                    //Loop through each line that has data
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Split each line into an array seperated by a space and extract each bit of necessary data.
                        string[] becFileData = line.Split(' ');
                        if (becFileData[0] == "IPAddress")
                        {
                            IPAddress = becFileData[1];
                            internalExtractedData.Add(IPAddress);//0
                        }
                        else if (becFileData[0] == "Subnet")
                        {
                            Subnet = becFileData[1];
                            internalExtractedData.Add(Subnet);//1
                        }
                        //presuming chat is the primary dns
                        else if (becFileData[0] == "FirstDns")
                        {
                            chatGW = becFileData[1];
                            internalExtractedData.Add(chatGW);//2
                        }
                    }
                    
                }
            }
          
        }
         
    }
}

/*
//THE CODE BELOW WRITES THE EXTRACTED DATA TO A CONFIG FILE
using (System.IO.StreamReader sr = new System.IO.StreamReader(becFilePath))
                {
                    line = sr.ReadLine();
                    //Loop through each line that has data
                    while ((line = sr.ReadLine()) != null)
                    {
                        //Split each line into an array (input) seperated by a space and extract each bit of necessary data.
                        //Then stores each bit of data into a new array (output)
                        string[] becFileData = line.Split(' ');
                        if (becFileData[0] == "IPAddress")
                        {
                            IPAddress = becFileData[1];
                            output[0] = "IPAddress=" + IPAddress;
                            internalExtractedData.Add(IPAddress);//0
                        }
                        else if (becFileData[0] == "Subnet")
                        {
                            Subnet = becFileData[1];
                            output[1] = "Subnet=" + Subnet;
                            internalExtractedData.Add(Subnet);//1
                        }
                        //presuming chat is the primary dns
                        else if (becFileData[0] == "FirstDns")
                        {
                            chatGW = becFileData[1];
                            output[2] = "Chat GW=" + chatGW;
                            internalExtractedData.Add(chatGW);//2
                        }
                    }

                    internalConfigFilePath = @"C:\Program FIles (x86)\General Dynamics UK\LDG Management Application\InternalExtractedData.txt";
                    //create config file if it doesn't already exist
                    if (!File.Exists(internalConfigFilePath))
                    {
                        File.Create(internalConfigFilePath);
                    }
                    //Output each string to a single file
                    System.IO.File.WriteAllLines(internalConfigFilePath, output);
                    MessageBox.Show(@"Data Extracted. Find output file in C:\Program FIles (x86)\General Dynamics UK\LDG Management Application", "Job Complete");
                    return;
*/