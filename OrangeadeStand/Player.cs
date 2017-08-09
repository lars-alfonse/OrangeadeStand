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
        Inventory inventory;

        public void SellOrangeade(Customer currentCustomer)
        {
            bool canSell;
            canSell = inventory.CheckInventory(currentOrangeade);
        }
    }
}
