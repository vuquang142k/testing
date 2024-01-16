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
    public class BookstoreBuilder
    {
        private int id;
        private int idbook;
        private int idplace;
        private int count;

        public BookstoreBuilder buildId(int id)
        {
            this.id = id;
            return this;
        }

        public BookstoreBuilder buildIdbook(int idbook)
        {
            this.idbook = idbook;
            return this;
        }

        public BookstoreBuilder buildIdplace(int idplace)
        {
            this.idplace = idplace;
            return this;
        }

        public BookstoreBuilder buildCount(int count)
        {
            this.count = count;
            return this;
        }

        public Bookstore buildBL()
        {
            Bookstore bookstore = new Bookstore(id, idbook, idplace, count);
            return bookstore;
        }
        public BookstoreDB buildDA()
        {
            return new BookstoreDB
            {
                Id = id,
                Idbook = idbook,
                Idplace = idplace,
                Count = count
            };
        }
    }
}
