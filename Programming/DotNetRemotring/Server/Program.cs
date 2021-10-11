using GeneralLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel hc = new HttpChannel(10400);
            ChannelServices.RegisterChannel(hc, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(General), "MyRemoting", WellKnownObjectMode.Singleton);

            Console.ReadLine();
        }
    }
}
