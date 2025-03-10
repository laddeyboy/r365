public class StringCalculator
{
  public static int Calculate(string? input)
  {
    int sum = 0;
    if (string.IsNullOrEmpty(input)) return sum;
    var request = input?.Split(',');
    if (request!.Length > 2)
    {
      throw new ArgumentException("Input may only be two numbers!");
    }

    foreach (var num in request)
    {
      if (int.TryParse(num.Trim(), out int n))
      {
        sum += n;
      }
    }

    return sum;
  }
}