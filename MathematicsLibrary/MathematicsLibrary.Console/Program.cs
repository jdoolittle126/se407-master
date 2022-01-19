using System;
using System.Collections.Generic;
using MathematicsLibrary;

namespace MathematicsLibrary.Console
{
    /// <summary>
    /// A simple console application that uses our
    /// Mathematics library.
    /// </summary>
    internal static class Program
    {
        private static List<double> _values;
        private static string _operand;

        private static void Main(string[] args)
        {

            _values = new List<double>();

            HasValidArguments(args);

            var basicMath = new BasicMath();
            var advancedMath = new AdvancedMath();

            switch (_operand)
            {
                case "add":
                    HasArgumentRequirement(2, 2);
                    System.Console.WriteLine($"{_values[0]} + {_values[1]} = {basicMath.AddNumbers(_values[0], _values[1])}");
                    break;

                case "subtract":
                    HasArgumentRequirement(2, 2);
                    System.Console.WriteLine($"{_values[0]} - {_values[1]} = {basicMath.SubtractNumbers(_values[0], _values[1])}");
                    break;

                case "multiply":
                    HasArgumentRequirement(2, 2);
                    System.Console.WriteLine($"{_values[0]} * {_values[1]} = {basicMath.MultiplyNumbers(_values[0], _values[1])}");
                    break;

                case "divide":
                    HasArgumentRequirement(2, 2);
                    System.Console.WriteLine($"{_values[0]} / {_values[1]} = {basicMath.DivideNumbers(_values[0], _values[1])}");
                    break;

                case "area":
                    HasArgumentRequirement(2, 2);
                    System.Console.WriteLine($"The area of a {_values[0]} x {_values[1]} region is {advancedMath.CalculateArea(_values[0], _values[1])}");
                    break;

                case "square":
                    HasArgumentRequirement(1, 1);
                    System.Console.WriteLine($"{_values[0]}^2 = {advancedMath.CalculateSquared(_values[0])}");
                    break;

                case "pythagorean":
                    HasArgumentRequirement(2, 2);
                    System.Console.WriteLine($"The length of C is {advancedMath.PythagoreanTheorem(_values[0], _values[1])}");
                    break;

                case "average":
                    HasArgumentRequirement(1);
                    System.Console.WriteLine($"The average of these values is {advancedMath.CalculateAverage(_values)}");
                    break;

                default: 
                    System.Console.WriteLine("Unknown operand!");
                    DisplayHelp();
                    break;
            }

        }

        /// <summary>
        /// Checks that the provided arguments are valid, where the first
        /// argument is a string operand, the rest are numeric values.
        /// </summary>
        /// <param name="args">A list of arguments</param>
        private static void HasValidArguments(IReadOnlyList<string> args)
        {
            _operand = args[0].ToLower();
            var validArguments = true;

            for (var i = 1; i < args.Count; i++)
            {
                (bool parsed, double value) = ParseArgument(args[i]);
                if (parsed)
                {
                    _values.Add(value);
                }
                else
                {
                    validArguments = false;
                    System.Console.WriteLine($"Could not parse '{args[i]}' (Argument #{i})");
                }
            }

            if (validArguments) return;

            System.Console.WriteLine("Some arguments could not be parsed. Please correct them and try again.");
            Environment.Exit(99);
        }

        /// <summary>
        /// Checks that the user has provided the minimum number of arguments required for a
        /// specific operand. Additionally, the optional max parameter will display a warning
        /// that additional arguments will be ignored.
        /// </summary>
        /// <param name="required">The minimum number of arguments required. The program will exit
        /// with status 99 if this value is not met.</param>
        /// <param name="max">The maximum number of arguments this function takes. If exceeded,
        /// the user will be warned that additional arguments will be ignored.</param>
        private static void HasArgumentRequirement(int required, int max = 0)
        {
            if (max >= required && _values.Count > max)
            {
                System.Console.WriteLine("You have provided more arguments than this function takes. Additional arguments will be ignored.");
                return;
            }

            if (_values.Count >= required) return;

            System.Console.WriteLine("Missing arguments!");
            Environment.Exit(99);
        }

        /// <summary>
        /// Parses a string argument as a double
        /// </summary>
        /// <param name="arg">The string to parse</param>
        /// <returns>A (bool, double) tuple, where the bool
        /// is true when the parse was successful, and the double contains the value</returns>
        private static (bool, double) ParseArgument(string arg)
        {
            return (double.TryParse(arg, out double result), result);
        }

        /// <summary>
        /// Displays the help description
        /// </summary>
        private static void DisplayHelp()
        {
            System.Console.WriteLine("Usage: [operand] value1 value2 value3\n" +
                                     "Operands: \n" +
                                     " add value1 value2\n" +
                                     " subtract value1 value2\n" +
                                     " multiply value1 value2\n" +
                                     " divide value1 value2\n" +
                                     " area length width\n" +
                                     " square value1\n" +
                                     " pythagorean a b\n" +
                                     " average a b c ...\n");
        }


    }
}
