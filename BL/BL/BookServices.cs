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
    public class BookServices
    {
        private IBookDB ibookDB;
        public IBookDB IbookDB { get => ibookDB; set => ibookDB = value; }

        public BookServices(IBookDB bookDB)
        {
            this.ibookDB = bookDB;
        }
        public int addBook(Book addbook)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (this.ibookDB.getIdBook(addbook.Name) != -1)
            {
                log.Info("Book exists.");
                throw new BookExistsException();
            }
            log.Info("Library adds new book successfully.");
            return this.ibookDB.addBook(addbook);
            
        }
        public int deleteBook(int id)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Book book = this.IbookDB.getBook(id);
            if (book == null)
            {
                log.Info("Book not found.");
                throw new BookNotFoundException();
            }
            else
            {
                return this.IbookDB.deleteBook(id);
            }
        }
        public Book? getBook(int id)
        {
            Book? book = this.ibookDB.getBook(id);
            if (book == null)
                throw new BookNotFoundException();
            return book;
        }
        public List<Book> getAllBook()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all books.");
            return this.ibookDB.getAllBook();
        }
        public int getIdBook(string name)
        {
            int id = this.ibookDB.getIdBook(name);
            if (id == -1)
                throw new BookNotFoundException();
            else
                return id;
        }
    }
}
