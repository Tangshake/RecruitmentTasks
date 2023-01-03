public class Converter
{
    static Dictionary<char, string> board = new Dictionary<char, string>(){
        {'1',""},
        {'2',"ABC"},
        {'3',"DEF"},
        {'4',"GHI"},
        {'5',"JKL"},
        {'6',"MNO"},
        {'7',"PQRS"},
        {'8',"TUV"},
        {'9',"WXYZ"},
        {'*',"*"},
        {'0',"0"},
        {'#'," #"}};

    /// <summary>
    /// Convert provided text to the key sequence, required to push, in order to get text.
    /// </summary>
    /// <param name="text">Text to convert</param>
    /// <returns>Numbers sequence as a string</returns>
    public string ConvertTextToKeys(string text)
    {
        var result = text
                  .Select(x=> new {letter = x, item = board.First(o=>o.Value.Contains(x))})
                  .Select(x=> new {numbers = new string(x.item.Key, x.item.Value.IndexOf(x.letter) + 1)})
                  .Select(x=> x.numbers);
        
        return string.Join("",result);
    }
}