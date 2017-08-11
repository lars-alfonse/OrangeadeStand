using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrangeadeStand
{
    class Game
    {
        static string connectionString = "SERVER = DESKTOP-2C737RL; DATABASE = OrangeadeStand; Trusted_Connection = true";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        Player playerOne;
        Player playerTwo;
        Day today;
        List<Player> players = new List<Player>();
        List<TurnMenu> playerMenus = new List<TurnMenu>();
        Customer currentCustomer;
        Weather prediction;
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
        }
        private void StartCustomers(Player player)
        {
            for (int i = 0; i < today.CustomerAmounts; i++)
            {
                currentCustomer = new Customer(today.todaysWeather, player.currentOrangeade);
                if (player.SellOrangeade(currentCustomer))
                {
                    AddSales(player);
                }
            }
        }
        private void ResetDay(Player player)
        {
            player.inventory.SoldOut = false;
            today.Sales = 0;
            today.Profit = 0;
        }
        private void AddSales(Player player)
        {
            today.Sales += 1;
            today.Profit += player.currentOrangeade.Cost;
        }
        private void LogDayResults(Player player)
        {
            today.AddRecipie(player.currentOrangeade);
            player.Days.Add(today);
            player.TotalProfit += today.Profit;
            player.TotalSales += today.Sales;
            Console.WriteLine($"{player.Name} Sold {today.Sales} cups, and made {today.Profit} shillings");
        }
        private void CreateDay()
        {
            dayCounter += 1;
            today = new Day(prediction, dayCounter);
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
                prediction = new Weather();
                foreach(Player player in players)
                {
                    player.prediction = this.prediction;
                    player.RunTurnMenu();
                }
                StartNextDay();
                foreach (Player player in players)
                {
                    ResetDay(player);
                    StartCustomers(player);
                    LogDayResults(player);
                }
                Console.ReadLine();
            }
        }
        private void LoadGame()
        {
            Console.WriteLine("Please Enter Username (cAsE sEnSiTiVe)");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter password (cAsE sEnSiTiVe)");
            string password = Console.ReadLine();
                using (sqlconn)
                    try
                    {
                        sqlconn.Open();
                        SqlCommand cmd = new SqlCommand($"SELECT * FROM SaveDATA WHERE UserName = '{username}' AND Pass = '{password}'", sqlconn);
                        SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string name = reader.GetInt32(0).ToString();
                        string pass = reader.GetString(1);

                        Console.WriteLine(pass + name);
                    }
                        sqlconn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Failed Connection. Save Data will not be accessable during this game");
                        sqlconn.Close();
                        Console.ReadLine();
                        LoadGame();
                    }
                    finally
                    {
                        Console.WriteLine("Press Enter to Start");
                        sqlconn.Close();
                        Console.ReadLine();
                    }

            }
        }
}
