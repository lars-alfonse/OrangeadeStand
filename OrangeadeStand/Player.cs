using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Player
    {
        private string number;
        private string name;
        private int totalProfit;
        private int totalSales;
        public Orangeade currentOrangeade;
        public Inventory inventory;

        public string Name
        {
            get
            {
                return name;

            }
        }
        public int TotalProfit
        {
            get
            {
                return totalProfit;
            }
            set
            {
                totalProfit = value;
            }
        }
        public int TotalSales
        {
            get
            {
                return totalSales;
            }
            set
            {
                totalSales = value;
            }
        }
        public Player(string playerNumber)
        {
            number = playerNumber;
            GetPlayerName();
            currentOrangeade = new Orangeade();
            inventory = new Inventory();
        }

        private void GetPlayerName()
        {
            Console.WriteLine($"Player {number} please enter your name");
            name = Console.ReadLine();
        }
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
