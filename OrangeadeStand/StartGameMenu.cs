using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    public class StartGameMenu : UserInterface
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
            try
            {
                possibleDays = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                ChangeDays();
                return;
            }
            CheckDayLimit(possibleDays);
        }
        private void CheckDayLimit(int possibleDays)
        {
            if(possibleDays < 7)
            {
                Console.WriteLine("Number of days not accepted please enter day amount greater than 7");
                ChangePlayers();
                return;
            }
            else
            {
                numberOfDays = possibleDays;
            }
        }
        private void ChangePlayers()
        {
            int possiblePlayers;
            Console.WriteLine("How many Players would you like?");
            try
            {
                possiblePlayers = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                ChangePlayers();
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
