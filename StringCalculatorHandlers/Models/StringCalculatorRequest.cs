public class StringCalculatorRequest 
{
    public bool AllowNegatives { get; set; } = false;
    public string? CustomDelimiter { get; set; }
    public string Operation { get; set; } = "+";
    public int UpperBound { get; set;} = 1000;
    public string? Input {get; set;} = null;
}