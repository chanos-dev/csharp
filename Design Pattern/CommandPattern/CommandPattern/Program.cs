using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

    public abstract class Command
    {
        protected Receiver Receiver { get; set; }

        public Command(Receiver receiver)
        {
            this.Receiver = receiver;
        }

        public abstract void Execure();
    }

    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {

        }

        public override void Execure()
        {
            Receiver.Action();
        }
    }

    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    public class Invoker
    {
        private Command Command;

        public void SetCommand(Command command)
        {
            this.Command = command;
        }

        public void ExecuteCommand()
        {
            Command.Execure();
        }
    }
}
