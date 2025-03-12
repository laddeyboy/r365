// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddSingleton<ICommandLineService, CommandLineService>()
    .AddSingleton<IStringCalculator, StringCalculator>()
    .AddSingleton<CalculatorRunner>()
    .BuildServiceProvider();

var commandLineService = services.GetRequiredService<ICommandLineService>();
var calculator = services.GetRequiredService<IStringCalculator>();
var runner = services.GetRequiredService<CalculatorRunner>();

var (delimiter, allowNegative, upperBound, operation) = await commandLineService.ParseArgumentsAsync(args);

Console.WriteLine($"Delimiter: {delimiter ?? "default"}");
Console.WriteLine($"Allow Negative Numbers: {allowNegative}");
Console.WriteLine($"Upper Bound: {upperBound}");
Console.WriteLine($"Operation: {operation}");

runner.Run(calculator, upperBound, allowNegative, delimiter, operation);



