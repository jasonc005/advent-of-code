using System.Text;

namespace AoC_2024.Solutions
{
    public static class Day05
    {
        private static List<string> rules = [];
        private static List<string[]> updates = [];

        public static void Run()
        {
            LoadInput();

            var medianTotal = 0;
            foreach (var update in updates)
            {
                if (IsUpdateValid(update))
                {
                    medianTotal += GetMedianValue(update);
                }
            }
            Console.WriteLine($"Sum of Valid Medians: {medianTotal}");
        }

        private static void LoadInput()
        {
            using var file = new StreamReader("Input/day05_input.txt");
            var writeUpdates = false;
            string? line;
            while ((line = file.ReadLine()) != null)
            {
                if (!writeUpdates && string.IsNullOrWhiteSpace(line))
                {
                    writeUpdates = true;
                    continue;
                }

                if (writeUpdates)
                    updates.Add(line.Split(','));
                else
                    rules.Add(line);
            }
        }

        private static bool IsUpdateValid(string[] update)
        {
            foreach (var page in update)
            {
                foreach (var rule in rules.Where(rule => rule.Contains(page)))
                {
                    var ruleParts = rule.Split('|');
                    var firstRuleIndex = Array.IndexOf(update, ruleParts[0]);
                    var secondRuleIndex = Array.IndexOf(update, ruleParts[1]);

                    if (firstRuleIndex < 0 || secondRuleIndex < 0)
                    {
                        continue;
                    }
                    if (firstRuleIndex > secondRuleIndex)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static int GetMedianValue(string[] data)
        {
            if (data.Length % 2 == 0)
                return int.Parse(data[data.Length / 2]);
            else
                return int.Parse(data[(data.Length - 1) / 2]);
        }
    }
}