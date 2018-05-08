using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace DataExtraction
{
    class Ping_
    {
        //these are the public bools that will be used in the main class
        public static bool BNAUPingable, firewallPingable, externalPingable;
        string BNAUIPAddr, firewallIPAddr;

        //timer that is set up in design time to ping
        public void Ping_BNAU(string SubnetIP, bool DMZ)
        {

            if (DMZ == true)
            {
                BNAUIPAddr = SubnetIP + ".0";
            }
            else if (DMZ == false)
            {
                //get the BNAU IP and firewall IP from the subnet
                BNAUIPAddr = SubnetIP + ".1";
                firewallIPAddr = SubnetIP + ".17";
            }
            
            //if the BNAU Subnet is empty then quit
            if (SubnetIP == "")
            {
                MessageBox.Show("Please enter the BNAU subnet IP Address to monitor", "Error");
                return;
            }

            //Ping BNAU
            try
            {
                Ping pingBNAU = new Ping();
                PingReply BNAUReply = pingBNAU.Send(BNAUIPAddr);
                if (BNAUReply.Status == IPStatus.Success)
                {
                    BNAUPingable = true;                    
                }
                else
                {
                    BNAUPingable = false;
                }
            }
            catch (PingException)
            {
                BNAUPingable = false;
            }

            if (DMZ == false)
            {
                //Ping Firewall
                try
                {
                    Ping pingFW = new Ping();
                    PingReply FWReply = pingFW.Send(firewallIPAddr);
                    if (FWReply.Status == IPStatus.Success)
                    {
                        firewallPingable = true;

                    }
                    else
                    {
                        firewallPingable = false;
                    }
                }
                catch (PingException)
                {

                    firewallPingable = false;
                }
            }           
        }
        public void Ping_External(string externalIP)
        {
            //Ping External System (passes in full external IP)
            try
            {
                Ping pingBNAU = new Ping();
                PingReply BNAUReply = pingBNAU.Send(externalIP);
                if (BNAUReply.Status == IPStatus.Success)
                {
                    externalPingable = true;
                }
                else
                {
                    externalPingable = false;
                }
            }
            catch (PingException)
            {
                externalPingable = false;
            }
        }
    }
}
