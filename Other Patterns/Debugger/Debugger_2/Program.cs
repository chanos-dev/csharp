using System.Diagnostics;

while (true)
{
    Console.WriteLine("the debugger command is to connect to a debugger process.");
    Console.WriteLine("others command do nothing. ");
    Console.Write("CMD : ");
    var cmd = Console.ReadLine();
    if (cmd is null) continue;
    if (cmd.ToLower() == "debugger")
        if (!Debugger.IsAttached)
            Debugger.Launch();
}