using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    abstract class CreateUnit
    {
        public abstract Unit createUnit(string name);
    }
}
