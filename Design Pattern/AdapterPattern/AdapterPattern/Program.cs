using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Volt> volts = new List<Volt>();
            volts.Add(new Socket220V());
            volts.Add(new Socket());

            foreach(Volt volt in volts)
            {
                volt.Connect("My home");
            }
        }
    }

    interface Volt
    {
        void Connect(string path);
    }

    class Socket220V : Volt
    {
        public virtual void Connect(string path)
        {
            Console.WriteLine($"Connect to {path} at 220V");
        }
    }

    class Socket : Socket220V
    {
        private Socket110V socket110;

        public Socket()
        {
            socket110 = new Socket110V();
        }

        public override void Connect(string path)
        {
            socket110.Connect(path);
        }
    }

    class Socket110V
    {
        public void Connect(string path)
        {
            Console.WriteLine($"Connect to {path} at 110V");
        }
    } 
}
