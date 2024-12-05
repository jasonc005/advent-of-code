namespace AoC_2024.Solutions
{
    public static class Day01
    {
        private static readonly List<int> leftList = [];
        private static readonly List<int> rightList = [];

        public static void Run()
        {
            CreateLists();
            DoPart1();
            DoPart2();
        }

        private static void CreateLists()
        {
            using (var file = new StreamReader("Input/day01_input.txt"))
            {
                string? record;

                while ((record = file.ReadLine()) != null)
                {
                    var items = record.Split("   ").Select(x => int.Parse(x)).ToList();
                    leftList.Add(items[0]);
                    rightList.Add(items[1]);
                }
            }
        }

        private static void DoPart1()
        {
            leftList.Sort();
            rightList.Sort();

            var totalDistance = 0;

            for (int i = 0; i < leftList.Count; i++)
            {
                totalDistance += Math.Abs(leftList[i] - rightList[i]);
            }

            Console.WriteLine($"Total Distance: {totalDistance}");
        }

        private static void DoPart2()
        {
            var similarityScore = 0;

            foreach (var leftItem in leftList)
            {
                similarityScore += leftItem * rightList.Count(rightItem => leftItem == rightItem);
            }

            Console.WriteLine($"Similarity Score: {similarityScore}");
        }
    }
}
