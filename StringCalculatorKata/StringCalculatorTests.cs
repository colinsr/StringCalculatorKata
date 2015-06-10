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
    }
}

//1. Create a String calculator with a method int Add(string numbers)
//a. The method can take 0, 1, or 2 numbers and will return their sum.
//b. An empty string will return 0.
//c. Example inputs: “”, “1”, or “1,2”
//d. Start with the simplest test case of an empty string. Then 1 number. Then 2 numbers.
//e. Remember to solve things as simply as possible, forcing yourself to write tests for things you
//didn’t think about.
//f. Remember to refactor after each passing test.