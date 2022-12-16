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

var m4_result = FindMissingNumber(new int[] {1,2,0,3});
Console.WriteLine($"Is number: {m4_result} the missing element that you have been looking for?");

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

/// <summary>
/// Find the missing number in an arithmetic sequence that is stored in an array.
/// </summary>
/// <param name="numbers">The <see cref="System.Array"/> represents the array with integer numbers. Numbers are unique.</param>
/// <returns>Missing number</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="numbers"/>
/// </exception>
int FindMissingNumber(int[] numbers)
{
    //Basically we have an array of type int and size n. example:[0,3,1] (n=3)
    //Numbers stored in this array are unique. When sorted, numbers should create a sequence (part of it) of size n with one missing element. [0,1,3] (2 is missing)
    Console.WriteLine($"Hi! My name is {nameof(FindMissingNumber)}. I am going to find the missing number.");
    
    if(numbers is null || numbers.Length < 1 || numbers.Length < numbers.Max())
        throw new ArgumentException("Provided array is null, has not enough elements or numbers will not create an arithmetic sequence.");

    //Since its an arithmetic sequence easiest way to do it is to calculate sum of all elements in the array and substract it from the sum of arithmetic sequence stored in an array with lenght n+1. Result will be a missing element
    
    //Get max integer value from our input array
    var sum = numbers.Sum();

    //calculate arithemtic sequence of size n+1 [0,1,2,3] (n=4)
    //We take the first and the last element of the aritmhetic sequence and we sum it. Then we multiply it by number of elements in the sequence and divide it by 2. 
    var sum_big = ((0 + numbers.Length + 1) * numbers.Length) / 2;

    return sum_big - sum;
}