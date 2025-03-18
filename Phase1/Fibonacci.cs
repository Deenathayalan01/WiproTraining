using System;

class FibonacciSeries
{
    static void PrintFibonacci(int terms)
    {
        int first = 0, second = 1, next;
        Console.Write($"{first} {second} ");
        for (int i = 2; i < terms; i++)
        {
            next = first + second;
            Console.Write($"{next} ");
            first = second;
            second = next;
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.Write("Enter the number of terms: ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("Please enter a positive integer.");
        }
        else
        {
            Console.WriteLine("Fibonacci Series:");
            PrintFibonacci(n);
        }
    }
}
