// See https://aka.ms/new-console-template for more information

string? delimiter = null;
bool allowNegative = false;
int upperBound = 1000;

for (int i = 0; i < args.Length; i++)
{
  switch (args[i].ToLower())
  {
    case "-d":
    case "--delimiter":
      if (i + 1 < args.Length)
      {
        delimiter = args[i + 1];
        i++;
      }
      break;

    case "-n":
    case "--negatives":
      allowNegative = true;
      break;

    case "-u":
    case "--upper-bound":
      if (i + 1 < args.Length && int.TryParse(args[i + 1], out int bound))
      {
        upperBound = bound;
        i++;
      }
      break;

    default:
      Console.WriteLine($"Unknown argument: {args[i]}");
      break;
  }
}

// Example usage of the parsed values
Console.WriteLine($"Delimiter: {delimiter}");
Console.WriteLine($"Allow Negative Numbers: {allowNegative}");
Console.WriteLine($"Upper Bound: {upperBound}");


Console.WriteLine("Press Ctrl+C to exit.");
while (true)
{
  Console.Write("Please provide input: ");
  var input = Console.ReadLine();
  try
  {
    var result = StringCalculator.Calculate(input, upperBound, allowNegative, delimiter);
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
}

