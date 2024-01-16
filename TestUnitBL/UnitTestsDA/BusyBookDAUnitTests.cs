using Allure.Xunit.Attributes;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using UnitTests.UnitTestsBL.Classic;
using Xunit;

namespace UnitTests.UnitTestsDA
{
    [AllureOwner("Quang")]
    [AllureSuite("Busy Book DataAccess Unit Tests")]
    [Collection("DBCollection")]
    public class BusyBookDAUnitTests
    {
        private DBFixture fixture;
        public BusyBookDAUnitTests(DBFixture _dbFixture)
        {
            fixture = _dbFixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public async void TestAddBusyBook()
        {
            //Arrange
            int id_busybook = 2;
            BusyBook busybook = BusyBookOM.NumberedBusyBook(id_busybook).buildBL();
            int count = fixture.context.BusyBooks.Count() + 1;
            //Action
            fixture.busybookDA.addBusyBook(busybook);
            //Assert
            Assert.Equal(count, fixture.context.BusyBooks.Count());
        }

        [AllureXunit]
        public void TestGetIdBusyBookByBook()
        {
            //Arrange
            int id_busybook = 2;
            int id_book = 2;
            //Action
            int result = fixture.busybookDA.getIdBusyBookByBook(id_book);
            //Assert
            Assert.Equal(id_busybook, result);
        }

        [AllureXunit]
        public void TestGetBusyBook()
        {
            //Arrange
            int id_busybook = 2;
            //Action
            var result = fixture.busybookDA.getBusyBook(id_busybook);
            //Assert
            Assert.Equal(id_busybook, result.Id);
        }

        [AllureXunit]
        public async void TestGetAllBusyBook()
        {
            //Arrange
            int count = fixture.context.BusyBooks.Count();
            //Action
            var result = fixture.busybookDA.getAllBusyBook();
            //Assert
            Assert.Equal(count, result.Count);
        }
    }
}
