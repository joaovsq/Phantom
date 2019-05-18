using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Phantom.Network
{
    internal struct ServerBootstrapInfo
    {
        public IPHostEntry IpHostInfo;
        public IPAddress Address;
        public IPEndPoint LocalEndpoint;

    }

    internal class ServerBootstrap
    {

        // required info to bootstrap a new server
        
        private void SetupServerInfo()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        }


    }
}
