using System.Text;
using StringCalculator.Model;

namespace StringCalculator.ReversePolishNotation;

public class RPNParser
{
    private const string LEFT_BRACKET = "(";
    private const string RIGHT_BRACKET = ")";

    private List<IToken> output = new List<IToken>(); //FIFO
    private List<IToken> stack = new List<IToken>(); //LIFO
    private Dictionary<string, int> operators = new Dictionary<string, int>()
    {
        {"-",0},
        {"+",0},
        {"/",1},
        {"*",1},
        {"^",2},
        {"(",3},
        {")",3}
    };

    StringBuilder buffer = new StringBuilder();
    
    public List<IToken> Parse(string input)
    {
        output.Clear();
        stack.Clear();
        input = input.Trim().Replace(" ","");

        foreach(var ch in input)
            ProcessSingleCharacter(ch);
        
        if (buffer.Length > 0)
            Push(new Operand() { Value = buffer.ToString() });

        stack.Reverse();
        output.AddRange(stack);
        stack.Clear();
        
        return output;
    }

    private void ProcessSingleCharacter(char ch)
    {
        if (IsCharacterAnOperator(ch))
        {
            if (buffer.Length > 0)
                Push(new Operand() { Value = buffer.ToString() });

            Push(new Operator() { Value = ch.ToString() });
            buffer.Clear();
        }
        else
        {
            buffer.Append(ch);
        }
    }

    private void Push(IToken token)
    {
        switch (token)
        {
            case Operand: PushOperand(token); break;
            case Operator: PushOperator(token); break;
        };
    }

    /// <summary>
    /// Add Operator of type IToken to the stack list.
    /// </summary>
    /// <param name="token">Operator of type IToken</param>
    private void PushOperator(IToken token)
    {
        if (token.Value.Equals(RIGHT_BRACKET))
        {
            var index = stack.Select((t, idx) => new { t, idx }).Last(x => x.t.Value.Equals(LEFT_BRACKET)).idx;
            var pop = Pop(index);

            pop.Reverse();

            output.AddRange(pop);
        }
        else if (!token.Value.Equals(LEFT_BRACKET) && stack.Count > 0 && !stack.ElementAt(stack.Count - 1).Value.Equals(LEFT_BRACKET) && operators[token.Value] <= operators[stack.ElementAt(stack.Count - 1).Value])
        {
            var temp = stack.ElementAt(stack.Count - 1);
            stack.RemoveAt(stack.Count - 1);
            stack.Add(token);
            output.Add(temp);
        }
        else
            stack.Add(token);
    }

    /// <summary>
    /// Add Operand of type IToken to the output list.
    /// </summary>
    /// <param name="token">Operator of type IToken</param>
    private void PushOperand(IToken token)
    {
        output.Add(token);
    }

    /// <summary>
    /// Take out one element from the list. Element is then removed from the list. 
    /// </summary>
    /// <param name="index">Index of the element.</param>
    /// <returns>Returns IToken element</returns>
    private List<IToken> Pop(int index)
    {
        var result = stack.GetRange(index + 1, stack.Count - index - 1);

        stack.RemoveRange(index, stack.Count - index);
        return result;
    }

    /// <summary>
    /// Check if provided character is an math operator.
    /// </summary>
    /// <param name="ch">Character to check</param>
    /// <returns>True if character matches defined one.</returns>
    private bool IsCharacterAnOperator(char ch)
    {
        return operators.ContainsKey(ch.ToString());
    }
}