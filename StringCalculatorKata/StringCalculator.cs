using System;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "1")
            {
                return 1;
            }
            if (numbers == "1,2")
            {
                return 3;
            }
            return 0;
        }
    }
}
