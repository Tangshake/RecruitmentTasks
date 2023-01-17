using System.Text;
using System.Text.RegularExpressions;

public class Converter : IConverter
{
    int[] array = new int[] { 1000, 500, 100, 50, 10, 5, 1 };
    char[] symbols = new char[] {'M', 'D', 'C', 'L', 'X', 'V', 'I'};
    Regex reg = new Regex(@"[^IVXLCDM]");

    public string ConvertToRoman(int input)
    {
        if(input <=0 || input >= 4000)
            throw new ArgumentException("Input number should be > 0 and < 4000");
        
        int tmp = input;
        StringBuilder sb = new StringBuilder();
        
        for(int i=0; i < array.Length; i++)
        {
            tmp = input / array[i];
            Console.WriteLine($"[{i}] arr:{array[i]} tmp:{tmp} numb:{input}");
            if(tmp == 0)
                continue;
            
            if(i+1 < array.Length && (input - tmp * array[i]) / (array[i+1]) == 4)
            {
                Console.WriteLine($"{symbols[i+1]}{symbols[i-1]}");
                sb.Append(symbols[i+1]).Append(symbols[i-1]);
                input = input - (array[i-1] - array[i+1]);
            }
            else
            {
                if(tmp == 4)
                {
                    sb.Append(symbols[i]).Append(symbols[i-1]);
                    Console.WriteLine($"{symbols[i]}{symbols[i-1]}");
                    input = input - tmp * array[i];
                }
                else
                {
                    Console.WriteLine($"{new string(symbols[i], tmp)}");
                    sb.Append(new string(symbols[i], tmp));
                    input = input - tmp * array[i];
                }
            }
            
            Console.WriteLine("");
        }
        

        return sb.ToString();
    }

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