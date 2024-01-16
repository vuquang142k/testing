using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Bookstore
    {
        public Bookstore() { }

        public Bookstore(int id, int idbook, int idplace, int count)
        {
            this.id = id;
            this.idbook = idbook;
            this.idplace = idplace;
            this.count = count;
        }
        private int count;
        private int idplace;
        private int idbook;
        private int id;

        public int Id { get => id; set => id = value; }
        public int Idbook { get => idbook; set => idbook = value; }
        public int Idplace { get => idplace; set => idplace = value; }
        public int Count { get => count; set => count = value; }
    }
}
