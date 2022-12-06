using Console = Colorful.Console;

namespace AOC {
    
    public struct Elf {
        public int calories;
        public int position;
        public Elf()
        {
            calories = 0;
            position = 1;
        }
    }

    class DayOne : Day
    {
        public override void run()
        {
            Console.WriteAscii("Day 1");
            Console.WriteLine("Find the elf with the most calories.");

            string[] lines = File.ReadAllLines("inputs/day1.input");

            List<Elf> elves = new List<Elf>();

            Elf currentElf = new Elf();
            
            foreach(string l in lines)
            {
                if (l.Count() >= 1)
                    currentElf.calories += int.Parse(l);
                else
                {
                    int last = currentElf.position;
                    elves.Add(currentElf);
                    currentElf = new Elf();
                    currentElf.position = last + 1;
 
                }
                
            }
            elves.Add(currentElf); // add the last one

            elves = elves.OrderByDescending((e) => e.calories).ToList();

            int amount = 0;

            Console.WriteLine("How many elves do you want to compare?");
            Console.Write("\nAmount >");
            
            int.TryParse(Console.ReadLine(), out amount);
            
            int totalCalories = 0;

            for(int i = 0; i < amount; i++)
            {
                Elf e = elves[i];
                Console.WriteLine("#" + (i + 1) + " - Elf Number " + e.position + " - Calories: " + e.calories);
                totalCalories += e.calories;
            }
            Console.WriteLine("Total: " + totalCalories);
            Console.Read();
        }
    }
}