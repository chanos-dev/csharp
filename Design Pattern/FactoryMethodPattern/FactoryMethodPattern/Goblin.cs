using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class Goblin : Unit
    {
        public Goblin(string name) : base(name)
        {
            Life = 1000;
            Damage = 150;
        }

        public override void Attack(Unit unit)
        {
            unit.Life -= this.Damage;
            Console.WriteLine($"{unit.Name}이 {this.Name}에게 공격받아 생명력이 {unit.Life} 남았습니다.");
        }

        public override void Move(string pos)
        {
            Console.WriteLine($"{this.Name}이 {pos}로 이동하였습니다.");
        } 
    }
}
