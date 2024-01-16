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
    [AllureSuite("Bookstore DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class BookstoreDaUnitTests : IDisposable
    {
        private DBFixture fixture;
        public BookstoreDaUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public async void TestAddBookstore()
        {
            //Arrange
            int id_bookstore = 3;
            Bookstore bookstore = BookstoreOM.NumberedBookstore(id_bookstore).buildBL();
            int count = fixture.context.Bookstores.Count() + 1;
            //Action
            fixture.bookstoreDA.addBookstore(bookstore);
            //Assert
            Assert.Equal(count, fixture.context.Bookstores.Count());
        }

        [AllureXunit]
        public void TestGetIdBookstoreByBook()
        {
            //Arrange
            int id_bookstore = 2;
            int id_book = 2;
            //Action
            int result = fixture.bookstoreDA.getIdBookstoreByBook(id_book);
            //Assert
            Assert.Equal(id_bookstore, result);
        }

        [AllureXunit]
        public void TestGetIdBookstoreByPlaceBook()
        {
            //Arrange
            int id_bookstore = 2;
            int id_placebook = 2;
            //Action
            int result = fixture.bookstoreDA.getIdBookstoreByPlaceBook(id_placebook);
            //Assert
            Assert.Equal(id_bookstore, result);
        }

        [AllureXunit]
        public void TestGetBookstore()
        {
            //Arrange
            int id_bookstore = 2;
            //Action
            var result = fixture.bookstoreDA.getBookstore(id_bookstore);
            //Assert
            Assert.Equal(id_bookstore, result.Id);
        }

        [AllureXunit]
        public async void TestDeleteBookstore()
        {
            //Arrange
            int id_bookstore = 1;
            int count = fixture.context.Bookstores.Count() - 1;
            //Action
            fixture.bookstoreDA.deleteBookstore(id_bookstore);
            //Assert
            Assert.Equal(count, fixture.context.Bookstores.Count());
        }

        [AllureXunit]
        public async void TestGetAllBookstore()
        {
            //Arrange
            int count = fixture.context.Bookstores.Count();
            //Action
            var result = fixture.bookstoreDA.getAllBookstore();
            //Assert
            Assert.Equal(count, result.Count);
        }
    }
}
