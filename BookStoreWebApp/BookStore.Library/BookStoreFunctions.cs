using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Library
{
    public class BookStoreFunctions
    {

        /// <summary>
        /// Retrieves the first book with the given title, if any
        /// </summary>
        /// <param name="title">The title of the book</param>
        /// <param name="full">If true, will include the <see cref="Author"/>and <see cref="Genre"/> data</param>
        /// <returns>The book, or null if no such book exists</returns>
        public static Book GetBookByTitle(string title, bool full = false)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return full
                    ? context.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .First(b => b.BookTitle.ToLower() == title)
                    : context.Books
                        .First(b => b.BookTitle.ToLower() == title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves the book with the given id, if any
        /// </summary>
        /// <param name="id">The id of the book</param>
        /// <param name="full">If true, will include the <see cref="Author"/>and <see cref="Genre"/> data</param>
        /// <returns>The book, or null if no such book exists</returns>
        public static Book GetBookById(int id, bool full = false)
        {
            try
            {
                using var context = new SE407_BookStoreContext();

                return full
                    ? context.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .First(b => b.BookId == id)
                    : context.Books
                        .First(b => b.BookId == id);
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
        /// <param name="full">If true, will include the <see cref="Author"/>and <see cref="Genre"/> data</param>
        /// <returns>A list of all books, or null if no books exist</returns>
        public static List<Book> GetAllBooks(bool full = false)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return full
                    ? context.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .ToList()
                    : context.Books
                        .ToList();
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

        /// <summary>
        /// Creates a new <see cref="Book"/> in the SE407 BookStore database
        /// </summary>
        /// <param name="book">The book to add to the database</param>
        public static void AddBook(Book book)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Books.Add(book);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Removes a <see cref="Book"/> from the SE407 BookStore database
        /// </summary>
        /// <param name="book">The book to remove from the database</param>
        public static void DeleteBook(Book book)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Books.Remove(book);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Updates a <see cref="Book"/> in the SE407 BookStore database
        /// </summary>
        /// <param name="book">The book to be updated</param>
        public static void EditBook(Book book)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Books.Update(book);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
