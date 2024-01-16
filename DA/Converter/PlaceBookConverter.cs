using BL.Models;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Converter
{
    public class PlaceBookConverter
    {
        public static PlaceBook? DBtoBL(PlaceBookDB? placebook)
        {
            if (placebook == null) return null;
            return new PlaceBook(placebook.Id, placebook.Shelf, placebook.Shelving, placebook.Size_shelf);
        }
        public static PlaceBookDB? BLtoDB(PlaceBook? placebook)
        {
            if (placebook == null) return null;
            return new PlaceBookDB { Id = placebook.Id, Shelf = placebook.Shelf, Shelving = placebook.Shelving, Size_shelf = placebook.Size_shelf };
        }
    }
}
