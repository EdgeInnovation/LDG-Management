using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGManagementApplication
{
    public class ChatPutty : Putty
    {
        public ChatPutty(string SelectedIP, string ExternalIP)
        {
            selectedIP = SelectedIP;
            externalIP = ExternalIP;
        }

        public override string interfaceCommand
        {
            get
            {
                return ("cf policy modify name=\"Chat to External 1\" disable=no & cf policy modify name =\"Chat from External 1\" disable=no");
            }
        }
        public override string netObjCommand
        {
            get
            {
                return ("cf ipaddr modify name=\"External 1 Chat Server\" ipaddr=" + externalIP);
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