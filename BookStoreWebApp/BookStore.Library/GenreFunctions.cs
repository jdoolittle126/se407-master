using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Library.Models;

namespace BookStore.Library
{
    public class GenreFunctions
    {
        /// <summary>
        /// Retrieves the <see cref="Genre"/> with the given id, if any
        /// </summary>
        /// <param name="id">The id of the genre</param>
        /// <returns>The genre, or null if no such genre exists</returns>
        public static Genre GetGenreById(int id)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Genres.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Genre"/>s in
        /// the SE407 BookStore database
        /// </summary>
        /// <returns>A list of all genres, or null if no genres exist</returns>
        public static List<Genre> GetAllGenres()
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                return context.Genres.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Genre"/> in the SE407 BookStore database
        /// </summary>
        /// <param name="genre">The genre to add to the database</param>
        public static void AddGenre(Genre genre)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Genres.Add(genre);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Removes a <see cref="Genre"/> from the SE407 BookStore database
        /// </summary>
        /// <param name="genre">The genre to remove from the database</param>
        public static void DeleteGenre(Genre genre)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Genres.Remove(genre);
                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Updates a <see cref="Genre"/> in the SE407 BookStore database
        /// </summary>
        /// <param name="genre">The genre to be updated</param>
        public static void EditGenre(Genre genre)
        {
            try
            {
                using var context = new SE407_BookStoreContext();
                context.Genres.Update(genre);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
