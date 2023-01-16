using StringCalculator.Model;

namespace StringCalculator.Model;

public class Operator : IToken
{
    public string Value { get; set; }
    public TokenType Type { get; } = TokenType.Operator;
}