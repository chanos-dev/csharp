using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Felidae Tiger = new Tiger();
            Felidae Lion = new Lion();

            Animal animalTiger = new Animal(Tiger);
            animalTiger.Sound();

            Animal animalLion = new Animal(Lion);
            animalLion.Sound(); 
        }
    }
}
