using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MSTest Project")]
namespace ConsoleApp1
{

    public class Problem
    {
        private int _numberOfItems;
        private List<Item> _items;

        public Problem(int numberOfItems, int seed)
        {
            _numberOfItems = numberOfItems;
            _items = new List<Item>();

            Random random = new Random(seed);
            for (int i = 0; i < _numberOfItems; i++)
            {
                int value = random.Next(1, 11);
                int weight = random.Next(1, 11);
                _items.Add(new Item(value, weight));
            }
        }

        public Item GetItem(int index)
        {
            return _items[index];
        }


        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public Result Solve(int capacity)
        {
            List<Item> sortedItems = _items.OrderByDescending(item => (double)item.Value / item.Weight).ToList();

            List<int> selectedItems = new List<int>();
            int totalValue = 0;
            int totalWeight = 0;

            Console.WriteLine("Przedmioty wygenerowane:");
            foreach (var item in _items)
            {
                Console.WriteLine($"Wartosc: {item.Value}, Waga: {item.Weight}");
            }
            Console.WriteLine();

            foreach (var item in sortedItems)
            {
                if (totalWeight + item.Weight <= capacity)
                {
                    selectedItems.Add(_items.IndexOf(item) + 1);
                    totalValue += item.Value;
                    totalWeight += item.Weight;
                }
                else
                {
                    break;
                }
            }

            return new Result
            {
                ItemNumbers = selectedItems,
                TotalValue = totalValue,
                TotalWeight = totalWeight
            };
        }
    }
}
