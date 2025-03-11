namespace StringCalculatorTests;

[TestFixture]
public class StringCalculatorTests
{
    string? input = null;
    int? result = null;
    Exception? exception = null;

    [Test]
    public void ItShouldReturnZeroForNoInput()
    {
        givenInput("");
        whenCallingCalculate();
        thenResultShouldEqualZero();
    }

    [Test]
    public void ItShouldSubstituteZeroForInvalidInput()
    {
        givenInput("5, tytyt");
        whenCallingCalculate();
        thenResultShouldBeCorrect(5);
    }

    [Test]
    public void IsShouldWorkForNegativeInputs()
    {
        givenInput("4, -3");
        whenCallingCalculate();
        thenResultShouldBeCorrect(1);
    }

    [Test]
    public void ItShouldAddValidInputs()
    {
        givenInput("4,6,5");
        whenCallingCalculate();
        thenResultShouldBeCorrect(15);
    }

    void givenInput(string src)
    {
        input = src;
    }
    void whenCallingCalculate()
    {
        result = StringCalculator.Calculate(input);
    }
    void thenResultShouldEqualZero()
    {
        Assert.That(result, Is.EqualTo(0));
    }
    void thenResultShouldBeCorrect(int num)
    {
        Assert.That(result, Is.EqualTo(num));
    }
}