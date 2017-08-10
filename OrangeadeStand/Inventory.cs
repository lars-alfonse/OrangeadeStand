using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Inventory
    {
        private int money;
        private bool soldOut;
        private int cupsInPitcher;
        public List<InventoryItems> oranges;
        public List<InventoryItems> sugars;
        public List<InventoryItems> iceCubes;
        public List<InventoryItems> cups;
     
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public bool SoldOut
        {
            get
            {
                return soldOut;
            
            }
            set
            {
                soldOut = value;
            }
        }
        public Inventory()
        {
            money = 500;
            oranges = new List<InventoryItems>();
            sugars = new List<InventoryItems>();
            iceCubes = new List<InventoryItems>();
            cups = new List<InventoryItems>();

        }
        public bool CheckInventory(Orangeade currentOrangeade)
        {
            if (soldOut)
            {
                return false;
            }
            else if (cupsInPitcher == 0)
            {
                CreatePitcher(currentOrangeade);
                return CheckInventory(currentOrangeade);
            }
            else if (cups.Count < 1)
            {
                soldOut = true;
                return false;
            }
            else if (iceCubes.Count < currentOrangeade.Ice)
            {
                soldOut = true;
                return false;
            }
            else
            {
                return true;
            }
        }
        private void CreatePitcher(Orangeade currentOrangeade)
        {
            if(oranges.Count >= currentOrangeade.Oranges && sugars.Count >= currentOrangeade.Sugar)
            {
                cupsInPitcher = 8;
                SubtractFromInventory(oranges, currentOrangeade.Oranges);
                SubtractFromInventory(sugars, currentOrangeade.Sugar);
            }
            else
            {
                soldOut = true;
            }
        }
        private void SubtractFromInventory(List<InventoryItems> stock, int count)
        {
            for (int i = 0; i < count; i++)
            {
                stock.RemoveAt(0);
            }
        }
        public void ExchangeGoods(Orangeade currentOrangeade)
        {
            money += currentOrangeade.Cost;
            SubtractFromInventory(iceCubes, currentOrangeade.Ice);
            SubtractFromInventory(cups, 1);
            cupsInPitcher -= 1;
        }
    }
}
