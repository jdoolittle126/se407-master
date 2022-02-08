using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Library.Models;
using CsvHelper;

namespace BookStore.Console
{
    internal static class OutputHelper
    {
        /// <summary>
        /// Outputs a list of books as a formatted string to
        /// the console.
        /// </summary>
        /// <param name="books"></param>
        public static void WriteToConsole(List<Book> books)
        {
            System.Console.WriteLine("-- LIST OF BOOKS --");
            books.ForEach(book =>
            {
                System.Console.WriteLine(FormatBookString(book));
            });
        }

        /// <summary>
        /// Outputs a list of books to a CSV file
        /// </summary>
        /// <param name="books"></param>
        /// <param name="file">The name of the CSV file, including the .csv extension</param>
        public static void WriteToCsv(List<Book> books, string file = "books.csv")
        {
            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(books);
        }

        private static string FormatBookString(Book book)
        {
            return $"ID: {book.BookId, -4} TITLE: {book.BookTitle,-25} PUBLISHED: {book.YearOfRelease,4}";
        }

    }
}
