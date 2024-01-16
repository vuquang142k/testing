using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUnitBL.Builders;

namespace TestUnitBL.ObjectMothers
{
    public class PlaceBookOM
    {
        public static PlaceBookBuilder NumberedPlaceBook(int number)
        {
            return new PlaceBookBuilder()
                       .buildId(number)
                       .buildShelf(number)
                       .buildShelving(number)
                       .buildSize_shelf(number);
        }
    }
}
