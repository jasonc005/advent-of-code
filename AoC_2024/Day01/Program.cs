// Create lists
var leftList = new List<int>();
var rightList = new List<int>();

using (var file = new StreamReader("input.txt"))
{
    string? record;

    while ((record = file.ReadLine()) != null)
    {
        var items = record.Split("   ").Select(x => int.Parse(x)).ToList();
        leftList.Add(items[0]);
        rightList.Add(items[1]);
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