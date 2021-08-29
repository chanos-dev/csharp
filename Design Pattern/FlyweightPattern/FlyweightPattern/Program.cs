using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;

            FlyweightFactory factory = new FlyweightFactory();

            factory.GetFlyweight("X").Operation(--extrinsicstate);
            factory.GetFlyweight("Y").Operation(--extrinsicstate);
            factory.GetFlyweight("Z").Operation(--extrinsicstate);

            UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight();
            fu.Operation(--extrinsicstate);
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> Flyweights { get; set; } = new Dictionary<string, Flyweight>();

        public FlyweightFactory()
        {
            Flyweights.Add("X", new ConcreteFlyweight());
            Flyweights.Add("Y", new ConcreteFlyweight());
            Flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key) => (Flyweight)Flyweights[key];
    }

    public abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"ConcreteFlyweight : {extrinsicstate}");
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"UnsharedConcreteFlyweight : {extrinsicstate}");
        }
    }
}
