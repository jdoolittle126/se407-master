using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Library;
using BookStore.Library.Models;
using CsvHelper;

namespace BookStore.Console
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
        private static readonly CommandLineArgument[] Arguments =
        {
            new("s", "silent", "Runs the process without outputting book(s) to the console.", 0),
            new("c", "csv", "Stores the results in [arg0].csv", 1),
            new("h", "help", "Displays the help menu", 0),
            new("a", "author", "Only fetches books by the author with the last name of [arg0]", 1),
            new("t", "title", "Fetches the book with the title of [arg0]", 1)
        };

        private static void Main(string[] args)
        {

            List<Book> books = new List<Book>();

            ParseArgs(args);
            ValidateArgs();

            // Checks if no arguments were provided, or if the help flag was triggered
            if ((!Arguments[0].IsFlagged() && !Arguments[1].IsFlagged() && !Arguments[3].IsFlagged() && !Arguments[4].IsFlagged()) || Arguments[2].IsFlagged())
            {
                DisplayHelp();
            }

            // If the author, title, or no flag is provided
            if (Arguments[3].IsFlagged())
            {
                books = BookStoreFunctions.GetBooksByAuthorLastName(Arguments[3].GetArgument(0));
            } else if (Arguments[4].IsFlagged())
            {
                books.Add(BookStoreFunctions.GetBookByTitle(Arguments[4].GetArgument(0)));
            }
            else
            {
                books = BookStoreFunctions.GetAllBooks();
            }


            // If the '--silent' flag is not present, display movies in console
            if (!Arguments[0].IsFlagged())
            {
                OutputHelper.WriteToConsole(books);
            }

            // If the '--csv [file]' flag is present, write to file
            if (Arguments[1].IsFlagged())
            {
                OutputHelper.WriteToCsv(books, Arguments[1].GetArgument(0));
            }

            // Pause (Would be removed if this were production)
            System.Console.ReadKey();
        }

        /// <summary>
        /// Ensures conflicting arguments are not provided
        /// </summary>
        private static void ValidateArgs()
        {
            if (Arguments[3].IsFlagged() && Arguments[4].IsFlagged())
            {
                System.Console.WriteLine("You have provided conflicting arguments, '-a, --author' and '-t, --title' cannot be used together.");
                Environment.Exit(99);
            }

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
                int index = Math.Max(argsList.IndexOf($"-{Arguments[j].ShortFlag}"),
                    argsList.IndexOf($"--{Arguments[j].LongFlag}"));
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
            System.Console.WriteLine("Pulls books from the bookstore database, and outputs them in various formats");
            System.Console.WriteLine("Use the '-a, --author' or '-t, --title' flags to drill down your search. If neither are specified, all books are selected.");
            foreach (var commandLineArgument in Arguments)
            {
                System.Console.WriteLine($"\t{commandLineArgument.GetHelpString()}");
            }
        }
    }
}
