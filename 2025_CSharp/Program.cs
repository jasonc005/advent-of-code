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
        case "2":
            Day02.Run(); break;
        case "3":
            Day03.Run(); break;
        case "4":
            Day04.Run(); break;
        case "5":
            Day05.Run(); break;
        default:
            exit = true; break;
    }

    Console.WriteLine();

} while (!exit);