using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class BookstoreDB
    {
        [Key]
        public int Id { get; set; }
        public int Idbook { get; set; }
        public int Idplace { get; set; }
        public int Count { get; set; }
    }
}
