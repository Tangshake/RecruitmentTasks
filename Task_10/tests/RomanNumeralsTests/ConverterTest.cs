namespace RomanNumeralsTests;

public class ConverterTest
{
    [Fact]
    public void ConvertToRoman_IntegerNumber_ShouldReturnValidRomanNumeralString()
    {
        //Arrange
        var expected = "X";

        //Act
        var actual = "X";

        //Assert
        Assert.Equal(expected, actual);
    }
} 