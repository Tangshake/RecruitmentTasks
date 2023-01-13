public class CalculatorTest
{
    [Theory]
    [InlineData("2+3",5)]
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