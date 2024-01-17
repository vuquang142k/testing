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
    [AllureSuite("Book Integration Tests")]
    [Collection("ITCollection")]
    public class InteTestBook : IDisposable
    {
        private readonly ITFixture _fixture;
        public InteTestBook(ITFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose() { }

        [AllureXunit]
        public void TestAddBook()
        {
            //Arrange
            int id_book = 4;
            string name = "Book4";
            Book newBook = BookOM.NumberedBook(id_book).buildBL();
            //Action
            int id_newBook = _fixture.bookServices.addBook(newBook);
            //Assert
            Assert.Equal(newBook.Id, id_newBook);
            _fixture.bookServices.deleteBook(id_book);
        }

        [AllureXunit]
        public void TestGetIdBook()
        {
            //Arrange
            string name = "Alex";
            //Action
            int id = _fixture.bookServices.getIdBook(name);
            //Assert
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetBook()
        {
            //Arrange
            int id_book = 1;
            //Action
            Book user = _fixture.bookServices.getBook(id_book);
            //Assert
            Assert.Equal(1, user.Id);
        }
        [AllureXunit]
        public void TestDeleteBook()
        {
            //Arrange
            int id_book = 4;
            //Action
            Book newBook = BookOM.NumberedBook(id_book).buildBL();
            _fixture.bookServices.addBook(newBook);
            int id_newBook = _fixture.bookServices.deleteBook(id_book);
            //Assert
            Assert.Equal(4, id_newBook);
        }
        [AllureXunit]
        public void TestBookGetAll()
        {
            //Action
            List<Book> result = _fixture.bookServices.getAllBook();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 3));
        }
    }
}
