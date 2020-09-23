using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildPattern
{
    class Person
    {
        private string Name;
        private string Age;
        private string Sex;
        private string Address;
        private string Job;

        private Person(PersonBuilder pb)
        {            
            this.Name = pb.Name;
            this.Age = pb.Age;
            this.Sex = pb.Sex;
            this.Address = pb.Address;
            this.Job = pb.Job;
        }

        public class PersonBuilder
        {
            public string Name { get; private set; }
            public string Age { get; private set; }
            public string Sex { get; private set; }
            public string Address { get; private set; }
            public string Job { get; private set; }

            public PersonBuilder SetName(string Name)
            {
                this.Name = Name;
                return this;
            }

            public PersonBuilder SetAge(string Age)
            {
                this.Age = Age;
                return this;
            }

            public PersonBuilder SetSex(string Sex)
            {
                this.Sex = Sex;
                return this;
            }

            public PersonBuilder SetAddress(string Address)
            {
                this.Address = Address;
                return this;
            }

            public PersonBuilder SetJob(string Job)
            {
                this.Job = Job;
                return this;
            }

            public Person Build()
            {
                return new Person(this);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name : {Name}\n");
            sb.Append($"Age : {Age}\n");
            sb.Append($"Sex : {Sex}\n");
            sb.Append($"Address : {Address}\n");
            sb.Append($"Job : {Job}\n");

            return sb.ToString();
        }
    } 
}
