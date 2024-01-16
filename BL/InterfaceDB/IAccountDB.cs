using BL.Models;

namespace BL.InterfaceDB
{
    public interface IAccountDB
    {
        int addAccount(Account account);
        int getIdAccount(string login);
        Account? getAccount(int id);
        int deleteAccount(int id);
        List<Account> getAllAccount();
    }
}
