using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Game
    {
        Player playerOne;
        Player playerTwo;
        Day today;
        List<Player> players = new List<Player>();
        List<TurnMenu> playerMenus = new List<TurnMenu>();
        Customer currentCustomer;
        MainMenu mainMenu = new MainMenu();
        StartGameMenu startGameMenu = new StartGameMenu();
        private int dayCounter;

        public void RunGame()
        {
           mainMenu.RunMenu();
           RunMainMenuSelection();
        }
        private void StartNextDay()
        {
            CreateDay();
            ReportWeather();
            foreach (Player player in players)
            {
                today.Sales = 0;
                today.Profit = 0;
                for (int i = 0; i < today.CustomerAmounts; i++)
                {
                    player.inventory.SoldOut = false;
                    currentCustomer = new Customer(today.todaysWeather, playerOne.currentOrangeade);
                    if (player.SellOrangeade(currentCustomer))
                    {
                        today.Sales += 1;
                        today.Profit += playerOne.currentOrangeade.Cost;
                    }
                }
                player.TotalProfit += today.Profit;
                player.TotalSales += today.Sales;
                Console.WriteLine($"{player.Name} Sold {today.Sales} cups, and made {today.Profit} shillings");

            }
        }
        private void CreateDay()
        {
            dayCounter += 1;
            today = new Day();
        }
        private void ReportWeather()
        {
            Console.WriteLine($"Today's Temperature is {today.todaysWeather.temperature} Degrees\nToday's Weather: {today.todaysWeather.WeatherType}\nTodays Percipitation: {today.todaysWeather.PercipitationType}");
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
                    mainMenu.RunMenu();
                    return;
            }
        }
        private void StartNewGame()
        {
            startGameMenu.runMenu();
            CheckPlayerNumber();
            PlayGame();

        }
        private void CheckPlayerNumber()
        {
            switch (startGameMenu.NumberOfPlayers)
            {
                case 1:
                    playerOne = new Player("one");
                    players.Add(playerOne);
                    break;
                case 2:
                    playerTwo = new Player("two");
                    playerOne = new Player("one");
                    players.Add(playerOne);
                    players.Add(playerTwo);
                    break;
                default:
                    break;
            }
        }
        private void PlayGame()
        {
            while (dayCounter <= startGameMenu.NumberOfDays)
            {
                foreach(Player player in players)
                {
                    player.RunTurnMenu();
                }
                StartNextDay();
                Console.ReadLine();
            }
        }
        private void LoadGame()
        {
            Console.WriteLine("Feature not available please look forward to it");
        }
    }
}
