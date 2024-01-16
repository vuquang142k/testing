using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using DA.Converter;
using Microsoft.EntityFrameworkCore;
using ModelDB;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class BookDA : IBookDB
    {
        private readonly AppDataContext appDataContext;
        public BookDA(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }
        public List<Book> getAllBook()
        {
            List<BookDB> bookdb = appDataContext.Books.ToList();
            List<Book> books = new List<Book>();
            foreach (BookDB book in bookdb)
            {
                Book a = new Book(book.Id, book.Name, book.Dateproduct);
                books.Add(a);
            }
            return books;
        }
        public int addBook(Book addbook)
        {
            List<BookDB>? lst = appDataContext.Books.Count() > 0 ? appDataContext.Books.ToList() : null;
            int maxid = 0;
            foreach (BookDB temp in lst)
                if (temp.Id > maxid)
                    maxid = temp.Id;
            addbook.Id = maxid + 1;
            appDataContext.Books.Add(BookConverter.BLtoDB(addbook));
            appDataContext.SaveChanges();
            return addbook.Id;

        }
        public int getMaxIdBook()
        {
            return appDataContext.Books.Max(u => u.Id);
        }
        public int deleteBook(int id)
        {
            BookDB? book = appDataContext.Books.Where(n => n.Id == id).FirstOrDefault();
            if (book == null)
                throw new AccountNotFoundException();
            appDataContext.Books.Remove(book);
            appDataContext.SaveChanges();
            return book.Id;
        }
        public Book getBook(int id)
        {
            BookDB? book = appDataContext.Books.Where(n => n.Id == id).FirstOrDefault();
            return new Book(book.Id, book.Name, book.Dateproduct);
        }
        public int getIdBook(string name)
        {
            foreach (BookDB temp in this.appDataContext.Books)
                if (temp.Name == name)
                    return BookConverter.DBtoBL(temp).Id;
            return -1;
        }
    }
}
