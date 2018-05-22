using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace LDGMangementApplication
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

        //methods to return lists from other classes
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

        public void Extract_LDG_Data()
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
            if (DMZBecFilePath == null)
            {
                return;
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

        public void Extract_Internal_Data()
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
            if (internalBecFilePath == null)
            {
                return;
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