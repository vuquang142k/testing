using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class PlaceBook
    {
        public PlaceBook() { }

        public PlaceBook(int id, int shelf, int shelving, int size_shelf)
        {
            this.id = id;
            this.shelf = shelf;
            this.shelving = shelving;
            this.size_shelf = size_shelf;
        }

        private int size_shelf;
        private int shelving;
        private int shelf;
        private int id;

        public int Id { get => id; set => id = value; }
        public int Shelf { get => shelf; set => shelf = value; }
        public int Shelving { get => shelving; set => shelving = value; }
        public int Size_shelf { get => size_shelf; set => size_shelf = value; }
    }
}
