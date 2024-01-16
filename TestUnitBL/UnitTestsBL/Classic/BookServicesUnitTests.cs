using Allure.Xunit.Attributes;
using BL.Error;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.UnitTestsBL.Classic
{
    [AllureSuite("Classic Book Unit Tests")]
    [Collection("BLCollection")]
    public class BookServicesUnitTests : IDisposable
    {
        private BLFixture _fixture;
        public BookServicesUnitTests(BLFixture fixture)
        {
            _fixture = fixture;
        }
        public void Dispose() { }

        [AllureXunit]
        public void TestGetAllBook()
        {
            //Arrange
            int bookCount = _fixture.Context.Books.Count();
            //Act
            List<Book> result = _fixture.bookService.getAllBook();
            //Assert
            Assert.Equal(bookCount, result.Count);
        }
        
    }
}
