namespace _2025_CSharp.Solutions;

public static class Day04
{
    private const string InputFile = "Input/day04_input.txt";

    public static void Run()
    {
        var grid = GetGrid();

        var initialAccessibleRolls = GetInitialAccessibleRolls(grid);
        Console.WriteLine($"Total Accessible Rolls: {initialAccessibleRolls}");
    }
    
    private static string[] GetGrid()
    {
        return File.ReadAllLines(InputFile);
    }
    
    private static int GetInitialAccessibleRolls(string[] grid)
    {
        var result = 0;
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (!CanBeAccessed(row, col, grid)) continue;
                result++;
            }
        }
        return result;
    }

    private static bool CanBeAccessed(int row, int col, string[] grid)
    {
        if (grid[row][col] != '@') return false;

        var adjacentRolls = PositionsToCheck(row, col)
            .Where(position => IsInBounds(position.row, position.col, grid))
            .Count(position => grid[position.row][position.col] == '@');

        return adjacentRolls < 4;
    }
    
    private static List<(int row, int col)> PositionsToCheck(int row, int col) =>
    [
        (row - 1, col - 1),
        (row - 1, col),
        (row - 1, col + 1),
        (row, col - 1),
        (row, col + 1),
        (row + 1, col - 1),
        (row + 1, col),
        (row + 1, col + 1)
    ];
    
    private static bool IsInBounds(int row, int col, string[] grid) => 
        row >= 0 && row < grid.Length && col >= 0 && col < grid[row].Length;
}