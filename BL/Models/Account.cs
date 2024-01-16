using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Account
    {
        private int type;
        private string password;
        private string login;
        private string name;
        private int id;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }

        public Account() { }

        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public Account(int id, string name, string login, string password, int type)
        {
            this.id = id;
            this.name = name;
            this.login = login;
            this.password = password;
            this.type = type;
        }
    }
}
