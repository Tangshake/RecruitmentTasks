using FirstLowerNumber.Alghorithm;

namespace FirstLowerNumberTests;

public class LowerNumberAlgTest
{
    [Theory]
    [InlineData(503, 350)]
    [InlineData(1234567908, 1234567890)]
    public void FindFirstLowerNumber_LongNumber_ReturnsLowerNumber(long number, long expectedNumber)
    {
        //Arrange
        var alghoritm = new LowerNumberAlg();

        //Act
        var actualNumber = alghoritm.FindFirstLowerNumber(number);
        
        //Assert
        Assert.Equal(expected: expectedNumber, actual: actualNumber);
    }

    [Theory]
    [InlineData(0, -1)]
    [InlineData(123, -1)]
    [InlineData(1027, -1)]
    public void FindFirstLowerNumber_LongNumber_ReturnsNotFound(long number, long expectedNumber)
    {
        //Arrange
        var alghoritm = new LowerNumberAlg();

        //Act
        var actualNumber = alghoritm.FindFirstLowerNumber(number);
        
        //Assert
        Assert.Equal(expected: expectedNumber, actual: actualNumber);
    }
}