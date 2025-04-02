// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using StringCalculatorHandlers.Handlers;

var services = new ServiceCollection()
    .AddSingleton<ICommandLineService, CommandLineService>()
    .AddSingleton<IStringCalculatorHandler, StringCalculatorHandler>()
    .AddSingleton<CalculatorRunner>()
    .BuildServiceProvider();

var runner = services.GetRequiredService<CalculatorRunner>();

runner.Run(args);