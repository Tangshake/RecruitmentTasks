using StringCalculator.ReversePolishNotation;

public class Calculator
{
    RPNParser rpnParser = new RPNParser();
    RPNProcessor rpnProcessor = new RPNProcessor();

    public double Calculate(string input)
    {
        var rpnTokens = rpnParser.Parse(input);
        var mathResult = rpnProcessor.Process(rpnTokens);

        return mathResult;
    }
}
