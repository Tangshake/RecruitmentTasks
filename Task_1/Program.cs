/*
    Tangshake
    Very Simple recruitment questions
    Topic: Strings
*/
using System;

var m1_result = ReverseMethod1("Hello");
Console.WriteLine($"Result: {m1_result}");

var m2_result = ReverseMethod2("Hello");
Console.WriteLine($"Result: {m2_result}");

var m3_result = IsStringAPalindrome("Kajak", ignoreCase: true);
Console.WriteLine($"Result: {m3_result}");

var m4_result = CountEachLetter("Kajak");
PrintDictionaryContent(m4_result);

#region String manipulation
/// <summary>
/// Reverse provided string.
/// </summary>
/// <param name="text">The <see cref="System.String"/> represents the string to be reversed.</param>
/// <returns>Reversed string</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="text"/> is <c>null or empty</c>.
/// </exception>
string ReverseMethod1(string text)
{
    Console.WriteLine($"Hi! My name is {nameof(ReverseMethod1)}. Am gonna reverse your string."); //nameof(method) c#6

    //Let's check if given string is not empty or null
    if(string.IsNullOrEmpty(text))
        throw new ArgumentException("Provided string is null or empty");

    var arr = text.Reverse().ToArray();

    return new string(arr);
}

/// <summary>
/// Reverse provided string.
/// </summary>
/// <param name="text">The <see cref="System.String"/> represents the string to be reversed.</param>
/// <returns>Reversed string</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="text"/> is <c>null or empty</c>.
/// </exception>
string ReverseMethod2(string text)
{
    Console.WriteLine($"Hi! My name is {nameof(ReverseMethod2)}. Am gonna reverse your string."); //nameof(method) c#6

    //Let's check if given string is not empty or null
    if(string.IsNullOrEmpty(text))
        throw new ArgumentException("Provided string is null or empty");

    //Array thats gonna contain each character of reversed string. Length of the array is the same as the length of the input string.
    var arr = new char[text.Length];

    //Iterate over each character of the string in the reverse order and write it to the array
    for(int i=text.Length - 1; i >= 0; i--)
    {
        arr[text.Length - 1 - i] = text[i];
    }

    return new string(arr);
}

/// <summary>
/// Check if string is a palindrome.
/// </summary>
/// <param name="text">The <see cref="System.String"/> represents the string to checked.</param>
/// <param name="ignoreCase">The <see cref="System.Boolean"/> flag used to ignore case while checking.</param>
/// <returns>Result of compare: true or false</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="text"/> is <c>null or empty</c>.
/// </exception>
bool IsStringAPalindrome(string text, bool ignoreCase)
{
    Console.WriteLine($"Hi! My name is {nameof(IsStringAPalindrome)}. Am gonna check if your string \"{text}\" reads the same backwards as forwards."); //nameof(method) c#6

    //Let's check if given string is not empty or null
    if(string.IsNullOrEmpty(text))
        throw new ArgumentException("Provided string is null or empty");

    //if ignoreCase flag is true lets convert string so it has no upper character. Otherwise do not change anything
    text = ignoreCase ? text.ToLower() : text;

    var reversed = new string(text.Reverse().ToArray());

    return reversed.Equals(text) ? true : false;
}

/// <summary>
/// Counts occurence of each letter in the provided text.
/// </summary>
/// <param name="text">The <see cref="System.String"/> represents the string to process.</param>
/// <returns><b>Dictionary<b>with <char,count> pairs.</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="text"/> is <c>null or empty</c>.
/// </exception>
Dictionary<char,int> CountEachLetter(string text)
{
     Console.WriteLine($"Hi! My name is {nameof(IsStringAPalindrome)}. Let me count occurence of each letter in the given text: \"{text}\" "); //nameof(method) c#6

    //Let's check if given string is not empty or null
    if(string.IsNullOrEmpty(text))
        throw new ArgumentException("Provided string is null or empty");

    Dictionary<char,int> dict = new Dictionary<char, int>();

    //Iterate through all characters in the text. Add to the dictionary each letter with initial value of 1. When letter already exists in the dictionary increase its value by 1.
    foreach(char ch in text)
        if(dict.ContainsKey(ch))
            dict[ch]++;
        else
            dict.Add(ch,1);
    
    return dict;
}


/// <summary>
/// Print to the console contnent of the dictionary.
/// </summary>
/// <param name="dict">The <see cref="System.Collections.Generic.Dictionary<char,string>"/> represents set of data to be printed to the console.</param>
/// <returns><b>Dictionary<b>with <char,count> pairs.</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="dict"/> is <c>null</c>.
/// </exception>
void PrintDictionaryContent(Dictionary<char, int> dict)
{
        //Let's check if dictionary is not null
    if(dict is null)
        throw new ArgumentException("Dictionary can't be null.");

   foreach (var keyValuePair in dict)
   {
      Console.WriteLine($"Character:{keyValuePair.Key} Count: {keyValuePair.Value}");
   }
}

#endregion