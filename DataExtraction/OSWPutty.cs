using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGManagementApplication
{
    public class OSWPutty : Putty
    {
        public OSWPutty(string SelectedIP, string ExternalIP)
        {
            selectedIP = SelectedIP;
            externalIP = ExternalIP;
        }

        public override string interfaceCommand
        {
            get
            {
                return ("cf policy modify name=\"OSW WMS External 1\" disable=no");
            }
        }
        public override string netObjCommand
        {
            get
            {
                return ("cf ipaddr modify name=\"DMZ BCIP OSW Gateway\" ipaddr=" + selectedIP +
                     " & cf ipaddr modify name=\"External 1 Sharepoint Server\" ipaddr=" + externalIP);
            }
        }
        public override string interfaceStatusCommand
        {
            get
            {
                return ("ping -c 2 " + externalIP);
            }
        }
    }
}