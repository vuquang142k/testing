using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Book
    {
        public Book() { }

        public Book(int id, string name, string dateproduct)
        {
            this.Id = id;
            this.Name = name;
            this.Dateproduct = dateproduct;
        }

        private string dateproduct;
        private string name;
        private int id;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Dateproduct { get => dateproduct; set => dateproduct = value; }
    }
}
