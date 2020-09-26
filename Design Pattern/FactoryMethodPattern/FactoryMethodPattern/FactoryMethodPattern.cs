using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class FactoryMethodPattern
    {
        static void Main(string[] args)
        {
            CreateUnit[] createUnits = new CreateUnit[2];

            createUnits[0] = new CreateGoblin();
            createUnits[1] = new CreateDragon();

            List<Unit> units = new List<Unit>();
            units.Add(createUnits[0].createUnit("Goblin"));
            units.Add(createUnits[1].createUnit("Dragon"));

            units[0].Move("마을");
            units[1].Move("마을");

            units[1].Attack(units[0]);
            units[0].Attack(units[1]);
        }
    }
}
