using BlockBusterLibrary.Models;
using System;
using BlockBusterLibrary;
using Xunit;

namespace BlockBuster.Tests
{
    /// <summary>
    /// Provides tests for the <see cref="BlockBusterBasicFunctions"/> library
    /// </summary>
    public class BlockBusterBasicFunctionsTest
    {

        // TODO ALL: Coverage for 'catch' statements

        [Fact]
        public void GetMovieByIdTest()
        {
            var resultSuccess = BlockBusterBasicFunctions.GetMoveById(11);
            var resultFail = BlockBusterBasicFunctions.GetMoveById(-10);
            Assert.True(resultSuccess.Title.ToLower() == "vertigo");
            Assert.True(resultSuccess.ReleaseYear == 1958);
            Assert.True(resultFail is null);
        }


        [Fact]
        public void GetAllMoviesTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMovies();
            Assert.True(result.Count == 49);
        }

        [Fact]
        public void GetAllCheckedOutMoviesTest()
        {
            var result = BlockBusterBasicFunctions.GetAllCheckedOutMovies();
            Assert.True(result.Count == 3);
        }


        [Fact]
        public void GetAllMoviesByGenreTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMoviesByGenre("Drama");
            Assert.True(result.Count == 27);
        }


        [Fact]
        public void GetAllMoviesByDirectorLastNameTest()
        {
            var result = BlockBusterBasicFunctions.GetAllMoviesByDirectorLastName("Ford");
            Assert.True(result.Count == 1);
        }
    }
}
