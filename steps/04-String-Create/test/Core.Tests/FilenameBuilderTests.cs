using System;
using Xunit;

namespace Core.Tests
{
    public class FilenameBuilderTests
    {
        [Fact]
        public void BuildFilename_ReturnsCorrectString()
        {
            var sut = new FilenameBuilder();

            var result = sut.BuildFilename(TestContext);

            Assert.Equal(Expected, result);
        }

        [Fact]
        public void BuildFilenameWithStringBuilder_ReturnsCorrectString()
        {
            var sut = new FilenameBuilder();

            var result = sut.BuildFilenameWithStringBuilder(TestContext);

            Assert.Equal(Expected, result);
        }

        [Fact]
        public void BuildFilenameWithStringCreate_ReturnsCorrectString()
        {
            var sut = new FilenameBuilder();

            var result = sut.BuildFilenameWithStringCreate(TestContext);

            Assert.Equal(Expected, result);
        }

        public DataContext TestContext => new DataContext
        {
            EventDateUtc = new DateTime(2019, 09,13, 10,00,00, DateTimeKind.Utc),
            Title = "ProgNet2019",
            Key = "WS"
        };

        public string Expected => "2019-09-13-10-PROGNET2019-WS.txt";
    }
}
