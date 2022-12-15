/*
    Tangshake
    Very Simple recruitment questions
    Topic: Strings
*/
using System;

var m1_result = FactorialWithRecurency(4);
Console.WriteLine($"Factorial number (recurency): {m1_result}");

var m2_result = FactorialWithRecurency(4);
Console.WriteLine($"Factorial number: {m2_result}");

/// <summary>
/// Calculate factorial from given natural number using recurency
/// </summary>
/// <param name="value">The <see cref="System.UInt32"/> represents the factorial number.</param>
/// <returns>Factorial number</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="value"/> is <c>null or empty</c>.
/// </exception>
uint FactorialWithRecurency(uint value)
{
    //Console.WriteLine($"Hi! My name is {nameof(Factorial)}. I am going to calculate factorial number using recurency."); //nameof(method) c#6
    return value == 0 ? 1 : value * FactorialWithRecurency(value - 1);
}

/// <summary>
/// Calculate factorial from given natural number without using recurency
/// </summary>
/// <param name="value">The <see cref="System.UInt32"/> represents the factorial number.</param>
/// <returns>Factorial number</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="value"/> is <c>null or empty</c>.
/// </exception>
uint Factorial(uint value)
{
    Console.WriteLine($"Hi! My name is {nameof(Factorial)}. I am going to calculate factorial number."); //nameof(method) c#6
    var factorial = value;

    for(uint i=value; i > 0; i--)
    {
        factorial *= i;
    }

    return factorial;
}
