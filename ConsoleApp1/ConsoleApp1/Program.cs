using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj ilosc przedmiotow:");
            int numberOfItems = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj ziarno:");
            int seed = int.Parse(Console.ReadLine());

            Problem problem = new Problem(numberOfItems, seed);

            Console.WriteLine("Podaj pojemnosc:");
            int capacity = int.Parse(Console.ReadLine());

            Result result = problem.Solve(capacity);
            Console.WriteLine(result);
        }
    }
}
