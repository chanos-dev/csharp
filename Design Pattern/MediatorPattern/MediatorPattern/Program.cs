using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreateMediator m = new ConcreateMediator();

            var c1 = new ConcreteColleague1(m);
            var c2 = new ConcreteColleague2(m);

            m.ConcreteColleague1 = c1;
            m.ConcreteColleague2 = c2;

            c1.Send("How are you?");
            c2.Send("Fine, thanks");
        }
    }

    internal abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    internal class ConcreateMediator : Mediator
    {
        public ConcreteColleague1 ConcreteColleague1 { get; set; }
        public ConcreteColleague2 ConcreteColleague2 { get; set; }
        public override void Send(string message, Colleague colleague)
        {
            if (colleague == ConcreteColleague1)
                ConcreteColleague2.Notify(message);
            else
                ConcreteColleague1.Notify(message);
        }
    }

    internal abstract class Colleague
    {
        protected Mediator Mediator { get; set; }

        public Colleague(Mediator mediator)
        {
            this.Mediator = mediator;
        }
    }

    internal class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator)
        {

        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine($"Colleague1 gets message : {message}");
        }
    }

    internal class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator)
        {

        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine($"Colleague2 gets message : {message}");
        }
    }
}
