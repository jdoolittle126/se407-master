using System;
using BookStore.Library;
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


    }
}
