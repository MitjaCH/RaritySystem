# Rarity System 🎲

A C# console application that simulates a rarity system with customizable probabilities. It features manual rolling, auto-rolling, and instant rolls. It also displays statistics, including the actual chances for each rarity type.

## Features
- **Manual Roll:** Press `R` to roll once.
- **Auto-Roll:** Press `A` to start/stop continuous rolling.
- **Instant Rolls:** Press `I` to perform a specified number of rolls instantly.
- **Probability Display:** Shows the actual chances for each rarity next to the statistics.
- **Statistics Tracking:** Displays the number of times each rarity has been obtained, along with the percentage.

## Rarity Table
| Rarity    | Color          | Chance | Threshold  |
|-----------|----------------|--------|------------|
| Common    | Dark Gray      | 50%    | 0 - 49     |
| Uncommon  | Green          | 25%    | 50 - 74    |
| Rare      | Cyan           | 15%    | 75 - 89    |
| Epic      | Magenta        | 7%     | 90 - 96    |
| Legendary | Yellow         | 2%     | 97 - 98    |
| Mythic    | Red            | 1%     | 99 - 99    |

## How to Use
1. Clone the repository:
    ```sh
    git clone https://github.com/MitjaCH/RaritySystem.git
    ```
2. Navigate to the project directory:
    ```sh
    cd RaritySystem
    ```
3. Build and run the application:
    ```sh
    dotnet run
    ```

## Controls
- `R`: Roll once.
- `A`: Toggle auto-rolling.
- `I`: Input the number of rolls to perform instantly.
- `ESC`: Exit the application.

## Example Output
```
Last obtained item:
╔══════╗
║ Epic ║
╚══════╝

Statistics:
Common      : 48    (48.00%) - Chance: 50%
Uncommon    : 25    (25.00%) - Chance: 25%
Rare        : 15    (15.00%) - Chance: 15%
Epic        : 7     (7.00%)  - Chance: 7%
Legendary   : 2     (2.00%)  - Chance: 2%
Mythic      : 1     (1.00%)  - Chance: 1%

Total Rolls: 100

Press R to roll, A to auto-roll, I for instant rolls, ESC to exit
```

## Dependencies
- .NET 9.x.x

## Installation
Ensure you have the .NET SDK installed. You can download it from [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

## Customization
You can modify the rarity table by changing the `RarityTable` list in `Program.cs`. Adjust the following properties for each `RarityItem`:
- **Name**: The display name of the rarity.
- **Color**: The console color for the rarity.
- **Probability**: The chance of obtaining the rarity.
- **Thresholds**: The range for the random roll.

## Contributing
Contributions are welcome! Feel free to open issues or submit pull requests.

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.

## Acknowledgments
- Inspired by loot box systems in games.

---

Happy rolling! 🎲
