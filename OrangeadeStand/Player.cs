using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Player
    {
        private string playerNumber;
        private string playerName;
        public Orangeade currentOrangeade;
        public Inventory inventory;

        public string PlayerName
        {
            get
            {
                return playerName;

            }
        }
        public Player(string playerNumber)
        {
            this.playerNumber = playerNumber;
            GetPlayerName();
            currentOrangeade = new Orangeade();
            inventory = new Inventory();
        }

        private void GetPlayerName()
        {
            Console.WriteLine($"Player {playerNumber} please enter your name");
            playerName = Console.ReadLine();
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
