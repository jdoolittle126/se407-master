using BlockbusterLibrary.Models;
using System;
using BlockbusterLibrary;
using Xunit;

namespace BlockBuster.Tests
{
    public class BlockBusterBasicFunctionsTest
    {
        [Fact]
        public void GetMovieByIdTest()
        {
            var result = BlockBusterBasicFunctions.GetMoveById(11);
            Assert.True(result.Title.ToLower() == "vertigo");
            Assert.True(result.ReleaseYear == 1958);
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
    }
}
