/*
    Create a function that validates date between years: 2001-2099. 
    Input: three parameters (day, month, year)
    Output: false that indicates that date is invalid and true for valid date
    Design your own validation schema. You cannot use in-built tools like LocalDate, Calendar.
*/

/*
    Things to consider:
    - leap years. February has 29 days and it happens every four years,
    - different number of days in different months. 30 vs 31.
    
    Leap years: Every year that is divisible by 4 is a leap year also years that are divisible by 100 and 400 at the same time are also leap years.
    
    - number of days in a month depends on month,
    - month depends on a year. It is february that may be a leap year. Number of days in other months are constant and dont change.

*/

var isDateValid = ValidateDate(30,6,2032);
Console.WriteLine($"Date validation result: {isDateValid}");

/// <summary>
/// Validate provided date.
/// </summary>
/// <param name="day">The <see cref="System.Int32"/> represents the day of the month.</param>
/// <param name="month">The <see cref="System.Int32"/> represents the month of the year.</param>
/// <param name="year">The <see cref="System.Int32"/> represents the year.</param>
/// <returns>True if date is valid and false when invalid.</returns>
/// <exception cref="System.ArgumentException">
/// <paramref name="day"/> is <c></c>.
/// <paramref name="month"/> is <c></c>.
/// <paramref name="year"/> is <c></c>.
/// </exception>
bool ValidateDate(int day, int month, int year)
{
    if(day < 1 || day > 31 || month < 1 || month > 12 || year < 2001 || year > 2099)
        throw new System.ArgumentException("Provided parameters are not valid for this method.");
    
    //Get valid number of days in a month based on the year
    var validNumberOfDays = GetNumberOfDaysInAMonth(month, year);
    
    return day <= validNumberOfDays ? true : false;
}


/// <summary>
/// Get number of days in a month base on a year.
/// </summary>
/// <param name="month">The <see cref="System.Int32"/> represents the month of the year.</param>
/// <param name="year">The <see cref="System.Int32"/> represents the year.</param>
/// <returns>Number of days in a month.</returns>
int GetNumberOfDaysInAMonth(int month, int year)
{
    return month % 2 == 0 ? (
        month == 2 ? (
            IsThisYearALeapYear(year) ? 29 : 28
            ) : 30
        ) : 31;
}

/// <summary>
/// Check if provided year is a leap year.
/// </summary>
/// <param name="year">The <see cref="System.Int32"/> represents the year.</param>
/// <returns>True for leap year and false for regular one.</returns>
bool IsThisYearALeapYear(int year)
{
    return year % 4 == 0 ? (
            year % 100 == 0 ? (
                year % 400 == 0 ? true : false
            ) : true
        ) : false;
}