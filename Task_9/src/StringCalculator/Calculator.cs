using System.Text;
using System.Linq;
using StringCalculator.Interfaces.Token;
using StringCalculator.Model;

public class Calculator
{
    private List<IToken> output = new List<IToken>(); //FIFO
    private List<IToken> stack = new List<IToken>(); //LIFO
    private static Dictionary<string, int> operators = new Dictionary<string, int>()
    {
        {"-",0},
        {"+",0},
        {"/",1},
        {"*",1},
        {"^",2},
        {"(",3},
        {")",3}
    };
    
    public double Calculate(string input)
    {
        Console.WriteLine($"INPUT STRING TRIMMED: {input}");
        output.Clear();
        stack.Clear();
        input = input.Trim().Replace(" ","");
        StringBuilder sb = new StringBuilder();
        foreach(var ch in input)
        {
            if(operators.ContainsKey(ch.ToString()))
            {
                if(sb.Length > 0 )
                Push(new Operand() { Value = sb.ToString() });

                Push(new Operator() { Value = ch.ToString() });
                sb.Clear();
            }
            else
            {
                sb.Append(ch);
            }
        }

        if(sb.Length > 0)
            Push(new Operand() { Value = sb.ToString() });

        stack.Reverse();
        output.AddRange(stack);
        stack.Clear();

        Evaluate(output);

        return double.Parse(stack.ElementAt(0).Value);
  }

  private void Push(IToken token)
  {
    Console.WriteLine($"PUSH: {token.Value}");

    if(token.Type == TokenType.Operand)
    {
      output.Add(token);
    }
    else if(token.Type == TokenType.Operator)
    {
      if(token.Value == ")")
      {
        var index = stack.Select((x,i)=> new {x, i}).Last(x=>x.x.Value.Equals("(")).i;
        var pop = Pop(index);

        pop.Reverse();

        output.AddRange(pop);
      }
      else if(token.Value != "(" && stack.Count > 0 && stack.ElementAt(stack.Count - 1).Value != "(" && operators[token.Value] <= operators[stack.ElementAt(stack.Count - 1).Value])
      {
        var temp = stack.ElementAt(stack.Count - 1);
        Console.WriteLine($"Swap: S:[{temp.Value}:{operators[stack.ElementAt(stack.Count - 1).Value]} <-> O:[{token.Value}:{operators[token.Value]}]");
        stack.RemoveAt(stack.Count - 1);
        stack.Add(token);
        output.Add(temp);
      }
      else 
        stack.Add(token);
    }

    PrintQueues();
  }

  private List<IToken> Pop(int index)
  {
    var result = stack.GetRange(index + 1, stack.Count - index - 1);

    Console.Write($"->[{index}] POP: ");
    foreach(var item in result)
      Console.Write($"\"{item.Value}\", ");
    Console.WriteLine("");

    stack.RemoveRange(index, stack.Count - index);
    return result;
  }

  private void Evaluate(List<IToken> operations)
  {
    foreach(var item in output)
    {
      EvaluatePush(item);
    }
  }

  private void EvaluatePush(IToken token)
  {
    switch(token.Type)
    {
      case TokenType.Operand: 
        stack.Add(token);
        PrintQueues();
        break;
      case TokenType.Operator: 
        var op1 = stack.ElementAt(stack.Count - 1);
        var op2 = stack.ElementAt(stack.Count - 2);
        var math = DoMath(op1, op2, token);
        stack.RemoveRange(stack.Count - 2, 2);
        stack.Add(math);

        PrintQueues();
        break;
    }
  }


  private IToken DoMath(IToken t1, IToken t2, IToken oper)
  {
    switch(oper.Value)
    {
      case "+": return new Operand(){ Value = (double.Parse(t2.Value) + double.Parse(t1.Value)).ToString()}; 
      case "-": return new Operand(){ Value = (double.Parse(t2.Value) - double.Parse(t1.Value)).ToString()};  
      case "*": return new Operand(){ Value = (double.Parse(t2.Value) * double.Parse(t1.Value)).ToString()};
      case "/": return new Operand(){ Value = (double.Parse(t2.Value) / double.Parse(t1.Value)).ToString()};  
      case "^": return new Operand(){ Value = Math.Pow(double.Parse(t2.Value),double.Parse(t1.Value)).ToString()};
      default: return new Operand(){ Value = (double.MinValue).ToString()};
    }
  }

  private void PrintQueues()
  {
    Console.Write("OUTPUT: [");
    foreach(var item in output)
      Console.Write($"\"{item.Value}\", ");
    
    Console.WriteLine("]");

    Console.Write("STACK: [");
    foreach(var item in stack)
      Console.Write($"\"{item.Value}\", ");
      Console.WriteLine("]"+Environment.NewLine);
  }
}
