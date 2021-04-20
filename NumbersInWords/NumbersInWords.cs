namespace NumbersInWords
{
    public class NumbersInWords
    {
        public string Convert(int number)
        {
            switch (number)
            {
                case 9: return "Nine";
                case 8: return "Eight";
                case 7: return "Seven";
                case 6: return "Six";
                case 5: return "Five";
                case 4: return "Four";
                case 3: return "Three";
                case 2: return "Two";
                case 1: return "One";
                default: return "Zero";
            }
        }
    }
}
