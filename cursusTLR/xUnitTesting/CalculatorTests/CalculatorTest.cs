using CalculatorLibrary;
using System;
using Xunit;

namespace CalculatorTests
{
    public class CalculatorTest
    {
        [Fact]
        public void OnePlusOneIsTwo()
        {
            //Arrange
            var one = 1;
            var expected = 2;
            var actual = 0;

            //Act
            actual = Calculator.Sum(one, one);

            //Assert
            Assert.Equal<int>(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(3, 8, 11)]
        [InlineData(-4, 9, 5)]
        public void Sum(int one, int two, int expected)
        {
            var actual = Calculator.Sum(one, two);
            Assert.Equal<int>(expected, actual);
        }
    }
}
