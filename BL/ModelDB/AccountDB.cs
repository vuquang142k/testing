﻿using System.ComponentModel.DataAnnotations;

namespace ModelDB
{
    public class AccountDB
    {
        [Key]
        public int Id { get;set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }

    }
}
