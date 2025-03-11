// See https://aka.ms/new-console-template for more information
Console.WriteLine("Press Ctrl+C to exit.");
while (true)
{
  Console.Write("Please provide input: ");
  var input = Console.ReadLine();
  try
  {
    var result = StringCalculator.Calculate(input);
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
}

