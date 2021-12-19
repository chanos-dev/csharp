using CommandLine;
using CommandLineParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var arguments = new Arguments();
            Parser.Default.ParseArguments<Arguments>(args).WithParsed((a) =>
            {
                arguments.Name = a.Name;
                arguments.Directory = a.Directory;
                arguments.Ignore = a.Ignore;
            });

            Console.WriteLine(arguments);
        } 
    }
}
