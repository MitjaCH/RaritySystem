# Rarity System 🎲

A C# console application that simulates a rarity system with customizable probabilities. It features manual rolling (for now). It also displays statistics, including the actual chances for each rarity type.

## Features
- **Manual Roll:** Press any key to roll once.
- - **Statistics Tracking:** Displays the number of times each rarity has been obtained, along with the percentage.

## Rarity Table

## Rarity Table
| Rarity    | Color          | Chance |
|-----------|----------------|--------|
| Common    | Dark Gray      | 50%    |
| Uncommon  | Green          | 25%    |
| Rare      | Cyan           | 15%    |
| Epic      | Magenta        | 7%     |
| Legendary | Yellow         | 2%     |
| Mythic    | Red            | 1%     |

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
   - `ESC`: Exit the application.

## Dependencies
- .NET 9

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
