using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

// Create lists
var leftList = new List<int>();
var rightList = new List<int>();

using (var reader = new StreamReader("input.csv"))
using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HasHeaderRecord = false }))
{
    var records = csv.GetRecords<Tuple<int, int>>();

    foreach (var record in records)
    {
        leftList.Add(record.Item1);
        rightList.Add(record.Item2);
    }
}

// Part One
leftList.Sort();
rightList.Sort();

var totalDistance = 0;

for (int i = 0; i < leftList.Count; i++)
{
    totalDistance += Math.Abs(leftList[i] - rightList[i]);
}

Console.WriteLine($"Total Distance: {totalDistance}");

// Part Two
var similarityScore = 0;

foreach (var leftItem in leftList)
{
    similarityScore += leftItem * rightList.Count(rightItem => leftItem == rightItem);
}

Console.WriteLine($"Similarity Score: {similarityScore}");