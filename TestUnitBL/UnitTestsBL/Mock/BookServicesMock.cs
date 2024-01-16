using Allure.Xunit.Attributes;
using BL.BL;
using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using Moq;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace UnitTests.UnitTestsBL.Mock
{
    [AllureOwner("Quang")]
    [AllureSuite("Book Services Unit Tests")]
    public class BookServicesMock
    {
        private List<Book> books;
        public BookServicesMock()
        {
            Book book1 = BookOM.NumberedBook(1).buildBL();
            Book book2 = BookOM.NumberedBook(2).buildBL();
            Book book3 = BookOM.NumberedBook(3).buildBL();
            books = new List<Book>() { book1, book2, book3 };
        }

        [AllureXunit]
        public void TestAddBook()
        {
            //Arrange
            int id_book = 4;
            string name = "Book4";
            Book newBook = BookOM.NumberedBook(id_book).buildBL();
            var mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.getIdBook(name))
                .Returns(-1);
            mockIBookDB.Setup(repo => repo.addBook(newBook))
                .Returns(id_book);
            BookServices bookServices = new BookServices(mockIBookDB.Object);
            //Action
            int id_newBook = bookServices.addBook(newBook);
            //Assert
            mockIBookDB.Verify(repo => repo.getIdBook(name), Times.Once);
            mockIBookDB.Verify(repo => repo.addBook(newBook), Times.Once);
            Assert.Equal(newBook.Id, id_newBook);
        }

        [AllureXunit]
        public void TestAddExistsBook()
        {
            //Arrange
            int id_book = 1;
            Book newBook = BookOM.NumberedBook(id_book).buildBL();
            var mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.addBook(newBook))
                .Returns(id_book);
            BookServices bookServices = new BookServices(mockIBookDB.Object);
            //Action & Assert
            Assert.Throws<BookExistsException>(() => bookServices.addBook(newBook));
        }

        [AllureXunit]
        public void TestGetIdBook()
        {
            //Arrange
            string name = "Book1";
            var mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.getIdBook(name))
                .Returns(books.Where(s => s.Name == name).FirstOrDefault().Id);
            BookServices bookServices = new BookServices(mockIBookDB.Object);
            //Action
            int id = bookServices.getIdBook(name);
            //Assert
            mockIBookDB.Verify(repo => repo.getIdBook(name), Times.Once);
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetBook()
        {
            //Arrange
            int id_user = 1;
            var mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.getBook(id_user))
                .Returns(books.Where(s => s.Id == id_user).FirstOrDefault());
            BookServices bookServices = new BookServices(mockIBookDB.Object);
            //Action
            Book user = bookServices.getBook(id_user);
            //Assert
            mockIBookDB.Verify(repo => repo.getBook(id_user), Times.Once);
            Assert.Equal(1, user.Id);
        }
        [AllureXunit]
        public void TestDeleteBook()
        {
            //Arrange
            int id_user = 1;
            var mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.deleteBook(id_user))
                .Returns(id_user);
            mockIBookDB.Setup(repo => repo.getBook(id_user))
                .Returns(books.Where(s => s.Id == id_user).FirstOrDefault());
            BookServices bookServices = new BookServices(mockIBookDB.Object);
            //Action
            int id_newBook = bookServices.deleteBook(id_user);
            //Assert
            mockIBookDB.Verify(repo => repo.deleteBook(id_user), Times.Once);
            mockIBookDB.Verify(repo => repo.getBook(id_user), Times.Once);
            Assert.Equal(1, id_newBook);
        }
        [AllureXunit]
        public void TestBookGetAll()
        {
            // Arrange
            var mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.getAllBook()).Returns(books);
            BookServices bookServices = new BookServices(mockIBookDB.Object);

            //Action
            List<Book> result = bookServices.getAllBook();

            //Assert
            mockIBookDB.Verify(repo => repo.getAllBook(), Times.Once);
            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 3));
        }
    }
}
