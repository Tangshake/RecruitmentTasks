namespace StringCalculator.Interfaces.Token;

public interface IToken
{
  TokenType Type { get; }
  string Value { get; set; }
}

public enum TokenType
{
    Operator,
    Operand
}