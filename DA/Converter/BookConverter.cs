using BL.Models;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Converter
{
    public class BookConverter
    {
        public static Book? DBtoBL(BookDB? book)
        {
            if (book == null) return null;
            return new Book(book.Id, book.Name, book.Dateproduct);
        }
        public static BookDB? BLtoDB(Book? book)
        {
            if (book == null) return null;
            return new BookDB { Id = book.Id, Name = book.Name, Dateproduct = book.Dateproduct };
        }
    }
}
