using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace MSTest_Project
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestCoNajmniejJeden()
        {
            Problem problem = new Problem(5, 123); // Przykładowa liczba przedmiotów i ziarno
            Result result = problem.Solve(10); // Przykładowa pojemność

            Assert.IsTrue(result.ItemNumbers.Count > 0);
        }

        [TestMethod]
        public void TestNiePasuje()
        {
            Problem problem = new Problem(5, 123); // Przykładowa liczba przedmiotów i ziarno
            Result result = problem.Solve(0); // Bardzo mała pojemność, żaden przedmiot nie zmieści się

            Assert.IsFalse(result.ItemNumbers.Count > 0);
        }

        [TestMethod]
        public void TestKolejnoscBezZnaczenia()
        {
            Problem problem1 = new Problem(5, 123); // Przykładowa liczba przedmiotów i ziarno
            Problem problem2 = new Problem(5, 123); // Ten sam ziarno, ale inne kolejności przedmiotów

            Result result1 = problem1.Solve(10);
            Result result2 = problem2.Solve(10);

            // Porównujemy wartości i wagi przedmiotów, a nie kolejność
            Assert.AreEqual(result1.TotalValue, result2.TotalValue);
            Assert.AreEqual(result1.TotalWeight, result2.TotalWeight);
        }

        [TestMethod]
        public void TestKonkretnaInstancja()
        {
            Problem problem = new Problem(0, 1); // Tworzymy instancję problemu bez losowo wygenerowanych przedmiotów

            // Dodaj konkretne elementy do instancji problemu
            problem.AddItem(new Item(7, 1)); // Wartość: 7, Waga: 1       
            problem.AddItem(new Item(9, 9)); // Wartość: 9, Waga: 9
            problem.AddItem(new Item(7, 8)); // Wartość: 7, Waga: 8
            problem.AddItem(new Item(3, 4)); // Wartość: 3, Waga: 4
            problem.AddItem(new Item(2, 3)); // Wartość: 2, Waga: 3
            problem.AddItem(new Item(4, 7)); // Wartość: 4, Waga: 7
            problem.AddItem(new Item(1, 2)); // Wartość: 1, Waga: 2
            problem.AddItem(new Item(2, 6)); // Wartość: 2, Waga: 6
            problem.AddItem(new Item(5, 2)); // Wartość: 5, Waga: 2
            problem.AddItem(new Item(7, 5)); // Wartość: 7, Waga: 5

            // Oczekiwane wyniki
            var expectedItems = new[] { 1, 9, 10 }; // Oczekiwane przedmioty (indeksowane od 1)
            int expectedTotalValue = 19; // Oczekiwana całkowita wartość
            int expectedTotalWeight = 8; // Oczekiwana całkowita waga

            // Act
            Result result = problem.Solve(10);

            // Assert
            CollectionAssert.AreEqual(expectedItems, result.ItemNumbers.ToArray());
            Assert.AreEqual(expectedTotalValue, result.TotalValue);
            Assert.AreEqual(expectedTotalWeight, result.TotalWeight);
        }

        [TestMethod]
        public void TestKolejnoscSortowania()
        {
            // Utwórz instancję problemu z określonymi przedmiotami
            Problem problem = new Problem(0, 1);
            problem.AddItem(new Item(10, 5)); // Dodajmy przedmioty w określonej kolejności
            problem.AddItem(new Item(5, 3));
            problem.AddItem(new Item(9, 4));

            // Rozwiąż problem dla dowolnej pojemności
            Result result = problem.Solve(10);

            // Sprawdź, czy zwrócone przedmioty są posortowane malejąco według stosunku wartości do wagi
            int highestValueItemIndex = result.ItemNumbers[0] - 1; // Indeks najwyżej wartościowego przedmiotu
            Item highestValueItem = problem.GetItem(highestValueItemIndex); // Pobierz najwyżej wartościowy przedmiot
            Assert.AreEqual(9, highestValueItem.Value); // Sprawdź, czy wartość najwyżej wartościowego przedmiotu wynosi 10
        }

        [TestMethod]
        public void TestMaxPojemnosc()
        {
            Problem problem = new Problem(3, 123);
            problem.AddItem(new Item(5, 3));
            problem.AddItem(new Item(10, 5));
            problem.AddItem(new Item(7, 4));

            Result result = problem.Solve(12); // Maksymalna pojemność, równa sumie wag przedmiotów

            Assert.AreEqual(3, result.ItemNumbers.Count); // Oczekujemy, że wszystkie przedmioty zostaną wybrane
        }

        [TestMethod]
        public void TestUjemnaPojemnosc()
        {
            Problem problem = new Problem(3, 123);
            problem.AddItem(new Item(5, 3));
            problem.AddItem(new Item(10, 5));
            problem.AddItem(new Item(7, 4));

            Result result = problem.Solve(-5); // Ujemna pojemność

            Assert.IsFalse(result.ItemNumbers.Count > 0); // Oczekujemy pustego rozwiązania
        }


        [TestMethod]
        public void TestDuzaPojemnosc()
        {
            Problem problem = new Problem(1000, 123); // Duża liczba przedmiotów
            // Dodajemy 1000 losowych przedmiotów
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                problem.AddItem(new Item(random.Next(1, 10), random.Next(1, 10)));
            }

            Result result = problem.Solve(10000); // Bardzo duża pojemność

            Assert.IsTrue(result.ItemNumbers.Count > 0); // Oczekujemy, że zostaną wybrane przynajmniej niektóre przedmioty
        }
    }
}