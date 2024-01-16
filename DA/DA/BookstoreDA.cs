using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using DA.Converter;
using Microsoft.EntityFrameworkCore;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class BookstoreDA : IBookstoreDB
    {
        private readonly AppDataContext appDataContext;
        public BookstoreDA(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }
        public List<Bookstore> getAllBookstore()
        {
            List<BookstoreDB> bookstoredb = appDataContext.Bookstores.ToList();
            List<Bookstore> bookstores = new List<Bookstore>();
            foreach (BookstoreDB bookstore in bookstoredb)
            {
                Bookstore a = new Bookstore(bookstore.Id, bookstore.Idbook, bookstore.Idplace, bookstore.Count);
                bookstores.Add(a);
            }
            return bookstores;
        }
        public int addBookstore(Bookstore bookstore)
        {
            List<BookstoreDB>? lst = appDataContext.Bookstores.Count() > 0 ? appDataContext.Bookstores.ToList() : null;
            int maxid = 0;
            foreach (BookstoreDB temp in lst)
                if (temp.Id > maxid)
                    maxid = temp.Id;
            bookstore.Id = maxid + 1;
            appDataContext.Bookstores.Add(BookstoreConverter.BLtoDB(bookstore));
            appDataContext.SaveChanges();
            return bookstore.Id;

        }
        public int deleteBookstore(int id)
        {
            BookstoreDB? bookstore = appDataContext.Bookstores.Where(n => n.Id == id).FirstOrDefault();
            if (bookstore == null)
                throw new BookstoreNotFoundException();
            appDataContext.Bookstores.Remove(bookstore);
            appDataContext.SaveChanges();
            return bookstore.Id;
        }
        public Bookstore getBookstore(int id)
        {
            BookstoreDB? bookstore = appDataContext.Bookstores.Where(n => n.Id == id).FirstOrDefault();
            return new Bookstore(bookstore.Id, bookstore.Idbook, bookstore.Idplace, bookstore.Count);
        }
        public int getIdBookstoreByBook(int idbook)
        {
            foreach (BookstoreDB temp in this.appDataContext.Bookstores)
                if (temp.Idbook == idbook)
                    return BookstoreConverter.DBtoBL(temp).Id;
            return -1;
        }
        public int getIdBookstoreByPlaceBook(int idplacebook)
        {
            foreach (BookstoreDB temp in this.appDataContext.Bookstores)
                if (temp.Idplace == idplacebook)
                    return BookstoreConverter.DBtoBL(temp).Id;
            return -1;
        }
    }
}
