using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL
{
    public class BookstoreServices
    {
        private IBookstoreDB ibookstoreDB;
        private readonly IBookDB ibookDB;
        private readonly IPlaceBookDB iplacebookDB;
        public IBookstoreDB IbookstoreDB { get => ibookstoreDB; set => ibookstoreDB = value; }

        public BookstoreServices(IBookstoreDB ibookstoreDB, IBookDB ibookDB, IPlaceBookDB iplacebookDB)
        {
            this.ibookstoreDB = ibookstoreDB;
            this.iplacebookDB = iplacebookDB;
            this.ibookDB = ibookDB;
        }
        public int addBookstore(Bookstore bookstore)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (iplacebookDB.getPlaceBook(bookstore.Idplace) == null)
            {
                log.Info("Library adds bookstore unsuccessfully.");
                throw new PlaceBookNotFoundException();
            }
            else if (ibookDB.getBook(bookstore.Idbook) == null)
            {
                log.Info("Library adds bookstore unsuccessfully.");
                throw new BookNotFoundException();
            }
            else
            {
                log.Info("Library adds bookstore successfully.");
                return this.ibookstoreDB.addBookstore(bookstore);
            }
        }
        public int deleteBookstore(int id)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Bookstore bookstore = this.IbookstoreDB.getBookstore(id);
            if (bookstore == null)
            {
                log.Info("Library deletes bookstore unsuccessfully.");
                throw new BookstoreNotFoundException();
            }
            else
            {
                return this.IbookstoreDB.deleteBookstore(id);
            }
        }
        public Bookstore getBookstore(int id)
        {
            Bookstore? bookstore = this.ibookstoreDB.getBookstore(id);
            if (bookstore == null)
                throw new BookstoreNotFoundException();
            return bookstore;
        }
        public List<Bookstore> getAllBookstore()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all bookstores.");
            return this.ibookstoreDB.getAllBookstore();
        }
        public int getIdBookstoreByBook(int idbook)
        {
            int id = this.ibookstoreDB.getIdBookstoreByBook(idbook);
            return id;
        }
        public int getIdBookstoreByPlaceBook(int idplacebook)
        {
            int id = this.ibookstoreDB.getIdBookstoreByPlaceBook(idplacebook);
            return id;
        }
    }
}
