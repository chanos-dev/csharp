using Disposable.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disposable
{
    class Program
    {
        static void Main(string[] args)
        {
            newPerson();

            //using (var p = new Person())
            //{
            //    p.Name = "chanos";
            //    p.Age = 24;
            //    p.Selfie = Image.FromFile(@"C:\test.jpg");
            //}

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void newPerson()
        {
            foreach (var i in Enumerable.Range(1, 10))
            {
                var p = new Person()
                {
                    Name = $"chanos{i}",
                    Age = 24 + i,
                    Selfie = Image.FromFile(@"C:\test.jpg"),
                };
            }
        }
    }
}
