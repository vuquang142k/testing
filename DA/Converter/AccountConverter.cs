using BL.Models;
using ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Converter
{
    public class AccountConverter
    {
        public static Account? DBtoBL(AccountDB? account)
        {
            if (account == null) return null;
            return new Account(account.Id, account.Name, account.Login, account.Password, account.Type);
        }
        public static AccountDB? BLtoDB(Account? account)
        {
            if (account == null) return null;
            return new AccountDB
            {
                Id = account.Id,
                Name = account.Name,
                Login = account.Login,
                Password = account.Password,
                Type = account.Type
            };
        }
    }
}
