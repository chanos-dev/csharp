using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person()
            {
                Name = "백찬호",
                Age = 24,
                Address = "경기도 광주시 오포읍",
            };

            var config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Person, PersonDTO>();
            });

            IMapper mapper = config.CreateMapper();

            var personDTO = mapper.Map<Person, PersonDTO>(person);

            Console.WriteLine(person.GetType().Name);
            Console.WriteLine(person);
            Console.WriteLine(personDTO.GetType().Name);
            Console.WriteLine(personDTO);
            personDTO.Age++;
            Console.WriteLine(personDTO);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public override string ToString() => $"Name : {Name}\nAge : {Age}\nAddress : {Address}";
    }

    public class PersonDTO
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public override string ToString() => $"Name : {Name}\nAge : {Age}\nAddress : {Address}";
    }
}
