﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    public class Orange : InventoryItems
    {
        public Orange()
        {
            name = "orange";
            cost = 7;
            shelfLife = 4;
            unit = 1;
        }
    }

}
