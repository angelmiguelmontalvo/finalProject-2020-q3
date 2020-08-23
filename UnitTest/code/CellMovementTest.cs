using finalProject_2020_q3.code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code.Tests
{
    [TestClass()]
    public class CellsMovementTest
    {

        [TestMethod()]
        public void CellsMovemetsTestDownLeaftCell()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.DownLeftDiagonal(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 4);
            Assert.AreEqual(c.Column, 4);
            Assert.AreEqual(c.ToString(), "4e");
        }

        [TestMethod()]
        public void CellsMovemetsTestDownRightCell()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.DownRightDiagonal(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 4);
            Assert.AreEqual(c.Column, 6);
            Assert.AreEqual(c.ToString(), "4g");
        }

        [TestMethod()]
        public void CellsMovemetsTestDownStrightCell()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.DownStraight(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 4);
            Assert.AreEqual(c.Column, 5);
            Assert.AreEqual(c.ToString(), "4f");
        }

        [TestMethod()]
        public void CellsMovemetsTestUpStrightCell()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.UpStraight(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 6);
            Assert.AreEqual(c.Column, 5);
            Assert.AreEqual(c.ToString(), "2f");
        }

        [TestMethod()]
        public void CellsMovemetsTestUpLeftCell()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.UpLeftDiagonal(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 6);
            Assert.AreEqual(c.Column, 4);
            Assert.AreEqual(c.ToString(), "2e");
        }

        [TestMethod()]
        public void CellsMovemetsTestUpRightCell()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.UpRightDiagonal(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 6);
            Assert.AreEqual(c.Column, 6);
            Assert.AreEqual(c.ToString(), "2g");
        }

        [TestMethod()]
        public void CellsMovemetsTestRight()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.RightStraight(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 5);
            Assert.AreEqual(c.Column, 6);
            Assert.AreEqual(c.ToString(), "3g");
        }

        [TestMethod()]
        public void CellsMovemetsTestLeft()
        {
            Board board = CreateDefaultBoard();
            Cell c = CellMovements.LeftStraight(board.Sets, board.Sets[5, 5]);
            Assert.AreEqual(c.Row, 5);
            Assert.AreEqual(c.Column, 4);
            Assert.AreEqual(c.ToString(), "3e");
        }

        private Board CreateDefaultBoard()
        {
            return new Board();
        }
    }
}
