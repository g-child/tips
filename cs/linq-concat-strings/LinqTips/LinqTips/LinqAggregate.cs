namespace LinqTips;

public class LinqAggregate
{
    public static void Execute()
    {
        var dictionary = new Dictionary<string, string>
        {
            ["key1"] = "value1",
            ["key2"] = "value2",
            ["key3"] = "value3",
        };

        var aggregated = dictionary
                            .Select(x => $"{x.Key} : {x.Value}")
                            .Aggregate((current, next) => $"{current} --- {next}");

        Console.WriteLine($"{nameof(LinqAggregate)} result...  {aggregated}");
    }
}
