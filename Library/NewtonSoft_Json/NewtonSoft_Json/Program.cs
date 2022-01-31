using Newtonsoft.Json;
using NewtonSoft_Json.Converter;
using NewtonSoft_Json.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewtonSoft_Json
{
    class Program
    {
        private const string JSON_PATH = "family.json";
        static void Main(string[] args)
        {
            while(true)
            {
                var s = Console.ReadLine();

                if (s.ToUpper() == "EXIT") break;

                if (int.TryParse(s, out int result))
                {
                    try
                    {
                        switch (result)
                        {
                            case 1:
                                FooJson();
                                break;
                            case 2:
                                BooJson();
                                break;
                            default:
                                // throw new NotImplementedException();
                                Console.WriteLine("NotImplementedException");
                                break;
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
        static void BooJson()
        {
            // if added a unknown property in json file.
            var json = JsonConvert.DeserializeObject<UnknownPerson>(File.ReadAllText(JSON_PATH));
            Console.WriteLine(json);

            Console.WriteLine("DONE");
        }

        static void FooJson()
        {
            // single
            var p1 = Person.CreateInstance("홍길동", 24, "Cook");

            var sjson = JsonConvert.SerializeObject(p1, Formatting.Indented);

            File.WriteAllText(JSON_PATH, sjson);

            Console.WriteLine(sjson);

            Console.WriteLine(JsonConvert.DeserializeObject<Person>(sjson));

            var ps = new List<Person>()
            {
                Person.CreateInstance("홍길동", 24, "Cook"),
                Person.CreateInstance("고길동", 42, "Teacher"),
                Person.CreateInstance("김길동", 12, "Student"),
                Person.CreateInstance("백길동", 38, "Programmer"),
            };

            var json = JsonConvert.SerializeObject(ps, Formatting.Indented, new FamilyJsonConverter<List<Person>>());

            Console.WriteLine(json);

            var family = JsonConvert.DeserializeObject<List<Person>>(json, new FamilyJsonConverter<List<Person>>());

            foreach (var f in family)
            {
                Console.WriteLine(f);
            } 
            Console.WriteLine("DONE");
        }
    }
}
