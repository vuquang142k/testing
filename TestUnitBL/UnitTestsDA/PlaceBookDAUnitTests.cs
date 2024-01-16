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
    [AllureSuite("Place Book DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class PlaceBookDAUnitTests : IDisposable
    {
        private DBFixture fixture;
        public PlaceBookDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public async void TestAddPlaceBook()
        {
            //Arrange
            int id_placebook = 3;
            PlaceBook placebook = PlaceBookOM.NumberedPlaceBook(id_placebook).buildBL();
            int count = fixture.context.PlaceBooks.Count() + 1;
            //Action
            fixture.placebookDA.addPlaceBook(placebook);
            //Assert
            Assert.Equal(count, fixture.context.PlaceBooks.Count());
        }

        [AllureXunit]
        public void TestGetIdPlaceBook()
        {
            //Arrange
            int id_placebook = 2;
            int shelf = 2;
            int shelving = 2;
            int size_shelf = 2;
            //Action
            int result = fixture.placebookDA.getIdPlaceBook(shelf, shelving, size_shelf);
            //Assert
            Assert.Equal(id_placebook, result);
        }

        [AllureXunit]
        public void TestGetPlaceBook()
        {
            //Arrange
            int id_placebook = 2;
            //Action
            var result = fixture.placebookDA.getPlaceBook(id_placebook);
            //Assert
            Assert.Equal(id_placebook, result.Id);
        }

        [AllureXunit]
        public async void TestDeletePlaceBook()
        {
            //Arrange
            int id_placebook = 1;
            int count = fixture.context.PlaceBooks.Count() - 1;
            //Action
            fixture.placebookDA.deletePlaceBook(id_placebook);
            //Assert
            Assert.Equal(count, fixture.context.PlaceBooks.Count());
        }

        [AllureXunit]
        public async void TestGetAllPlaceBook()
        {
            //Arrange
            int count = fixture.context.PlaceBooks.Count();
            //Action
            var result = fixture.placebookDA.getAllPlaceBook();
            //Assert
            Assert.Equal(count, result.Count);
        }
    }
}
