
namespace FirstLowerNumber.Alghorithm;

public class LowerNumberAlg
{
    public long FindFirstLowerNumber(long number)
    {
        List<int> list = number.ToString().Select(x=> int.Parse(x.ToString())).ToList();

        var item1ToSwap = FindFirstSwapIndex(list);
        Console.WriteLine($"Item1: {item1ToSwap}");

        if(item1ToSwap == null)
            return -1; //Already lowest possible number

        var item2ToSwap = FindSecondSwapIndex(list, item1ToSwap.Value.Item1);
        Console.WriteLine($"Item1: {item2ToSwap}");

        if(item2ToSwap == null)
            return -1;

        if(!SwapElements(list, item1ToSwap.Value.Item1, item2ToSwap.Value.Item1))
            return -1;

        Console.WriteLine($"Swapped two numbers:{string.Join("",list)}");

        if(!SplitAndReverseElements(list, item1ToSwap.Value.Item1 + 1))
            return (-1);

        Console.WriteLine($"Splitted and reversed:{string.Join("",list)}");
        Console.WriteLine($"ResultString:{string.Join("",list)}");
        
        return long.Parse(string.Join("", list));
    }

    /// <summary>
    /// Looking for the Last number that meets the following assumption list[index-1] > list[index]. 
    /// <example> 2451 => (3,1), 2017 => null, 503 => (0,5) </example
    /// </summary>
    /// <param name="list">List of integers</param>
    /// <returns>Null or Tuple that contains index and number (int,int)?</returns>
    private (int,int)? FindFirstSwapIndex(List<int> list)
    {
        var result = list
                        .Select((n,i)=> new {num = n, index = i})
                        .LastOrDefault(x=> x.index > 0 && x.num < list[x.index - 1]);

        return result == null ? null : (result.index - 1, list[result.index - 1]);
    }
    
    /// <summary>
    /// Looking for the highest number on the list where: list[startIndex] > list[startIndex + 1]
    /// <example>2451 => (3,1), 503 => (2,3) </example
    /// </summary>
    /// <param name="list">List of integers</param>
    /// <param name="startIndex">Index of the reference number</param>
    /// <returns>Null or Tuple that contains index and number (int,int)?</returns>
    private (int,int)? FindSecondSwapIndex(List<int> list, int startIndex)
    {
        var result = list
                        .Select((n,i)=> new {num = n, index = i})
                        .Where(x=> x.index > startIndex && x.num < list[startIndex] && !(x.num == 0 && startIndex == 0))
                        .OrderByDescending(x=>x.num)
                        .FirstOrDefault();

        return result == null ? null : (result.index, result.num);
    }

    /// <summary>
    /// Swaps two elements on the list.
    /// </summary>
    /// <param name="list">List of integers</param>
    /// <param name="i1">First index to swap</param>
    /// <param name="i2">Second index to swap with</param>
    /// <returns>Bool value that indicates if swap succeeded or not</returns>
    private bool SwapElements(List<int> list, int i1, int i2)
    {
        if(list == null || list.Count < 2) return false;
        if(i1 < 0 || i1 > list.Count - 1) return false;
        if(i2 < 0 || i2 > list.Count - 1) return false;

        var temp = list[i1];
        list[i1] = list[i2];
        list[i2] = temp;

        return true;
    }

    /// <summary>
    /// Splits list at given index. Order right part Descending and rejoin with list at its end.
    /// <example> (<513>,1) => 5 13 => 5 31 => 531 </example
    /// </summary>
    /// <param name="list">List of integers</param>
    /// <param name="splitIndex">Index at which list will be splitted</param>
    /// <returns>Bool value that indicates if operation succeeded or not</returns>
    private bool SplitAndReverseElements(List<int> list, int splitIndex)
    {
        if(list == null || list.Count < 1) return false;
        if(splitIndex < 0 || splitIndex > list.Count - 1) return false;
        if(list.Count == 1) return true;

        var partToSwap = list
                            .Skip(splitIndex)
                            .Select(x=>x).ToList()
                            .OrderByDescending(x=>x);
        
        list.RemoveRange(splitIndex, list.Count - splitIndex);
        list.AddRange(partToSwap);

        return true;
    }
}