using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloneable.Model
{
    public class Person : ICloneable
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person()
        {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public object Clone() => this.MemberwiseClone();

        public override string ToString() => $"Name : {Name}, Age : {Age}";
    }
}
