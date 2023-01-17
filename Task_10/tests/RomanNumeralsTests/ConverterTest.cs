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
} 