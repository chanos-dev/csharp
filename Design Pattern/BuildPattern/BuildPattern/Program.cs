using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildPattern
{
    class Program
    {
        static void Main(string[] args)
        {  
            Person.PersonBuilder personBuilder = new Person.PersonBuilder();
            Person person = personBuilder.SetName("Chan")
                                         .SetAge("98")
                                         .SetSex("Male")
                                         .SetAddress("Gyeonggi-do")
                                         .SetJob("Dev")
                                         .Build();
            
            Console.WriteLine(person.ToString()); 
        }
    }
}
