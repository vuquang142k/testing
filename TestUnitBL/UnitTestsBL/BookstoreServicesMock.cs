using Allure.Xunit.Attributes;
using BL.BL;
using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace UnitTests.UnitTestsBL.Mock
{
    [AllureOwner("Quang")]
    [AllureSuite("Bookstore Services Unit Tests")]
    public class BookstoreServicesMock
    {
        private List<Bookstore> bookstores;
        private List<Book> books;
        private List<PlaceBook> placebooks;
        private Mock<IBookDB> mockIBookDB;
        private Mock<IPlaceBookDB> mockIPlaceBookDB;
        public BookstoreServicesMock()
        {
            Bookstore bookstore1 = BookstoreOM.NumberedBookstore(1).buildBL();
            Bookstore bookstore2 = BookstoreOM.NumberedBookstore(2).buildBL();
            bookstores = new List<Bookstore>() { bookstore1, bookstore2 };

            Book book1 = BookOM.NumberedBook(1).buildBL();
            Book book2 = BookOM.NumberedBook(2).buildBL();
            Book book3 = BookOM.NumberedBook(3).buildBL();
            books = new List<Book> { book1, book2, book3 };
            mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.getBook(2))
                .Returns(books.Where(s => s.Id == 2).FirstOrDefault());

            PlaceBook placebook1 = PlaceBookOM.NumberedPlaceBook(1).buildBL();
            PlaceBook placebook2 = PlaceBookOM.NumberedPlaceBook(2).buildBL();
            PlaceBook placebook3 = PlaceBookOM.NumberedPlaceBook(3).buildBL();
            placebooks = new List<PlaceBook> { placebook1, placebook2, placebook3 };
            mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.getPlaceBook(1))
                .Returns(placebooks.Where(s => s.Id == 1).FirstOrDefault());
        }

        [AllureXunit]
        public void TestAddBookstore()
        {
            //Arrange
            int id_bookstore = 3;
            int id_book = 3;
            int id_placebook = 3;
            Bookstore newBookstore = BookstoreOM.NumberedBookstore(id_bookstore).buildBL();
            var mockIBookstoreDB = new Mock<IBookstoreDB>();
            mockIBookDB.Setup(repo => repo.getBook(id_book))
                .Returns(books.Where(s => s.Id == id_book).FirstOrDefault());
            mockIPlaceBookDB.Setup(repo => repo.getPlaceBook(id_placebook))
                .Returns(placebooks.Where(s => s.Id == id_placebook).FirstOrDefault());
            mockIBookstoreDB.Setup(repo => repo.addBookstore(newBookstore))
                .Returns(id_bookstore);
            BookstoreServices bookstoreServices = new BookstoreServices(mockIBookstoreDB.Object, mockIBookDB.Object, mockIPlaceBookDB.Object);
            //Action
            int id_newBookstore = bookstoreServices.addBookstore(newBookstore);
            //Assert
            mockIBookDB.Verify(repo => repo.getBook(id_book), Times.Once);
            mockIPlaceBookDB.Verify(repo => repo.getPlaceBook(id_placebook), Times.Once);
            mockIBookstoreDB.Verify(repo => repo.addBookstore(newBookstore), Times.Once);
            Assert.Equal(newBookstore.Id, id_newBookstore);
        }

        [AllureXunit]
        public void TestFailAddBookstore()
        {
            //Arrange
            int id_bookstore = 3;
            int id_book = 1;
            int id_placebook = 4;
            Bookstore newBookstore = BookstoreOM.NumberedBookstore(id_bookstore).buildBL();
            var mockIBookstoreDB = new Mock<IBookstoreDB>();
            mockIBookstoreDB.Setup(repo => repo.addBookstore(newBookstore))
                .Returns(id_bookstore);
            BookstoreServices bookstoreServices = new BookstoreServices(mockIBookstoreDB.Object, mockIBookDB.Object, mockIPlaceBookDB.Object);
            //Action && Assert
            Assert.Throws<PlaceBookNotFoundException>(() => bookstoreServices.addBookstore(newBookstore));
        }

        [AllureXunit]
        public void TestGetBookstore()
        {
            //Arrange
            int id_bookstore = 1;
            var mockIBookstoreDB = new Mock<IBookstoreDB>();
            mockIBookstoreDB.Setup(repo => repo.getBookstore(id_bookstore))
                .Returns(bookstores.Where(s => s.Id == id_bookstore).FirstOrDefault());
            BookstoreServices bookstoreServices = new BookstoreServices(mockIBookstoreDB.Object, mockIBookDB.Object, mockIPlaceBookDB.Object);
            //Action
            Bookstore bookstore = bookstoreServices.getBookstore(id_bookstore);
            //Assert
            mockIBookstoreDB.Verify(repo => repo.getBookstore(id_bookstore), Times.Once);
            Assert.Equal(1, bookstore.Id);
        }

        [AllureXunit]
        public void TestGetAllBookstore()
        {
            //Arrange
            var mockIBookstoreDB = new Mock<IBookstoreDB>();
            mockIBookstoreDB.Setup(repo => repo.getAllBookstore()).Returns(bookstores);
            BookstoreServices bookstoreServices = new BookstoreServices(mockIBookstoreDB.Object, mockIBookDB.Object, mockIPlaceBookDB.Object);
            //Action
            List<Bookstore> result = bookstoreServices.getAllBookstore();
            //Assert
            mockIBookstoreDB.Verify(repo => repo.getAllBookstore(), Times.Once);
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 2));
        }

        [AllureXunit]
        public void TestGetIdBookstoreByBook()
        {
            //Arrange
            int id_book = 1;
            var mockIBookstoreDB = new Mock<IBookstoreDB>();
            mockIBookstoreDB.Setup(repo => repo.getIdBookstoreByBook(id_book))
                .Returns(bookstores.Where(s => s.Idbook == id_book).FirstOrDefault().Id);
            BookstoreServices bookstoreServices = new BookstoreServices(mockIBookstoreDB.Object, mockIBookDB.Object, mockIPlaceBookDB.Object);
            //Action
            int id_bookstore = bookstoreServices.getIdBookstoreByBook(id_book);
            //Assert
            mockIBookstoreDB.Verify(repo => repo.getIdBookstoreByBook(id_book), Times.Once);
            Assert.Equal(1, id_bookstore);
        }

        [AllureXunit]
        public void TestGetIdBookstoreByPlaceBook()
        {
            //Arrange
            int id_placebook = 1;
            var mockIBookstoreDB = new Mock<IBookstoreDB>();
            mockIBookstoreDB.Setup(repo => repo.getIdBookstoreByPlaceBook(id_placebook))
                .Returns(bookstores.Where(s => s.Idplace == id_placebook).FirstOrDefault().Id);
            BookstoreServices bookstoreServices = new BookstoreServices(mockIBookstoreDB.Object, mockIBookDB.Object, mockIPlaceBookDB.Object);
            //Action
            int id_bookstore = bookstoreServices.getIdBookstoreByPlaceBook(id_placebook);
            //Assert
            mockIBookstoreDB.Verify(repo => repo.getIdBookstoreByPlaceBook(id_placebook), Times.Once);
            Assert.Equal(1, id_bookstore);
        }
    }
}
