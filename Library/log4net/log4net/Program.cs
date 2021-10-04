using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace log4net
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            Log.Info("info");
            Log.Fatal("fatal");
            Log.Error("error");
            Log.Debug("Debug");            
        }
    }
}
