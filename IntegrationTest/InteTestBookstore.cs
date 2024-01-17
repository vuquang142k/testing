using Allure.Xunit.Attributes;
using BL.BL;
using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using Moq;
using System.Security.Principal;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace IntegrationTests
{
    [AllureOwner("Quang")]
    [AllureSuite("Bookstore Integration Tests")]
    [Collection("ITCollection")]
    public class InteTestBookstore : IDisposable
    {
        private readonly ITFixture _fixture;
        public InteTestBookstore(ITFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose() { }

        [AllureXunit]
        public void TestGetAllBookstore()
        {
            //Action
            List<Bookstore> result = _fixture.bookstoreServices.getAllBookstore();
            //Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 2));
        }

        [AllureXunit]
        public void TestGetBookstore()
        {
            //Arrange
            int id_bookstore = 1;
            //Action
            Bookstore bookstore = _fixture.bookstoreServices.getBookstore(id_bookstore);
            //Assert
            Assert.Equal(1, bookstore.Id);
        }

        [AllureXunit]
        public void TestGetIdBookstoreByBook()
        {
            //Arrange
            int id_book = 2;
            //Action
            int id_bookstore = _fixture.bookstoreServices.getIdBookstoreByBook(id_book);
            //Assert
            Assert.Equal(1, id_bookstore);
        }

        [AllureXunit]
        public void TestGetIdBookstoreByPlaceBook()
        {
            //Arrange
            int id_placebook = 2;
            //Action
            int id_bookstore = _fixture.bookstoreServices.getIdBookstoreByPlaceBook(id_placebook);
            //Assert
            Assert.Equal(1, id_bookstore);
        }
    }
}
