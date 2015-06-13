using System;
using NUnit.Framework;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void SetUp()
        {
            this._stringCalculator = new StringCalculator();
        }

        [Test]
        public void ShouldReturn_Zero_WhenGivenEmptyString()
        {
            string numbers = string.Empty;
            int expected = 0;

            int result = _stringCalculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1",1)]
        [TestCase("4", 4)]
        [TestCase("7", 7)]
        [TestCase("111", 111)]
        [TestCase("11111", 11111)]
        public void ShouldReturn_TheNumber_WhenGivenSingleNumber(string numbers, int expected)
        {
            int result = _stringCalculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("5,2", 7)]
        [TestCase("9,9", 18)]
        public void ShouldReturn_Sum_WhenGiven2Numbers(string numbers, int expected)
        {
            int result = _stringCalculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1,2,3", 6)]
        [TestCase("5,2,7,14", 28)]
        [TestCase("9,9,9,9,9,9,9,9,9,9", 90)]
        public void ShouldReturn_Sum_WhenGivenMultipleNumbers_SeperatedByCommas(string numbers, int expected)
        {
            int result = _stringCalculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1\n2,3", 6)]
        [TestCase("5,2\n7,14", 28)]
        [TestCase("9,9,9\n9,9,9,9,9,9,9", 90)]
        public void ShouldReturn_Sum_WhenGivenMultipleNumbers_SeperatedByNewLines(string numbers, int expected)
        {
            int result = _stringCalculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("//foo\n1\n2foo3", 6)]
        [TestCase("//( * )\n5,2\n7( * )14", 28)]
        [TestCase("//###\n9,9###9\n9,9,9,9###9,9,9", 90)]
        public void ShouldReturn_Sum_WhenGivenMultipleNumbers_SeperatedByCustomDelimiter(string numbers, int expected)
        {
            int result = _stringCalculator.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("-1,2", "Negatives not allowed: -1")]
        [TestCase("-1,2,-3", "Negatives not allowed: -1, -3")]
        [TestCase("-1,-2,-3\n-4", "Negatives not allowed: -1, -2, -3, -4")]
        public void ShouldThrow_WhenGivenNegativeNumbers(string numbers, string expected)
        {
            try
            {
                _stringCalculator.Add(numbers);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }
    }
}

//5. Calling Add with a negative number will throw an exception “Negatives not allowed: “ listing all
//negative numbers that were in the list of numbers.
//a. Example “-1,2” throws “Negatives not allowed: -1”
//b. Example “2,-4,3,-5” throws “Negatives not allowed: -4,-5”

//4. Allow the Add method to handle a different delimiter:
//a. To change the delimiter, the beginning of the string will contain a separate line that looks like
//this: “//[delimiter]\n[numbers]”
//b. Example: “//;\n1;2” should return 3 (the delimiter is ;)
//c. This first line is optional; all existing scenarios (using , or \n) should work as before.

//3. Allow the Add method to handle new lines between numbers (instead of commas).
//a. Example: “1\n2,3” should return 6.
//b. Example: “1,\n” is invalid, but you don’t need a test for this case.
//c. Only test correct inputs – there is no need to deal with invalid inputs for this kata.

//2. Allow the Add method to handle an unknown number of arguments/numbers.

//1. Create a String calculator with a method int Add(string numbers) --done
//a. The method can take 0, 1, or 2 numbers and will return their sum. --done
//b. An empty string will return 0. --done
//c. Example inputs: “”, “1”, or “1,2” --done
//d. Start with the simplest test case of an empty string. Then 1 number. Then 2 numbers. --done
//e. Remember to solve things as simply as possible, forcing yourself to write tests for things you  --done
//didn’t think about.  --done
//f. Remember to refactor after each passing test.  --done