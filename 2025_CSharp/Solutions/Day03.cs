namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/3
public static class Day03
{
    private const string InputFile = "Input/day03_input.txt";
    
    public static void Run()
    {
        var banks = GetBatteryBanks();

        var totalJoltage2Digits = banks.Sum(bank => GetMaxJoltage(bank, 2));
        var totalJoltage12Digits = banks.Sum(bank => GetMaxJoltage(bank, 12));

        Console.WriteLine($"Max 2-Digit Output Joltage: {totalJoltage2Digits}");
        Console.WriteLine($"Max 12-Digit Output Joltage: {totalJoltage12Digits}");
    }
    
    private static string[] GetBatteryBanks()
    {
        return File.ReadAllLines(InputFile);
    }

    private static long GetMaxJoltage(string bank, int digits)
    {
        var result = "";
        var remainingDigits = digits;
        var startIndex = 0;

        while (remainingDigits > 0)
        {
            var largestDigit = '0';
            
            remainingDigits--;
            for (var i = startIndex; i < bank.Length - remainingDigits; i++)
            {
                if (bank[i] <= largestDigit) continue;
                largestDigit = bank[i];
                startIndex = i + 1;
            }
            result += largestDigit;
        }
        
        return long.Parse(result);
    }
}