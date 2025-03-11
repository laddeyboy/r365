using System.Text.RegularExpressions;

public class StringCalculator
{
  public static int Calculate(string? input)
  {
    int sum = 0;
    int upperBound = 1000;
    var nums = ValidateInput(input, upperBound);
    var negativeNumbers = nums.Where(n => n < 0).ToList();
    if (negativeNumbers.Any())
    {
      var errorValues = string.Join(", ", negativeNumbers);
      throw new ArgumentOutOfRangeException(errorValues);
    }
    foreach (var num in nums)
    {
      sum += num;
    }
    return sum;
  }

  private static List<int> ValidateInput(string? input, int upperBound)
  {
    var nums = new List<int>();
    if (string.IsNullOrEmpty(input)) return [0];
    // string literal \n needs to be converted to actual newline \n first
    var denormedInput = input.Trim().Replace("\\n", "\n");
    var pattern = $@"\s*,\s*|\s*\n\s*";
    var (delimiter, newInput) = ExtractDelimiter(denormedInput);
    if(delimiter is not null)
    {
      var escapedDelimiter = Regex.Escape(delimiter);
      pattern = pattern + $@"|\s*{escapedDelimiter}\s*";
    }
    var request = Regex.Split(newInput, pattern).ToList();

    foreach (var req in request!)
    {
      nums.Add((int.TryParse(req.Trim(), out int n) && n < upperBound) ? n : 0);
    }
    return nums;
  }

  private static (string?, string) ExtractDelimiter(string input)
  {
    string delimiterKey = "//";
    int newLineIndex = input.IndexOf('\n');
    if(input.StartsWith(delimiterKey))
    {
      return (
        input.Substring(delimiterKey.Length, newLineIndex - delimiterKey.Length),
        input.Substring(newLineIndex + 1)
      );
        
    }
    return (null, input);
  }
}