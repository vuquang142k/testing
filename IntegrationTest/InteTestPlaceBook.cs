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
    [AllureSuite("Place Book Integration Tests")]
    [Collection("ITCollection")]
    public class InteTestPlaceBook : IDisposable
    {
        private readonly ITFixture _fixture;
        public InteTestPlaceBook(ITFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose() { }

        [AllureXunit]
        public void TestAddPlaceBook()
        {
            //Arrange
            int id_placebook = 4;
            PlaceBook newPlaceBook = PlaceBookOM.NumberedPlaceBook(id_placebook).buildBL();
            //Action
            int id_newPlaceBook = _fixture.placeServices.addPlaceBook(newPlaceBook);
            //Assert
            Assert.Equal(newPlaceBook.Id, id_newPlaceBook);
            _fixture.placeServices.deletePlaceBook(id_placebook);
        }

        [AllureXunit]
        public void TestGetIdPlaceBook()
        {
            //Arrange
            int shelf = 3;
            int shelving = 4;
            int size_shelf = 3;
            //Action
            int id = _fixture.placeServices.getIdPlaceBook(shelf, shelving, size_shelf);
            //Assert
            Assert.Equal(1, id);
        }
        [AllureXunit]
        public void TestGetPlaceBook()
        {
            //Arrange
            int id_placebook = 1;
            //Action
            PlaceBook placebook = _fixture.placeServices.getPlaceBook(id_placebook);
            //Assert
            Assert.Equal(1, placebook.Id);
        }
        [AllureXunit]
        public void TestDeletePlaceBook()
        {
            //Arrange
            int id_placebook = 4;
            //Action
            PlaceBook newPlaceBook = PlaceBookOM.NumberedPlaceBook(id_placebook).buildBL();
            _fixture.placeServices.addPlaceBook(newPlaceBook);
            int id_newPlaceBook = _fixture.placeServices.deletePlaceBook(id_placebook);
            //Assert
            Assert.Equal(4, id_newPlaceBook);
        }
        [AllureXunit]
        public void TestPlaceBookGetAll()
        {
            //Action
            List<PlaceBook> result = _fixture.placeServices.getAllPlaceBook();

            //Assert
            Assert.Equal(3, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 3));
        }
    }
}
