using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Animal
    {
        private Parents parents;
        private Babies babies;

        public Animal(Felidae felidae)
        {
            parents = felidae.createParents();
            babies = felidae.createBabies();
        }

        public void Sound()
        {
            parents.growl();
            babies.growl();
        }
    }
}
