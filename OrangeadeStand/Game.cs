using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrangeadeStand
{
    public class Game
    {
        static string connectionString = "SERVER = DESKTOP-2C737RL; DATABASE = OrangeadeStand; Trusted_Connection = true";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        Player player;
        Day today;
        public List<Player> players = new List<Player>();
        List<TurnMenu> playerMenus = new List<TurnMenu>();
        Customer currentCustomer;
        Weather prediction;
        MainMenu mainMenu = new MainMenu();
        public StartGameMenu startGameMenu = new StartGameMenu();
        private int dayCounter;
        private int winningProfit;
        private int profit;
        
        public int WinningProfit
        {
            get
            {
                return winningProfit;
            }
            set
            {
                winningProfit = value;
            }
        }

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
                case "load player":
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
           for (int i = 0; i < startGameMenu.NumberOfPlayers; i++)
            {
                    player = new Player($"{i+1}");
                    players.Add(player);
            }
        }
        private void CheckPlayerNumber(bool isLoaded)
        {
            for (int i = 0; i < startGameMenu.NumberOfPlayers; i++)
            {
                if (CheckIfLoaded(i + 1))
                {
                    player = LoadPlayer(i + 1);
                    players.Add(player);
                }
                else
                {
                    player = new Player($"{i}");
                    players.Add(player);
                }
            }
        }
        private string GetLoadInfo(string parameter)
        {
            Console.WriteLine($"Please Enter {parameter} (cAsE sEnSiTiVe)");
            return Console.ReadLine();
        }
        private Player LoadPlayer(int playerNumber)
        {
            Eraser.ClearConsole();

            string username = GetLoadInfo("Username");

            string password = GetLoadInfo("Password");

            using (sqlconn)
                try
                {
                    sqlconn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM SaveDATA WHERE UserName = '{username}' AND Pass = '{password}'", sqlconn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        player = GenerateLoadedPlayer(reader, playerNumber);
                    }
                    sqlconn.Close();
                    if (player == null)
                    {
                        ReportLoadFailure();
                        player = new Player(playerNumber.ToString());
                        return player;
                    }
                    ReportLoadSuccess();
                    return player;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    sqlconn.Close();
                    ReportLoadFailure();
                    player = new Player(playerNumber.ToString());
                    return player;
                }
            
        }
        private void ReportLoadFailure()
        {
            Console.WriteLine("Player not Found. New player will be created press enter to continue");
            Console.ReadLine();
            Eraser.ClearConsole();
        }
        private void ReportLoadSuccess()
        {
            Eraser.ClearConsole();
            Console.WriteLine("Player Loaded press enter to continue");
            Console.ReadLine();
            Eraser.ClearConsole();
        }
        private Player GenerateLoadedPlayer(SqlDataReader reader, int playerNumber)
        {
            Player loadedPlayer;
            string name = reader.GetString(3);
            int money = reader.GetInt32(4);
            int oranges = reader.GetInt32(5);
            int sugar = reader.GetInt32(6);
            int ice = reader.GetInt32(7);
            int cups = reader.GetInt32(8);
            int cost = reader.GetInt32(9);
            int recipieOranges = reader.GetInt32(10);
            int recipieSugar = reader.GetInt32(11);
            int recipieIce = reader.GetInt32(12);
            string pulp = reader.GetString(13);
            loadedPlayer = new Player(playerNumber.ToString(), name, money, oranges, sugar, ice, cups, cost, recipieOranges, recipieSugar, recipieIce, pulp);
            return loadedPlayer;
        }
        private bool CheckIfLoaded(int number)
        {
            string playerInput;
            Console.WriteLine($"Player {number} would you like to load a player?");
            playerInput = Console.ReadLine().ToLower();
            if (playerInput == "yes" || playerInput == "y")
            {
                return true;
            }
            else
            {
                return false;
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
                    Eraser.ClearConsole();
                }
                StartNextDay();
                foreach (Player player in players)
                {
                    ResetDay(player);
                    StartCustomers(player);
                    LogDayResults(player);
                }
                Console.ReadLine();
                Eraser.ClearConsole();
            }
            EndGame();
        }
        private void EndGame()
        {
            CheckProfits();
            ReportWinner();
        }
        private void ResetWinner()
        {
            winningProfit = 0;
        }
        private void CheckProfits()
        {
            ResetWinner();
            foreach (Player player in players)
            {
                profit = player.ReportTotalProfit();
                if (profit > winningProfit)
                {
                    winningProfit = profit;
                }
            }
            RecordWinner();
        }
        private void RecordWinner()
        {
            foreach (Player player in players)
            {
                if (winningProfit == player.TotalProfit)
                    player.IsWinner = true;
            }
        }
        private void ReportWinner()
        {
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name} made {player.ReportTotalProfit()}");
                if (player.IsWinner)
                {
                    Console.WriteLine($"{player.Name} WINS!!!");
                }
            }
        }
        private void LoadGame()
        {
            startGameMenu.runMenu();
            CheckPlayerNumber(true);
            PlayGame();
            
        }
        }
}
