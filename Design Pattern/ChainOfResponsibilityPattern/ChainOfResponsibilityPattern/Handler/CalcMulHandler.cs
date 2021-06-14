using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Handler
{
    public class CalcMulHandler : BaseHandler
    {
        public CalcMulHandler(HandlerMode mode) : base(mode)
        {

        }

        public override void Request(HandlerMode mode, int val1, int val2)
        {
            if (mode.HasFlag(this.Mode))
            {
                Console.WriteLine($"Mul Handler : {val1 * val2}");
            }

            if (NextHandler != null)
            {
                NextHandler.Request(mode, val1, val2);
            }
        }
    }
}
