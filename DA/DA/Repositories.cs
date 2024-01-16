using BL.InterfaceDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.DA
{
    public class Repositories
    {
        private readonly string conn;

        public Repositories(string conn)
        {
            this.conn = conn;
        }

        public IAccountDB CreateAccountDB()
        {
            return new AccountDA(new AppDataContext(conn));
        }
        public IBookDB CreateBookDB()
        {
            return new BookDA(new AppDataContext(conn));
        }
        public IBookstoreDB CreateBookstoreDB()
        {
            return new BookstoreDA(new AppDataContext(conn));
        }
        public IBusyBookDB CreateBusyBookDB()
        {
            return new BusyBookDA(new AppDataContext(conn));
        }
        public IPlaceBookDB CreatePlaceBookDB()
        {
            return new PlaceBookDA(new AppDataContext(conn));
        }
    }
}
