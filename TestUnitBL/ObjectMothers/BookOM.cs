using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.Builders;

namespace TestUnitBL.ObjectMothers
{
    public class BookOM
    {
        public static BookBuilder NumberedBook(int number)
        {
            return new BookBuilder()
                       .buildId(number)
                       .buildName(string.Format("Book{0}", number))
                       .buildDateproduct(string.Format("{0}-{1}-{2}", number % 30 + 1, number % 12 + 1, 2000 + number));
        }
    }
}
