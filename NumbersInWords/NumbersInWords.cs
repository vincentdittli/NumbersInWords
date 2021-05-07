namespace NumbersInWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumbersInWords
    {
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

            if (numbers.Count < 4)
            {
                return this.GetUpToThousandWord(numbers);
            }

            if (numbers.Count < 7)
            {
                numberWord = this.GetUpToThousandWord(numbers.Skip(3).ToList());
                numberWord += "Thousand";
                numberWord += this.GetUpToThousandWord(numbers);
            }

            return numberWord;
        }

        private string GetUpToThousandWord(IReadOnlyList<int> numbers)
        {
            string numberWord = "";

            if (numbers.Count > 2 && numbers[2] > 0)
            {
                numberWord += this.GetNumberUpToTwentyWord(numbers[2]);
                numberWord += "Hundred";
            }

            if (numbers.Count > 1 && numbers[1] > 1)
            {
                numberWord += this.GetTenthNumberWord(numbers[1]);
            }
            else if (numbers.Count > 1 && numbers[1] > 0)
            {
                numberWord += this.GetNumberUpToTwentyWord(10 + numbers[0]);
                return numberWord;
            }

            if (numbers.Count > 0 && numbers[0] > 0)
            {
                numberWord += this.GetNumberUpToTwentyWord(numbers[0]);
            }

            return numberWord;
        }

        private string GetTenthNumberWord(int tenthDigit)
        {
            switch (tenthDigit)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
                default: throw new Exception("Invalid Number");
            }
        }

        private string GetNumberUpToTwentyWord(int number)
        {
            switch (number)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
                default: return "";
            }
        }
    }
}
