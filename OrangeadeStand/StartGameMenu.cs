using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class StartGameMenu : UserInterface
    {
        private int numberOfPlayers;
        private int numberOfDays;

        public int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
        }
        public int NumberOfDays
        {
            get
            {
                return numberOfDays;
            }
        }
        public StartGameMenu()
        {
            userOptions = new List<string> { "1. Change Players", "2. Switch Day Limit", "3. Start Game" };
            numberOfDays = 7;
            numberOfPlayers = 1;
        }
        protected override void GetUserInput()
        {
            Console.WriteLine($"Select Options for game or start. (Current Selection: {numberOfPlayers} player(s), {numberOfDays} days");
            Console.WriteLine($"Would you like to \n{string.Join("\n", userOptions)}");
            PlayerInput = Console.ReadLine().ToLower();
        }
        private void TranslateUserInput()
        {
            if (PlayerInput == "change players" || PlayerInput == "change" || PlayerInput == "1")
            {
                PlayerInput = "change players";
            }
            else if (PlayerInput == "switch day limit" || PlayerInput == "switch" || PlayerInput == "2")
            {
                PlayerInput = "switch day limit";
            }
            else if (PlayerInput == "start game" || PlayerInput == "start" || PlayerInput == "3")
            {
                PlayerInput = "start game";
            }
        }
        private void RunUserInput()
        {
            switch (PlayerInput)
            {
                case "start game":
                    break;
                case "switch day limit":
                    ChangeDays();
                    runMenu();
                    return;
                case "change players":
                    ChangePlayers();
                    runMenu();
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
        private void ChangeDays()
        {
            int possibleDays;
            Console.WriteLine("How many days would you like to play (minimum 7)");
            possibleDays = int.Parse(Console.ReadLine());
            CheckDays(possibleDays);
        }
        private void CheckDays(int possibleDays)
        {
            if (VerifyInput(possibleDays, 6, false))
            {
                numberOfDays = possibleDays;
            }
            else
            {
                Console.WriteLine("Number of days not accepted, please enter minimum of 7 days");
                runMenu();
                return;
            }
        }
        private bool VerifyInput(int testNumber, int check, bool result)
        {
            if (testNumber <= check && testNumber != 0)
            {
                return result;
            }
            else
            {
                return !result;
            }
        }
        private void ChangePlayers()
        {
            int possiblePlayers;
            Console.WriteLine("How many Players would you like? (1 or 2)");
            possiblePlayers = int.Parse(Console.ReadLine());
            CheckPlayers(possiblePlayers);
        }
        private void CheckPlayers(int possiblePlayers)
        {
            if (VerifyInput(possiblePlayers, 2, true))
            {
                numberOfPlayers = possiblePlayers;
            }
            else
            {
                Console.WriteLine("Number of Players not accepted, please enter 1 or 2 players");
                runMenu();
                return;
            }
        }
        public void runMenu()
        {
            GetUserInput();
            TranslateUserInput();
            RunUserInput();
        }

    }
}
