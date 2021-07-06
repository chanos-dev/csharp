using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Decorator : Component
    {
        private Component Component { get; set; }

        public Decorator(Component component)
        {
            Component = component;
        }

        public override void Move()
        {
            if (Component != null)
            {
                Component.Move();
            }
        }
    }

    internal class JumpDecorator : Decorator
    {
        public JumpDecorator(Component component) : base(component)
        {
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("신나게 점프!");
        }
    }

    internal class TumblingDecorator : Decorator
    {
        public TumblingDecorator(Component component) : base(component)
        {
        }

        public override void Move()
        {
            base.Move();
            Console.WriteLine("멋있게 덤블링!");
            SpecialAction();
        }

        private void SpecialAction()
        {
            Console.WriteLine("덤블링 하면서 박수치기~!");
        }
    }
}
