using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singletone
{
    class Program
    {
        static void Main(string[] args)
        {
            Singletone s1 = Singletone.Instance();
            Singletone s2 = Singletone.Instance();

            if (s1 == s2)
                Console.WriteLine("SAME!!");

            s1.Print();
            Singletone.Instance().Print();

            Console.ReadLine();
        }
    }

    class Singletone
    {
        private static Singletone _instance;

        protected Singletone() { }

        public static Singletone Instance()
        {
            if (_instance is null)
                _instance = new Singletone();

            return _instance;
        }

        public void Print()
        {
            Console.WriteLine("Singletone Print!!");
        }
    }

}
