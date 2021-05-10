namespace NumbersInWords.Test
{
    using FluentAssertions;
    using Xunit;

    public class NumbersInWordsTest
    {
        [Theory]
        [InlineData(1,"One")]
        [InlineData(2,"Two")]
        [InlineData(3,"Three")]
        [InlineData(4,"Four")]
        [InlineData(5,"Five")]
        [InlineData(6,"Six")]
        [InlineData(7,"Seven")]
        [InlineData(8,"Eight")]
        [InlineData(9,"Nine")]
        [InlineData(10,"Ten")]
        [InlineData(11,"Eleven")]
        [InlineData(12,"Twelve")]
        [InlineData(13,"Thirteen")]
        [InlineData(14,"Fourteen")]
        [InlineData(15,"Fifteen")]
        [InlineData(16,"Sixteen")]
        [InlineData(17,"Seventeen")]
        [InlineData(18,"Eighteen")]
        [InlineData(19,"Nineteen")]
        [InlineData(20,"Twenty")]
        [InlineData(21,"TwentyOne")]
        [InlineData(29, "TwentyNine")]
        [InlineData(30, "Thirty")]
        [InlineData(31, "ThirtyOne")]
        [InlineData(40, "Forty")]
        [InlineData(42, "FortyTwo")]
        [InlineData(50, "Fifty")]
        [InlineData(53, "FiftyThree")]
        [InlineData(64, "SixtyFour")]
        [InlineData(99, "NinetyNine")]
        [InlineData(100, "OneHundred")]
        [InlineData(120, "OneHundredTwenty")]
        [InlineData(745, "SevenHundredFortyFive")]
        [InlineData(999, "NineHundredNinetyNine")]
        [InlineData(1000, "OneThousand")]
        [InlineData(1099, "OneThousandNinetyNine")]
        [InlineData(9999, "NineThousandNineHundredNinetyNine")]
        [InlineData(10000, "TenThousand")]
        [InlineData(14000, "FourteenThousand")]
        [InlineData(16521, "SixteenThousandFiveHundredTwentyOne")]
        [InlineData(20000, "TwentyThousand")]
        [InlineData(100000, "OneHundredThousand")]
        [InlineData(214565, "TwoHundredFourteenThousandFiveHundredSixtyFive")]
        [InlineData(1214565, "OneMillionTwoHundredFourteenThousandFiveHundredSixtyFive")]
        [InlineData(231214565, "TwoHundredThirtyOneMillionTwoHundredFourteenThousandFiveHundredSixtyFive")]
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
