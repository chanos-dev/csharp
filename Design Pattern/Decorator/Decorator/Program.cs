using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person("홍길동");
            p.Move();
            Console.WriteLine("");

            var jump = new JumpDecorator(p);
            jump.Move();
            Console.WriteLine("");

            var tumbling = new TumblingDecorator(jump);
            tumbling.Move();
        }
    }
}
