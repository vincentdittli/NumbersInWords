namespace NumbersInWords.Test
{
    using FluentAssertions;
    using Xunit;

    public class NumbersInWordsTest
    {
        [Fact]
        public void Number1ShouldBe_One()
        {
            // Arrange
            NumbersInWords testee = new NumbersInWords();

            // Act
            string result = testee.Convert(1);

            // Assert
            result.Should().Be("One");
        }

        [Fact]
        public void Number2ShouldBe_Two()
        {
            // Arrange
            NumbersInWords testee = new NumbersInWords();

            // Act
            string result = testee.Convert(2);

            // Assert
            result.Should().Be("Two");
        }
    }
}
