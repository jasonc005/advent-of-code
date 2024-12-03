using System.Text.RegularExpressions;

string fullText;
using (var file = new StreamReader("input.txt"))
{
    fullText = file.ReadToEnd();
}

// Part One
var mulMatches = Regex.Matches(fullText, @"mul\(\d{1,3},\d{1,3}\)");

var total = 0;
foreach (var match in mulMatches)
{
    total += getMulResult(match.ToString());
}

Console.WriteLine($"Sum of Multiplications: {total}");

// Part Two
var filteredMatches = Regex.Matches(fullText, @"mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\)");

var filteredTotal = 0;
var process = true;
foreach (var match in filteredMatches)
{
    var matchString = match.ToString();
    
    switch (matchString)
    {
        case "do()":
            process = true; break;
        case "don't()":
            process = false; break;
        default:
            if (!process) break;
            filteredTotal += getMulResult(matchString);
            break;
    }
}

Console.WriteLine($"Sum of Filtered: {filteredTotal}");

int getMulResult(string? mulString)
{
    if (string.IsNullOrEmpty(mulString)) return 0;

    var digits = mulString.Substring(4, mulString.Length - 5).Split(',');

    return int.Parse(digits[0]) * int.Parse(digits[1]);
}