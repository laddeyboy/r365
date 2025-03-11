public class StringCalculator
{
  public static int Calculate(string? input)
  {
    try
    {
      int sum = 0;
      var nums = ValidateInput(input);
      foreach (var num in nums)
      {
        sum += num;
      }
      return sum;
    }
    catch (Exception)
    {
      throw;
    }
  }

  private static List<int> ValidateInput(string? input)
  {
    var nums = new List<int>();
    if (string.IsNullOrEmpty(input)) return [0];
    var request = input?.Split(',');
    if (request!.Length > 2)
    {
      throw new ArgumentException("Input may only be two numbers!");
    }

    foreach (var req in request)
    {
      nums.Add(int.TryParse(req.Trim(), out int n) ? n : 0);
    }
    return nums;
  }
}