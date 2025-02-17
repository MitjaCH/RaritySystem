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
    private static bool _autoRolling = false;

    static void Main(string[] args)
    {
        InitializeCounter();
        Console.WriteLine("Rarity System Demonstration");
        Console.WriteLine("Press R to roll, A to auto-roll, I for instant rolls, ESC to exit\n");

        while (true)
        {
            if (!_autoRolling)
            {
                var input = Console.ReadKey();
                if (input.Key == ConsoleKey.Escape) break;

                if (input.Key == ConsoleKey.R)
                {
                    RollAndDisplay();
                }
                else if (input.Key == ConsoleKey.A)
                {
                    _autoRolling = true;
                    AutoRoll();
                }
                else if (input.Key == ConsoleKey.I)
                {
                    Console.Write("\nEnter the number of rolls: ");
                    if (int.TryParse(Console.ReadLine(), out int rollCount) && rollCount > 0)
                    {
                        InstantRolls(rollCount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                AutoRoll();
            }
        }
    }

    private static void RollAndDisplay()
    {
        var obtainedItem = Roll();
        UpdateStatistics(obtainedItem);
        DisplayResults(obtainedItem);
    }

    private static void AutoRoll()
    {
        RollAndDisplay();
        Thread.Sleep(200); // Adjust the speed of auto-rolling here

        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.A)
        {
            _autoRolling = false;
            Console.WriteLine("\nAuto-roll stopped. Press any key to continue...");
            Console.ReadKey();
        }
    }

    private static void InstantRolls(int rollCount)
    {
        for (int i = 0; i < rollCount; i++)
        {
            var obtainedItem = Roll();
            UpdateStatistics(obtainedItem);
        }
        DisplayResults(null);
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
        if (obtainedItem != null)
        {
            Console.WriteLine("Last obtained item:");
            Console.ForegroundColor = obtainedItem.Color;
            Console.WriteLine($"╔{new string('═', obtainedItem.Name.Length + 2)}╗");
            Console.WriteLine($"║ {obtainedItem.Name} ║");
            Console.WriteLine($"╚{new string('═', obtainedItem.Name.Length + 2)}╝");
            Console.ResetColor();
        }

        Console.WriteLine("\nStatistics:");
        foreach (var item in RarityTable)
        {
            Console.ForegroundColor = item.Color;
            double percentage = (_totalRolls > 0) ? (Counter[item.Rarity] / (double)_totalRolls) * 100 : 0;
            Console.WriteLine($"{item.Name.PadRight(12)}: {Counter[item.Rarity].ToString().PadRight(5)} ({percentage:0.00}%) - Chance: {item.Probability}%");
        }
        Console.ResetColor();

        Console.WriteLine($"\nTotal Rolls: {_totalRolls}");
        Console.WriteLine("\nPress R to roll, A to auto-roll, I for instant rolls, ESC to exit");
    }

    private static void InitializeCounter()
    {
        foreach (Rarity rarity in Enum.GetValues(typeof(Rarity)))
        {
            Counter[rarity] = 0;
        }
    }
}
