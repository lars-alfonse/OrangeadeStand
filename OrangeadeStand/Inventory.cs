using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Inventory
    {
        public int money;
        private bool soldOut;
        private int cupsInPitcher;
        public List<Orange> oranges;
        public List<Sugar> sugars;
        public List<IceCube> iceCubes;
        public List<Cup> cups;
     
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
            else if (iceCubes.Count < currentOrangeade.ice)
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
            if(oranges.Count >= currentOrangeade.oranges && sugars.Count >= currentOrangeade.sugar)
            {
                cupsInPitcher = 8;
                SubtractFromInventory(oranges, currentOrangeade.oranges);
            }
        }
    }
}
