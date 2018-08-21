using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDGManagementApplication
{
    public class InternalPutty : Putty
    {
        public InternalPutty(string InternalIPAddr, string FirewallIPAddr)
        {
            internalIPAddr = InternalIPAddr;
            firewallIPAddr = FirewallIPAddr;
        }

        public override string interfaceCommand
        {
            get
            {
               return ("cf interface modify name=\"Internal BCIP\" addresses=" + firewallIPAddr + "/24");
            }
        }
        public override string netObjCommand
        {
            get
            {
                return ("cf ipaddr modify name=\"Internal BCIP BNAU\" ipaddr=" + internalIPAddr +
                " & " + "cf ipaddr modify name=\"Internal BCIP Firewall\" ipaddr=" + firewallIPAddr);
            }
        }
        public override string interfaceStatusCommand
        {
            get
            {
                return ("ifconfig 1-6");
            }
        }
    }
}
