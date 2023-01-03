namespace MobilePhoneTextToKeysTests;

public class ConverterTest
{
    [Theory]
    [InlineData("CAT","22228")]
    [InlineData("HELLO THERE","4433555555666#8443377733")]
    public void ConvertTextToKeys_TextWithNoSpecialCharacters_ReturnsKeySequence(string text, string expectedKeySequence)
    {
        //Arrange
        var convertTextToKeys = new Converter();

        //Act
        var actualKeysPressedSequence = convertTextToKeys.ConvertTextToKeys(text);

        //Assert
        Assert.Equal(expected: expectedKeySequence, actual: actualKeysPressedSequence);
    }
}