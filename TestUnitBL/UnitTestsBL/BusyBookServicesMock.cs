using Allure.Xunit.Attributes;
using BL.BL;
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
    [AllureSuite("Busy Book Services Unit Tests")]
    public class BusyBookServicesMock
    {
        private List<BusyBook> busybooks;
        private List<Book> books;
        private List<Account> accounts;
        private Mock<IBookDB> mockIBookDB;
        private Mock<IAccountDB> mockIAccountDB;

        public BusyBookServicesMock()
        {
            BusyBook busybook1 = BusyBookOM.NumberedBusyBook(1).buildBL();
            BusyBook busybook2 = BusyBookOM.NumberedBusyBook(2).buildBL();
            busybooks = new List<BusyBook>() { busybook1, busybook2 };

            Book book1 = BookOM.NumberedBook(1).buildBL();
            Book book2 = BookOM.NumberedBook(2).buildBL();
            Book book3 = BookOM.NumberedBook(3).buildBL();
            books = new List<Book> { book1, book2, book3 };
            mockIBookDB = new Mock<IBookDB>();
            mockIBookDB.Setup(repo => repo.getBook(2))
                .Returns(books.Where(s => s.Id == 2).FirstOrDefault());

            Account user1 = AccountOM.CreateUser(1).buildBL();
            Account user2 = AccountOM.CreateAdmin(2).buildBL();
            accounts = new List<Account> { user1, user2 };
            mockIAccountDB = new Mock<IAccountDB>();
            mockIAccountDB.Setup(repo => repo.getAccount(1))
                .Returns(accounts.Where(s => s.Id == 1).FirstOrDefault());
        }

        [AllureXunit]
        public void TestAddBusyBook()
        {
            //Arrange
            int id_busybook = 3;
            int id_book = 3;
            int id_account = 2;
            BusyBook newBusyBook = BusyBookOM.NumberedBusyBook(id_busybook).buildBL();
            var mockIBusyBookDB = new Mock<IBusyBookDB>();
            mockIBookDB.Setup(repo => repo.getBook(id_book))
                .Returns(books.Where(s => s.Id == id_book).FirstOrDefault());
            mockIAccountDB.Setup(repo => repo.getAccount(id_account))
                .Returns(accounts.Where(s => s.Id == id_account).FirstOrDefault());
            mockIBusyBookDB.Setup(repo => repo.addBusyBook(newBusyBook))
                .Returns(id_busybook);
            BusyBookServices busybookServices = new BusyBookServices(mockIBusyBookDB.Object, mockIBookDB.Object, mockIAccountDB.Object);
            //Action
            int id_newBusyBook = busybookServices.addBusyBook(newBusyBook);
            //Assert
            mockIBookDB.Verify(repo => repo.getBook(id_book), Times.Once);
            mockIAccountDB.Verify(repo => repo.getAccount(id_account), Times.Once);
            mockIBusyBookDB.Verify(repo => repo.addBusyBook(newBusyBook), Times.Once);
            Assert.Equal(newBusyBook.Id, id_newBusyBook);
        }

        [AllureXunit]
        public void TestGetBusyBook()
        {
            //Arrange
            int id_busybook = 1;
            var mockIBusyBookDB = new Mock<IBusyBookDB>();
            mockIBusyBookDB.Setup(repo => repo.getBusyBook(id_busybook))
                .Returns(busybooks.Where(s => s.Id == id_busybook).FirstOrDefault());
            BusyBookServices busybookServices = new BusyBookServices(mockIBusyBookDB.Object, mockIBookDB.Object, mockIAccountDB.Object);
            //Action
            BusyBook busybook = busybookServices.getBusyBook(id_busybook);
            //Assert
            mockIBusyBookDB.Verify(repo => repo.getBusyBook(id_busybook), Times.Once);
            Assert.Equal(1, busybook.Id);
        }

        [AllureXunit]
        public void TestGetAllBusyBook()
        {
            //Arrange
            var mockIBusyBookDB = new Mock<IBusyBookDB>();
            mockIBusyBookDB.Setup(repo => repo.getAllBusyBook()).Returns(busybooks);
            BusyBookServices busybookServices = new BusyBookServices(mockIBusyBookDB.Object, mockIBookDB.Object, mockIAccountDB.Object);
            //Action
            List<BusyBook> result = busybookServices.getAllBusyBook();
            //Assert
            mockIBusyBookDB.Verify(repo => repo.getAllBusyBook(), Times.Once);
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 2));
        }

        [AllureXunit]
        public void TestGetIdBusyBookByBook()
        {
            //Arrange
            int id_book = 1;
            var mockIBusyBookDB = new Mock<IBusyBookDB>();
            mockIBusyBookDB.Setup(repo => repo.getIdBusyBookByBook(id_book))
                .Returns(busybooks.Where(s => s.Idbook == id_book).FirstOrDefault().Id);
            BusyBookServices busybookServices = new BusyBookServices(mockIBusyBookDB.Object, mockIBookDB.Object, mockIAccountDB.Object);
            //Action
            int id_busybook = busybookServices.getIdBusyBookByBook(id_book);
            //Assert
            mockIBusyBookDB.Verify(repo => repo.getIdBusyBookByBook(id_book), Times.Once);
            Assert.Equal(1, id_busybook);
        }
    }
}
