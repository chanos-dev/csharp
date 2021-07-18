using Equatable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equatable
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person()
            {
                Name = "백찬호",
                Age = 24,
            };

            var p2 = new Person()
            {
                Name = "백찬호",
                Age = 25,
            };

            // false
            Console.WriteLine(p == p2);

            p2.Age = p.Age;

            // true
            Console.WriteLine(p == p2);
        }
    }
}
