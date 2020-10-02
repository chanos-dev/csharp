using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Tiger : Felidae
    {
        public override Parents createParents()
        {
            return new WhiteTiger();
        }

        public override Babies createBabies()
        {
            return new WhiteTigerBaby();
        }
    }
}
