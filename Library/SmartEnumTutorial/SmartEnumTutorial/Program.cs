// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Ardalis.SmartEnum;

Console.WriteLine("Hello, World!");

foreach(var foo in FooEnum.List)
    Console.WriteLine($"FooEnum : {foo}");

Console.WriteLine($"Count : {FooEnum.List.Count}");

Console.WriteLine($"FooOne Name : {FooEnum.FromName("One")}");

if (FooEnum.TryFromName("Onee", out FooEnum result))
    Console.WriteLine($"result : {result}");
else
    Console.WriteLine($"have no");

Console.WriteLine($"FooOne Value : {FooEnum.FromValue(1)}");

var boo = BooEnum.Three;

boo.When(BooEnum.One).Then(() => Console.WriteLine("One!!"))
    .When(BooEnum.Two).Then(() => Console.WriteLine("Two!!"))
    .When(BooEnum.Three).Then(() => Console.WriteLine("Three!!"))
    .Default(() => Console.WriteLine("Default!!"));

// default
sealed class FooEnum : SmartEnum<FooEnum>
{
    public static readonly FooEnum One = new FooEnum(nameof(One), 1);
    public static readonly FooEnum Two = new FooEnum(nameof(Two), 2);
    public static readonly FooEnum Three = new FooEnum(nameof(Three), 3);

    private FooEnum(string name, int value) : base(name, value)
    {
    }
}

// change integer type
sealed class BooEnum : SmartEnum<BooEnum, ushort>
{
    public static readonly BooEnum One = new BooEnum(nameof(One), 1);
    public static readonly BooEnum Two = new BooEnum(nameof(Two), 2);
    public static readonly BooEnum Three = new BooEnum(nameof(Three), 3);

    private BooEnum(string name, ushort value) : base(name, value)
    {
    }
}