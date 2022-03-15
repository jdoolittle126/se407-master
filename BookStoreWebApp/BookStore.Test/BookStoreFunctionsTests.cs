using System;
using BookStore.Library;
using BookStore.Library.Models;
using Xunit;

namespace BookStore.Test
{
    public class BookStoreFunctionsTests
    {
        [Fact]
        public void GetAllBooksTest()
        {
            var bookList = BookStoreFunctions.GetAllBooks();
            Assert.Equal(2, bookList.Count);
            Assert.Equal("The Travels of Marco Polo", bookList[0].BookTitle);
        }

        [Fact]
        public void GetBookByTitleTest()
        {
            var book = BookStoreFunctions.GetBookByTitle("The Travels of Marco Polo");
            Assert.Equal(2, book.AuthorId);
            Assert.Equal(1, book.GenreId);
            Assert.Equal("The Travels of Marco Polo", book.BookTitle);
        }

        [Fact]
        public void GetBookByAuthorLastNameTest()
        {
            var bookList = BookStoreFunctions.GetBooksByAuthorLastName("polo");
            Assert.Equal("Canterbury Tales", Assert.Single(bookList).BookTitle);
        }

        [Fact]
        public void GetAuthorByIdTest()
        {
            var author = AuthorFunctions.GetAuthorById(1);
            Assert.Equal("Polo", author.AuthorLast);
        }

        [Fact]
        public void GetAllAuthorsTest()
        {
            var authorList = AuthorFunctions.GetAllAuthors();
            Assert.Equal(5, authorList.Count);
        }

        [Fact]
        public void GetGenreByIdTest()
        {
            var genre = GenreFunctions.GetGenreById(1);
            Assert.Equal("Adventure", genre.GenreType);
        }

        [Fact]
        public void GetAllGenresTest()
        {
            var genreList = GenreFunctions.GetAllGenres();
            Assert.Equal(4, genreList.Count);
        }


    }
}
