using Microsoft.EntityFrameworkCore;
using Xunit;
using DA;
using BL;
using BL.BL;

namespace IntegrationTests
{
    public class ITFixture : IDisposable
    {
        private string _conn = "Server=localhost;Database=ppo;Username=postgres;Password=quang";
        private DbContextOptions<AppDataContext> _options;

        public AppDataContext Context;
        public AccountServices accountServices;
        public BookServices bookServices;
        public BookstoreServices bookstoreServices;
        public BusyBookServices busyBookServices;
        public PlaceBookServices placeServices;
        public ITFixture()
        {
            _options = new DbContextOptionsBuilder<AppDataContext>()
                                .UseNpgsql(_conn)
                                .Options;
            Context = new AppDataContext(_options);

            AccountDA accountDA = new AccountDA(Context);
            BookDA bookDA = new BookDA(Context);
            BookstoreDA bookstoreDA = new BookstoreDA(Context);
            BusyBookDA busyBookDA = new BusyBookDA(Context);
            PlaceBookDA placeBookDA = new PlaceBookDA(Context);

            accountServices = new AccountServices(accountDA);
            bookServices = new BookServices(bookDA);
            bookstoreServices = new BookstoreServices(bookstoreDA, bookDA, placeBookDA);
            busyBookServices = new BusyBookServices(busyBookDA, bookDA, accountDA);
            placeServices = new PlaceBookServices(placeBookDA);
        }

        public void Dispose()
        {
            Context.ChangeTracker.Clear();
            Context.Dispose();
        }
    }

    [CollectionDefinition("ITCollection")]
    public class ITCollection : ICollectionFixture<ITFixture>
    {
    }
}