using System;

public class CalculatorRunner
{
    public void Run(IStringCalculator calculator, int upperBound, bool allowNegative, string? delimiter, string? operation)
    {
        Console.WriteLine("Press Ctrl+C to exit.");
        while (true)
        {
            Console.Write("Please provide input: ");
            var input = Console.ReadLine();
            try
            {
                var result = calculator.Calculate(input, upperBound, allowNegative, delimiter, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}