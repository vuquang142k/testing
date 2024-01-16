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
    [AllureSuite("Place Book Services Unit Tests")]
    public class PlaceBookServicesMock
    {
        private List<PlaceBook> placebooks;
        public PlaceBookServicesMock()
        {
            PlaceBook placebook1 = PlaceBookOM.NumberedPlaceBook(1).buildBL();
            PlaceBook placebook2 = PlaceBookOM.NumberedPlaceBook(2).buildBL();
            PlaceBook placebook3 = PlaceBookOM.NumberedPlaceBook(3).buildBL();
            placebooks = new List<PlaceBook>() { placebook1, placebook2, placebook3 };
        }

        [AllureXunit]
        public void TestAddPlaceBook()
        {
            //Arrange
            int id_placebook = 4;
            int shelf = 4;
            int shelving = 4;
            int size_shelf = 4;
            PlaceBook newPlaceBook = PlaceBookOM.NumberedPlaceBook(id_placebook).buildBL();
            var mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.getIdPlaceBook(shelf, shelving, size_shelf))
                .Returns(-1);
            mockIPlaceBookDB.Setup(repo => repo.addPlaceBook(newPlaceBook))
                .Returns(id_placebook);
            PlaceBookServices placebookServices = new PlaceBookServices(mockIPlaceBookDB.Object);
            //Action
            int id_newPlaceBook = placebookServices.addPlaceBook(newPlaceBook);
            //Assert
            mockIPlaceBookDB.Verify(repo => repo.getIdPlaceBook(shelf, shelving, size_shelf), Times.Once);
            mockIPlaceBookDB.Verify(repo => repo.addPlaceBook(newPlaceBook), Times.Once);
            Assert.Equal(newPlaceBook.Id, id_newPlaceBook);
        }

        [AllureXunit]
        public void TestAddExistsPlaceBook()
        {
            //Arrange
            int id_placebook = 1;
            PlaceBook newPlaceBook = PlaceBookOM.NumberedPlaceBook(id_placebook).buildBL();
            var mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.getPlaceBook(newPlaceBook.Id))
                .Returns(newPlaceBook);
            PlaceBookServices placebookServices = new PlaceBookServices(mockIPlaceBookDB.Object);
            //Action & Assert
            Assert.Throws<PlaceBookExistsException>(() => placebookServices.addPlaceBook(newPlaceBook));
        }
        [AllureXunit]
        public void TestGetIdPlaceBook()
        {
            //Arrange
            int shelf = 1;
            int shelving = 1;
            int size_shelf = 1;
            var mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.getIdPlaceBook(shelf, shelving, size_shelf))
                .Returns(placebooks.Where(s => s.Shelf == shelf && s.Shelving == shelving && s.Size_shelf == size_shelf).FirstOrDefault().Id);
            PlaceBookServices placebookServices = new PlaceBookServices(mockIPlaceBookDB.Object);
            //Action
            int id = placebookServices.getIdPlaceBook(shelf, shelving, size_shelf);
            //Assert
            mockIPlaceBookDB.Verify(repo => repo.getIdPlaceBook(shelf, shelving, size_shelf), Times.Once);
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetPlaceBook()
        {
            //Arrange
            int id_placebook = 1;
            var mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.getPlaceBook(id_placebook))
                .Returns(placebooks.Where(s => s.Id == id_placebook).FirstOrDefault());
            PlaceBookServices placebookServices = new PlaceBookServices(mockIPlaceBookDB.Object);
            //Action
            PlaceBook placebook = placebookServices.getPlaceBook(id_placebook);
            //Assert
            mockIPlaceBookDB.Verify(repo => repo.getPlaceBook(id_placebook), Times.Once);
            Assert.Equal(1, placebook.Id);
        }
        [AllureXunit]
        public void TestDeletePlaceBook()
        {
            //Arrange
            int id_placebook = 1;
            var mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.deletePlaceBook(id_placebook))
                .Returns(id_placebook);
            mockIPlaceBookDB.Setup(repo => repo.getPlaceBook(id_placebook))
                .Returns(placebooks.Where(s => s.Id == id_placebook).FirstOrDefault());
            PlaceBookServices placebookServices = new PlaceBookServices(mockIPlaceBookDB.Object);
            //Action
            int id_newPlaceBook = placebookServices.deletePlaceBook(id_placebook);
            //Assert
            mockIPlaceBookDB.Verify(repo => repo.deletePlaceBook(id_placebook), Times.Once);
            mockIPlaceBookDB.Verify(repo => repo.getPlaceBook(id_placebook), Times.Once);
            Assert.Equal(1, id_newPlaceBook);
        }
        [AllureXunit]
        public void TestPlaceBookGetAll()
        {
            // Arrange
            var mockIPlaceBookDB = new Mock<IPlaceBookDB>();
            mockIPlaceBookDB.Setup(repo => repo.getAllPlaceBook()).Returns(placebooks);
            PlaceBookServices placebookServices = new PlaceBookServices(mockIPlaceBookDB.Object);

            //Action
            List<PlaceBook> result = placebookServices.getAllPlaceBook();

            //Assert
            mockIPlaceBookDB.Verify(repo => repo.getAllPlaceBook(), Times.Once);
            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 3));
        }
    }
}
