using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Lion : Felidae
    {
        public override Parents createParents()
        {
            return new AsiaticLion();
        }

        public override Babies createBabies()
        {
            return new AsiaticLionBaby();
        }
    }
}
