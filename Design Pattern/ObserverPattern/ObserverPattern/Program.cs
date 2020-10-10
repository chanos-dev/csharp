using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Dragon fireDragon = new Dragon("FireDragon", 100);
            fireDragon.Attach(new MainScreen());
            fireDragon.Attach(new StatusScreen());

            fireDragon.Health = 90;
            fireDragon.Health = 10;
        }
    }

    class Unit
    {
        private string name;
        private int health;
        private List<IUnitViewer> unitViewers = new List<IUnitViewer>();

        public Unit(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public void Attach(IUnitViewer unitViewer)
        {
            unitViewers.Add(unitViewer);
        }

        public void Detach(IUnitViewer unitViewer)
        {
            unitViewers.Remove(unitViewer);
        }

        public void Notify()
        {
            foreach(IUnitViewer unitViewer in unitViewers)
            {
                unitViewer.Update(this);
            }
        }

        public int Health
        {
            get { return health; }
            set
            {
                health = value;
                Notify();
            }
        }

        public string Name
        {
            get { return name; }
        }
    }

    class Dragon : Unit
    {
        public Dragon(string name, int health) : base(name, health)
        {

        }
    }

    interface IUnitViewer
    {
        void Update(Unit unit);
    }

    class MainScreen : IUnitViewer
    {
        private Unit unit;

        public void Update(Unit unit)
        {
            this.unit = unit;
            Console.WriteLine("메인화면 {0} 상태 변경 : 체력 {1}", this.unit.Name, this.unit.Health.ToString()); 
        } 
    }

    class StatusScreen : IUnitViewer
    {
        private Unit unit;

        public void Update(Unit unit)
        {
            this.unit = unit;
            Console.WriteLine("상태창 {0} 상태 변경 : 체력 {1}", this.unit.Name, this.unit.Health.ToString());
        }
    }
}
