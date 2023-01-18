using System.Text;
using System.Text.RegularExpressions;

public class Converter : IConverter
{
    int[] array = new int[] { 1000, 500, 100, 50, 10, 5, 1 };
    char[] symbols = new char[] {'M', 'D', 'C', 'L', 'X', 'V', 'I'};
    Regex reg = new Regex(@"[^IVXLCDM]");
    StringBuilder sb = new StringBuilder();


    /// <summary>
    /// Convert Roman Numeral string to int.
    /// </summary>
    /// <param name="input">Roman Numeral string</param>
    /// <exception cref="System.ArgumentException">Thrown when input value is 0 or below 0 or when input value is greater or equal 4000.</exception>
    /// <returns>int</returns>
    public string ConvertToRoman(int input)
    {
        if(input <=0 || input >= 4000)
            throw new ArgumentException("Input number should be > 0 and < 4000");

        sb.Clear();    
        int tmp = input;
        
        for(int i=0; i < array.Length; i++)
        {
            tmp = input / array[i];
            if(tmp == 0)
                continue;
            
            if(i+1 < array.Length && (input - tmp * array[i]) / (array[i+1]) == 4)
            {
                sb.Append(symbols[i+1]).Append(symbols[i-1]);
                input = input - (array[i-1] - array[i+1]);
            }
            else
            {
                if(tmp == 4)
                {
                    sb.Append(symbols[i]).Append(symbols[i-1]);
                }
                else
                {
                    sb.Append(new string(symbols[i], tmp));
                }
                
                input = input - tmp * array[i];
            }
        }

        return sb.ToString();
    }

    /// <summary>
    /// Convert int number to Roman Numeral string.
    /// </summary>
    /// <param name="input">Integer number between 0 and 4000</param>
    /// <exception cref="System.ArgumentException">Thrown when string is null, empty or contains illegal characters.</exception>
    /// <returns>Roman numeral string.</returns>
    public int ConvertFromRoman(string input)
    {
        if(string.IsNullOrEmpty(input) || reg.IsMatch(input))
            throw new ArgumentException();

        int result = 0;
        for(int i=0; i < input.Length; i++)
        {
            int idx1 = Array.IndexOf(symbols, input[i]);
            if(i+1 >= input.Length)
            {
                result += array[idx1];
                break;
            }
            
            int idx2 = Array.IndexOf(symbols, input[i+1]);

            if(array[idx1] >= array[idx2])
            {
                result += array[idx1];
            }
            else
            {
                result += (array[idx2] - array[idx1]);
                i++;
            }

        }

        return result;
    }
}