namespace _2025_CSharp.Solutions;

public static class Day03
{
    private const string InputFile = "Input/day03_input.txt";
    
    public static void Run()
    {
        var banks = GetBatteryBanks();

        var totalOutputJoltage = banks.Sum(GetMaxJoltage);

        Console.WriteLine($"Total Output Joltage: {totalOutputJoltage}");
    }
    
    private static string[] GetBatteryBanks()
    {
        return File.ReadAllLines(InputFile);
    }

    // Finds the largest 2 digits in a given string of digits, without changing the order
    private static int GetMaxJoltage(string bank)
    {
        // Find largest digit x in 0..length-1
        var firstDigit = '0';
        var maxIndex = -1;
        
        for (var i = 0; i < bank.Length - 1; i++)
        {
            if (bank[i] <= firstDigit) continue;
            firstDigit = bank[i];
            maxIndex = i;
        }
        
        // Append largest digit from x..length
        var secondDigit = '0';
        
        for (var i = maxIndex + 1; i < bank.Length; i++)
        {
            if (bank[i] <= secondDigit) continue;
            secondDigit = bank[i];
        }
        
        return int.Parse($"{firstDigit}{secondDigit}");
    }
}