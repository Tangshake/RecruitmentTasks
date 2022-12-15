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

FizzBuzz();
HandsOfClockAngle(time: null);

var m3_result = HandsOfClockAngle(DateTime.Parse("12:15"));
Console.WriteLine($"Angle between clock hands: {m3_result}°");

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

/// <summary>
/// Write Fizz when number is divisible by 3, Buzz when by 5 and FizzBuzz when number is divisible by 15
/// </summary>
void FizzBuzz()
{
    Console.WriteLine($"Hi! My name is {nameof(FizzBuzz)}. Game result: ");
    
    for(int i=1; i <= 100; i++)
    {
        if(i % 3 == 0 && i % 5 == 0)
            Console.WriteLine($"[{i}] FizzBuzz");
        if(i % 3 == 0)
            Console.WriteLine($"[{i}] Fizz");
        else if (i % 5 == 0)
            Console.WriteLine($"[{i}] Buzz");
        else
            Console.WriteLine($"[{i}]");
    }
}

/// <summary>
/// Find angle between hands of clock. 
/// </summary>
/// <param name="time">The <see cref="System.DateTime"/> represents time. When null current time is used.</param>
/// <returns>Angle in degrees</returns>
double HandsOfClockAngle(DateTime? time)
{
    if(time is null) time = DateTime.Now;
    Console.WriteLine($"Hi! My name is {nameof(Factorial)}. I am going to calculate the angle between hands of a clock based on time. Time is: {time.Value.ToString("HH:mm")} "); //nameof(method) c#6

    var hour = time.Value.Hour;
    var minute = time.Value.Minute;

    //Every hour = 30 degrees, every minut = 6 degrees 
    double minuteDegrees = minute * 6;
    double hourDegrees = hour * 30 + (minute * 30.0) / 60.0;
    
    double angle = Math.Abs(hourDegrees - minuteDegrees);
    if(angle > 180) angle = 360 - angle; 
    
    return angle;
}