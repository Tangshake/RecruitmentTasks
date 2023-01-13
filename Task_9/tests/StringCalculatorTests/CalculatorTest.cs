public class CalculatorTest
{
    [Theory]
    [InlineData("2+3",5)]
    [InlineData("3 * (4 +       (2 / 3) * 6 - 5)",9)]
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
}