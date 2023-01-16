using System.Text.RegularExpressions;
using StringCalculator.ReversePolishNotation;

public class Calculator
{
    RPNParser rpnParser = new RPNParser();
    RPNProcessor rpnProcessor = new RPNProcessor();

    public double Calculate(string input)
    {
        if(string.IsNullOrEmpty(input))
            throw new ArgumentNullException("String cannot be null.");

        if(input.Length <= 2)
            throw new ArgumentException("String cannot be shorter than 3 characters");

        var regexItem = new Regex(@"^[0-9-+/*^() ]+$");
        if(!regexItem.IsMatch(input))
            throw new ArgumentException("String contains illegal characters.");

        var rpnTokens = rpnParser.Parse(input);
        var mathResult = rpnProcessor.Process(rpnTokens);

        return mathResult;
    }
}
