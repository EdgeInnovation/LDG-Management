using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGManagementApplication
{
    public class DMZPutty : Putty
    {
        string DMZIPAddr,DMZBQSIP, DMZFirewallExt, DMZFirewallMIP, DMZFirewallExtWMS, DMZNetObjChatGW, DMZNetObjFWBqs, DMZNetObjFWExt1, DMZNetObjFWMip;
        public DMZPutty(string ChatGW)
        {
            chatGW = ChatGW;
            //produce the other IPs
            string[] chatGWArray = chatGW.Split('.');
            string chatGWSubnet = chatGWArray[0] + "." + chatGWArray[1] + "." + chatGWArray[2];

            //retrieve fourth octets of IP's from config file
            string DMZIP_FO = ConfigurationManager.AppSettings.Get("DMZIP");
            string DMZBQSIP_FO = ConfigurationManager.AppSettings.Get("BNAUIP");
            string DMZFirewallExt_FO = ConfigurationManager.AppSettings.Get("FirewallIP");
            string DMZFirewallMIP_FO = ConfigurationManager.AppSettings.Get("DMZFirewallMIP");
            string DMZFirewallExtWMS_FO = ConfigurationManager.AppSettings.Get("DMZFirewallExtWMS");

            //produce every other IP from the subnet and the fourth octets
            DMZIPAddr = chatGWSubnet + DMZIP_FO;
            DMZBQSIP = chatGWSubnet + DMZBQSIP_FO;
            DMZFirewallExt = chatGWSubnet + DMZFirewallExt_FO;
            DMZFirewallMIP = chatGWSubnet + DMZFirewallMIP_FO;
            DMZFirewallExtWMS = chatGWSubnet + DMZFirewallExtWMS_FO;

            //sub commands for netowrk objects
            DMZNetObjChatGW = ("cf ipaddr modify name=\"DMZ BCIP Chat Gateway\" ipaddr=" + chatGW);
            DMZNetObjFWBqs = ("cf ipaddr modify name=\"DMZ BCIP Firewall BQS\" ipaddr=" + DMZBQSIP);
            DMZNetObjFWExt1 = ("cf ipaddr modify name=\"DMZ BCIP Firewall External 1\" ipaddr=" + DMZFirewallExt);
            DMZNetObjFWMip = ("cf ipaddr modify name=\"DMZ BCIP Firewall MIP\" ipaddr=" + DMZFirewallMIP);
        }

        public override string interfaceCommand
        {
            get
            {
                return ("cf interface modify name=\"DMZ BCIP\" addresses=" + DMZBQSIP + "/24," + DMZFirewallExt + "/24," + DMZFirewallExtWMS + "/24," + DMZFirewallMIP + "/24");
            }
        }
        public override string netObjCommand
        {
            get
            {
                return (DMZNetObjChatGW + " & " + DMZNetObjFWBqs + " & " + DMZNetObjFWExt1 + " & " + DMZNetObjFWMip);
            }
        }
        public override string interfaceStatusCommand
        {
            get
            {
                return ("ifconfig 1-1");
            }
        }
    }
}
