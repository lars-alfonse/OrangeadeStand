using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    public class Cup : InventoryItems
    {
        public Cup()
        {
            name = "cup";
            cost = 2;
            shelfLife = 1000;
            unit = 1;

        }
    }
}
