using StringCalculator.Model;
using StringCalculator.ReversePolishNotation;

public class RPNProcessorTest
{
    [Theory]
    [ClassData(typeof(RPNProcessorTest_InputData))]
    public void Process_MathematicalOperationsAsRPNTokens_ValidCalculationResult(List<IToken> input, double expected)
    {
        //Arrange
        var rpnProcessor = new RPNProcessor();

        //Act
        var actual = rpnProcessor.Process(input);

        //Assert
        Assert.Equal(expected, actual);
    }
}