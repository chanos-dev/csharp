using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLog
{
    class Program
    {
        private static readonly Logger Logger = LogManager.GetLogger("NLog");

        static void Main(string[] args)
        { 
            Logger.Info("Info log");
            Logger.Info("Info log2");

            Logger.Warn("warning");

            Logger.Fatal("fatal");
        }
    }
}