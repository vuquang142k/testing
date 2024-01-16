using BL.Models;
using ModelDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class AppDataContext : DbContext
    {
        private string ConnectionString { get; set; }
        public AppDataContext(string conn)
        {
            ConnectionString = conn;
        }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        public DbSet<AccountDB> Accounts { get; set; }

        public DbSet<BookstoreDB> Bookstores { get; set; }

        public DbSet<BookDB> Books { get; set; }

        public DbSet<BusyBookDB> BusyBooks { get; set; }

        public DbSet<PlaceBookDB> PlaceBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }
    }
}
