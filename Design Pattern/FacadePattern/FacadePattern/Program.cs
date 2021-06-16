using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Facade();

            foo.On();

            Console.WriteLine(Environment.NewLine);

            foo.Off();
        }
    }
}
