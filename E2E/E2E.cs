using Allure.Xunit.Attributes;
using BL.BL;
using BL.Models;
using DA;
using Microsoft.EntityFrameworkCore;
using System;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace E2ETest
{

    [AllureSuite("E2ETest")]
    public class E2E : IDisposable
    {
        private string _conn = "Host=localhost; Port=5432; Database=ppo; Username=postgres; Password=quang";
        private DbContextOptions<AppDataContext> _options;
        private AppDataContext _context;

        public E2E()
        {
            _options = new DbContextOptionsBuilder<AppDataContext>().UseNpgsql(_conn).Options;
            _context = new AppDataContext(_options);
        }
        public void Dispose() { }

        [AllureXunit]
        public void TestSetAndDeleteStudentRoom()
        {
            //Arrange
            BookDA bookDA = new BookDA(_context);
            BookServices bookServices = new BookServices(bookDA);
            int id_book = 4;
            Book newBook = BookOM.NumberedBook(id_book).buildBL();
            //Act
            int id_newBook = bookServices.addBook(newBook);
            //Assert
            Assert.Equal(id_newBook, id_book);

            //End Act
            int id_delBook = bookServices.deleteBook(id_book);
            //End Assert
            Assert.Equal(id_delBook, id_book);
        }
    }
}