using CalculatorLibrary;
using System;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            double result = _calculator.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Add_WhenAddingZero_ReturnsSameNumber()
        {
            double result = _calculator.Add(7, 0);
            Assert.AreEqual(7, result);
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifference()
        {
            double result = _calculator.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Subtract_WhenSubtractingZero_ReturnsSameNumber()
        {
            double result = _calculator.Subtract(9, 0);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void Multiply_WhenCalled_ReturnsProduct()
        {
            double result = _calculator.Multiply(6, 7);
            Assert.AreEqual(42, result);
        }

        [Test]
        public void Divide_WhenCalledWithNonZeroDivider_ReturnsQuotient()
        {
            double result = _calculator.Divide(12, 3);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void Divide_WhenDividingByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}
