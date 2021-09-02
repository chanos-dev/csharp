using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate aggregate = new ConcreteAggregate();

            aggregate[0] = "Item A";
            aggregate[1] = "Item B";
            aggregate[2] = "Item C";
            aggregate[3] = "Item D";

            Iterator i = aggregate.CreateIterator();

            Console.WriteLine("Iterating over collection:");

            var item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            Console.WriteLine("Done!!");
        }
    }

    public abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    public class ConcreteAggregate : Aggregate
    {
        private List<object> Items = new List<object>();

        public override Iterator CreateIterator() => new ConcreteIterator(this);

        public int Count => Items.Count;

        public object this[int idx]
        {
            get => Items[idx];
            set => Items.Insert(idx, value);
        }
    }

    public abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    public class ConcreteIterator : Iterator
    {
        private ConcreteAggregate ConcreteAggregate;
        private int Current = 0;

        public ConcreteIterator(ConcreteAggregate concreteAggregate)
        {
            ConcreteAggregate = concreteAggregate;
        }

        public override object CurrentItem() => ConcreteAggregate[Current];

        public override object First() => ConcreteAggregate[0];

        public override bool IsDone() => Current == ConcreteAggregate.Count;

        public override object Next()
        {
            if (Current < ConcreteAggregate.Count - 1)
                return ConcreteAggregate[++Current];

            return null;
        }
    }
}
