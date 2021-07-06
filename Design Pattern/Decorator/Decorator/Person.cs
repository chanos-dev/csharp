using System;

namespace Decorator
{
    internal class Person : Component
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}이 움직인다!");
        }
    }
}
