using Newtonsoft.Json;
using NewtonSoft_Json.Converter;
using NewtonSoft_Json.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoft_Json
{
    class Program
    {
        static void Main(string[] args)
        {
            // single
            var p1 = Person.CreateInstance("홍길동", 24, "Cook");

            var sjson = JsonConvert.SerializeObject(p1);

            Console.WriteLine(sjson);

            Console.WriteLine(JsonConvert.DeserializeObject<Person>(sjson));


            var ps = new List<Person>()
            {
                Person.CreateInstance("홍길동", 24, "Cook"),
                Person.CreateInstance("고길동", 42, "Teacher"),
                Person.CreateInstance("김길동", 12, "Student"),
                Person.CreateInstance("백길동", 38, "Programmer"),
            };


            var json = JsonConvert.SerializeObject(ps, new FamilyJsonConverter<List<Person>>());

            Console.WriteLine(json);


            var family = JsonConvert.DeserializeObject<List<Person>>(json, new FamilyJsonConverter<List<Person>>());

            foreach (var f in family)
            {
                Console.WriteLine(f);
            }

            Console.ReadLine();
        }
    }
}
