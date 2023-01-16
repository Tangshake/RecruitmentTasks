using System.Collections;
using StringCalculator.Model;

public class RPNProcessorTest_InputData : IEnumerable<object[]>
{
    private readonly List<object[]> data = new List<object[]>() 
    {
        new object[] 
        {
            new List<IToken> {
                new Operand()   {Value = "2"},
                new Operand()   {Value = "3"},
                new Operator()  {Value = "+"}
            },
            5
        },
       
        new object[] 
        {
            new List<IToken> {
                new Operand()   {Value = "5"},
                new Operand()   {Value = "3"},
                new Operator()  {Value = "-"},
                new Operand()   {Value = "2"},
                new Operator()  {Value = "*"}
            },
            4
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