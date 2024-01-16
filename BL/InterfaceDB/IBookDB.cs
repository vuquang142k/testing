using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceDB
{
    public interface IBookDB
    {
        int addBook(Book book);
        int deleteBook(int id);
        Book? getBook(int id);
        List<Book> getAllBook();
        int getIdBook(string name);
    }
}
