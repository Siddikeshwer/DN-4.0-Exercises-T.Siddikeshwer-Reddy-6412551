using NUnit.Framework;
using CalcLibrary; // Assuming this is the namespace of CalcLibrary

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            // Initialize before each test
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            _calculator = null;
        }

        [TestCase(2, 3, 5, TestName = "Add_2Plus3_Returns5")]
        [TestCase(0, 0, 0, TestName = "Add_0Plus0_Returns0")]
        [TestCase(-1, 1, 0, TestName = "Add_Negative1Plus1_Returns0")]
        [TestCase(100, 200, 300, TestName = "Add_100Plus200_Returns300")]
        public void Add_ValidInputs_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(expected), $"Expected {expected} but got {result} for inputs {a} and {b}.");
        }

        [Test]
        [Ignore("Test under development")]
        public void Add_UnderDevelopmentTest()
        {
            Assert.Fail("Test not implemented");
        }
    }
}
