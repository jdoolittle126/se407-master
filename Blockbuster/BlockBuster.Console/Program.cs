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
            o.WriteToConsole(BlockBusterLibrary.BlockBusterBasicFunctions.GetAllMovies());
        }
    }
}
