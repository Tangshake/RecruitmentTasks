using System.Text.RegularExpressions;

public class Converter : IConverter
{
    Regex reg = new Regex(@"[^IVXLCDM]");

    public string ConvertToRoman(int input)
    {
        if(input <=0 || input >= 4000)
            throw new ArgumentException("Input number should be > 0 and < 4000");

        return "X";
    }

    public int ConvertFromRoman(string input)
    {
        if(string.IsNullOrEmpty(input) || reg.IsMatch(input))
            throw new ArgumentException();

        return 0;
    }
}