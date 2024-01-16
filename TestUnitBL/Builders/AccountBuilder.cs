using BL.Models;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitBL.Builders
{
    public class AccountBuilder
    {
        private int id;
        private string name = "";
        private string login = "";
        private string password = "";
        private int type;

        public AccountBuilder buildId(int id)
        {
            this.id = id;
            return this;
        }

        public AccountBuilder buildName(string name)
        {
            this.name = name;
            return this;
        }

        public AccountBuilder buildLogin(string login)
        {
            this.login = login;
            return this;
        }
        public AccountBuilder buildPassword(string password)
        {
            this.password = password;
            return this;
        }
        public AccountBuilder buildType(int type)
        {
            this.type = type;
            return this;
        }

        public Account buildBL()
        {
            Account account = new Account(id, name, login, password, type);
            return account;
        }
        public AccountDB buildDA()
        {
            return new AccountDB
            {
                Id = id,
                Name = name,
                Login = login,
                Password = password,
                Type = type
            };
        }
    }
}
