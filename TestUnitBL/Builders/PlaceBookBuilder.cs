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
    public class PlaceBookBuilder
    {
        private int id;
        private int shelf;
        private int shelving;
        private int size_shelf;

        public PlaceBookBuilder buildId(int id)
        {
            this.id = id;
            return this;
        }

        public PlaceBookBuilder buildShelf(int shelf)
        {
            this.shelf = shelf;
            return this;
        }

        public PlaceBookBuilder buildShelving(int shelving)
        {
            this.shelving = shelving;
            return this;
        }

        public PlaceBookBuilder buildSize_shelf(int size_shelf)
        {
            this.size_shelf = size_shelf;
            return this;
        }

        public PlaceBook buildBL()
        {
            PlaceBook placebook = new PlaceBook(id, shelf, shelving, size_shelf);
            return placebook;
        }
        public PlaceBookDB buildDA()
        {
            return new PlaceBookDB
            {
                Id = id,
                Shelf = shelf,
                Shelving = shelving,
                Size_shelf = size_shelf
            };
        }
    }
}
