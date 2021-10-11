using GeneralLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel hc = new HttpChannel();
            ChannelServices.RegisterChannel(hc, false);

            General general = Activator.GetObject(typeof(General), @"http://127.0.0.1:10400/MyRemoting") as General;

            foreach (var i in Enumerable.Range(1,5))
            {
                var str = general.ConvertIntToStr(i);
                Console.WriteLine($"Retrun : {str}");
                Console.ReadLine();
            } 
        }
    }
}
