#if DEBUG
using System.Diagnostics;

Console.WriteLine("Wait for connecting to a debugger for 10 seconds.");
var th = new Thread(() =>
{
    try
    {
        while (!Debugger.IsAttached)
        {
            Console.WriteLine("wait..");
            Thread.Sleep(1000);
        }

        Console.WriteLine("Success to connect to a debugger!!");
    }
    catch (ThreadInterruptedException tex)
    {
        Console.WriteLine("Interrupted..");
        Console.WriteLine(tex.Message);
    }
});

th.Start();
// wait main thread..
if (!th.Join(10 * 1000))
{ 
    th.Interrupt(); 
}
#endif 

Console.WriteLine("Hello! .NET 6~~");