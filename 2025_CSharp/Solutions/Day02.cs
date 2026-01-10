namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/2
public static class Day02
{
    private const string InputFile = "Input/day02_input.txt";

    public static void Run()
    {
        var idRanges = GetIdRanges().ToList();
        
        Console.WriteLine($"Sum of Invalid IDs - Part 1: {GetPart1Solution(idRanges)}");
        Console.WriteLine($"Sum of Invalid IDs - Part 2: {GetPart2Solution(idRanges)}");
    }

    private static IEnumerable<string[]> GetIdRanges()
    {
        using var reader = new StreamReader(InputFile);
        var rangeList = reader.ReadToEnd();
        return rangeList.Split(",").Select(x => x.Split("-"));
    }
    
    private static bool IsOdd(this int number) => number % 2 == 1;
    
    private static long GetPart1Solution(IEnumerable<string[]> idRanges)
    {
        long result = 0;
        foreach (var range in idRanges)
        {
            if (range[0].Length == range[1].Length && range[0].Length.IsOdd()) continue;

            for (var i = long.Parse(range[0]); i <= long.Parse(range[1]); i++)
            {
                var id = i.ToString();
                if (id.Length.IsOdd()) continue;
                
                if (id[..(id.Length / 2)] == id[(id.Length / 2)..]) result += i;
            }
        }
        return result;
    }

    private static long GetPart2Solution(IEnumerable<string[]> idRanges)
    {
        long result = 0;
        // Loop through each range
        foreach (var range in idRanges)
        {
            // Loop through each ID in range
            for (var i = long.Parse(range[0]); i <= long.Parse(range[1]); i++)
            {
                if (i.ToString().IsInvalidIdPart2()) result += i;
            }
        }
        return result;
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
        for (var i = 0; i < expectedRepetitions; i++)
        {
            var startPos = i * pattern.Length;
            var endPos = startPos + pattern.Length;
            if (id[startPos..endPos] != pattern) return false;
        }
        return true;
    }

}