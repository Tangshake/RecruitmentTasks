using StringCalculator.Model;

namespace StringCalculator.Model;

public class Operand : IToken
{
  public string Value { get; set; }
  public TokenType Type { get; } = TokenType.Operand;
}
