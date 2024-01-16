using BL.Models;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Converter
{
    public class BookstoreConverter
    {
        public static Bookstore? DBtoBL(BookstoreDB? bookstore)
        {
            if (bookstore == null) return null;
            return new Bookstore(bookstore.Id, bookstore.Idbook, bookstore.Idplace, bookstore.Count);
        }
        public static BookstoreDB? BLtoDB(Bookstore? bookstore)
        {
            if (bookstore == null) return null;
            return new BookstoreDB { Id = bookstore.Id, Idbook = bookstore.Idbook, Idplace = bookstore.Idplace, Count = bookstore.Count };
        }
    }
}
