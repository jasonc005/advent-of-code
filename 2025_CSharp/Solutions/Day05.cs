namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/5
public static class Day05
{
    private const string InputFile = "Input/day05_input.txt";

    public static void Run()
    {
        var (idRanges, availableIds) = GetIdRangesAndAvailableIds();

        var freshIngredientsCount = GetFreshIngredientsCount(idRanges, availableIds);
        var totalFreshIngredientIds = GetTotalFreshIngredientIds(idRanges);

        Console.WriteLine($"Fresh Ingredients: {freshIngredientsCount}");
        Console.WriteLine($"Total Fresh Ingredient IDs: {totalFreshIngredientIds}");
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

    private static int GetFreshIngredientsCount(List<(long start, long end)> idRanges, List<long> availableIds)
    {
        return availableIds.Count(id => idRanges.Any(range => range.start <= id && id <= range.end));
    }

    private static long GetTotalFreshIngredientIds(List<(long start, long end)> idRanges)
    {
        if (!idRanges.Any()) return 0;

        // Sort ranges by start position
        var sortedRanges = idRanges.OrderBy(r => r.start).ToList();

        long totalCount = 0;
        long currentStart = sortedRanges[0].start;
        long currentEnd = sortedRanges[0].end;

        for (int i = 1; i < sortedRanges.Count; i++)
        {
            var range = sortedRanges[i];

            if (range.start <= currentEnd + 1)
            {
                // Overlapping or adjacent ranges - merge them
                currentEnd = Math.Max(currentEnd, range.end);
            }
            else
            {
                // Non-overlapping range - add current range size and start new range
                totalCount += currentEnd - currentStart + 1;
                currentStart = range.start;
                currentEnd = range.end;
            }
        }

        // Add the last range
        totalCount += currentEnd - currentStart + 1;

        return totalCount;
    }
}