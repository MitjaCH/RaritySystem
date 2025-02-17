using RaritySystem.Models;

namespace RaritySystem;

class Program
{
    private static readonly List<RarityItem> RarityTable = new List<RarityItem>
        {
            new RarityItem(Rarity.Common, "Common", ConsoleColor.DarkGray, 50, 0, 49),
            new RarityItem(Rarity.Uncommon, "Uncommon", ConsoleColor.Green, 25, 50, 74),
            new RarityItem(Rarity.Rare, "Rare", ConsoleColor.Cyan, 15, 75, 89),
            new RarityItem(Rarity.Epic, "Epic", ConsoleColor.Magenta, 7, 90, 96),
            new RarityItem(Rarity.Legendary, "Legendary", ConsoleColor.Yellow, 2, 97, 98),
            new RarityItem(Rarity.Mythic, "Mythic", ConsoleColor.Red, 1, 99, 99)
        };

    private static readonly Dictionary<Rarity, int> Counter = new Dictionary<Rarity, int>();
    private static int _totalRolls = 0;

    static void Main(string[] args)
    {
        InitializeCounter();
        Console.WriteLine("Rarity System Demonstration");
        Console.WriteLine("Press any key to roll, ESC to exit\n");

        while (true)
        {
            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape) break;

            var obtainedItem = Roll();
            UpdateStatistics(obtainedItem);
            DisplayResults(obtainedItem);
        }
    }

    private static RarityItem Roll()
    {
        var random = new Random();
        int roll = random.Next(100);
        return RarityTable.First(item => roll >= item.MinThreshold && roll <= item.MaxThreshold);
    }

    private static void UpdateStatistics(RarityItem item)
    {
        _totalRolls++;
        Counter[item.Rarity]++;
    }

    private static void DisplayResults(RarityItem obtainedItem)
    {
        Console.Clear();
        Console.WriteLine("Last obtained item:");
        Console.ForegroundColor = obtainedItem.Color;
        Console.WriteLine($"╔{new string('═', obtainedItem.Name.Length + 2)}╗");
        Console.WriteLine($"║ {obtainedItem.Name} ║");
        Console.WriteLine($"╚{new string('═', obtainedItem.Name.Length + 2)}╝");
        Console.ResetColor();

        Console.WriteLine("\nStatistics:");
        foreach (var item in RarityTable)
        {
            Console.ForegroundColor = item.Color;
            double percentage = (Counter[item.Rarity] / (double)_totalRolls) * 100;
            Console.WriteLine($"{item.Name.PadRight(12)}: {Counter[item.Rarity].ToString().PadRight(5)} ({percentage:0.00}%)");
        }
        Console.ResetColor();

        Console.WriteLine($"\nTotal Rolls: {_totalRolls}");
        Console.WriteLine("\nPress any key to roll again, ESC to exit");
    }

    private static void InitializeCounter()
    {
        foreach (Rarity rarity in Enum.GetValues(typeof(Rarity)))
        {
            Counter[rarity] = 0;
        }
    }
}