using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockBuster.Console
{
    internal static class Program
    {
        private struct CommandLineArgument
        {
            // TODO Rework using factory or builder to allow more nuanced argument types
            public readonly string ShortFlag;
            public readonly string LongFlag;
            public readonly int Expects;
            private readonly string _description;
            private readonly List<string> _arguments;
            private bool _flagged;

            /// <param name="shortFlag">The short, single letter flag for this argument, with no prefix ('s' would result in the flag '-s')</param>
            /// <param name="longFlag">The extended, multi-character flag for this argument, with no prefix ('silent' would result in the flag '--silent')</param>
            /// <param name="description">The help description for this argument</param>
            /// <param name="expects">The amount of sub arguments expected following this flag</param>
            public CommandLineArgument(string shortFlag, string longFlag, string description, int expects)
            {
                ShortFlag = shortFlag;
                LongFlag = longFlag;
                _description = description;
                Expects = expects;
                _arguments = new List<string>();
                _flagged = false;
            }

            public void Flag()
            {
                _flagged = true;
            }

            public bool IsFlagged()
            {
                return _flagged;
            }

            public void AddArgument(string arg)
            {
                _arguments.Add(arg);
            }

            public string GetArgument(int index)
            {
                return _arguments[index];
            }

            /// <returns>A formatted help string for this argument</returns>
            public string GetHelpString()
            {
                var result = $"-{ShortFlag}, --{LongFlag} ";
                for (var i = 0; i < Expects; i++)
                {
                    result += $"arg{i} ";
                }
                result += $"\t | {_description}";
                return result;
            }
        }

        // TODO Move to dictionary-based format for readability (i.e. Arguments["help"] as opposed to Arguments[2])
        private static readonly CommandLineArgument[] Arguments = {
            new("s", "silent", "Runs the process without outputting a movie list to the console.", 0),
            new("c", "csv", "Stores the results in [arg0].csv", 1),
            new("h", "help", "Displays the help menu", 0)
        };

        private static void Main(string[] args)
        {

            var movies = BlockBusterLibrary.BlockBusterBasicFunctions.GetAllMovies();

            ParseArgs(args);

            // Checks if no arguments were provided, or if the help flag was triggered
            if ((!Arguments[0].IsFlagged() && !Arguments[1].IsFlagged()) || Arguments[2].IsFlagged())
            {
                DisplayHelp();
            }

            // If the '--silent' flag is not present, display movies in console
            if (!Arguments[0].IsFlagged())
            {
                OutputHelper.WriteToConsole(movies);
            }

            // If the '--csv [file]' flag is present, write to file
            if (Arguments[1].IsFlagged())
            {
                OutputHelper.WriteToCsv(movies, Arguments[1].GetArgument(0));
            }

            // Pause (Would be removed if this were production)
            System.Console.ReadKey();
        }

        /// <summary>
        /// Parses arguments based on the rules defined in the Arguments array
        /// </summary>
        /// <param name="args">A list of string arguments</param>
        private static void ParseArgs(IEnumerable<string> args)
        {
            // TODO Clean for readability
            var argsList = args.ToList();
            for (var j = 0; j < Arguments.Length; j++)
            {
                int index = Math.Max(argsList.IndexOf($"-{Arguments[j].ShortFlag}"), argsList.IndexOf($"--{Arguments[j].LongFlag}"));
                if (index <= -1) continue;
                Arguments[j].Flag();
                for (var i = 0; i < Arguments[j].Expects; i++)
                {
                    Arguments[j].AddArgument(argsList.ElementAt(index + i + 1));
                }
            }
        }

        /// <summary>
        /// Displays command-line argument help text in the console.
        /// </summary>
        private static void DisplayHelp()
        {
            System.Console.WriteLine("Pulls movies from the blockbuster database, and outputs them in various formats");
            foreach (var commandLineArgument in Arguments)
            {
                System.Console.WriteLine($"\t{commandLineArgument.GetHelpString()}");
            }
        }




    }
}
