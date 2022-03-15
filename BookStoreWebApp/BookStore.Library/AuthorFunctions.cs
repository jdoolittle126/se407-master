using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Library
{
    public class AuthorFunctions
    {

        /// <summary>
        /// Retrieves the <see cref="Author"/> with the given id, if any
        /// </summary>
        /// <param name="id">The id of the author</param>
        /// <returns>The author, or null if no such author exists</returns>
        public static Author GetAuthorById(int id)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Authors.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Author"/>s in
        /// the SE407 BookStore database
        /// </summary>
        /// <returns>A list of all authors, or null if no authors exist</returns>
        public static List<Author> GetAllAuthors()
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Authors.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Author"/> in the SE407 BookStore database
        /// </summary>
        /// <param name="author">The author to add to the database</param>
        public static void AddAuthor(Author author)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Authors.Add(author);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Removes a <see cref="Author"/> from the SE407 BookStore database
        /// </summary>
        /// <param name="author">The author to remove from the database</param>
        public static void DeleteAuthor(Author author)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Authors.Remove(author);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Updates a <see cref="Author"/> in the SE407 BookStore database
        /// </summary>
        /// <param name="author">The author to be updated</param>
        public static void EditAuthor(Author author)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Authors.Update(author);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
