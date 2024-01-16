using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.Builders;

namespace TestUnitBL.ObjectMothers
{
    public class BookstoreOM
    {
        public static BookstoreBuilder NumberedBookstore(int number)
        {
            return new BookstoreBuilder()
                       .buildId(number)
                       .buildIdbook(number)
                       .buildIdplace(number)
                       .buildCount(number);
        }
    }
}
