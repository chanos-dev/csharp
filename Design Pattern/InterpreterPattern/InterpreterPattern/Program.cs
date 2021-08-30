using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context()
            {
                Value = "Hello",
            };

            List<AbstractExpression> abstractExpressions = new List<AbstractExpression>()
            {
                new TerminalExpression(),
                new NonterminalExpression(),
                new TerminalExpression(),
                new TerminalExpression(),
            };

            foreach (var exp in abstractExpressions)
            {
                exp.Interpret(context);
            }
        }
    }

    internal class Context
    {
        public string Value { get; set; }
    }

    internal abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    internal class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine($"Called Terminal.Interpret {context.Value}");
        }
    }

    internal class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine($"Called Nonterminal.Interpret {context.Value}");
        }
    }
}
