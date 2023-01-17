namespace RomanNumeralsTests;

public class ConverterTest
{
    [Theory]
    [InlineData(10, "X")]
    [InlineData(999, "CMXCIX")]
    public void ConvertToRoman_IntegerNumber_ShouldReturnValidRomanNumeralString(int input, string expected)
    {
        //Arrange
        var converter = new Converter();

        //Act
        var actual = converter.ConvertToRoman(input);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("X", 10)]
    [InlineData("CMXCIX", 999)]
    public void ConvertFromRoman_RomanNumeralsAsString_ShouldReturnValidNumber(string input, int expected)
    {
        //Arrange
        var converter = new Converter();

        //Act
        var actual = converter.ConvertFromRoman(input);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4000)]
    public void ConvertToRoman_InvalidIntegerNumber_ShouldThrowAnException(int input)
    {
        //Arrange
        var converter = new Converter();

        //Act + Assert
        Assert.Throws<ArgumentException>(()=> converter.ConvertToRoman(input));
        
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("XxX")]
    public void ConvertFromRoman_InvalidInputString_ShouldThrowAnException(string input)
    {
        //Arrange
        var converter = new Converter();

        //Act + Assert
        Assert.Throws<ArgumentException>(()=> converter.ConvertFromRoman(input));
    }
} 