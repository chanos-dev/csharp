using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item();
            item.Action = new MoveGround();
            item.Operation();

            item.Action = new MoveSky();
            item.Operation();
        }
    }

    class Item
    {
        private Action action;

        public Action Action
        {
            set { action = value; }
        }

        public void Operation()
        {
            action.Move();
        }
    }

    abstract class Action
    {
        public abstract void Move();
    }

    class MoveGround : Action
    {
        public override void Move()
        {
            Console.WriteLine("MoveGround!");
        }
    }

    class MoveSky : Action
    {
        public override void Move()
        {
            Console.WriteLine("MoveSky!");
        }
    }
}
