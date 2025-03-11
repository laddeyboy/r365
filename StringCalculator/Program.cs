// See https://aka.ms/new-console-template for more information
Console.Write("Please provide input: ");
var input = Console.ReadLine();
try
{
  var result = StringCalculator.Calculate(input);
  Console.WriteLine(result);
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
}
