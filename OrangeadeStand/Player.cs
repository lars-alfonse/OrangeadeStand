using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Player
    {
        public Orangeade currentOrangeade;
        public Inventory inventory;

        public bool SellOrangeade(Customer currentCustomer)
        {
            if (inventory.CheckInventory(currentOrangeade) && currentCustomer.WillBuy)
            {
                inventory.ExchangeGoods(currentOrangeade);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
