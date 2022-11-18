using System.Numerics;

namespace ConsoleAppTips.Net7.GenericMath;

internal class GenericMathSample
{
    internal static void Execute()
    {
        Console.WriteLine(nameof(GenericMathSample) + " Start");

        // case 1 普通に計算できる
        var case1 = Sum(1, 2, 3, 4);
        Console.WriteLine(case1);

        // case 2 int, double, long の混在 計算できる double になる
        var case2 = Sum(1, 2.2, 3, 4L);
        Console.WriteLine(case2);

        // case 3 int と long の混在 long になる
        var case3 = Sum(1, 4L);
        Console.WriteLine(case3);

        // case 4 int の計算で 最大値超えた場合 普通に溢れる
        var case4 = Sum(int.MaxValue, 1);
        Console.WriteLine(case4);

        Console.WriteLine(nameof(GenericMathSample) + " End");
    }

    static T Sum<T>(params T[] items) where T : INumber<T>
    {
        var sum = T.Zero;
        foreach (var x in items) sum += x;
        return sum;
    }
}
