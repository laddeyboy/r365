namespace StringCalculatorTests;

[TestFixture]
public class StringCalculatorTests
{
    string? input = null;
    int? result = null;
    Exception? exception = null;
    int upperBound = 1000;
    bool allowNegative = false;
    string? customDelimiter = null;

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
        givenNegativeArgumentsAreNotAllow();
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

    [Test]
    public void ItShouldHandleCustomDelimiters()
    {
        givenInput("//[***]\n11***22***33");
        whenCallingCalculate();
        thenResultShouldBeCorrect(66);
    }

    [Test]
    public void ItShouldHandleMultipleCustomDelimiters()
    {
        givenInput("//[*][!!][r9r]\n11r9r22*hh*33!!44");
        whenCallingCalculate();
        thenResultShouldBeCorrect(110);
    }

    [Test]
    public void ItShouldHandleCustomeDelimiterArgument()
    {
        givenACustomDelimiterArgument("!");
        givenInput("1!2!3");
        whenCallingCalculate();
        thenResultShouldBeCorrect(6);
    }

    [Test]
    public void ItShouldHandleAllowNegativeArgument()
    {
        givenAllowNegativeArgument();
        givenInput("1,-2\n3");
        whenCallingCalculate();
        thenResultShouldBeCorrect(2);
    }

    public void ItShouldHandleCustomUpperBound()
    {
        givenCustomUpperBoundArgument();
        givenInput("1,900\n3");
        whenCallingCalculate();
        thenResultShouldBeCorrect(4);
    }

    void givenCustomUpperBoundArgument()
    {
        upperBound = 900;
    }
    void givenInput(string src)
    {
        input = src;
    }
    void givenACustomDelimiterArgument(string? cd)
    {
        customDelimiter = cd;
    }
    void givenAllowNegativeArgument()
    {
        allowNegative = true;
    }
    void givenNegativeArgumentsAreNotAllow()
    {
        allowNegative = false;
    }
    void whenCallingCalculate()
    {
        try
        {
            StringCalculator stringCalculator = new StringCalculator();
            result = stringCalculator.Calculate(input, upperBound, allowNegative, customDelimiter, null);
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