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
    public class BusyBookDA : IBusyBookDB
    {
        private readonly AppDataContext appDataContext;
        public BusyBookDA(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }
        public List<BusyBook> getAllBusyBook()
        {
            List<BusyBookDB> busybookdb = appDataContext.BusyBooks.ToList();
            List<BusyBook> busybooks = new List<BusyBook>();
            foreach (BusyBookDB busybook in busybookdb)
            {
                BusyBook a = new BusyBook(busybook.Id, busybook.Idbook, busybook.Date_received, busybook.Date_return, busybook.Idaccount);
                busybooks.Add(a);
            }
            return busybooks;
        }
        public int addBusyBook(BusyBook busybook)
        {
            List<BusyBookDB>? lst = appDataContext.BusyBooks.Count() > 0 ? appDataContext.BusyBooks.ToList() : null;
            int maxid = 0;
            foreach (BusyBookDB temp in lst)
                if (temp.Id > maxid)
                    maxid = temp.Id;
            busybook.Id = maxid + 1;
            appDataContext.BusyBooks.Add(BusyBookConverter.BLtoDB(busybook));
            appDataContext.SaveChanges();
            return busybook.Id;
        }

        public BusyBook getBusyBook(int id)
        {
            BusyBookDB? busybook = appDataContext.BusyBooks.Where(n => n.Id == id).FirstOrDefault();
            return new BusyBook(busybook.Id, busybook.Idbook, busybook.Date_received, busybook.Date_return, busybook.Idaccount);
        }
        public int getIdBusyBookByBook(int idbook)
        {
            foreach (BusyBookDB temp in this.appDataContext.BusyBooks)
                if (temp.Idbook == idbook && temp.Date_return == "Null")
                    return BusyBookConverter.DBtoBL(temp).Id;
            return -1;
        }
        
    }
}
