using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    public class ConcreateElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreateElementA(this);
        }
    }

    public class ConcreateElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreateElementB(this);
        }
    }

    public abstract class Visitor
    {
        public abstract void VisitConcreateElementA(ConcreateElementA concreateElementA);
        public abstract void VisitConcreateElementB(ConcreateElementB concreateElementB);
    }

    public class ConcreateVisitor1 : Visitor
    {
        public override void VisitConcreateElementA(ConcreateElementA concreateElementA)
        {
            Console.WriteLine($"{concreateElementA.GetType().Name} visited by {this.GetType().Name}");
        }

        public override void VisitConcreateElementB(ConcreateElementB concreateElementB)
        {
            Console.WriteLine($"{concreateElementB.GetType().Name} visited by {this.GetType().Name}");
        }
    }

    public class ConcreateVisitor2 : Visitor
    {
        public override void VisitConcreateElementA(ConcreateElementA concreateElementA)
        {
            Console.WriteLine($"{concreateElementA.GetType().Name} visited by {this.GetType().Name}");
        }

        public override void VisitConcreateElementB(ConcreateElementB concreateElementB)
        {
            Console.WriteLine($"{concreateElementB.GetType().Name} visited by {this.GetType().Name}");
        }
    }

    public class ObjectStructure
    {
        List<Element> Elements { get; set; } = new List<Element>();

        public void Attach(Element element)
        {
            Elements.Add(element);
        }
        public void Detach(Element element)
        {
            Elements.Remove(element);
        }
        public void Accept(Visitor visitor)
        {
            foreach (Element element in Elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
