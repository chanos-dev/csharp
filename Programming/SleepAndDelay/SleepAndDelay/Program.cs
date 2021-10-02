using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SleepAndDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            Sleep();

            foreach (var i in Enumerable.Range(1,10))
            {
                Thread.Sleep(200);
                Console.Write("1");
            }

            Delay();

            foreach (var i in Enumerable.Range(1, 10))
            {
                Thread.Sleep(200);
                Console.Write("2");
            }

            Console.ReadLine();
        }

        static void Sleep()
        {
            Thread.Sleep(1000);
            Console.Write("Sleep");
        }

        static async void Delay()
        {
            await Task.Delay(1000);
            Console.Write("Delay");
        }
    }
}
