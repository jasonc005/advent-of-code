using AoC_2024.Solutions;

var exit = false;
do
{
    Console.Write("\nSelect Day: ");
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
        default:
            exit = true; break;
    }

} while (!exit);
