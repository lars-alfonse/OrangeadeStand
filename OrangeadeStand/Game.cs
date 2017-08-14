﻿using System;
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
        Player player;
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
        private Player LoadPlayer(int playerNumber)
        {
            Eraser.ClearConsole();
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
                        player = new Player(playerNumber.ToString(), name, money, oranges, sugar, ice, cups, cost, recipieOranges, recipieSugar, recipieIce, pulp);
                    }
                    sqlconn.Close();
                    Eraser.ClearConsole();
                    Console.WriteLine("Player Loaded press enter to continue");
                    Console.ReadLine();
                    Eraser.ClearConsole();
                    return player;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Eraser.ClearConsole();
                    Console.WriteLine("Player not Found. New player will be created press enter to continue");
                    sqlconn.Close();
                    Console.ReadLine();
                    Eraser.ClearConsole();
                    player = new Player(playerNumber.ToString());
                    return player;
                }
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
        }
        private void LoadGame()
        {
            startGameMenu.runMenu();
            CheckPlayerNumber(true);
            PlayGame();
            
        }
        }
}
