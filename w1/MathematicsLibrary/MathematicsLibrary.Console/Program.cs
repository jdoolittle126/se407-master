using System;
using MathematicsLibrary;

namespace MathematicsLibrary.Console
{
    class Program
    {

        private static double _number1;
        private static double _number2;
        private static string _operand;

        private static void Main(string[] args)
        {
            HasValidArguments(args);
            var basicMath = new BasicMath();

            // System.Console.WriteLine($"{_number1} + {_number2} = {}");

            switch (_operand)
            {
                case "add":

            }


        }

        private static void HasValidArguments(string[] args)
        {
            _operand = args[1].ToLower();
            _number1 = ParseArgument(args[2]);
            _number2 = ParseArgument(args[3]);
            System.Console.WriteLine("Arguments are valid!");
        }

        private static double ParseArgument(string arg)
        {
            if (double.TryParse(arg, out var result))
            {
                return result;
            }

            System.Console.WriteLine($"Could not parse {arg}");
            return 0;
        }


    }
}
