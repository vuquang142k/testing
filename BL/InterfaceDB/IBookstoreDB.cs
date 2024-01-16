using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceDB
{
    public interface IBookstoreDB
    {
        int addBookstore(Bookstore bookstore);
        int deleteBookstore(int id);
        Bookstore getBookstore(int id);
        List<Bookstore> getAllBookstore();
        int getIdBookstoreByBook(int idbook);
        int getIdBookstoreByPlaceBook(int idplacebook);
    }
}
