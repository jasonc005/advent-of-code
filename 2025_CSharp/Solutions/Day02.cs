namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/2
public static class Day02
{
    private const string InputFile = "Input/day02_input.txt";

    public static void Run()
    {
        var idRanges = GetIdRanges();
        long sumOfInvalidIds = 0;

        foreach (var range in idRanges)
        {
            var start = long.Parse(range[0]);
            var end = long.Parse(range[1]);
            var startLength = range[0].Length;
            var endLength = range[1].Length;

            if (startLength == endLength && startLength.IsOdd()) continue;

            for (var i = start; i <= end; i++)
            {
                var id = i.ToString();
                if (id.Length.IsOdd()) continue;
                
                var firstPart = id[..(id.Length / 2)];
                var secondPart = id[(id.Length / 2)..];
                
                if (firstPart == secondPart) sumOfInvalidIds += i;
            }
        }
        
        Console.WriteLine($"Sum of Invalid IDs: {sumOfInvalidIds}");
    }

    private static IEnumerable<string[]> GetIdRanges()
    {
        using var reader = new StreamReader(InputFile);

        var rangeList = reader.ReadToEnd();
        return rangeList.Split(",").Select(x => x.Split("-"));
    }
    
    private static bool IsOdd(this int number) => number % 2 == 1;
}