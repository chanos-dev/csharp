using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serilog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var consoleLog = new LoggerConfiguration().WriteTo.Console().CreateLogger())
            {
                consoleLog.Verbose("Console Log : Verbose");
                consoleLog.Debug("Console Log : Debug");
                consoleLog.Information("Console Log : Info");
                consoleLog.Warning("Console Log : Warning");
                consoleLog.Error("Console Log : Error");
                consoleLog.Fatal("Console Log : Fatal");
            }
            
            using (var fileLog = new LoggerConfiguration().MinimumLevel.Verbose()
                                                          .WriteTo.Console()
                                                          .WriteTo.File(@"SeriLog.log",
                                                          rollingInterval : RollingInterval.Hour,
                                                          rollOnFileSizeLimit : true)
                                                          .CreateLogger())
            {
                fileLog.Verbose("File Log : Verbose");
                fileLog.Debug("File Log : Debug");
                fileLog.Information("File Log : Info");
                fileLog.Warning("File Log : Warning");
                fileLog.Error("File Log : Error");
                fileLog.Fatal("File Log : Fatal");

                // json
                fileLog.Information("Class {@Foo}", new Foo() { Name = "Foo", Age = 24});
            }

            // set global logger.
            //Log.Logger = new LoggerConfiguration().CreateLogger();
            //Log.CloseAndFlush();
        } 
    }

    class Foo
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
