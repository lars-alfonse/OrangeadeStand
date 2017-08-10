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
            else if (iceCubes.Count < currentOrangeade.iceCubes.Count)
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
            if(oranges.Count >= currentOrangeade.oranges.Count && sugars.Count >= currentOrangeade.sugars.Count)
            {
                cupsInPitcher = 8;
                SubtractFromInventory(oranges, currentOrangeade.oranges);
                SubtractFromInventory(sugars, currentOrangeade.sugars);
            }
            else
            {
                soldOut = true;
            }
        }
        private void SubtractFromInventory(List<InventoryItems> stock, List<InventoryItems> count)
        {
            for (int i = 0; i < count.Count; i++)
            {
                stock.RemoveAt(0);
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
            SubtractFromInventory(iceCubes, currentOrangeade.iceCubes);
            SubtractFromInventory(cups, 1);
        }
    }
}
