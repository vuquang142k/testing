using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.Builders;

namespace TestUnitBL.ObjectMothers
{
    public class AccountOM
    {
        public static AccountBuilder CreateUser(int id)
        {
            return new AccountBuilder()
                       .buildId(id)
                       .buildName("User")
                       .buildLogin(string.Format("user{0}", id))
                       .buildPassword(string.Format("password{0}", id))
                       .buildType(0);
        }

        public static AccountBuilder CreateAdmin(int id)
        {
            return new AccountBuilder()
                       .buildId(id)
                       .buildName("Admin")
                       .buildLogin(string.Format("admin{0}", id))
                       .buildPassword(string.Format("admin{0}", id))
                       .buildType(1);
        }
    }
}
