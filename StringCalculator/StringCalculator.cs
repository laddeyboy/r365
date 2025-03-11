using System.Text.RegularExpressions;

public class StringCalculator
{
  public static int Calculate(string? input)
  {
    int sum = 0;
    var nums = ValidateInput(input);
    foreach (var num in nums)
    {
      sum += num;
    }
    return sum;
  }

  private static List<int> ValidateInput(string? input)
  {
    var nums = new List<int>();
    if (string.IsNullOrEmpty(input)) return [0];
    var request = Regex.Split(input, @"[,\n]");
    foreach (var req in request!)
    {
      nums.Add(int.TryParse(req.Trim(), out int n) ? n : 0);
    }
    return nums;
  }
}