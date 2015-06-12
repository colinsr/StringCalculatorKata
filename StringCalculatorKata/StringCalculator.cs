using System;
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

            if (FoundCustomDelimiter(numbers))
                numbers = PrepForCustomDelimiters(numbers);

            if (FoundNewLine(numbers))
                numbers = numbers.Replace("\n", ",");

            if (FoundComma(numbers))
                return SumAllNumbers(numbers);

            return int.Parse(numbers);
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
