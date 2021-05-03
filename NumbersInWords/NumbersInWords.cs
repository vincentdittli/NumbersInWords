namespace NumbersInWords
{
    using System;

    public class NumbersInWords
    {
        public string Convert(int number)
        {

            string numberWord = "";

            int singleNumber = Math.Abs(number / 1 % 10);

            int tenthDigit = Math.Abs(number / 10 % 10);

            int hundredDigit = Math.Abs(number / 100 % 10);

            int thousandDigit = Math.Abs(number / 1000 % 10);

            if (thousandDigit > 0)
            {
                numberWord = this.GetNumberUpToTwentyWord(thousandDigit);
                numberWord += "Thousand";
            }

            if (hundredDigit > 0)
            {
                numberWord += this.GetNumberUpToTwentyWord(hundredDigit);
                numberWord += "Hundred";
            }

            if (tenthDigit > 1)
            {
                numberWord += this.GetTenthNumberWord(tenthDigit);
            }
            else if(tenthDigit > 0)
            {
                numberWord += this.GetNumberUpToTwentyWord(10 + singleNumber);
                return numberWord;
            }

            if (singleNumber > 0)
            {
                numberWord += this.GetNumberUpToTwentyWord(singleNumber);
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
                default: throw new Exception("Invalid Number");
            }
        }
    }
}
