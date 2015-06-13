using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const int _START_OF_CUSTOM_DELIMITER_INDEX = 3;

        public int Add(string numbers)
        {
            if (NoNumbersFound(numbers)) 
                return 0;

            if (numbers.Length > 3 && FoundCustomDelimiter(numbers))
                numbers = PrepForCustomDelimiters(numbers);

            if (FoundNewLine(numbers))
                numbers = numbers.Replace("\n", ",");

            if (ContainsNegatives(numbers))
            {
                IEnumerable<string> negatives = numbers.Split(',').Where(n => int.Parse(n) < 0);

                throw new Exception("Negatives not allowed: " + string.Join(", ", negatives));
            }

            if (FoundComma(numbers))
                return SumAllNumbers(numbers);

            return int.Parse(numbers);
        }

        private bool ContainsNegatives(string numbers)
        {
            return numbers.Contains('-');
        }

        private string PrepForCustomDelimiters(string numbers)
        {
            int indexOfActualNumbers = numbers.IndexOf("\n", System.StringComparison.Ordinal) + 1;
            int numberOfCharactersInCustomDelimiter = indexOfActualNumbers - _START_OF_CUSTOM_DELIMITER_INDEX;

            string customDelimiter = GetCustomDelimiter(numbers, numberOfCharactersInCustomDelimiter);
            
            numbers = RemoveCustomDelimiterFromNumbers(numbers, indexOfActualNumbers);
            
            return numbers.Replace(customDelimiter, ",");
        }

        private static string RemoveCustomDelimiterFromNumbers(string numbers, int indexOfActualNumbers)
        {
            return numbers.Substring(indexOfActualNumbers);
        }

        private static string GetCustomDelimiter(string numbers, int numberOfCharactersInCustomDelimiter)
        {
            return numbers.Substring(2, numberOfCharactersInCustomDelimiter);
        }

        private bool FoundCustomDelimiter(string numbers)
        {
            return numbers.Substring(0,2) == "//";
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
