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
                    PurchaseStock();
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
        public void RunTurnMenu()
        {
            turnMenu.RunMenu();
            ProcessTurnInput();
        }
        private void PurchaseStock()
        {

        }
        private void CheckInventory()
        {
            Console.WriteLine($"{name} has {inventory.oranges.Count} Oranges \n{inventory.sugars.count} cups of sugar \n{inventory.iceCubes.count} ice cubes \n{inventory.cups.Count}");
        }
        private void RunShopOutput()
        {
            switch (purchaseMenu.PlayerInput)
            {
                case "purchase oranges":
                    PurchaseOranges();
                    PurchaseStock();
                    break;
                case "purchase sugar":
                    PurchaseSugar();
                    PurchaseStock();
                    break;
                case "purchase ice":
                    PurchaseIce();
                    PurchaseStock();
                    return;
                case "purchase cups":
                    PurchaseCups();
                    PurchaseStock();
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("input not recognized. Please use an approved input or type help for help");
                    return;
            }
        }
    }
}
