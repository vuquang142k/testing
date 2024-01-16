using DA;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.ObjectMothers;
using Xunit;

namespace UnitTests.UnitTestsDA
{
    public class DBFixture : IDisposable
    {
        private DbContextOptions<AppDataContext> _options;
        public AppDataContext context;
        public AccountDA accountDA;
        public BookDA bookDA;
        public BookstoreDA bookstoreDA;
        public BusyBookDA busybookDA;
        public PlaceBookDA placebookDA;
        public DBFixture()
        {
            _options = new DbContextOptionsBuilder<AppDataContext>()
                            .UseInMemoryDatabase(databaseName: "app")
                            .Options;
            context = new AppDataContext(_options);

            //Accounts
            context.Accounts.Add(AccountOM.CreateUser(1).buildDA());
            context.Accounts.Add(AccountOM.CreateAdmin(2).buildDA());

            //Books
            context.Books.Add(BookOM.NumberedBook(1).buildDA());
            context.Books.Add(BookOM.NumberedBook(2).buildDA());
            context.Books.Add(BookOM.NumberedBook(3).buildDA());

            //Bookstores
            context.Bookstores.Add(BookstoreOM.NumberedBookstore(1).buildDA());
            context.Bookstores.Add(BookstoreOM.NumberedBookstore(2).buildDA());

            //BusyBooks
            context.BusyBooks.Add(BusyBookOM.NumberedBusyBook(1).buildDA());
            context.BusyBooks.Add(BusyBookOM.NumberedBusyBook(2).buildDate_return("Null").buildDA());

            //PlaceBooks
            context.PlaceBooks.Add(PlaceBookOM.NumberedPlaceBook(1).buildDA());
            context.PlaceBooks.Add(PlaceBookOM.NumberedPlaceBook(2).buildDA());

            context.SaveChanges();

            accountDA = new AccountDA(context);
            bookDA = new BookDA(context);
            bookstoreDA = new BookstoreDA(context);
            busybookDA = new BusyBookDA(context);
            placebookDA = new PlaceBookDA(context);
        }
        public void Dispose()
        {
            context.ChangeTracker.Clear();
            context.Dispose();
        }
        [CollectionDefinition("DBCollection")]
        public class DBCollection : ICollectionFixture<DBFixture>
        {

        }
    }
}
