using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL
{
    public class BusyBookServices
    {
        private IBusyBookDB ibusybookDB;
        private readonly IBookDB ibookDB;
        private readonly IAccountDB iaccountDB;
        public IBusyBookDB IbusybookDB { get => ibusybookDB; set => ibusybookDB = value; }

        public BusyBookServices(IBusyBookDB ibusybookDB, IBookDB ibookDB, IAccountDB iaccountDB)
        {
            this.ibusybookDB = ibusybookDB;
            this.iaccountDB = iaccountDB;
            this.ibookDB = ibookDB;
        }
        public int addBusyBook(BusyBook busybook)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (iaccountDB.getAccount(busybook.Idaccount) == null)
            {
                log.Info("User adds busybook unsuccessfully.");
                throw new AccountNotFoundException();
            }
            else if (ibookDB.getBook(busybook.Idbook) == null)
            {
                log.Info("User adds busybook unsuccessfully.");
                throw new BookNotFoundException();
            }
            else
            {
                return this.ibusybookDB.addBusyBook(busybook);
                log.Info("User adds busybook successfully.");
            }
        }
      
        public BusyBook getBusyBook(int id)
        {
            BusyBook? busybook = this.ibusybookDB.getBusyBook(id);
            if (busybook == null)
                throw new BusyBookNotFoundException();
            return busybook;
        }
        public List<BusyBook> getAllBusyBook()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all busybooks.");
            return this.ibusybookDB.getAllBusyBook();
        }
        public int getIdBusyBookByBook(int idbook)
        {
            int id = this.ibusybookDB.getIdBusyBookByBook(idbook);
            return id;
        }
        
    }
}
