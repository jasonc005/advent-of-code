namespace _2025_CSharp.Helpers;

public static class FileUtility
{
    public static string GetFilePathForDay(int day, bool useSample = false)
    {
        return Path.Combine(Environment.CurrentDirectory, $"Input{(useSample ? "/Samples" : "")}/day{day:D2}_input.txt");
    }
}