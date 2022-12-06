using Console = Colorful.Console;

// all of the days

List<AOC.Day> days = new List<AOC.Day>() {
    new AOC.DayOne(),
    new AOC.DayTwo()
    };
int day = -1;

while(true)
{
    
    Console.WriteAscii("Advant Of Code 2022");

    Console.Write("\nDay >");

    int.TryParse(Console.ReadLine(), out day);

    if (day >= 1 && day <= days.Count())
        days[day - 1].run();
    else
        Console.WriteLine("That isn't a day!");
    Console.Clear();
}