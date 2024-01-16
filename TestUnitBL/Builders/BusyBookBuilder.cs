using BL.Models;
using ModelDB;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitBL.Builders
{
    public class BusyBookBuilder
    {
        private int id;
        private int idbook;
        private string date_received = "";
        private string date_return = "";
        private int idaccount;

        public BusyBookBuilder buildId(int id)
        {
            this.id = id;
            return this;
        }

        public BusyBookBuilder buildIdbook(int idbook)
        {
            this.idbook = idbook;
            return this;
        }

        public BusyBookBuilder buildDate_received(string date_received)
        {
            this.date_received = date_received;
            return this;
        }

        public BusyBookBuilder buildDate_return(string date_return)
        {
            this.date_return = date_return;
            return this;
        }

        public BusyBookBuilder buildIdaccount(int idaccount)
        {
            this.idaccount = idaccount;
            return this;
        }

        public BusyBook buildBL()
        {
            BusyBook busybook = new BusyBook(id, idbook, date_received, date_return, idaccount);
            return busybook;
        }
        public BusyBookDB buildDA()
        {
            return new BusyBookDB
            {
                Id = id,
                Idbook = idbook,
                Date_received = date_received,
                Date_return = date_return,
                Idaccount = idaccount
            };
        }
    }
}
