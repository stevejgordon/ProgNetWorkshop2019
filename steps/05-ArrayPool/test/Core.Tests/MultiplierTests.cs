using Xunit;

namespace Core.Tests
{
    public class MultiplierTests
    {
        [Fact]
        public void PopulateMultiplesOfTwo_Should_PopulateArrayWithExpectedValues()
        {
            var array = new int[5];

            Multiplier.PopulateMultiplesOfTwo(array);

            Assert.Equal(2, array[0]);
            Assert.Equal(4, array[1]);
            Assert.Equal(6, array[2]);
            Assert.Equal(8, array[3]);
            Assert.Equal(10, array[4]);
        }
    }
}
