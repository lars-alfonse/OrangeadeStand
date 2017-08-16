using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrangeadeStand;
using System.IO;

namespace OrangeadeStandUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MainMenu_GetsPlayerInputAndConvertToLowerCase()
        {
            MainMenu mainMenu = new MainMenu();
            PrivateObject menu = new PrivateObject(mainMenu);
            string expectedResult = "start game";
            string input = "Start Game";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            menu.Invoke("GetUserInput");

            Assert.AreEqual(mainMenu.PlayerInput, expectedResult);
            
        }
        [TestMethod]
        public void MainMenu_TranslatesNumber1InputToStartGame()
        {
            MainMenu mainMenu = new MainMenu();
            PrivateObject menu = new PrivateObject(mainMenu);
            string expectedResult = "start game";
            mainMenu.PlayerInput = "1";

            menu.Invoke("TranslateUserInput");

            Assert.AreEqual(mainMenu.PlayerInput, expectedResult);

        }
        [TestMethod]
        public void MainMenu_TranslatesNumber2InputToLoadPlayer()
        {
            MainMenu mainMenu = new MainMenu();
            PrivateObject menu = new PrivateObject(mainMenu);
            string expectedResult ="load player";
            mainMenu.PlayerInput = "2";

            menu.Invoke("TranslateUserInput");

            Assert.AreEqual(mainMenu.PlayerInput, expectedResult);

        }
        [TestMethod]
        public void MainMenu_TranslatesNumber3InputToRules()
        {
            MainMenu mainMenu = new MainMenu();
            PrivateObject menu = new PrivateObject(mainMenu);
            string expectedResult = "rules";
            mainMenu.PlayerInput = "3";

            menu.Invoke("TranslateUserInput");

            Assert.AreEqual(mainMenu.PlayerInput, expectedResult);

        }
        [TestMethod]
        public void MainMenu_TranslatesNumber4InputToQuit()
        {
            MainMenu mainMenu = new MainMenu();
            PrivateObject menu = new PrivateObject(mainMenu);
            string expectedResult = "quit";
            mainMenu.PlayerInput = "4";

            menu.Invoke("TranslateUserInput");

            Assert.AreEqual(mainMenu.PlayerInput, expectedResult);

        }
        [TestMethod]
        public void StartMenu_GetsPlayerInputAndConvertToLowerCase()
        {
            StartGameMenu startMenu = new StartGameMenu();
            PrivateObject menu = new PrivateObject(startMenu);
            string expectedResult = "start game";
            string input = "Start Game";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            menu.Invoke("GetUserInput");
            string actualResult = startMenu.PlayerInput;

            Assert.AreEqual(actualResult, expectedResult);

        }
        [TestMethod]
        public void StartMenu_TranslatesNumber3InputToStartGame()
        {
            StartGameMenu startMenu = new StartGameMenu();
            PrivateObject menu = new PrivateObject(startMenu);
            string expectedResult = "start game";
            startMenu.PlayerInput = "3";

            menu.Invoke("TranslateUserInput");

            Assert.AreEqual(startMenu.PlayerInput, expectedResult);

        }
        [TestMethod]
        public void StartMenu_ChangeDaysFunctionChangesDayNumbers()
        {
            StartGameMenu startMenu = new StartGameMenu();
            PrivateObject menu = new PrivateObject(startMenu);
            int expectedResult = 14;
            string input = "14";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            menu.Invoke("ChangeDays");
            int actualResult = startMenu.NumberOfDays;

            Assert.AreEqual(actualResult, expectedResult);

        }
        public void StartMenu_ChangeDaysFunctionChangesPlayerNumber()
        {
            StartGameMenu startMenu = new StartGameMenu();
            PrivateObject menu = new PrivateObject(startMenu);
            int expectedResult = 10;
            string input = "10";
            StringReader stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            menu.Invoke("ChangePlayers");
            int actualResult = startMenu.NumberOfDays;

            Assert.AreEqual(actualResult, expectedResult);

        }
        [TestMethod]
        public void Game_CheckIfPlayersAdd()
        {
            Game game = new Game();
            game.startGameMenu.NumberOfPlayers = 3;
            int expectedResult = 3;
            PrivateObject obj = new PrivateObject(game);
            string names = "testName";
            StringReader stringReader = new StringReader(names);
            Console.SetIn(stringReader);

            obj.Invoke("CheckPlayerNumber");
            int actualResult = game.players.Count;

            Assert.AreEqual(expectedResult, actualResult);

        }
        public void Game_WinningProfitCheckMakesisWinnerTrue()
        {
            Game game = new Game();
            Player playerOne = new Player("1");
            Player playerTwo = new Player("2");
            Player playerThree = new Player("3");
            playerOne.TotalProfit = 100;
            playerTwo.TotalProfit = 500;
            playerThree.TotalProfit = 300;
            bool expectedValue = true;
            game.WinningProfit = 500;
            PrivateObject obj = new PrivateObject(game);
            game.players.Add(playerOne);
            game.players.Add(playerTwo);
            game.players.Add(playerThree);

            obj.Invoke("RecordWinner");
            bool actualValue = playerTwo.IsWinner;

            Assert.AreEqual(actualValue, expectedValue);

        }
        public void Game_WinningProfitCheckMakesisWinnerFalse()
        {
            Game game = new Game();
            Player playerOne = new Player("1");
            Player playerTwo = new Player("2");
            Player playerThree = new Player("3");
            playerOne.TotalProfit = 100;
            playerTwo.TotalProfit = 500;
            playerThree.TotalProfit = 300;
            bool expectedValue = false;
            game.WinningProfit = 500;
            PrivateObject obj = new PrivateObject(game);
            game.players.Add(playerOne);
            game.players.Add(playerTwo);
            game.players.Add(playerThree);

            obj.Invoke("RecordWinner");
            bool actualValue = playerOne.IsWinner;

            Assert.AreEqual(actualValue, expectedValue);

        }
        [TestMethod]
        public void Game_WinnerReportedisTrue()
        {
            Game game = new Game();
            Player playerOne = new Player("1");
            Player playerTwo = new Player("2");
            Player playerThree = new Player("3");
            playerOne.TotalProfit = 100;
            playerTwo.TotalProfit = 500;
            playerThree.TotalProfit = 300;
            bool expectedValue = true;
            PrivateObject obj = new PrivateObject(game);
            game.players.Add(playerOne);
            game.players.Add(playerTwo);
            game.players.Add(playerThree);

            obj.Invoke("CheckProfits");
            bool actualValue = playerTwo.IsWinner;

            Assert.AreEqual(actualValue, expectedValue);

        }

        [TestMethod]
        public void Game_LoserReportedisFalse()
        {
            Game game = new Game();
            Player playerOne = new Player("1");
            Player playerTwo = new Player("2");
            Player playerThree = new Player("3");
            playerOne.TotalProfit = 100;
            playerTwo.TotalProfit = 500;
            playerThree.TotalProfit = 300;
            bool expectedValue = false;
            PrivateObject obj = new PrivateObject(game);
            game.players.Add(playerOne);
            game.players.Add(playerTwo);
            game.players.Add(playerThree);

            obj.Invoke("CheckProfits");
            bool actualValue = playerOne.IsWinner;

            Assert.AreEqual(actualValue, expectedValue);

        }

    }
}
