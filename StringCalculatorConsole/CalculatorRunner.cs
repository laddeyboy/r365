using System;
using StringCalculatorHandlers.Handlers;

public class CalculatorRunner
{
    readonly ICommandLineService _clis;
    readonly IStringCalculatorHandler _calcHandler;

    public CalculatorRunner(ICommandLineService clis, IStringCalculatorHandler calcHandler)
    {
        _clis = clis;
        _calcHandler = calcHandler;
    }
    public async void Run(string[] args)
    {
        Console.WriteLine("Press Ctrl+C to exit.");
        while (true)
        {
            Console.Write("Please provide input: ");
            var input = Console.ReadLine();
            try
            {
                var commandLineArgs = await _clis.ParseArgumentsAsync(args);
                var result = await _calcHandler.Calculate(new()
                {
                    Input = input,
                    AllowNegatives = commandLineArgs.AllowNegatives,
                    CustomDelimiter = commandLineArgs.CustomDelimiter,
                    Operation = commandLineArgs.Operation,
                    UpperBound = commandLineArgs.UpperBound
                });
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}