namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/5
public static class Day05
{
    private const string InputFile = "Input/day05_input.txt";

    public static void Run()
    {
        var (idRanges, availableIds) = GetIdRangesAndAvailableIds();
        
        var idMatchCount = 0;
        foreach (var id in availableIds)
        {
            if (idRanges.Any(range => range.start <= id && id <= range.end))
                idMatchCount++;
        }
        
        Console.WriteLine($"Fresh Ingredients: {idMatchCount}");
    }
    
    private static (List<(long start, long end)> IdRanges, List<long> AvailableIds) GetIdRangesAndAvailableIds()
    {
        var idRanges = new List<(long start, long end)>();
        var availableIds = new List<long>();
        using var reader = new StreamReader(InputFile);

        while (reader.ReadLine() is { } record)
        {
            if (string.IsNullOrWhiteSpace(record)) break;
            var parts = record.Split('-');
            idRanges.Add((long.Parse(parts[0]), long.Parse(parts[1])));
        }

        while (reader.ReadLine() is { } record)
        {
            availableIds.Add(long.Parse(record));
        }

        return (idRanges, availableIds);
    }
}