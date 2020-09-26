using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    abstract class Unit :IAction
    {
        public string Name { get; set; }
        public int Life { get; set; }
        public int Damage { get; set; }

        protected Unit(string name)
        {
            Name = name; 
        }

        public abstract void Attack(Unit unit);
        public abstract void Move(string pos);
    }
}
