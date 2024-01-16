using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BL.BL
{
    public class PlaceBookServices
    {
        private IPlaceBookDB iplacebookDB;
        public IPlaceBookDB IplacebookDB { get => iplacebookDB; set => iplacebookDB = value; }

        public PlaceBookServices(IPlaceBookDB placebookDB)
        {
            this.iplacebookDB = placebookDB;
        }
        public int addPlaceBook(PlaceBook placebook)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (this.iplacebookDB.getIdPlaceBook(placebook.Shelf, placebook.Shelving, placebook.Size_shelf) != -1)
            {
                log.Info("User adds placebook unsuccessfully.");
                throw new PlaceBookExistsException();
            }
            log.Info("User adds placebook successfully.");
            return this.iplacebookDB.addPlaceBook(placebook);
        }
        public int deletePlaceBook(int id)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            PlaceBook placebook = this.IplacebookDB.getPlaceBook(id);
            if (placebook == null)
            {
                log.Info("User deletes placebook unsuccessfully.");
                throw new PlaceBookNotFoundException();
            }
            else
            {
                return this.IplacebookDB.deletePlaceBook(id);
            }
        }
        public PlaceBook? getPlaceBook(int id)
        {
            PlaceBook? placebook = this.iplacebookDB.getPlaceBook(id);
            if (placebook == null)
                throw new PlaceBookNotFoundException();
            return placebook;
        }
        public List<PlaceBook> getAllPlaceBook()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all placebooks.");
            return this.iplacebookDB.getAllPlaceBook();
        }
        public int getIdPlaceBook(int shelf, int shelving, int size_shelf)
        {
            int id = this.iplacebookDB.getIdPlaceBook(shelf, shelving, size_shelf);
            if (id == -1)
                throw new PlaceBookNotFoundException();
            else
                return id;
        }
    }
}
