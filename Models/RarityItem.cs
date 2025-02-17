using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaritySystem.Models
{
    public class RarityItem
    {
        public Rarity Rarity { get; }
        public string Name { get; }
        public ConsoleColor Color { get; }
        public double Probability { get; }
        public int MinThreshold { get; }
        public int MaxThreshold { get; }

        public RarityItem(Rarity rarity, string name, ConsoleColor color, double probability, int min, int max)
        {
            Rarity = rarity;
            Name = name;
            Color = color;
            Probability = probability;
            MinThreshold = min;
            MaxThreshold = max;
        }
    }
}
