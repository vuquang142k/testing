using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using ModelDB;
using Microsoft.EntityFrameworkCore;
using DA.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class AccountDA : IAccountDB
    {
        private readonly AppDataContext appDataContext;
        public AccountDA(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }
        public Account? getAccount(int id)
        {
            AccountDB? account = appDataContext.Accounts.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return new Account(account.Id, account.Name, account.Login,account.Password,account.Type);
        }

        public List<Account> getAllAccount()
        {
            List<AccountDB> accountdb = appDataContext.Accounts.ToList();
            List<Account> accounts = new List<Account>();
            foreach (AccountDB account in accountdb)
            {
                Account a = new Account(account.Id, account.Name, account.Login, account.Password, account.Type);
                accounts.Add(a);
            }
            return accounts;
        }

        public int addAccount(Account account)
        {
            List<AccountDB>? lst = appDataContext.Accounts.Count() > 0 ? appDataContext.Accounts.ToList() : null;
            int maxid = 0;
            foreach (AccountDB temp in lst)
                if (temp.Id > maxid)
                    maxid = temp.Id;
            account.Id = maxid + 1;
            appDataContext.Accounts.Add(AccountConverter.BLtoDB(account));
            appDataContext.SaveChanges();
            return account.Id;

        }

        public int deleteAccount(int id)
        {
            AccountDB? account = appDataContext.Accounts.Where(n => n.Id == id).FirstOrDefault();
            if (account == null)
                throw new AccountNotFoundException();
            appDataContext.Accounts.Remove(account);
            appDataContext.SaveChanges();
            return account.Id;
        }

        public int getIdAccount(string login)
        {
            foreach (AccountDB temp in this.appDataContext.Accounts)
                if (temp.Login == login)
                    return AccountConverter.DBtoBL(temp).Id;
            return -1;
        }
    }
}
