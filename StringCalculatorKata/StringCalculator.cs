using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (NoNumbersFound(numbers)) 
                return 0;

            if (FoundNewLine(numbers))
                numbers = numbers.Replace("\n", ",");

            if (FoundComma(numbers))
                return SumAllNumbers(numbers);

            return int.Parse(numbers);
        }

        private bool FoundNewLine(string numbers)
        {
            return numbers.Contains("\n");
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

        private bool NoNumbersFound(string numbers)
        {
            return numbers == string.Empty;
        }
    }


}
