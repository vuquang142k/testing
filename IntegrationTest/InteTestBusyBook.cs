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
    [AllureSuite("Busy Book Integration Tests")]
    [Collection("ITCollection")]
    public class InteTestBusyBook : IDisposable
    {
        private readonly ITFixture _fixture;
        public InteTestBusyBook(ITFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose() { }

        [AllureXunit]
        public void TestGetAllBusyBook()
        {
            //Action
            List<BusyBook> result = _fixture.busyBookServices.getAllBusyBook();
            //Assert
            Assert.Equal(2, result.Count);
            Assert.All(result, item => Assert.InRange(item.Id, low: 1, high: 2));
        }

        [AllureXunit]
        public void TestAddBusyBook()
        {
            //Arrange
            int id_busybook = 3;
            BusyBook newBusyBook = BusyBookOM.NumberedBusyBook(id_busybook).buildBL();
            //Action
            int id_newBusyBook = _fixture.busyBookServices.addBusyBook(newBusyBook);
            //Assert
            Assert.Equal(newBusyBook.Id, id_newBusyBook);
        }

        [AllureXunit]
        public void TestGetBusyBook()
        {
            //Arrange
            int id_busybook = 1;
            //Action
            BusyBook busybook = _fixture.busyBookServices.getBusyBook(id_busybook);
            //Assert
            Assert.Equal(1, busybook.Id);
        }

        [AllureXunit]
        public void TestGetIdBusyBookByBook()
        {
            //Arrange
            int id_book = 1;
            //Action
            int id_busybook = _fixture.busyBookServices.getIdBusyBookByBook(id_book);
            //Assert
            Assert.Equal(-1, id_busybook);
        }
    }
}
