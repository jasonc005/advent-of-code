using System.Collections;

namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/1
public static class Day01
{
    private const string InputFile = "Input/day01_input.txt";
    private const int StartingNumber = 50;
    private const int MaxNumber = 99;
    private const int MinNumber = 0;
    private const int RangeLength = MaxNumber - MinNumber + 1;

    public static void Run()
    {
        var currentNumber = StartingNumber;
        var part1Count = 0;

        foreach ((char direction, int distance) instruction in GetInstructions())
        {
            if (instruction.direction == 'L') currentNumber -= instruction.distance;
            else if (instruction.direction == 'R') currentNumber += instruction.distance;

            while (currentNumber is < MinNumber or > MaxNumber)
            {
                if (currentNumber > MaxNumber) currentNumber -= RangeLength;
                else currentNumber += RangeLength;
            }
            
            if (currentNumber == 0) part1Count++;
        }
        
        Console.WriteLine($"Part 1 Password: {part1Count}");
    }
    
    private static IEnumerable<(char direction, int distance)> GetInstructions()
    {
        using var reader = new StreamReader(InputFile);
        while (reader.ReadLine() is { } record)
        {
            yield return (record[0], int.Parse(record.Substring(1)));
        }
    }
}