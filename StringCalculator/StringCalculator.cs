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
    var (delimiters, newInput) = ExtractDelimiter(denormedInput);
    if (delimiters.Count > 0)
    {
      foreach (var delimiter in delimiters)
      {
        var escapedDelimiter = Regex.Escape(delimiter);
        pattern = pattern + $@"|\s*{escapedDelimiter}\s*";
      }
    }
    var request = Regex.Split(newInput, pattern);
    foreach (var req in request!)
    {
      nums.Add((int.TryParse(req.Trim(), out int n) && n < upperBound) ? n : 0);
    }
    return nums;
  }

  private static (List<string>, string) ExtractDelimiter(string input)
  {
    string delimiterKey = "//";
    var delimiters = new List<string>();
    var modifiedInput = input;
    if (input.StartsWith(delimiterKey))
    {
      int newLineIndex = input.IndexOf('\n');
      var delimiterString = input.Substring(delimiterKey.Length, newLineIndex - delimiterKey.Length);
      modifiedInput = input.Substring(newLineIndex + 1);
      string bracketPattern = @"\[(.*?)\]";
      MatchCollection matches = Regex.Matches(delimiterString, bracketPattern);
      delimiters = matches.Where(x => x.Groups[1].Success).Select(x => x.Groups[1].Value).ToList();
      if (delimiters.Count == 0)
      {
        delimiters.Add(delimiterString);
      }
    }
    return (delimiters, modifiedInput);
  }
}