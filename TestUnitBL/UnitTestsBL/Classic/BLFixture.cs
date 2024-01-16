using BL.BL;
using DA;
using System;
using Xunit;

namespace UnitTests.UnitTestsBL.Classic
{
    public class BLFixture : IDisposable
    {
        private string _connectionString = "Server=localhost;Database=ppo;Username=postgres;Password=quang";
        public AppDataContext Context;
        public BookServices bookService;
        public BLFixture()
        {
            Context = new AppDataContext(_connectionString);
            bookService = new BookServices(new BookDA(Context));
        }
        public void Dispose()
        {
            Context.ChangeTracker.Clear();
            Context.Dispose();
        }
    }
    [CollectionDefinition("BLCollection")]
    public class BLCollection : ICollectionFixture<BLFixture>
    {
    }
}
