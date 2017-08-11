using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrangeadeStand
{
    class Player
    {
        static string connectionString = "SERVER = DESKTOP-2C737RL; DATABASE = OrangeadeStand; Trusted_Connection = true";
        static SqlConnection sqlconn = new SqlConnection(connectionString);
        private string number;
        private string name;
        private int totalProfit;
        private int totalSales;
        private Cup cup = new Cup();
        public List<Day> Days = new List<Day>();
        private Orange orange = new Orange();
        private IceCube iceCube = new IceCube();
        private Sugar sugar = new Sugar();
        public TurnMenu turnMenu;
        public PurchaseMenus purchaseMenu;
        public Orangeade currentOrangeade;
        public Inventory inventory;
        public Weather prediction = null;
        public string Name
        {
            get
            {
                return name;

            }
        }
        public int TotalProfit
        {
            get
            {
                return totalProfit;
            }
            set
            {
                totalProfit = value;
            }
        }
        public int TotalSales
        {
            get
            {
                return totalSales;
            }
            set
            {
                totalSales = value;
            }
        }
        public Player(string playerNumber)
        {
            number = playerNumber;
            GetPlayerName();
            currentOrangeade = new Orangeade();
            inventory = new Inventory();
            turnMenu = new TurnMenu(name);
            purchaseMenu = new PurchaseMenus();
        }

        private void GetPlayerName()
        {
            Console.WriteLine($"Player {number} please enter your name");
            name = Console.ReadLine();
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
        private void ProcessTurnInput()
        {
            switch (turnMenu.PlayerInput)
            {
                case "start turn":
                    return;
                case "check inventory":
                    CheckInventory();
                    RunTurnMenu();
                    return;
                case "purchase stock":
                    RunPurchaseMenu();
                    RunTurnMenu();
                    return;
                case "check recipie":
                    CheckRecipie();
                    RunTurnMenu();
                    return;
                case "check weather":
                    CheckWeather();
                    RunTurnMenu();
                    return;
                case "check days":
                    CheckDays();
                    RunTurnMenu();
                    return;
                case "change recipie":
                    ChangeRecipie();
                    RunTurnMenu();
                    return;
                case "save game":
                    SaveGame();
                    RunTurnMenu();
                    return;
                default:
                    return;
            }
        }
        private void CheckWeather()
        {
            if (prediction == null)
            {
                prediction = new Weather();
            }
            ReportWeather();
        }
        private void ReportWeather()
        {
            Console.WriteLine($"Todays's Temperature will be {prediction.temperature} Degrees\nToday's Weather will be: {prediction.WeatherType}\nTodays Percipitation will be: {prediction.PercipitationType}");
        }
        private void CheckDays()
        {
            string playerInput;
            int playerInputNumber;
            Console.WriteLine($"{Days.Count} Day(s) passed which day would you like check (enter day number or type quit)");
            playerInput = Console.ReadLine();
            try
            {
                playerInputNumber = int.Parse(playerInput) -1;
            }
            catch(Exception)
            {
                RunTurnMenu();
                return;
            }
            DisplayDay(playerInputNumber);
        }
        private void DisplayDay(int inputNumber)
        {
            if(inputNumber>=0)
            Days[inputNumber].ReportDay();
        }
        public void RunTurnMenu()
        {
                turnMenu.RunMenu();
                ProcessTurnInput();
        }
        private void RunPurchaseMenu()
        {
            purchaseMenu.PlayerInput = "not exit";
            while(purchaseMenu.PlayerInput != "exit")
            {
                purchaseMenu.RunMenu();
                RunShopOutput();
            }
        }
        private void CheckInventory()
        {
            Console.WriteLine($"{name} has {inventory.oranges.Count} Oranges \n{inventory.sugars.Count} cups of sugar \n{inventory.iceCubes.Count} ice cubes \nCups: {inventory.cups.Count}");
        }
        private void RunShopOutput()
        {
            switch (purchaseMenu.PlayerInput)
            {
                case "purchase oranges":
                    PurchaseStock(orange, inventory.oranges);
                    RunPurchaseMenu();
                    return;
                case "purchase sugar":
                    PurchaseStock(sugar, inventory.sugars);
                    RunPurchaseMenu();
                    return;
                case "purchase ice":
                    PurchaseStock(iceCube, inventory.iceCubes);
                    RunPurchaseMenu();
                    return;
                case "purchase cups":
                    PurchaseStock(cup, inventory.cups);
                    RunPurchaseMenu();
                    return;
                case "exit":
                    return;
                default:
                    Console.WriteLine("input not recognized. Please use an approved input or type help for help");
                    return;
            }
        }
        private void PurchaseStock(InventoryItems item, List<InventoryItems> itemType)
        {
            int purchaseNumber;
            purchaseNumber = GetTransactionChoice(item);
            if(CheckFunds(item.Cost, purchaseNumber))
            {
                FinalizeTransaction(item, purchaseNumber, itemType);
            }
            else
            {
                Console.WriteLine("insufficient funds please choose a different amount");
                PurchaseStock(item, itemType);
                return;
            }

        }
        private int GetTransactionChoice(InventoryItems item)
        {
            int userInput;
            Console.WriteLine($"{item.Name}(s) costs {item.Cost} shillings\nHow many would you like to buy?\nCurrent funds: {inventory.Money} shillings");
            try
            {
               userInput =  int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                userInput = GetTransactionChoice(item);
                return userInput;
            }
            return userInput;
        }
        private void FinalizeTransaction(InventoryItems item, int purchaseAmount, List<InventoryItems> itemType)
        {
            for (int i = 0; i < purchaseAmount*item.Unit; i++)
            {
                itemType.Add(item);
                inventory.Money -= (item.Cost/item.Unit);
            }
        }
        private bool CheckFunds(int itemCost, int itemAmount)
        {
            if(inventory.Money < itemAmount * itemCost)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void CheckRecipie()
        {
            Console.WriteLine($"Current Recipie: \nOranges: {currentOrangeade.Oranges} \nSugar: {currentOrangeade.Sugar} \nIce Cubes per cup: {currentOrangeade.Ice} \nPulp: {currentOrangeade.Pulp}");
        }
        private void ChangeRecipie()
        {
            currentOrangeade.SetRecipie();
        }
        private void SaveGame()
        {
            string username = GetUserInput("UserName");
            string password = GetUserInput("password");
            SavePlayerInventory(username, password);
            return;
        
        }
        private void SavePlayerInventory(string username, string password)
        {
            using (sqlconn)
                try
                {
                    SaveUserItem(inventory.iceCubes.Count(), "Ice", username, password);
                    SaveUserItem(inventory.oranges.Count(), "Oranges", username, password);
                    SaveUserItem(inventory.cups.Count(), "Cups", username, password);
                    SaveUserItem(inventory.sugars.Count(), "Sugar", username, password);
                    SaveUserItem(name, "Name", username, password);
                    SaveUserItem(inventory.Money, "Money", username, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Save Failed");
                    sqlconn.Close();
                    Console.ReadLine();
                    SaveGame();
                    return;
                }
                finally
                {
                    Console.WriteLine("Press Enter to Continue");
                    sqlconn.Close();
                    Console.ReadLine();
                }
        }
        private string GetUserInput(string parameter)
        {
            Console.WriteLine($"Please Enter {parameter} (cAsE sEnSiTiVe)");
            string returnParameter = Console.ReadLine();
            return returnParameter;
        }
        private void SaveUserItem(int itemCount, string columnName, string username, string password)
        {
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand($"UPDATE SaveDATA SET Player{columnName} = {itemCount} WHERE UserName = '{username}' AND Pass = '{password}'", sqlconn);
            cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
        private void SaveUserItem(string name, string columnName, string username, string password)
        {
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand($"UPDATE SaveDATA SET Player{columnName} = '{name}' WHERE UserName = '{username}' AND Pass = '{password}'", sqlconn);
            cmd.ExecuteNonQuery();
            sqlconn.Close();
        }
    }
}
