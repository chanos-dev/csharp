using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Refrigerator> refrigerators = new List<Refrigerator>();
            refrigerators.Add(new GeneralRefrigerator(new ActionGeneral(), "일반냉장고"));
            refrigerators.Add(new KimchiRefrigerator(new ActionKimchi(), "김치냉장고"));

            foreach(Refrigerator refrigerator in refrigerators)
            {
                refrigerator.OpenRefrigerator();
                refrigerator.RunRefrigerator();
            }
        }
    }

    abstract class Action
    {
        public abstract void Run(string name);
    }

    class ActionKimchi : Action
    {
        public override void Run(string name)
        {
            Console.WriteLine($"Run Kimchi {name}~!");
            Console.WriteLine("I Love it~!");
        }
    }

    class ActionGeneral : Action
    {
        public override void Run(string name)
        {
            Console.WriteLine($"Run General {name}~!");
        }
    }

    abstract class Refrigerator
    {
        protected Action action;
        public string Name { get; private set; }
        
        public Refrigerator(Action action,string name)
        {
            this.Name = name;
            this.action = action;
        }

        public abstract void OpenRefrigerator();
        public abstract void RunRefrigerator();
    }

    class KimchiRefrigerator : Refrigerator
    {
        public KimchiRefrigerator(Action action, string name) : base(action, name)
        {

        }

        public override void OpenRefrigerator()
        {
            Console.WriteLine($"Open {Name}~!");
        }

        public override void RunRefrigerator()
        {
            action.Run(this.Name);
        }
    }

    class GeneralRefrigerator : Refrigerator
    {
        public GeneralRefrigerator(Action action, string name) : base(action, name)
        {

        }

        public override void OpenRefrigerator()
        {
            Console.WriteLine($"Open {Name}~!");
        }

        public override void RunRefrigerator()
        {
            action.Run(this.Name);
        }
    }
}
