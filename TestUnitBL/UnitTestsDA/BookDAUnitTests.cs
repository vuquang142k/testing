using Allure.Xunit.Attributes;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace UnitTests.UnitTestsDA
{
    [AllureOwner("Quang")]
    [AllureSuite("Book DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class BookDAUnitTests : IDisposable
    {
        private DBFixture fixture;
        public BookDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public async void TestAddBook()
        {
            //Arrange
            int id_book = 4;
            Book book = BookOM.NumberedBook(id_book).buildBL();
            int count = fixture.context.Books.Count() + 1;
            //Action
            fixture.bookDA.addBook(book);
            //Assert
            Assert.Equal(count, fixture.context.Books.Count());
        }

        [AllureXunit]
        public void TestGetIdBook()
        {
            //Arrange
            int id_book = 1;
            string name = "Book1";
            //Action
            int result = fixture.bookDA.getIdBook(name);
            //Assert
            Assert.Equal(id_book, result);
        }

        [AllureXunit]
        public void TestGetBook()
        {
            //Arrange
            int id_book = 1;
            //Action
            var result = fixture.bookDA.getBook(id_book);
            //Assert
            Assert.Equal(id_book, result.Id);
        }

        [AllureXunit]
        public async void TestDeleteBook()
        {
            //Arrange
            int id_book = 1;
            int count = fixture.context.Books.Count() - 1;
            //Action
            fixture.bookDA.deleteBook(id_book);
            //Assert
            Assert.Equal(count, fixture.context.Books.Count());
        }

        [AllureXunit]
        public async void TestGetAllBook()
        {
            //Arrange
            int count = fixture.context.Books.Count();
            //Action
            var result = fixture.bookDA.getAllBook();
            //Assert
            Assert.Equal(count, result.Count);
        }
    }
}
