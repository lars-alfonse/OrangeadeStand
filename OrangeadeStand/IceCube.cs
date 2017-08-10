using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class IceCube : InventoryItems
    {
        public IceCube()
        {
            name = "ice cube";
            cost = 1;
            shelfLife = 1;
            unit = 20;
        }
    }
}
