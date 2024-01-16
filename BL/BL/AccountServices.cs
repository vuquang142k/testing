using BL.Error;
using BL.InterfaceDB;
using BL.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BL.BL
{
    public class AccountServices
    {
        private IAccountDB iaccountDB;
        public IAccountDB IaccountDB { get => iaccountDB; set => iaccountDB = value; }

        public AccountServices(IAccountDB iaccountDB)
        {
            this.iaccountDB = iaccountDB;
        }
        public int addAccount(Account account)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            if (this.iaccountDB.getIdAccount(account.Login) != -1)
            {
                log.Info("User adds new account unsuccessfully.");
                throw new AccountExistsException();
            }
            
            return this.iaccountDB.addAccount(account);
            log.Info("User adds new account successfully.");
        }
        public int getIdAccount(string login)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            int id = this.iaccountDB.getIdAccount(login);
            if (id == -1)
            {
                log.Info("User get idaccount unsuccessfully.");
                throw new AccountNotFoundException();
            }
            else
            {
                log.Info("User get idaccount successfully.");
                return id;
            }
        }
        public Account? getAccount(int id)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Account? user = this.iaccountDB.getAccount(id);
            if (user == null)
            {
                log.Info("User get account unsuccessfully.");
                throw new AccountNotFoundException();
            }
            else
            {
                log.Info("User get account successfully.");
                return user;
            }
        }
        public int deleteAccount(int id)
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            Account? account = this.IaccountDB.getAccount(id);
            if (account == null)
            {
                log.Info("User get account unsuccessfully.");
                throw new AccountNotFoundException();
            }
            else
            {
                return this.IaccountDB.deleteAccount(id);
            }
        }

        public bool accountExists(string? login)
        {
            int id = -1;
            id = this.iaccountDB.getIdAccount(login);
            if (id == -1)
                return false;
            return true;
        }

        public List<Account> getAllAccount()
        {
            Logger log = LogManager.GetLogger("myAppLoggerRules");
            log.Info("User views all accounts.");
            return this.iaccountDB.getAllAccount();
        }
    }
}
