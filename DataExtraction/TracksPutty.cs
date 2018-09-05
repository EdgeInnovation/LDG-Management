using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGManagementApplication
{
    class TracksPutty : Putty
    {
        public TracksPutty(string SelectedIP, string ExternalIP)
        {
            selectedIP = SelectedIP;
            externalIP = ExternalIP;
        }

        public override string interfaceCommand
        {
            get
            {
                return ("cf policy modify name=\"Tracks to External 1\" disable=no & cf policy modify name =\"Tracks from External 1\" disable=no");
            }
        }
        public override string netObjCommand
        {
            get
            {
                return ("cf ipaddr modify name=\"DMZ BCIP Tracks Gateway\" ipaddr=" + selectedIP +
                        " & cf ipaddr modify name=\"External 1 Tracks Server\" ipaddr=" + externalIP);
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
