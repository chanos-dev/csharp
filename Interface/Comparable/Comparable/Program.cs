using Comparable.Comparer;
using Comparable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                Person.CreateInstace("백찬호", 29),
                Person.CreateInstace("백찬호", 30),
                Person.CreateInstace("백찬호", 21),
                Person.CreateInstace("홍길동", 31),
                Person.CreateInstace("백찬호", 24),
                Person.CreateInstace("고길동", 33),
                Person.CreateInstace("이길동", 26),
                Person.CreateInstace("김길동", 30),
            };

            Console.WriteLine("Before Sort");
            people.ForEach(p => Console.WriteLine(p));

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("After Sort");
            people.Sort(new PersonCompare());
            people.ForEach(p => Console.WriteLine(p));
        }
    }
}
