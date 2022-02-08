using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Library.Models;

namespace BookStore.Library
{
    public class BookStoreFunctions
    {

        /// <summary>
        /// Retrieves the first book with the given title, if any
        /// </summary>
        /// <param name="title">The title of the book</param>
        /// <returns>The book, or null if no such book exists</returns>
        public static Book GetBookByTitle(string title)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Books.First(b => b.BookTitle.ToLower() == title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Book"/>s in
        /// the SE407 BookStore database
        /// </summary>
        /// <returns>A list of all books, or null if no books exist</returns>
        public static List<Book> GetAllBooks()
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Books.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Book"/>s in
        /// the SE407 BookStore database by the given author
        /// </summary>
        /// <param name="lastName">The author's last name</param>
        /// <returns>A list of all books by the author, or null if no books exist</returns>
        public static List<Book> GetBooksByAuthorLastName(string lastName)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Books.Join(context.Authors, b => b.AuthorId, 
                        a => a.AuthorId, (b, a) => new
                {
                    b.BookId,
                    b.BookTitle,
                    b.GenreId,
                    b.AuthorId,
                    b.YearOfRelease,
                    a.AuthorLast
                }).Where(x => x.AuthorLast.ToLower() == lastName.ToLower())
                    .Select(b => new Book()
                {
                    BookId = b.BookId,
                    BookTitle = b.BookTitle,
                    GenreId = b.GenreId,
                    AuthorId = b.AuthorId,
                    YearOfRelease = b.YearOfRelease,
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


    }
}
