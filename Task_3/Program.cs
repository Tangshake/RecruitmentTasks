/* 
    Write a method that checks if given number (positive integer) contains digit 3.
    You cannot:
    - convert number to other type,
    - use built-in functions like Contains(), StartsWith(), etc.
*/

uint numberToCheck = 0124567892;
var result = Check(numberToCheck);
Console.WriteLine($"Result: {result}");

bool Check(uint number)
{
    while(number > 0)
    {
        if(number % 10 == 3 ? true : false)
            return true;
        else
            number /= 10;
    }

    return false;
}