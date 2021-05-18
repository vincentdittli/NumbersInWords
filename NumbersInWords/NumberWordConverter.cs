namespace NumbersInWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NumberWordConverter
    {
        private readonly StringBuilder numberWordStringBuilder = new StringBuilder();

        private readonly Dictionary<int, string> powerOfThreeNumberWords = new Dictionary<int, string>
        {
            {0, ""},
            {3, "Thousand"},
            {6, "Million"},
            {9, "Billion"},
            {12, "Trillion"}
        };

        private readonly Dictionary<long, string> tensNumberWords = new Dictionary<long, string>
        {
            {2, "Twenty"},
            {3, "Thirty"},
            {4, "Forty"},
            {5, "Fifty"},
            {6, "Sixty"},
            {7, "Seventy"},
            {8, "Eighty"},
            {9, "Ninety"},
            {10, "Hundred"}
        };

        private readonly Dictionary<long, string> upToTwentyNumberWords = new Dictionary<long, string>
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
            {19, "Nineteen"}
        };

        public string Convert(long number)
        {
            List<long> numbers = SplitNumberInExponent(number);

            foreach (KeyValuePair<int, string> powerOfThreeNumberWord in this.powerOfThreeNumberWords.Reverse())
            {
                if (numbers.Count <= powerOfThreeNumberWord.Key) { continue; }

                this.StringifyNumbersUpToThousand(numbers.Skip(powerOfThreeNumberWord.Key).ToList());
                this.numberWordStringBuilder.Append(powerOfThreeNumberWord.Value);
            }

            return this.numberWordStringBuilder.ToString();
        }

        public long Convert(string numberWord)
        {
            IEnumerable<string> substrings = this.SplitNumberWordInPowerOfThree(numberWord);

            Dictionary<string, long> numberWordsUpToThousand = this.GenerateNumberWordsUpToThousand();

            long number = 0;

            long multiplicand = 1;

            foreach (string substring in substrings.Reverse())
            {
                number += numberWordsUpToThousand[substring] * multiplicand;
                multiplicand *= 1000;
            }

            return number;
        }

        private Dictionary<string, long> GenerateNumberWordsUpToThousand()
        {
            Dictionary<string, long> numberWordsUpToThousand = new Dictionary<string, long>();

            for (int i = 0; i < 1000; i++)
            {
                this.numberWordStringBuilder.Clear();
                string tempNumberWord = this.Convert(i);
                numberWordsUpToThousand.Add(tempNumberWord, i);
            }

            return numberWordsUpToThousand;
        }

        private void StringifyNumbersUpToThousand(IReadOnlyList<long> numbers)
        {
            if (numbers.Count > 2 && numbers[2] > 0)
            {
                this.numberWordStringBuilder.Append(this.upToTwentyNumberWords[numbers[2]]);
                this.numberWordStringBuilder.Append(this.tensNumberWords[10]);
            }

            if (numbers.Count > 1 && numbers[1] > 1)
            {
                this.numberWordStringBuilder.Append(this.tensNumberWords[numbers[1]]);
            }
            else if (numbers.Count > 1 && numbers[1] > 0)
            {
                this.numberWordStringBuilder.Append(this.upToTwentyNumberWords[10 + numbers[0]]);
                return;
            }

            if (numbers.Count > 0 && numbers[0] > 0)
            {
                this.numberWordStringBuilder.Append(this.upToTwentyNumberWords[numbers[0]]);
            }
        }

        private IEnumerable<string> SplitNumberWordInPowerOfThree(string numberWord)
        {
            return numberWord.Split(this.powerOfThreeNumberWords.Values.ToArray(), StringSplitOptions.None);
        }

        private static List<long> SplitNumberInExponent(long number)
        {
            return number.ToString().Select(c => long.Parse(c.ToString())).Reverse().ToList();
        }
    }
}