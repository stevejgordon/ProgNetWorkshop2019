using Xunit;

namespace Core.Tests
{
    public class KeyParserTests
    {
        [Theory]
        [InlineData("ThisContainsNoColons", 0)]
        [InlineData("This:Contains:TwoColons", 2)]
        [InlineData("This:Contains:A:Total:Of:Six:Colons", 6)]
        public void GetDelimiterCount_ReturnsCorrectCount(string input, int expected)
        {
            var sut = new KeyParser();

            var result = sut.GetDelimiterCount(input);

            Assert.Equal(expected, result);
        }
    }
}
