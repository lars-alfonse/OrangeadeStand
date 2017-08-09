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
        MainMenu mainMenu = new MainMenu();
        StartGameMenu startGameMenu = new StartGameMenu();
        private int totalTransactions;
        private int totalProfit;
        private int dayCounter;

        public void RunGame()
        {
           mainMenu.RunMenu();
           RunMainMenuSelection();
        }
        private void StartNextDay()
        {
            dayCounter += 1;
            Day today = new Day();
            for (int i = 0; i < today.CustomerAmounts; i++)
            {
                currentCustomer = new Customer(today.todaysWeather, playerOne.currentOrangeade);
                if (playerOne.SellOrangeade(currentCustomer))
                {
                    today.Sales += 1;
                    today.Profit += playerOne.currentOrangeade.Cost;
                }
            }
            totalProfit += today.Profit;
            totalTransactions += today.Sales;

        }
        private void RunMainMenuSelection()
        {
            switch (mainMenu.PlayerInput)
            {
                case "start game":
                    StartNewGame();
                    break;
                case "load game":
                    LoadGame();
                    break;
                case "quit":
                    return;
                default:
                    return;
            }
        }
        private void StartNewGame()
        {

        }
        private void LoadGame()
        {
            Console.WriteLine("Feature not available please look forward to it");
        }
    }
}
