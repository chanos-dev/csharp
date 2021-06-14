using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Handler
{
    [Flags]
    public enum HandlerMode
    {
        Add = 1,
        Sub = 2,
        Mul = 4,
        Div = 8,
    }

    public abstract class BaseHandler
    {
        public BaseHandler NextHandler { get; set; }

        protected readonly HandlerMode Mode;

        public BaseHandler(HandlerMode mode)
        {
            this.Mode = mode;
            NextHandler = null;
        }

        public abstract void Request(HandlerMode mode, int val1, int val2);
    }
}
