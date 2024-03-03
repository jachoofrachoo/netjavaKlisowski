namespace FizzBuzz;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj górny zakres liczb:");
        int uB = Convert.ToInt32(Console.ReadLine());

        FizzBuzz fizzBuzz = new FizzBuzz(uB);
        fizzBuzz.Display();
    }
}

