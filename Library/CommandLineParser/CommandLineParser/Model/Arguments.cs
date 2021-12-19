using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLineParser.Model
{
    internal class Arguments
    {
        [Option('n', "name", Required = true, HelpText = "Set Name")]
        public string Name { get; set; }

        [Option('d', "dirs", Required = true, HelpText = "Set Directory Path")]
        public string Directory { get; set; }

        [Option('i', "ignore", Required = false, HelpText = "Ignore File.Exist Method")]
        public bool Ignore { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}\nDirectory : {Directory}\nIgnore : {Ignore}";
        }
    }
}
