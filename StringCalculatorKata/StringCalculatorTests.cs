using NUnit.Framework;

namespace StringCalculatorKata
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [Test]
        public void ShouldReturn_Zero_WhenGivenEmptyString()
        {
            var sc = new StringCalculator();
            string numbers = string.Empty;
            int expected = 0;

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturn_One_WhenGiven1()
        {
            var sc = new StringCalculator();
            string numbers = "1";
            int expected = 1;

            int result = sc.Add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ShouldReturn_Three_WhenGiven1_And_2()
        {
            var sc = new StringCalculator();
            string numbers = "1,2";
            int expected = 3;

            int result = sc.Add(numbers);

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