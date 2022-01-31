using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoft_Json.Model
{
    internal class BaseJson
    {
        [JsonExtensionData]
        public Dictionary<string, object> UnknownProperties { get; set; }
    }

    internal class Person : BaseJson
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Job { get; set; }

        internal static Person CreateInstance(string name, int age, string job)
        {
            return new Person()
            {
                Name = name,
                Age = age,
                Job = job,
            };
        }

        public override string ToString()
        {
            return $"Name : {Name}\nAge : {Age}\nJob : {Job}";
        }
    }

    internal class UnknownPerson : Person
    {
        public Home Home { get; set; }
    }

    internal class Home : BaseJson
    { 
        public int ZipCode { get; set; }
        public string Address { get; set; } 
    }
}
