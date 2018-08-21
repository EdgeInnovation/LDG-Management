using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDGManagementApplication
{
    abstract class WriteLog
    {
        public abstract string LogPath
        {
            get;
        }

        public abstract string ErrorOutput
        {
            get;
        }
        public void WriteLogFile ()
        {
            string lineBreak = "\n" + "------------------------------------------------------------";

            //get the strings depending on which class is called. The class which is called will overwrite the general string
            string logPath = LogPath;
            string errorOutput = ErrorOutput;
            try
            {
                //if file doesn't exist create it
                if (!File.Exists(logPath))
                {
                    File.Create(logPath).Dispose();
                    using (StreamWriter sw = File.CreateText(logPath))
                    {
                        sw.Write(errorOutput + System.Environment.NewLine + lineBreak);
                    }
                }
                //append to existing file
                else
                {
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        sw.Write(System.Environment.NewLine + errorOutput + System.Environment.NewLine + lineBreak);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Access to " + logPath + " denied. Log File not created.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    class InternalLog : WriteLog
    {
        public override string LogPath
        {
            get
            {
                string logPath = @"C:\Program Files\General Dynamics UK\LDG Management Application\LMA_InternalConfig_Log.txt";
                return logPath;
            }            
        }
        public override string ErrorOutput
        {
            get
            {
                string errorOutput = InternalPutty.errorLogOutput;
                return errorOutput;
            }
        }
    }
    class DMZLog : WriteLog
    {
        public override string LogPath
        {
            get
            {
                string logPath = @"C:\Program Files\General Dynamics UK\LDG Management Application\LMA_DMZConfig_Log.txt";
                return logPath;
            }
        }
        public override string ErrorOutput
        {
            get
            {
                string errorOutput = DMZPutty.errorLogOutput;
                return errorOutput;
            }
        }
    }
    class ExternalLog : WriteLog
    {
        public override string LogPath
        {
            get
            {
                string logPath = @"C:\Program Files\General Dynamics UK\LDG Management Application\LMA_ExternalConfig_Log.txt";
                return logPath;
            }
        }
        public override string ErrorOutput
        {
            get
            {
                string errorOutput = ExternalPutty.errorLogOutput;
                return errorOutput;
            }
        }
    }
}
