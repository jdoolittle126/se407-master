using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicsLibrary
{
    /// <summary>
    /// An advanced math library to demonstrate how unit tests
    /// are created and used.
    /// </summary>
    public class AdvancedMath
    {

        /// <summary>
        /// Calculates the area of a surface with the given width
        /// and height.
        /// </summary>
        /// <param name="width">The width of the region</param>
        /// <param name="height">The height of the region</param>
        /// <returns>The area of the region</returns>
        public double CalculateArea(double width, double height)
        {
            return width * height;
        }

        /// <summary>
        /// Calculates the average from a variable number of values
        /// </summary>
        /// <param name="values">One or more values to be averaged</param>
        /// <returns>The average of the provided values</returns>
        public double CalculateAverage(params double[] values)
        {
            return values.Average();
        }

        /// <summary>
        /// Calculates the average from a collection of values
        /// </summary>
        /// <param name="values">The collection of values to be averaged</param>
        /// <returns>The average of the provided values</returns>
        public double CalculateAverage(IEnumerable<double> values)
        {
            return values.Average();
        }

        /// <summary>
        /// Squares the given value
        /// </summary>
        /// <param name="a">The value to be squared</param>
        /// <returns>The squared value</returns>
        public double CalculateSquared(double a)
        {
            return a * a;
        }

        /// <summary>
        /// Calculates the length of side c (hypotenuse) when a (leg) and b (leg)
        /// are known and abc forms a right triangle.
        /// </summary>
        /// <param name="a">Side of right triangle</param>
        /// <param name="b">Side of right triangle</param>
        /// <returns>The length of the hypotenuse</returns>
        public double PythagoreanTheorem(double a, double b)
        {
           return Math.Sqrt(CalculateSquared(a) + CalculateSquared(b));
        }

    }
}
