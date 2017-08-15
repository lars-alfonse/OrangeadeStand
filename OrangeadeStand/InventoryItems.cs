using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    public class InventoryItems
    {
        protected string name;
        protected int cost;
        protected int shelfLife;
        protected int unit;

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
        public int Unit
        {
            get
            {
                return unit;
            }
        }   
    }
}
