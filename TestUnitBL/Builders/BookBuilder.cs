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
    public class BookBuilder
    {
        private int id;
        private string name = "";
        private string dateproduct = "";

        public BookBuilder buildId(int id)
        {
            this.id = id;
            return this;
        }

        public BookBuilder buildName(string name)
        {
            this.name = name;
            return this;
        }

        public BookBuilder buildDateproduct(string dateproduct)
        {
            this.dateproduct = dateproduct;
            return this;
        }

        public Book buildBL()
        {
            Book book = new Book(id, name, dateproduct);
            return book;
        }
        public BookDB buildDA()
        {
            return new BookDB
            {
                Id = id,
                Name = name,
                Dateproduct = dateproduct
            };
        }
    }
}
