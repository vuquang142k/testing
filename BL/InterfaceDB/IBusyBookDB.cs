using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.InterfaceDB
{
    public interface IBusyBookDB
    {
        int addBusyBook(BusyBook busybook);
        BusyBook getBusyBook(int id);
        List<BusyBook> getAllBusyBook();
        int getIdBusyBookByBook(int idbook);
    }
}
