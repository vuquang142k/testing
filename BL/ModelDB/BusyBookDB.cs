using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDB
{
    public class BusyBookDB
    {
        [Key]
        public int Id { get; set; }
        public int Idbook { get; set; }
        public string Date_received { get; set; }
        public string Date_return { get; set; }
        public int Idaccount { get; set; }
    }
}
