using BL.Models;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Converter
{
    public class BusyBookConverter
    {
        public static BusyBook? DBtoBL(BusyBookDB? busybook)
        {
            if (busybook == null) return null;
            return new BusyBook(busybook.Id, busybook.Idbook, busybook.Date_received, busybook.Date_return, busybook.Idaccount);
        }
        public static BusyBookDB? BLtoDB(BusyBook? busybook)
        {
            if (busybook == null) return null;
            return new BusyBookDB { Id = busybook.Id, Idbook = busybook.Idbook, Date_received = busybook.Date_received, Date_return = busybook.Date_return, Idaccount = busybook.Idaccount };
        }
    }
}
