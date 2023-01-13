using StringCalculator.Interfaces.Token;
using StringCalculator.Model;

namespace StringCalculator.ReversePolishNotation;

public class RPNProcessor
{
    private List<IToken> stack = new List<IToken>(); //FIFO

    public double Process(List<IToken> operations)
    {
        stack.Clear();
        foreach (var item in operations)
        {
            PorcessSingleRPNToken(item);
        }

        return double.Parse(stack[0].Value);
    }

    private void PorcessSingleRPNToken(IToken token)
    {
        switch (token)
        {
            case Operand:
                stack.Add(token);
                break;
            case Operator:
                var op1 = stack.ElementAt(stack.Count - 1);
                var op2 = stack.ElementAt(stack.Count - 2);
                var math = DoMath(op1, op2, token);
                stack.RemoveRange(stack.Count - 2, 2);
                stack.Add(math);
                break;
        }
    }

    private IToken DoMath(IToken t1, IToken t2, IToken oper)
    {
        switch (oper.Value)
        {
            case "+": return new Operand() { Value = (double.Parse(t2.Value) + double.Parse(t1.Value)).ToString() };
            case "-": return new Operand() { Value = (double.Parse(t2.Value) - double.Parse(t1.Value)).ToString() };
            case "*": return new Operand() { Value = (double.Parse(t2.Value) * double.Parse(t1.Value)).ToString() };
            case "/": return new Operand() { Value = (double.Parse(t2.Value) / double.Parse(t1.Value)).ToString() };
            case "^": return new Operand() { Value = Math.Pow(double.Parse(t2.Value), double.Parse(t1.Value)).ToString() };
            default: return new Operand() { Value = (double.MinValue).ToString() };
        }
    }
}