using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class CreateDragon : CreateUnit
    {
        public override Unit createUnit(string name)
        {
            return new Dragon(name);
        }
    }
}
