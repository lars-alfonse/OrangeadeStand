using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Player
    {
        private string number;
        private string name;
        private int totalProfit;
        private int totalSales;
        private Cup cup = new Cup();
        private Orange orange = new Orange();
        private IceCube iceCube = new IceCube();
        private Sugar sugar = new Sugar();
        public TurnMenu turnMenu;
        public PurchaseMenus purchaseMenu;
        public Orangeade currentOrangeade;
        public Inventory inventory;

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
                    break;
                case "check inventory":
                    CheckInventory();
                    RunTurnMenu();
                    break;
                case "purchase stock":
                    RunPurchaseMenu();
                    RunTurnMenu();
                    return;
                case "check recipie":
                    CheckRecipie();
                    RunTurnMenu();
                    break;
                case "check weather":
                    CheckWeather();
                    RunTurnMenu();
                    break;
                case "check days":
                    CheckDays();
                    RunTurnMenu();
                    break;
                case "change recipie":
                    ChangeRecipie();
                    RunTurnMenu();
                    break;
                default:
                    return;
            }
        }
        private void CheckWeather()
        {
            Console.WriteLine("Feature not implemented Please look forward to it");
        }
        private void CheckDays()
        {
            Console.WriteLine("Feature not implemented Please look forward to it");
        }
        public void RunTurnMenu()
        {
            turnMenu.RunMenu();
            ProcessTurnInput();
        }
        private void RunPurchaseMenu()
        {
            while(purchaseMenu.PlayerInput != "exit")
            {
                purchaseMenu.RunMenu();
                RunShopOutput();
            }
        }
        private void CheckInventory()
        {
            Console.WriteLine($"{name} has {inventory.oranges.Count} Oranges \n{inventory.sugars.Count} cups of sugar \n{inventory.iceCubes.Count} ice cubes \n{inventory.cups.Count}");
        }
        private void RunShopOutput()
        {
            switch (purchaseMenu.PlayerInput)
            {
                case "purchase oranges":
                    PurchaseStock(orange, inventory.oranges);
                    RunPurchaseMenu();
                    break;
                case "purchase sugar":
                    PurchaseStock(sugar, inventory.sugars);
                    RunPurchaseMenu();
                    break;
                case "purchase ice":
                    PurchaseStock(iceCube, inventory.iceCubes);
                    RunPurchaseMenu();
                    return;
                case "purchase cups":
                    PurchaseStock(cup, inventory.cups);
                    RunPurchaseMenu();
                    break;
                case "exit":
                    break;
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
      

    }
}
