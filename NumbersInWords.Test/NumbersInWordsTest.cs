namespace NumbersInWords.Test
{
    using FluentAssertions;
    using Xunit;

    public class NumbersInWordsTest
    {
        [Theory]
        [InlineData(0,"Zero")]
        [InlineData(1,"One")]
        [InlineData(2,"Two")]
        [InlineData(3,"Three")]
        [InlineData(4,"Four")]
        [InlineData(5,"Five")]
        [InlineData(6,"Six")]
        [InlineData(7,"Seven")]
        [InlineData(8,"Eight")]
        [InlineData(9,"Nine")]
        public void ShouldReturnCorrectString(int input, string expected)
        {
            // Arrange
            NumbersInWords testee = new NumbersInWords();

            // Act
            string result = testee.Convert(input);

            // Assert
            result.Should().Be(expected);
        }
    }
}
