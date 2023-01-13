using StringCalculator.Interfaces.Token;
using StringCalculator.Model;

public class Operand : IToken
{
  public string Value { get; set; }
  public TokenType Type { get; } = TokenType.Operand;
}
