using System.Collections;
using StringCalculator.Model;

public class RPNParserTest_InputData : IEnumerable<object[]>
{
    public readonly List<object[]> data = new List<object[]>()
    {
        new object[] {
            "2+3",
            new List<IToken>() {
                new Operand() { Value = "2"},
                new Operand() { Value = "3"},
                new Operator() { Value = "+"},
            }
        },
        new object[] 
        {
            "(5-3)*2",
            new List<IToken> {
                new Operand()   {Value = "5"},
                new Operand()   {Value = "3"},
                new Operator()  {Value = "-"},
                new Operand()   {Value = "2"},
                new Operator()  {Value = "*"}
            }
        }
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        return data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}