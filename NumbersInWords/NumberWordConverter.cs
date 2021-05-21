namespace NumbersInWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class NumberWordConverter
    {
        private static readonly IReadOnlyDictionary<int, string> PowerOfThreeNumberWords = new Dictionary<int, string>
        {
            {0, ""},
            {3, "Thousand"},
            {6, "Million"},
            {9, "Billion"},
            {12, "Trillion"}
        };

        private static readonly IReadOnlyDictionary<long, string> TensNumberWords = new Dictionary<long, string>
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

        private static readonly IReadOnlyDictionary<long, string> UpToTwentyNumberWords = new Dictionary<long, string>
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

        private static IReadOnlyDictionary<string, long> NumberWordsUpToThousand { get; }

        static NumberWordConverter()
        {
            NumberWordsUpToThousand = GenerateNumberWordsUpToThousand();
        }

        public string Convert(long number)
        {
            return ConvertInternal(number);
        }

        public long Convert(string numberWord)
        {
            string[] numberWordPowerOfThreeArray = SplitNumberWordInPowerOfThree(numberWord);
            
            return numberWordPowerOfThreeArray
                .Reverse()
                .Select((numberWordInPowerOfThree, i) 
                    => NumberWordsUpToThousand[numberWordInPowerOfThree] * System.Convert.ToInt64(Math.Pow(10, i * 3)))
                .Sum();
        }

        private static string ConvertInternal(long number)
        {
            StringBuilder numberWordStringBuilder = new StringBuilder();

            List<long> numbers = SplitNumberInExponent(number);

            foreach (KeyValuePair<int, string> powerOfThreeNumberWord in PowerOfThreeNumberWords.Reverse())
            {
                if (numbers.Count <= powerOfThreeNumberWord.Key) { continue; }

                numberWordStringBuilder.Append(StringifyNumbersUpToThousand(numbers.Skip(powerOfThreeNumberWord.Key).ToList()));
                numberWordStringBuilder.Append(powerOfThreeNumberWord.Value);
            }

            return numberWordStringBuilder.ToString();
        }

        private static Dictionary<string, long> GenerateNumberWordsUpToThousand()
        {
            Dictionary<string, long> numberWordsUpToThousand = new Dictionary<string, long>();

            for (int i = 0; i < 1000; i++)
            {
                string tempNumberWord = ConvertInternal(i);
                numberWordsUpToThousand.Add(tempNumberWord, i);
            }

            return numberWordsUpToThousand;
        }

        private static string StringifyNumbersUpToThousand(IReadOnlyList<long> numbers)
        {
            StringBuilder numberWordStringBuilder = new StringBuilder();

            if (numbers.Count > 2 && numbers[2] > 0)
            {
                numberWordStringBuilder.Append(UpToTwentyNumberWords[numbers[2]]);
                numberWordStringBuilder.Append(TensNumberWords[10]);
            }

            if (numbers.Count > 1)
            {
                if (numbers[1] > 1)
                {
                    numberWordStringBuilder.Append(TensNumberWords[numbers[1]]);
                }
                else if (numbers[1] > 0)
                {
                    numberWordStringBuilder.Append(UpToTwentyNumberWords[10 + numbers[0]]);
                    return numberWordStringBuilder.ToString();
                } 
            }

            if (numbers.Count > 0 && numbers[0] > 0)
            {
                numberWordStringBuilder.Append(UpToTwentyNumberWords[numbers[0]]);
            }

            return numberWordStringBuilder.ToString();
        }

        private static string[] SplitNumberWordInPowerOfThree(string numberWord)
        {
            return numberWord.Split(PowerOfThreeNumberWords.Values.ToArray(), StringSplitOptions.None);
        }

        private static List<long> SplitNumberInExponent(long number)
        {
            return number.ToString().Select(c => long.Parse(c.ToString())).Reverse().ToList();
        }
    }
}