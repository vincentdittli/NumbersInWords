namespace NumbersInWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersInWords
    {
        private readonly Dictionary<int,string> tensNumberWords = new Dictionary<int, string>()
        {
            {2,"Twenty"},
            {3,"Thirty"},
            {4,"Forty"},
            {5,"Fifty"},
            {6,"Sixty"},
            {7,"Seventy"},
            {8,"Eighty"},
            {9,"Ninety"}
        };

        private readonly Dictionary<int, string> upToTwentyNumberWords = new Dictionary<int, string>()
        {
            {1,"One"},
            {2,"Two"},
            {3,"Three"},
            {4,"Four"},
            {5,"Five"},
            {6,"Six"},
            {7,"Seven"},
            {8,"Eight"},
            {9,"Nine"},
            {10,"Ten"},
            {11,"Eleven"},
            {12,"Twelve"},
            {13,"Thirteen"},
            {14,"Fourteen"},
            {15,"Fifteen"},
            {16,"Sixteen"},
            {17,"Seventeen"},
            {18,"Eighteen"},
            {19,"Nineteen"},
        };

        public string Convert(int number)
        {

            string numberWord = "";

            List<int> numbers = new List<int>();
            int exponent = 1;

            for (int i = 0; i < number.ToString().Length; i++)
            {
                numbers.Add(number / exponent % 10);
                exponent *= 10;
            }

            if (numbers.Count > 6)
            {
                numberWord += this.StringifyNumbersUpToThousand(numbers.Skip(6).ToList());
                numberWord += "Million";
            }

            if (numbers.Count > 3)
            {
                numberWord += this.StringifyNumbersUpToThousand(numbers.Skip(3).ToList());
                numberWord += "Thousand";
            }

            numberWord += this.StringifyNumbersUpToThousand(numbers);
            
            return numberWord;
        }

        private string StringifyNumbersUpToThousand(IReadOnlyList<int> numbers)
        {
            string numberWord = "";

            if (numbers.Count > 2 && numbers[2] > 0)
            {
                numberWord += this.upToTwentyNumberWords[numbers[2]];
                numberWord += "Hundred";
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
