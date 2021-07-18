using Cloneable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloneable
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person("백찬호", 24);
            var cp = p;
            p.Age++;

            Console.WriteLine(object.ReferenceEquals(p, cp));
            Console.WriteLine(p);
            Console.WriteLine(cp);

            cp = p.Clone() as Person;
            p.Age++;

            Console.WriteLine(object.ReferenceEquals(p, cp));
            Console.WriteLine(p);
            Console.WriteLine(cp);
        }
    }
}
