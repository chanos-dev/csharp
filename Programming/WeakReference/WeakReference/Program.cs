using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakReference
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo foo1 = new Foo()
            {
                Value = "strong reference",
            };

            Foo foo2 = foo1;

            foo1 = null;
            GC.Collect();

            Console.WriteLine(GetValue(foo1));
            Console.WriteLine(GetValue(foo2));

            Foo foo3 = new Foo()
            {
                Value = "weak reference",
            };

            var foo4 = new System.WeakReference(foo3);

            foo3 = null;
            GC.Collect();

            Console.WriteLine(GetValue(foo3));
            Console.WriteLine(GetValue<Foo>(foo4));
        }

        private static string GetValue(Foo foo) => foo is null ? "null" : foo.Value;
        private static string GetValue<T>(System.WeakReference wref)
            where T : Foo
        {
            if (wref.IsAlive) 
                return (wref.Target as T).Value;
            else
                return "null";
        }
    }

    class Foo
    {
        public string Value { get; set; }
    }
}
