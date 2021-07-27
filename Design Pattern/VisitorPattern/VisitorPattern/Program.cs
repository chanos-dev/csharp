using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new ConcreateElementA());
            o.Attach(new ConcreateElementB());

            ConcreateVisitor1 v1 = new ConcreateVisitor1();
            ConcreateVisitor2 v2 = new ConcreateVisitor2();

            o.Accept(v1);
            o.Accept(v2);
        }
    } 
}
