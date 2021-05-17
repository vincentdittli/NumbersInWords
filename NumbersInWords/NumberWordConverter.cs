namespace NumbersInWords
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NumberWordConverter
    {
        private readonly StringBuilder numberWordStringBuilder = new StringBuilder();

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
            {12, "Trillion"},
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

            this.StringifyNumbersUpToThousand(numbers);

            return this.numberWordStringBuilder.ToString();
        }

        public long Convert(string numberWord)
        {
            Dictionary<long, string> numberWordsUpToThousand = new Dictionary<long, string>();

            for (int i = 0; i < 1000; i++)
            {
                this.numberWordStringBuilder.Clear();
                string tempNumberWord = this.Convert(i);
                numberWordsUpToThousand.Add(i,tempNumberWord);
            }
            return numberWordsUpToThousand.First(n => n.Value == numberWord).Key;
        }

        private static List<long> SplitNumberInExponent(long number)
        {
            return number.ToString().Select(c => long.Parse(c.ToString())).Reverse().ToList();
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
    }
}