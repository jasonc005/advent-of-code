int safeReportsPart1 = 0;
int safeReportsPart2 = 0;

using (var file = new StreamReader("input.txt"))
{
    string? report;

    while ((report = file.ReadLine()) != null)
    {
        List<int> levels = report.Split(' ').Select(x => int.Parse(x)).ToList();

        if (isSafeReport(levels))
        {
            safeReportsPart1++;
            safeReportsPart2++;
            continue;
        }

        // Continue processing with problem dampener
        for (int skip = 0; skip < levels.Count; skip++)
        {
            var levelsWithSkip = levels.ToList();
            levelsWithSkip.RemoveAt(skip);

            if (isSafeReport(levelsWithSkip))
            {
                safeReportsPart2++;
                break;
            }
        }
    }
}

Console.WriteLine($"Safe Reports - Part 1: {safeReportsPart1}");
Console.WriteLine($"Safe Reports - Part 2: {safeReportsPart2}");

bool isSafeReport(List<int>? levels)
{
    if (levels == null || levels.Count == 0) return false;

    var isIncreasing = levels[0] < levels[1];

    for (int i = 1; i < levels.Count; i++)
    {
        var difference = Math.Abs(levels[i - 1] - levels[i]);
        if (isIncreasing != levels[i - 1] < levels[i] || difference < 1 || difference > 3)
        {
            return false;
        }
    }

    return true;
}