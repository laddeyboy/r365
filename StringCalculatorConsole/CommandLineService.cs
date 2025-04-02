using System.CommandLine;

public interface ICommandLineService
{
    Task<CommandLineArgs> ParseArgumentsAsync(string[] args);
}

public class CommandLineArgs 
{
    public bool AllowNegatives { get; set; } = false;
    public int UpperBound { get; set;} = 1000;
    public string Operation { get; set; } = "+";
    public string? CustomDelimiter { get; set; }
}

public class CommandLineService : ICommandLineService
{
    public async Task<CommandLineArgs> ParseArgumentsAsync(string[] args)
    {
        var delimiterOption = new Option<string?>(
            new[] { "--delimiter", "-d" },
            () => null,
            "Custom delimiter to use for splitting numbers"
        );

        var allowNegativeOption = new Option<bool>(
            new[] { "--negatives", "-n" },
            () => false,
            "Allow negative numbers in calculations"
        );

        var upperBoundOption = new Option<int>(
            new[] { "--upper-bound", "-u" },
            () => 1000,
            "Upper bound for numbers (numbers above this will be treated as 0)"
        );

        var operationOption = new Option<string?>(
            new[] { "--operation", "-o" },
            () => "+",
            "Mathmatical operation to perform on numbers"
        );

        var rootCommand = new RootCommand("String Calculator - adds numbers from input strings")
        {
            delimiterOption,
            allowNegativeOption,
            upperBoundOption,
            operationOption
        };

        var parsedResult = new CommandLineArgs();
        
        rootCommand.SetHandler(
            (delimiter, allowNegatives, upperBound, operation) =>
            {
                Console.WriteLine($"Delimiter: {delimiter ?? "default"}");
                Console.WriteLine($"Allow Negative Numbers: {allowNegatives}");
                Console.WriteLine($"Upper Bound: {upperBound}");
                Console.WriteLine($"Operation: {operation}");
                parsedResult.CustomDelimiter = delimiter;
                parsedResult.AllowNegatives = allowNegatives;
                parsedResult.UpperBound = upperBound;
                parsedResult.Operation = operation ?? parsedResult.Operation;
            },
            delimiterOption,
            allowNegativeOption,
            upperBoundOption,
            operationOption
        );
        
        await rootCommand.InvokeAsync(args);
        return parsedResult;
    }
} 