using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class TurnMenu : UserInterface
    {
        private string playerName;
        public TurnMenu(string name)
        {
            playerName = name;
            userOptions = new List<string> { "1. Start Turn", "2. Check Inventory", "3. Purchase Stock", "4. Check Recipie", "5. Change Recipie", "6. Check Weather", "7. Check Days", "8. Save Game" };
        }
        protected override void GetUserInput()
        {
            Console.WriteLine($"{playerName} What would you like to do?");
            Console.WriteLine($"Would you like to \n{string.Join("\n", userOptions)}");
            Console.WriteLine("(any of the checks can be accesed with their second word as well)");
            PlayerInput = Console.ReadLine().ToLower();
        }
        private void RunUserInput()
        {
            switch (PlayerInput)
            {
                case "start turn":
                    return;
                case "check inventory":
                    return;
                case "purchase stock":
                    return;
                case "check recipie":
                    return;
                case "check weather":
                    return;
                case "check days":
                    return;
                case "change recipie":
                    return;
                case "save game":
                    return;
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
            if (PlayerInput == "start turn" || PlayerInput == "1" || PlayerInput == "start")
            {
                PlayerInput = "start turn";
            }
            else if (PlayerInput == "check inventory" || PlayerInput == "2" || PlayerInput == "inventory")
            {
                PlayerInput = "check inventory";
            }
            else if (PlayerInput == "purchase stock" || PlayerInput == "3" || PlayerInput == "purchase" || PlayerInput == "stock")
            {
                PlayerInput = "purchase stock";
            }
            else if (PlayerInput == "check recipie" || PlayerInput == "4" || PlayerInput == "recipie")
            {
                PlayerInput = "check recipie";
            }
            else if (PlayerInput == "change recipie" || PlayerInput == "5" || PlayerInput == "change")
            {
                PlayerInput = "change recipie";
            }
            else if (PlayerInput == "check weather" || PlayerInput == "6" || PlayerInput == "weather")
            {
                PlayerInput = "check weather";
            }
            else if (PlayerInput == "check days" || PlayerInput == "7" || PlayerInput == "days")
            {
                PlayerInput = "check days";
            }
            else if (PlayerInput == "reset")
            {
                RunMenu();
                return;
            }
            else if (PlayerInput == "save game" || PlayerInput == "8" || PlayerInput == "save")
            {
                PlayerInput = "save game";
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

    }
}
 