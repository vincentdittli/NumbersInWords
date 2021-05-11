namespace NumbersInWords
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    public class NumbersInWords
    {
        private readonly Dictionary<int, string> tensNumberWords = new Dictionary<int, string>()
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

        private readonly Dictionary<int, string> upToTwentyNumberWords = new Dictionary<int, string>()
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
            {6, "Million"}
        };

        public string Convert(int number)
        {
            string numberWord = "";

            List<int> numbers = SplitNumberInExponent(number);

            foreach (KeyValuePair<int, string> powerOfThreeNumberWord in this.powerOfThreeNumberWords.Reverse())
            {
                if (numbers.Count <= powerOfThreeNumberWord.Key) { continue; }

                numberWord += this.StringifyNumbersUpToThousand(numbers.Skip(powerOfThreeNumberWord.Key).ToList());
                numberWord += powerOfThreeNumberWord.Value;
            }

            numberWord += this.StringifyNumbersUpToThousand(numbers);

            return numberWord;
        }

        private static List<int> SplitNumberInExponent2(int number)
        {
            string s = number.ToString();
            int[] value = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                value[i] = (s[i] - 48);
            }

            return new List<int>(value);
        }

        public string SpeedTest()
        {
            Stopwatch sw = new Stopwatch();
            string result = "";

            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                SplitNumberInExponent(10000002);
            }
            sw.Stop();
            result += $"SplitNumberInExponent {sw.ElapsedMilliseconds} ms\r\n";

            sw.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                SplitNumberInExponent2(10000002);
            }
            sw.Stop();
            result += $"SplitNumberInExponent2 {sw.ElapsedMilliseconds} ms\r\n";

            return result;
        }

        private static List<int> SplitNumberInExponent(int number)
        {
            List<int> numbers = new List<int>();

            int exponent = 1;

            for (int i = 0; i < number.ToString().Length; i++)
            {
                numbers.Add(number / exponent % 10);
                exponent *= 10;
            }

            return numbers;
        }

        private string StringifyNumbersUpToThousand(IReadOnlyList<int> numbers)
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