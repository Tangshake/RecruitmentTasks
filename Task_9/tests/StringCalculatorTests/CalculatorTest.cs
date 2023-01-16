public class CalculatorTest
{
    [Theory]
    [InlineData("2+3", 5)]
    [InlineData("2^5", 32)]
    [InlineData("3 * (4 +       (2 / 3) * 6 - 5)", 9)]
    [InlineData("123      -( 4^ (       3 -   1) * 8 - 8      /(     1 + 1 ) *(3 -1) )", 3)]
    public void Calculate_MathematicalOperationAsString_CalculatedResultShouldBeValid(string input, double expectedResult)
    {
        //Arrange
        var calculator = new Calculator();

        //Act
        var actualResult = calculator.Calculate(input);

        //Assert
        Assert.Equal(expected: expectedResult, actual: actualResult);
    }

    [Fact]
    public void Calculate_NullStringAsInput_ShouldThrowException()
    {
        //Arrange
        var calculator = new Calculator();

        //Act
        var exception = Record.Exception(() => calculator.Calculate(null));

        //Assert
        Assert.IsType(typeof(ArgumentNullException), exception);
        Assert.True(exception.Message.Contains("String cannot be null"));
    }

    [Theory]
    [InlineData("1+")]
    [InlineData("1")]
    [InlineData("12")]
    public void Calculate_TooShortStringAsInput_ShouldThrowException(string input)
    {
        //Arrange
        var calculator = new Calculator();

        //Act + Assert
        Assert.Throws<ArgumentException>(()=> calculator.Calculate(input));
    }

    [Theory]
    [InlineData("1.2*4(2-3)+1")]
    [InlineData("1A2")]
    [InlineData("=1+2")]
    [InlineData("1?2")]
    public void Calculate_StringContainingIllegalCharacters_ShouldThrowException(string input)
    {
        //Arrange
        var calculator = new Calculator();

        //Act + Assert
        Assert.Throws<ArgumentNullException>(()=> calculator.Calculate(null));
    }
}