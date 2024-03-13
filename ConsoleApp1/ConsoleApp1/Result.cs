using System;
namespace ConsoleApp1
{
    public class Result
    {
        public List<int> ItemNumbers { get; set; }
        public int TotalValue { get; set; }
        public int TotalWeight { get; set; }

        public override string ToString()
        {
            string result = "Przedmioty: ";
            foreach (var number in ItemNumbers)
            {
                result += $"{number} ";
            }
            result += $"\nCalkowita wartosc: {TotalValue}, Calkowita waga: {TotalWeight}";
            return result;
        }
    }

}

