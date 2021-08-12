using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparable.Model
{
    public class Person : IComparable<Person>, IComparable
    {
        public string Name { get; set; } 

        public int Age { get; set; } 

        public int CompareTo(object obj) => this.CompareTo(obj as Person);

        public int CompareTo(Person other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
                return this.Age.CompareTo(other.Age);

            return result;
        }

        public override string ToString() => $"Name : {this.Name}, Age : {this.Age}";

        public static Person CreateInstace(string name, int age)
        {
            return new Person()
            {
                Name = name,
                Age = age,
            };
        }
    }
}
