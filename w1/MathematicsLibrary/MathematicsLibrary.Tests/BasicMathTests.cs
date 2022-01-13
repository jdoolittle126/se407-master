using Xunit;
using MathematicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicsLibrary.Tests
{
    /// <summary>
    /// Contains test for the BasicMath portion of
    /// the MathematicsLibrary.
    /// Considerations for more comprehensive testing:
    ///  - Edge cases
    ///  - Floating point values
    /// </summary>
    public class BasicMathTests
    {

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-5, 4, -1)]
        [InlineData(-100, -25, -125)]
        public void AddNumbersTheory(double a, double b, double expected)
        {
            var basicMath = new MathematicsLibrary.BasicMath();
            Assert.Equal(expected, basicMath.AddNumbers(a, b));
        }

        [Theory]
        [InlineData(50, 100, -50)]
        [InlineData(5, 5, 0)]
        [InlineData(-27, -17, -10)]
        public void SubtractNumbersTheory(double a, double b, double expected)
        {
            var basicMath = new MathematicsLibrary.BasicMath();
            Assert.Equal(expected, basicMath.SubtractNumbers(a, b));
        }

        [Theory]
        [InlineData(10, 10, 100)]
        [InlineData(-5, 20, -100)]
        [InlineData(0, 25, 0)]
        public void MultiplyNumbersTheory(double a, double b, double expected)
        {
            var basicMath = new MathematicsLibrary.BasicMath();
            Assert.Equal(expected, basicMath.MultiplyNumbers(a, b));
        }

        [Theory]
        [InlineData(100, 5, 20)]
        [InlineData(-200, 10, -20)]
        [InlineData(-100, -5, 20)]
        public void DivideNumbersTheory(double a, double b, double expected)
        {
            var basicMath = new MathematicsLibrary.BasicMath();
            Assert.Equal(expected, basicMath.DivideNumbers(a, b));
        }
    }
}