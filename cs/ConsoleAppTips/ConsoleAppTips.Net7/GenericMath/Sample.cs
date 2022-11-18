using System.Numerics;

namespace ConsoleAppTips.Net7.GenericMath;

internal class Sample
{
    static void Execute()
    {
        var a = Sum(1, 2, 3);
        Console.WriteLine(a);
    }
    
    static T Sum<T>(params T[] items) where T : INumber<T>
    {
        var sum = T.Zero;
        foreach (var x in items) sum += x;
        return sum;
    }
}
