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
    public class PlaceBookDA : IPlaceBookDB
    {
        private readonly AppDataContext appDataContext;
        public PlaceBookDA(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }
        public List<PlaceBook> getAllPlaceBook()
        {
            List<PlaceBookDB> placebookdb = appDataContext.PlaceBooks.ToList();
            List<PlaceBook> placebooks = new List<PlaceBook>();
            foreach (PlaceBookDB placebook in placebookdb)
            {
                PlaceBook a = new PlaceBook(placebook.Id, placebook.Shelf, placebook.Shelving, placebook.Size_shelf);
                placebooks.Add(a);
            }
            return placebooks;
        }
        public int addPlaceBook(PlaceBook placebook)
        {
            List<PlaceBookDB>? lst = appDataContext.PlaceBooks.Count() > 0 ? appDataContext.PlaceBooks.ToList() : null;
            int maxid = 0;
            foreach (PlaceBookDB temp in lst)
                if (temp.Id > maxid)
                    maxid = temp.Id;
            placebook.Id = maxid + 1;
            appDataContext.PlaceBooks.Add(PlaceBookConverter.BLtoDB(placebook));
            appDataContext.SaveChanges();
            return placebook.Id;

        }
        public int deletePlaceBook(int id)
        {
            PlaceBookDB? placebook = appDataContext.PlaceBooks.Where(n => n.Id == id).FirstOrDefault();
            if (placebook == null)
                throw new PlaceBookNotFoundException();
            appDataContext.PlaceBooks.Remove(placebook);
            appDataContext.SaveChanges();
            return placebook.Id;
        }
        public PlaceBook getPlaceBook(int id)
        {
            PlaceBookDB? placebook = appDataContext.PlaceBooks.Where(n => n.Id == id).FirstOrDefault();
            return new PlaceBook(placebook.Id, placebook.Shelf, placebook.Shelving, placebook.Size_shelf);
        }
        public int getIdPlaceBook(int shelf, int shelving, int size_shelf)
        {
            foreach (PlaceBookDB temp in this.appDataContext.PlaceBooks)
                if (temp.Shelf == shelf && temp.Shelving == shelving && temp.Size_shelf == size_shelf)
                    return PlaceBookConverter.DBtoBL(temp).Id;
            return -1;
        }
    }
}
