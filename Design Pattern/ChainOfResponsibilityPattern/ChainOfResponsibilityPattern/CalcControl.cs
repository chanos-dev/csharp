using ChainOfResponsibilityPattern.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern
{
    public class CalcControl
    {
        protected BaseHandler Head { get; set; }
        protected BaseHandler Tail { get; set; }

        public void AddHandler(BaseHandler handler)
        {
            if (Head is null)
            {
                Head = Tail = handler;
            }
            else
            {
                Tail.NextHandler = handler;
                Tail = handler;
            }
        }

        public void Request(HandlerMode mode, int val1, int val2)
        {
            if (Head != null)
            {
                Head.Request(mode, val1, val2);
            } 
        }
    }
}
