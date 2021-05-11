namespace NumbersInWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersInWords
    {
        private readonly Dictionary<long, string> tensNumberWords = new Dictionary<long, string>()
        {
            {2, "Twenty"},
            {3, "Thirty"},
            {4, "Forty"},
            {5, "Fifty"},
            {6, "Sixty"},
            {7, "Seventy"},
            {8, "Eighty"},
            {9, "Ninety"},
            {10, "Hundred"},
        };

        private readonly Dictionary<long, string> upToTwentyNumberWords = new Dictionary<long, string>()
        {
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
        };

        private readonly Dictionary<int, string> powerOfThreeNumberWords = new Dictionary<int, string>
        {
            {3, "Thousand"}, 
            {6, "Million"},
            {9, "Billion"},
        };

        public string Convert(long number)
        {
            string numberWord = "";

            List<long> numbers = SplitNumberInExponent(number);

            foreach (KeyValuePair<int, string> powerOfThreeNumberWord in this.powerOfThreeNumberWords.Reverse())
            {
                if (numbers.Count <= powerOfThreeNumberWord.Key) { continue; }

                numberWord += this.StringifyNumbersUpToThousand(numbers.Skip(powerOfThreeNumberWord.Key).ToList());
                numberWord += powerOfThreeNumberWord.Value;
            }

            numberWord += this.StringifyNumbersUpToThousand(numbers);

            return numberWord;
        }

        private static List<long> SplitNumberInExponent(long number)
        {
            return number.ToString().Select(c => long.Parse(c.ToString())).Reverse().ToList();
        }

        private string StringifyNumbersUpToThousand(IReadOnlyList<long> numbers)
        {
            string numberWord = "";

            if (numbers.Count > 2 && numbers[2] > 0)
            {
                numberWord += this.upToTwentyNumberWords[numbers[2]];
                numberWord += this.tensNumberWords[10];
            }

            if (numbers.Count > 1 && numbers[1] > 1)
            {
                numberWord += this.tensNumberWords[numbers[1]];
            }
            else if (numbers.Count > 1 && numbers[1] > 0)
            {
                numberWord += this.upToTwentyNumberWords[10 + numbers[0]];
                return numberWord;
            }

            if (numbers.Count > 0 && numbers[0] > 0)
            {
                numberWord += this.upToTwentyNumberWords[numbers[0]];
            }

            return numberWord;
        }
    }
}