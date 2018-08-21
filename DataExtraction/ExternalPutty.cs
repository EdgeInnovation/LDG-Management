using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDGManagementApplication
{
    class ExternalPutty : Putty
    {
        public ExternalPutty(string ExtRouterIP, string ExtFWIP, string ExtFWMask)
        {
            extRouterIP = ExtRouterIP;
            extFWIP = ExtFWIP;
            extFWMask = ExtFWMask;
        }

        public override string interfaceCommand
        {
            get
            {
                return ("cf interface modify name=\"External System 1\" addresses=" + extFWIP + "/" + extFWMask);
            }
        }
        public override string netObjCommand
        {
            get
            {
                return null;
            }
        }
        public override string interfaceStatusCommand
        {
            get
            {
                return ("ifconfig 2-0");
            }
        }
    }
}