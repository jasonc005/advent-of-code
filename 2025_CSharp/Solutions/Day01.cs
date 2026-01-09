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
        Part1();
    }

    private static void Part1()
    {
        var currentNumber = StartingNumber;
        var dialAtZeroCount = 0;
        
        using var reader = new StreamReader(InputFile);

        string record;
        while ((record = reader.ReadLine() ?? "") != "")
        {
            var direction = record[0];
            var distance = int.Parse(record.Substring(1));
            
            if (direction == 'L') currentNumber -= distance;
            else if (direction == 'R') currentNumber += distance;

            while (currentNumber is < MinNumber or > MaxNumber)
            {
                if (currentNumber > MaxNumber) currentNumber -= RangeLength;
                else currentNumber += RangeLength;
            }
            
            if (currentNumber == 0) dialAtZeroCount++;
        }
        
        Console.WriteLine($"Password: {dialAtZeroCount}");
    }
}