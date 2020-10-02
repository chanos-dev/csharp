using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    abstract class Felidae
    {
        abstract public Parents createParents();
        abstract public Babies createBabies();
    }
}
