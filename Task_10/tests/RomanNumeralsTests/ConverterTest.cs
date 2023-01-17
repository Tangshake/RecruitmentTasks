namespace RomanNumeralsTests;

public class ConverterTest
{
    [Fact]
    public void ConvertToRoman_IntegerNumber_ShouldReturnValidRomanNumeralString()
    {
        //Arrange
        var converter = new Converter();
        var input = 10;
        var expected = "X";

        //Act
        var actual = converter.ConvertToRoman(input);

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