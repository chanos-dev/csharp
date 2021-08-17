using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        { 
            IFoo[] foos = new[]
            {
                new ProxyFoo("Hello"),
                new ProxyFoo("World"),
            };

            foreach(var foo in foos)
            {
                foo.DoSomething();
            }
        }
    }

    interface IFoo
    {
        void DoSomething();
    }

    class Foo : IFoo
    {
        private string Data { get; set; }

        public Foo(string data)
        {
            this.Data = data;
        }

        public void DoSomething()
        {
            Console.WriteLine($"Data is {Data}.");
        }
    }

    class ProxyFoo : IFoo
    {
        private Foo Foo { get; set; }
        private string Data { get; set; }

        public ProxyFoo(string data)
        {
            this.Data = data;
        }

        public void DoSomething()
        {
            if (Foo is null)
                Foo = new Foo(Data);

            Foo.DoSomething();
        }
    }
}
