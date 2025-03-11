namespace StringCalculatorTests;

[TestFixture]
public class StringCalculatorTests
{
    string? input = null;
    int? result = null;

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

    [Test]
    public void ItShouldHandleInputWithNewlineDelimter()
    {
        givenInput("1\n2,3,4,\n5,6,7\n8\n,9,10\n11,12");
        whenCallingCalculate();
        thenResultShouldBeCorrect(78);
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