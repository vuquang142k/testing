using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class PlaceBookDB
    {
        [Key]
        public int Id { get; set; }
        public int Shelf { get; set; }
        public int Shelving { get; set; }
        public int Size_shelf { get; set; }
    }
}