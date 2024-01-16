using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.Builders;

namespace TestUnitBL.ObjectMothers
{
    public class BusyBookOM
    {
        public static BusyBookBuilder NumberedBusyBook(int number)
        {
            return new BusyBookBuilder()
                       .buildId(number)
                       .buildIdbook(number)
                       .buildDate_received(string.Format("{0}-{1}-{2}", number % 30 + 1, number % 12 + 1, 2002 + number))
                       .buildDate_return(string.Format("{0}-{1}-{2}", number % 30 + 1, number % 12 + 1, 2002 + number))
                       .buildIdaccount(number % 2 + 1);
        }
    }
}
