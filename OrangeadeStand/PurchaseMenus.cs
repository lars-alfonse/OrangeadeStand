using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class PurchaseMenus : UserInterface 
    {
        Orange orange = new Orange();
        Sugar sugar = new Sugar();
        IceCube iceCube = new IceCube();
        Cup cup = new Cup();
        public PurchaseMenus()
        {
            userOptions = new List<string> { "1. Purchase Oranges", "2. Purchase Sugar", "3. Purchase Cups", "4. Purchase Ice", "5. Item Info", "6. Exit" };
        }
        protected override void GetUserInput()
        {
            Console.WriteLine($"What would you like to do?");
            Console.WriteLine($"Would you like to \n{string.Join("\n", userOptions)}");
            Console.WriteLine("(any of the purchase options can be accesed with their second word as well)");
            PlayerInput = Console.ReadLine().ToLower();
        }
        private void RunUserInput()
        {
            switch (PlayerInput)
            {
                case "purchase oranges":
                    break;
                case "purchase sugar":
                    break;
                case "purchase ice":
                    return;
                case "purchase cups":
                    break;
                case "item info":
                    GetItemInfo();
                    RunMenu();
                    break;
                case "exit":
                    break;
                case "reset":
                    GetUserInput();
                    return;
                default:
                    Console.WriteLine("input not recognized. Please use an approved input or type help for help");
                    GetUserInput();
                    return;
            }
        }
        private void TranslateUserInput()
        {
            if (PlayerInput == "purchase oranges" || PlayerInput == "oranges" || PlayerInput == "1")
            {
                PlayerInput = "purchase oranges";
            }
            else if (PlayerInput == "purchase sugar" || PlayerInput == "sugar" || PlayerInput == "2")
            {
                PlayerInput = "purchase sugar";
            }
            else if (PlayerInput == "purchase cups" || PlayerInput == "cups" || PlayerInput == "3")
            {
                PlayerInput = "purchase cups";
            }
            else if (PlayerInput == "purchase ice" || PlayerInput == "ice" || PlayerInput == "4")
            {
                PlayerInput = "purchase ice";
            }
            else if (PlayerInput == "item info" || PlayerInput == "info" || PlayerInput == "item" || PlayerInput == "5")
            {
                PlayerInput = "purchase oranges";
            }
            else if(PlayerInput == "exit" || PlayerInput == "6")
            {
                PlayerInput = "exit";
            }
            else
            {
                Console.WriteLine("Input not recognized, please choose an approved input or type help for help");
                RunMenu();
                return;
            }
        }
        public void RunMenu()
        {
            GetUserInput();
            TranslateUserInput();
            RunUserInput();
        }
        private void  GetItemInfo()
        {
            DisplayItemInfo(orange);
            DisplayItemInfo(sugar);
            DisplayItemInfo(iceCube);
            DisplayItemInfo(cup);
            Console.WriteLine("Press any enter to continue");
            Console.ReadLine();
        }
        private void DisplayItemInfo(InventoryItems item)
        {
            Console.WriteLine($"{item.Name}\nCost: {item.Cost}\nShelf Life: {item.ShelfLife}");
        }
    }
}
