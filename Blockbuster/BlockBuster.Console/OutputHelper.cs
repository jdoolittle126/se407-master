using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockBusterLibrary.Models;
using CsvHelper;

namespace BlockBuster.Console
{
    internal static class OutputHelper
    {
        /// <summary>
        /// Outputs a list of movies as a formatted string to
        /// the console.
        /// </summary>
        /// <param name="movies"></param>
        public static void WriteToConsole(List<Movie> movies)
        {
            System.Console.WriteLine("-- LIST OF MOVIES --");
            movies.ForEach(movie =>
            {
                System.Console.WriteLine(FormatMovieString(movie));
            });
        }

        /// <summary>
        /// Outputs a list of movies to a CSV file
        /// </summary>
        /// <param name="movies"></param>
        /// <param name="file">The name of the CSV file, including the .csv extension</param>
        public static void WriteToCsv(List<Movie> movies, string file = "movies.csv")
        {
            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(movies);
        }

        private static string FormatMovieString(Movie movie)
        {
            return $"ID: {movie.MovieId,-5} TITLE: {movie.Title,-50} RELEASED: {movie.ReleaseYear,4}";
        }

    }
}
