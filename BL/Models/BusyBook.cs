using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BusyBook
    {
        public BusyBook() { }

        public BusyBook(int id, int idbook, string date_received, string date_return, int idaccount)
        {
            this.id = id;
            this.idbook = idbook;
            this.date_received = date_received;
            this.date_return = date_return;
            this.idaccount = idaccount;
        }

        private int idaccount;
        private string date_return;
        private string date_received;
        private int idbook;
        private int id;

        public int Id { get => id; set => id = value; }
        public int Idbook { get => idbook; set => idbook = value; }
        public string Date_received { get => date_received; set => date_received = value; }
        public string Date_return { get => date_return; set => date_return = value; }
        public int Idaccount { get => idaccount; set => idaccount = value; }
    }
}
