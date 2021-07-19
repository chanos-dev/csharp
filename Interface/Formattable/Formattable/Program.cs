using Formattable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formattable
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person()
            {
                Name = "Chanos",
                Age = 24,
                Job = "Programmer"
            };


            Console.WriteLine($"{p:N}");
            Console.WriteLine("");
            Console.WriteLine($"{p:A}");
            Console.WriteLine("");
            Console.WriteLine($"{p:J}");
            Console.WriteLine("");
            Console.WriteLine($"{p:P}");
            Console.WriteLine("");
            Console.WriteLine($"{p}");
        }
    }
}
