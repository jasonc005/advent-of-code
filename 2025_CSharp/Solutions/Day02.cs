using _2025_CSharp.Helpers;

namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/2
public static class Day02
{
    private static readonly string InputFile = FileUtility.GetFilePathForDay(2);

    public static void Run()
    {
        var idRanges = GetIdRanges();
        var solutions = GetSolutions(idRanges);

        Console.WriteLine($"Sum of Invalid IDs - Part 1: {solutions.Part1Solution}");
        Console.WriteLine($"Sum of Invalid IDs - Part 2: {solutions.Part2Solution}");
    }

    private static IEnumerable<(long start, long end)> GetIdRanges()
    {
        return File.ReadAllText(InputFile)
            .Split(',')
            .Select(range =>
            {
                var parts = range.Trim().Split('-');
                return (long.Parse(parts[0]), long.Parse(parts[1]));
            });
    }

    private static (long Part1Solution, long Part2Solution) GetSolutions(IEnumerable<(long start, long end)> idRanges)
    {
        long part1Solution = 0;
        long part2Solution = 0;

        foreach (var range in idRanges)
        {
            for (var i = range.start; i <= range.end; i++)
            {
                var idString = i.ToString();
                if (idString.IsInvalidIdPart1()) part1Solution += i;
                if (idString.IsInvalidIdPart2()) part2Solution += i;
            }
        }

        return (part1Solution, part2Solution);
    }

    private static bool IsInvalidIdPart1(this string id)
    {
        if (id.Length % 2 == 1) return false;
        return IsRepeatedPattern(id, id[..(id.Length / 2)], 2);
    }

    private static bool IsInvalidIdPart2(this string id)
    {
        var idLength = id.Length;
        for (var patternLength = 1; patternLength <= idLength / 2; patternLength++)
        {
            if (idLength % patternLength != 0) continue;

            var repetitions = idLength / patternLength;
            if (repetitions < 2) continue;

            if (IsRepeatedPattern(id, id[..patternLength], repetitions)) return true;
        }
        return false;
    }

    private static bool IsRepeatedPattern(string id, string pattern, int expectedRepetitions)
    {
        for (var i = 1; i < expectedRepetitions; i++)
        {
            var startPos = i * pattern.Length;
            var endPos = startPos + pattern.Length;
            if (id[startPos..endPos] != pattern) return false;
        }
        return true;
    }
}