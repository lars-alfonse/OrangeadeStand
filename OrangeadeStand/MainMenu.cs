using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class MainMenu : UserInterface
    {
        public MainMenu()
        {
            userOptions = new List<string> { "1. Start Game", "2. Load Game", "3. Rules", "4. Quit" };
        }
        protected override void GetUserInput()
        {
            Console.WriteLine("Welcome to OrangeAde Stand");
            Console.WriteLine($"Would you like to \n{string.Join("\n", userOptions)}");
            PlayerInput = Console.ReadLine().ToLower();
        }
        private void RunUserInput()
        {
            switch (PlayerInput)
            {
                case "start game":
                    break;
                case "load game":
                    break;
                case "rules":
                    PrintRules();
                    RunMenu();
                    return;
                case "quit":
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
            if (PlayerInput == "start game" || PlayerInput == "1" || PlayerInput == "start")
            {
                PlayerInput = "start game";
            }
            else if (PlayerInput == "rules" || PlayerInput == "3")
            {
                PlayerInput = "rules";
            }
            else if (PlayerInput == "load game" || PlayerInput == "2" || PlayerInput == "load")
            {
                PlayerInput = "load game";
            }
            else if (PlayerInput == "quit" || PlayerInput == "4")
            {
                PlayerInput = "quit";
            }
            else if (PlayerInput == "reset")
            {
                RunMenu();
                return;
            }
            else
            {
                Console.WriteLine("Input not recognized, please choose an approved input or type help for help");
                RunMenu();
                return;
            }
        }private void PrintRules()
        {
            Console.WriteLine("You are an entrepenuer who decided to combat scurvy for your pirate bretheren by selling them vitamin C packed Orangeade \nThe people you sell to will have their own preferences to the flavor of your orangeade\nYou can adjust the recipie of your orangeade by adjusting the ingredients. \nYour orangeade is created from ingredients that you can purchase before the day begins, if you run out of ingredients during the day, you will not be able to sell more drinks. \nBe carefull when purchasing items however, as they have a shelf life and can expire. (more details can be found in the shop menu) \nWeather will impact the amount of customers and their desire to buy. (More info can be found in the day preparation menu)\nThe goal of the game is to make as much profit as possible during the time alotted.\n press enter to continue");
            Console.ReadLine();
            RunMenu();

            return;
        }
        public void RunMenu()
        {
            GetUserInput();
            TranslateUserInput();
            RunUserInput();
        }

    }
}
