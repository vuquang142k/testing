using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceDB
{
    public interface IPlaceBookDB
    {
        int addPlaceBook(PlaceBook placebook);
        int deletePlaceBook(int id);
        PlaceBook? getPlaceBook(int id);
        List<PlaceBook> getAllPlaceBook();
        int getIdPlaceBook(int shelf, int shelving, int size_shelf);
    }
}
