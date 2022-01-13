using System;

namespace MathematicsLibrary
{
    /// <summary>
    /// A basic math library to demonstrate how unit tests
    /// are created and used.
    /// </summary>
    public class BasicMath
    {

        /// <summary>
        /// Adds the two provided values together and returns the result
        /// </summary>
        /// <param name="a">The first number for the operation</param>
        /// <param name="b">The second number for the operation</param>
        /// <returns>The sum of a and b</returns>
        public double AddNumbers(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts 'a' from 'b' and returns the result
        /// </summary>
        /// <param name="a">The first number for the operation</param>
        /// <param name="b">The second number for the operation</param>
        /// <returns>The difference of a and b</returns>
        public double SubtractNumbers(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies the two provided values together and returns the result
        /// </summary>
        /// <param name="a">The first number for the operation</param>
        /// <param name="b">The second number for the operation</param>
        /// <returns>The product of a and b</returns>
        public double MultiplyNumbers(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides 'a' into 'b' number of groups and returns the result
        /// </summary>
        /// <param name="a">The first number for the operation</param>
        /// <param name="b">The second number for the operation</param>
        /// <returns>The quotient of a and b</returns>
        public double DivideNumbers(double a, double b)
        {
            return a / b;
        }

    }
}
