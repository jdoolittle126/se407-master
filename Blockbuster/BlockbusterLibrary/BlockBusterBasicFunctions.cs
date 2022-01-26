using System;
using System.Collections.Generic;
using System.Linq;
using BlockBusterLibrary.Models;
// ReSharper disable SpecifyStringComparison

namespace BlockBusterLibrary
{
    /// <summary>
    /// Some basic functions that allow for queries against the
    /// SE407 BlockBluster database
    /// </summary>
    public class BlockBusterBasicFunctions
    {

        /// <summary>
        /// Retrieves a <see cref="Movie"/> from the SE407 BlockBuster
        /// database by ID
        /// </summary>
        /// <param name="id">The movie's ID</param>
        /// <returns>The requested movie, or null if the ID does not exist</returns>
        public static Movie GetMoveById(int id)
        {
            try
            {
                using var context = new SE407_BlockBusterContext();
                return context.Movies.Find(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Movie"/>s in
        /// the SE407 BlockBuster database
        /// </summary>
        /// <returns>A list of all movies, or null if no movies exist</returns>
        public static List<Movie> GetAllMovies()
        {
            try
            {
                using var context = new SE407_BlockBusterContext();
                return context.Movies.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Movie"/>s in
        /// the SE407 BlockBuster database that are currently
        /// checked out to customers
        /// </summary>
        /// <returns>A list of all checked out movies, or null if no movies that meet the criteria exist</returns>
        public static List<Movie> GetAllCheckedOutMovies()
        {
            try
            {
                using var context = new SE407_BlockBusterContext();
                return context.Movies.Join(context.Transactions, m => m.MovieId, t => t.MovieId, (m, t) => new
                {
                    m.MovieId,
                    m.Title,
                    m.ReleaseYear,
                    m.GenreId,
                    m.DirectorId,
                    t.CheckedIn
                }).Where(w => w.CheckedIn == "N").Select(m => new Movie()
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    ReleaseYear = m.ReleaseYear,
                    GenreId = m.GenreId,
                    DirectorId = m.DirectorId
                }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Retrieves all of the <see cref="Movie"/>s in
        /// the SE407 BlockBuster database that match the
        /// given genre, case insensitive.
        /// </summary>
        /// <param name="genreDescription">The genre of movie</param>
        /// <returns>A list of all movies of the given genre, or null if no movies that meet the criteria exist</returns>
        public static List<Movie> GetAllMoviesByGenre(string genreDescription)
        {
            try
            {
                using var context = new SE407_BlockBusterContext();
                return context.Movies.Join(context.Genres, movie => movie.GenreId, genre => genre.GenreId,
                        (movie, genre) => new
                        {
                            movie.MovieId,
                            movie.Title,
                            movie.ReleaseYear,
                            movie.GenreId,
                            movie.DirectorId,
                            GenreDescription = genre.GenreDescr
                        }).Where(movie => movie.GenreDescription.ToLower() == genreDescription.ToLower())
                    .Select(m => new Movie()
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
                    }).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        /// <summary>
        /// Retrieves all of the <see cref="Movie"/>s in
        /// the SE407 BlockBuster database that were directed
        /// by the given director, case insensitive.
        /// </summary>
        /// <param name="directorLastName">The last name of the director</param>
        /// <returns>A list of all movies by the given director, or null if no movies that meet the criteria exist</returns>
        public static List<Movie> GetAllMoviesByDirectorLastName(string directorLastName)
        {
            try
            {
                using var context = new SE407_BlockBusterContext();
                return context.Movies.Join(context.Directors, movie => movie.DirectorId, director => director.DirectorId,
                        (movie, director) => new
                        {
                            movie.MovieId,
                            movie.Title,
                            movie.ReleaseYear,
                            movie.GenreId,
                            movie.DirectorId,
                            DirectorLastName = director.LastName
                        }).Where(movie => movie.DirectorLastName.ToLower() == directorLastName.ToLower())
                    .Select(m => new Movie()
                    {
                        MovieId = m.MovieId,
                        Title = m.Title,
                        ReleaseYear = m.ReleaseYear,
                        GenreId = m.GenreId,
                        DirectorId = m.DirectorId
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
