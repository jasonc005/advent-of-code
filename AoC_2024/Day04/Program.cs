// Part One
static List<string> getRows()
{
    var result = new List<string>();
    using (var file = new StreamReader("input.txt"))
    {
        string? line;
        while ((line = file.ReadLine()) != null)
        {
            result.Add(line);
        }
    }
    return result;
}

static List<string> getColumns(List<string> rows)
{
    var result = new List<string>();
    for (int i = 0; i < rows.Count; i++)
    {
        var column = "";
        rows.ForEach(row => column += row[i]);
        result.Add(column);
    }
    return result;
}

static List<string> getDiagonals(List<string> rows)
{
    var result = new List<string>();
    var dimension = rows.Count;

    var mainDiagonal = "";
    for (int i = 0; i < dimension; i++)
    {
        mainDiagonal += rows[i][i];
    }
    result.Add(mainDiagonal);

    for (int i = 1; i < dimension - 3; i++)
    {
        var superDiagonal = "";
        for (int j = 0; j < dimension - i; j++)
        {
            superDiagonal += rows[j][j + i];
        }
        result.Add(superDiagonal);

        var subDiagonal = "";
        for (int j = i; j < dimension; j++)
        {
            subDiagonal += rows[j][j - i];
        }
        result.Add(subDiagonal);
    }

    return result;
}

var searchStrings = new List<string>();

var rows = getRows();
searchStrings.AddRange(rows);
searchStrings.AddRange(getColumns(rows));
searchStrings.AddRange(getDiagonals(rows));
searchStrings.AddRange(getDiagonals(rows.Select(row => string.Concat(row.Reverse())).ToList()));

var xmasCount = 0;
foreach (var item in searchStrings)
{
    for (int i = 0; i < item.Length - 3; i++)
    {
        var substring = item.Substring(i, 4);
        if (substring == "XMAS" || substring == "SAMX") xmasCount++;
    }
}

Console.WriteLine($"XMAS Count: {xmasCount}");

// Part Two
var x_masCount = 0;
for (int i = 0; i < rows.Count - 2; i++)
{
    for (int j = 0; j < rows.Count - 2; j++)
    {
        if (rows[i][j] == 'X') continue;

        var diag1 = $"{rows[i][j]}{rows[i + 1][j + 1]}{rows[i + 2][j + 2]}";

        if (diag1 == "MAS" || diag1 == "SAM")
        {
            var diag2 = $"{rows[i + 2][j]}{rows[i + 1][j + 1]}{rows[i][j + 2]}";
            if (diag2 == "MAS" || diag2 == "SAM")
            {
                x_masCount++;
            }
        }
    }
}

Console.WriteLine($"X MAS Count: {x_masCount}");