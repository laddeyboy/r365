using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.Binding;

public interface ICommandLineService
{
    Task<(string? Delimiter, bool AllowNegative, int UpperBound, string? Operation)> ParseArgumentsAsync(string[] args);
}

public class CommandLineService : ICommandLineService
{
    public async Task<(string? Delimiter, bool AllowNegative, int UpperBound, string? Operation)> ParseArgumentsAsync(string[] args)
    {
        var delimiterOption = new Option<string?>(
            new[] { "--delimiter", "-d" },
            "Custom delimiter to use for splitting numbers"
        );

        var allowNegativeOption = new Option<bool>(
            new[] { "--negatives", "-n" },
            "Allow negative numbers in calculations"
        );

        var upperBoundOption = new Option<int>(
            new[] { "--upper-bound", "-u" },
            () => 1000,
            "Upper bound for numbers (numbers above this will be treated as 0)"
        );

        var operationOption = new Option<string>(
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

        (string? Delimiter, bool AllowNegative, int UpperBound, string? Operation) parsedResult = (null, false, 1000, "+");
        
        rootCommand.SetHandler(
            (delimiter, allowNegative, upperBound, operation) =>
            {
                parsedResult = (delimiter, allowNegative, upperBound, operation);
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