using _2025_CSharp.Solutions;

var exit = false;
do
{
    Console.Write("Select Day: ");
    var day = Console.ReadLine();

    switch (day)
    {
        case "1":
            Day01.Run(); break;
        default:
            exit = true; break;
    }

    Console.WriteLine();

} while (!exit);