using _2025_CSharp.Helpers;

namespace _2025_CSharp.Solutions;

// Puzzle instructions: https://adventofcode.com/2025/day/4
public static class Day04
{
    private static readonly string InputFile = FileUtility.GetFilePathForDay(4);

    public static void Run()
    {
        var grid = GetGrid();

        var initialAccessibleRolls = GetInitialAccessibleRolls(grid);
        var allAccessibleRolls = GetAllAccessibleRolls(grid);

        Console.WriteLine($"Initial Accessible Rolls: {initialAccessibleRolls}");
        Console.WriteLine($"All Accessible Rolls: {allAccessibleRolls}");
    }

    private static char[][] GetGrid()
    {
        return File.ReadAllLines(InputFile).Select(row => row.ToCharArray()).ToArray();
    }

    private static int GetInitialAccessibleRolls(char[][] grid)
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

    private static int GetAllAccessibleRolls(char[][] grid)
    {
        var passResult = 0;
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (!CanBeAccessed(row, col, grid)) continue;
                grid[row][col] = 'x';
                passResult++;
            }
        }

        var totalResult = passResult;
        if (passResult > 0)
        {
            totalResult += GetAllAccessibleRolls(grid);
        }

        return totalResult;
    }

    private static bool CanBeAccessed(int row, int col, char[][] grid)
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

    private static bool IsInBounds(int row, int col, char[][] grid) =>
        row >= 0 && row < grid.Length && col >= 0 && col < grid[row].Length;
}