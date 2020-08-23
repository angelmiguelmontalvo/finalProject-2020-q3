using Microsoft.VisualStudio.TestTools.UnitTesting;
using finalProject_2020_q3.game;
using System;
using System.Collections.Generic;
using System.Text;
using finalProject_2020_q3.game.movement;
using finalProject_2020_q3.code;

namespace finalProject_2020_q3.game.Tests
{
    [TestClass()]
    public class GameTests
    {
        public Game GetTestPlayerGame()
        {
            Game game = new Game();
            Player player1 = new Player("Player1", Color.WHITE, 0);
            Player player2 = new Player("Player2", Color.BLACK, 1);
            game.GamePlayers.AddPlayers(player1, player2);
            return game;
        }

        [TestMethod()]
        [DataRow("S(a1)T(a8)")]
        [DataRow("S(aa)T(aa)")]
        [DataRow("S(ab)T(ab)")]
        [DataRow("S(11)T(18)")]
        public void IsValidCommandTest_NotValidValues(string input)
        {
            Game game = new Game();
            var valid = game.IsValidCommand(input);
            Assert.IsFalse(valid, $"{input} is valid");
        }

        [TestMethod()]
        [DataRow("S(1a)T(8a)")]
        [DataRow("S(1h)T(8a)")]
        [DataRow("S(1h)T(8h)")]
        [DataRow("S(8h)T(1a)")]
        [DataRow("P(8a)")]
        [DataRow("P(1h)")]
        [DataRow("P(1a)")]
        [DataRow("P(8h)")]
        public void IsValidCommandTest_ValidLimitValues(string input)
        {
            Game game = new Game();
            var valid = game.IsValidCommand(input);
            Assert.IsTrue(valid, $"{input} is invalid");
        }

        [TestMethod()]
        [DataRow("S(1a)T(1a)")]
        [DataRow("S(1b)T(1b)")]
        [DataRow("S(3c)T(3c)")]
        [DataRow("S(4d)T(4d)")]
        public void IsValidCommandTest_NotValidSameSource_Target(string input)
        {
            Game game = new Game();
            var valid = game.IsValidCommand(input);
            Assert.IsFalse(valid, $"{input} is valid");
        }

        [TestMethod()]
        [DataRow("S(1a)T(9a)")]
        [DataRow("S(0h)T(1g)")]
        [DataRow("S(9h)T(8a)")]
        [DataRow("S(0a)T(0h)")]
        public void IsValidCommandTest_OutOfRangeValues(string input)
        {
            Game game = new Game();
            var valid = game.IsValidCommand(input);
            Assert.IsFalse(valid, $"{input} is valid");
        }

        [TestMethod()]
        [DataRow("S(1a)T(8a)")]
        public void GetCellTest_Source(string input)
        {
            Game game = new Game();
            Cell source = game.GetCell(input, CellType.Source);
            string sourceString = source.ToString();
            Assert.AreEqual("1a", sourceString, $"Not match 1a {sourceString}");
        }

        [TestMethod()]
        [DataRow("S(1a)T(8a)")]
        public void GetCellTest_Target(string input)
        {
            Game game = new Game();
            Cell target = game.GetCell(input, CellType.Target);
            string targetString = target.ToString();
            Assert.AreEqual("8a", targetString, $"Not match 8a {targetString}");
        }

        [TestMethod()]
        public void GetNextPlayerTest()
        {
            Game game = GetTestPlayerGame();
            Player player2 = new Player("Player2", Color.BLACK, 1);
            game.SetFirstTurn();
            Player nextPlayer = game.GetNextPlayer();
            Assert.AreEqual(nextPlayer, player2, "Wrong next player.");
        }

        [TestMethod()]
        public void SetFirstTurnTest()
        {
            Game game = GetTestPlayerGame();
            Player player1 = new Player("Player1", Color.WHITE, 0);
            game.SetFirstTurn();
            Assert.AreEqual(game.Turn, player1, "Wrong first player.");
        }

        [TestMethod()]
        public void SetNextPlayerTest()
        {
            Game game = GetTestPlayerGame();
            Player player2 = new Player("Player2", Color.BLACK, 1);
            game.SetFirstTurn();
            game.SetNextPlayer();
            Assert.AreEqual(game.Turn, player2, "Wrong next player.");
        }

        [TestMethod()]
        public void SetResignationTest_BlackWin()
        {
            Game game = GetTestPlayerGame();
            Player player2 = new Player("Player2", Color.BLACK, 1);
            game.SetFirstTurn();
            game.SetResignation();
            Assert.AreEqual(game.Turn, player2, "Wrong winner player.");
        }

        [TestMethod()]
        public void SetResignationTest_WhiteWin()
        {
            Game game = GetTestPlayerGame();
            Player player1 = new Player("Player1", Color.WHITE, 0);
            game.SetFirstTurn();
            game.SetNextPlayer();
            game.SetResignation();
            Assert.AreEqual(game.Turn, player1, "Wrong winner player.");
        }
    }
}