using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcreteStateA());

            context.Request();
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }

    abstract class State
    {
        public abstract void Handle(Context context);
    }

    internal class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }

    internal class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateC();
        }
    }

    internal class ConcreteStateC : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateA();
        }
    }

    internal class Context
    {
        private State _state;

        public State State
        {
            get => _state;
            set
            {
                _state = value;
                Console.WriteLine($"State : {_state.GetType().Name}");
            }
        }

        public Context(State state)
        {
            this._state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}
