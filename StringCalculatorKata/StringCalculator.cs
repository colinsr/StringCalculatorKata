using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == string.Empty)
            {
                return 0;
            }
            if (FoundComma(numbers))
            {
                return SumAllNumbers(numbers);
            }
            return int.Parse(numbers);
        }

        private int SumAllNumbers(string numbers)
        {
            string[] splitNumbers = numbers.Split(',');
            return splitNumbers.Select(s => int.Parse(s)).ToArray().Sum();
        }

        private bool FoundComma(string numbers)
        {
            return numbers.Contains(",");
        }
    }


}
