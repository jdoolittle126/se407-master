using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockbusterLibrary.Models;

namespace BlockbusterLibrary
{
    public class BlockBusterBasicFunctions
    {

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

        public static List<Movie> GetAllCheckedOutMovies()
        {
            try
            {
                using var context = new SE407_BlockBusterContext();
                return context.Movies.Join(context.Transactions, m => m.MovieId, t => t.MovieId, (m, t) => new
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    ReleaseYear = m.ReleaseYear,
                    GenreId = m.GenreId,
                    DirectorId = m.DirectorId,
                    CheckedIn = t.CheckedIn
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



    }
}
