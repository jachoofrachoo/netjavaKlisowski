using System;
namespace ConsoleApp1
{
    public class Item
    {
        public int Value { get; }
        public int Weight { get; }

        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
        }
    }
}

