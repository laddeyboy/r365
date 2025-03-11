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
    public void ItShouldAddValidInputs()
    {
        givenInput("4,6,5");
        whenCallingCalculate();
        thenResultShouldBeCorrect(15);
    }

    [Test]
    public void ItShouldHandleInputWithNewlineDelimter()
    {
        givenInput("1\n2,3\n4\n5,6,7\n8\n9,10");
        whenCallingCalculate();
        thenResultShouldBeCorrect(55);
    }

    [Test]
    public void ItShouldThrowExceptionForNegativeNumbers()
    {
        givenInput("4,5,-5\n-7,3");
        whenCallingCalculate();
        thenArgumentOutOfRangeExceptionIsThrownWithValues();
    }

    [Test]
    public void ItShouldInvalidateNumbersGreaterThan1000()
    {
        givenInput("2,1001,6");
        whenCallingCalculate();
        thenResultShouldBeCorrect(8);
    }

    [Test]
    public void ItShouldHandleSingleCharacterCustomDelimiter()
    {
        givenInput("//#\n2#5");
        whenCallingCalculate();
        thenResultShouldBeCorrect(7);
    } 

    void givenInput(string src)
    {
        input = src;
    }
    void whenCallingCalculate()
    {
        try
        {
            result = StringCalculator.Calculate(input);
        }
        catch (Exception ex)
        {
            exception = ex;
        }
    }
    void thenResultShouldEqualZero()
    {
        Assert.That(result, Is.EqualTo(0));
    }
    void thenResultShouldBeCorrect(int num)
    {
        Assert.That(result, Is.EqualTo(num));
    }

    void thenArgumentOutOfRangeExceptionIsThrownWithValues()
    {
        Assert.That(exception!.Message, Does.Contain("-5, -7"));
    }
}