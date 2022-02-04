using System;

namespace BlockBuster.Console
{
    internal class Program
    {
        private enum OutputTypes {
            Console,
            Csv
        }

        private static void Main(string[] args)
        {
            OutputHelper o = new OutputHelper();
            //o.WriteToConsole();
            var test = BlockBusterLibrary.BlockBusterBasicFunctions.GetAllMovies();
            System.Console.ReadKey();
        }
    }
}
