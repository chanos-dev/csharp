using ChainOfResponsibilityPattern.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var control = new CalcControl();            

            control.AddHandler(new CalcMulHandler(HandlerMode.Mul));
            control.AddHandler(new CalcSubHandler(HandlerMode.Sub));
            control.AddHandler(new CalcDivHandler(HandlerMode.Div));
            control.AddHandler(new CalcAddHandler(HandlerMode.Add));

            Console.WriteLine("1 --- Add, Div 100, 10");
            control.Request(HandlerMode.Add | HandlerMode.Div, 100, 10);

            Console.WriteLine("\n2 --- Sub, Mul 50, 30");
            control.Request(HandlerMode.Sub | HandlerMode.Mul, 50, 30);

            Console.WriteLine("\n3 --- Div, Mul, Add, Sub 20, 5");
            control.Request(HandlerMode.Div | HandlerMode.Mul | HandlerMode.Add | HandlerMode.Sub, 20, 5);
        }
    }
}
