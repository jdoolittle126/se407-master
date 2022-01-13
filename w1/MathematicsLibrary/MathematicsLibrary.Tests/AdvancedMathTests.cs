using Xunit;
using MathematicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicsLibrary.Tests
{
    public class AdvancedMathTests
    {

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(50, 10, 500)]
        public void CalculateAreaTheory(double width, double height, double expected)
        {
            var advMath = new AdvancedMath();
            Assert.Equal(expected, advMath.CalculateArea(width, height));
        }

        private class CalculateAverageTestData
        {
            public static IEnumerable<object[]> AverageTestData => new List<object[]>
            {
                new object[] { new List<double> { 3, 3, 3 }, 3 },
                new object[] { new List<double> { 45, 22, 12, 19, 19 }, 23.4 },
                new object[] { new List<double> { -4, 1.2, 8.99, 24, 100, 13 }, 23.865 },
            };
        }

        [Theory]
        [MemberData(nameof(CalculateAverageTestData.AverageTestData), MemberType = typeof(CalculateAverageTestData))]
        public void CalculateAverageTheory(IEnumerable<double> values, double expected)
        {
            var advMath = new AdvancedMath();
            Assert.Equal(expected, advMath.CalculateAverage(values), 2);
            Assert.Equal(expected, advMath.CalculateAverage(values.ToArray()), 2);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        [InlineData(5, 25)]
        [InlineData(10, 100)]
        public void CalculateSquaredTheory(double a, double expected)
        {
            var advMath = new AdvancedMath();
            Assert.Equal(expected, advMath.CalculateSquared(a));
        }

        [Theory]
        [InlineData(5, 5, 7.07)]
        [InlineData(15, 2, 15.13)]
        [InlineData(8, 6, 10)]
        public void PythagoreanTheoremTheory(double a, double b, double expected)
        {
            var advMath = new AdvancedMath();
            Assert.Equal(expected, advMath.PythagoreanTheorem(a, b), 2);

        }
    }
}