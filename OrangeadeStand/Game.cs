using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Game
    {
        Player playerOne = new Player();
        Customer currentCustomer;
        private void StartNextDay()
        {
            Day today = new Day();
            for (int i = 0; i < today.CustomerAmounts; i++)
            {
                currentCustomer = new Customer(today.todaysWeather, playerOne.currentOrangeade);

            }
        }
    }
}
