using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class InventoryItems
    {
        protected string name;
        protected int cost;
        protected int shelfLife;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public int Cost
        {
            get
            {
                return cost;
            }
        }
        public int ShelfLife
        {
            get
            {
                return shelfLife;
            }
        }
    }
}
