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
        givenNoInput();
        whenCallingCalculate();
        thenResultShouldEqualZero();
    }

    [Test]
    public void ItShouldThrowAnExceptionForMoreThanTwoInputs()
    {
        givenMoreThanTwoInputs();
        whenCallingCalculate();
        thenExceptionIsThrown();
    }

    [Test]
    public void ItShouldSubstituteZeroForInvalidInput()
    {
        givenInvalidInput(); // "5, tytyt"
        whenCallingCalculate();
        thenResultShouldBeCorrect(5);
    }

        [Test]
    public void ItShouldAddTwoValidInputs()
    {
        givenOnlyTwoValidInputs(); // "3,5"
        whenCallingCalculate();
        thenResultShouldBeCorrect(8);
    }

    void givenNoInput()
    {
        input = "";
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

    void givenMoreThanTwoInputs()
    {
        input = "2,3,4";
    }
    void thenExceptionIsThrown()
    {
        Assert.That(exception?.Message, Is.EqualTo("Input may only be two numbers!"));
    }

    void givenInvalidInput()
    {
        input = "5, tytyt";
    }
    void thenResultShouldBeCorrect(int num)
    {
        Assert.That(result, Is.EqualTo(num));
    }

    void givenOnlyTwoValidInputs()
    {
        input = "3,5";
    }
}