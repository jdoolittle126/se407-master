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
    class OutputHelper
    {

        public void WriteToConsole(List<Movie> movies)
        {
            System.Console.WriteLine("-- LIST OF MOVIES --");
            movies.ForEach(movie =>
            {
                System.Console.WriteLine(FormatMovieString(movie));
            });
        }

        public void WriteToCsv(List<Movie> movies)
        {
            using var writer = new StreamWriter("");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(movies);
        }

        private static string FormatMovieString(Movie movie)
        {
            return $"ID: {movie.MovieId,-5} TITLE: {movie.Title,-25} RELEASED: {movie.ReleaseYear,4}";
        }

    }
}
