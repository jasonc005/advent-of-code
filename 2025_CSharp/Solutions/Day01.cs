using _2025_CSharp.Helpers;

namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/1
public static class Day01
{
    private static readonly string InputFile = FileUtility.GetFilePathForDay(1);
    private const int StartingNumber = 50;
    private const int MaxNumber = 99;
    private const int MinNumber = 0;
    private const int RangeLength = MaxNumber - MinNumber + 1;

    public static void Run()
    {
        var currentNumber = StartingNumber;
        var part1Count = 0;
        var part2Count = 0;

        foreach ((char direction, int distance) instruction in GetInstructions())
        {
            var startPosition = currentNumber;

            // Perform instructed movement
            if (instruction.direction == 'L') currentNumber -= instruction.distance;
            else if (instruction.direction == 'R') currentNumber += instruction.distance;
            else throw new Exception("Invalid instruction");

            // Part 2: Count how many times we pass through 0 during this movement
            part2Count += CountZeroCrossings(startPosition, currentNumber);

            // Handle wrapping around to valid number
            currentNumber = WrapPosition(currentNumber);

            // Part 1: Count when we stop exactly at 0
            if (currentNumber == 0) part1Count++;
        }

        Console.WriteLine($"Part 1 Password: {part1Count}");
        Console.WriteLine($"Part 2 Password: {part2Count}");
    }


    private static IEnumerable<(char direction, int distance)> GetInstructions()
    {
        using var reader = new StreamReader(InputFile);
        while (reader.ReadLine() is { } record)
        {
            yield return (record[0], int.Parse(record.Substring(1)));
        }
    }

    private static int WrapPosition(int position)
    {
        // Normalize to [0, RangeLength) then shift to [MinNumber, MaxNumber]
        return ((position - MinNumber) % RangeLength + RangeLength) % RangeLength + MinNumber;
    }

    private static int CountZeroCrossings(int start, int end)
    {
        if (start == end) return 0;
        if (end == MinNumber) return 1;
        if (end is <= MaxNumber and >= MinNumber) return 0;

        // Determine the range of positions we actually visit (excluding start)
        var minVisited = start < end ? start + 1 : end;
        var maxVisited = start < end ? end : start - 1;

        // Count multiples of RangeLength in [minVisited, maxVisited]
        // Find multipliers k where k * RangeLength falls in our range
        var minK = (int)Math.Ceiling((double)minVisited / RangeLength);
        var maxK = (int)Math.Floor((double)maxVisited / RangeLength);

        return minK <= maxK ? maxK - minK + 1 : 0;
    }
}