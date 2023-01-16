using FluentAssertions;
using StringCalculator.Model;
using StringCalculator.ReversePolishNotation;

public class RPNParserTest
{
    [Theory]
    [ClassData(typeof(RPNParserTest_InputData))]
    public void Parse_MathematicalOperationsAsString_ValidRPNList(string input, List<IToken> expected)
    {
        //Arrange
        var rpnParser = new RPNParser();
        
        //Act
        var actual = rpnParser.Parse(input);

        //Assert
        actual.Should().BeEquivalentTo(expected);
    }
}