using System;

namespace CalculatorLibrary
{
    public class Calculator
    {
        // Addition method
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Subtraction method
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiplication method
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Division method with division-by-zero handling
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        public static void Main()
        {
            Calculator calc = new Calculator();

            Console.WriteLine("Addition: " + calc.Add(5, 3));
            Console.WriteLine("Subtraction: " + calc.Subtract(10, 4));
            Console.WriteLine("Multiplication: " + calc.Multiply(6, 7));
            Console.WriteLine("Division: " + calc.Divide(12, 3));
            Console.WriteLine("Division by Zero: " + calc.Divide(10, 0));
        }
    }
}
