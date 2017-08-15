﻿using System;
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
    }
}
