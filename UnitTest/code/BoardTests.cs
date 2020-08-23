using Microsoft.VisualStudio.TestTools.UnitTesting;
using finalProject_2020_q3.code;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code.Tests
{

    [TestClass()]
    public class BoardTests
    {
        [TestMethod()]
        public void Add_ReturnsTrue_IfPositionExists()
        {
            Board board = CreateBoardMissingOnePiece();
            Piece piece = CreatePawn();

            bool actual = board.Add(piece, "5", "a");
            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void Add_ReturnsFalse_IfPositionDoesNotExists()
        {
            Board board = CreateBoardMissingOnePiece();
            Piece piece = CreatePawn();

            bool actual = board.Add(piece, "9", "a");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Add_ReturnsFalse_IfExceedingMaxOfPieces()
        {
            Board board = CreateDefaultBoard();
            Piece piece = CreatePawn();

            bool actual = board.Add(piece, "5", "a");
            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void Remove_ReturnsPiece_IfPieceExists()
        {
            Board board = CreateDefaultBoard();

            Piece actual = board.Remove("1", "a");
            Assert.IsTrue(actual is Rook);
        }

        [TestMethod()]
        public void Remove_ReturnsEmptyPiece_IfPieceNotExists()
        {
            Board board = CreateDefaultBoard();

            Piece actual = board.Remove("5", "a");
            Assert.IsTrue(actual.GetType() == typeof(Piece));
        }

        [TestMethod()]
        public void GetMovements_ReturnsPositions_IfNoObstacles()
        {
            Board board = CreateDefaultBoard();
            string[] expected = new string[]
            {
                "3a",
                "4a"
            };
            string[] actual = board.GetMovements("2", "a");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void GetMovements_ReturnsPositions_IfThereAreObstacles()
        {
            Board board = CreateBoardMissingOnePiece();
            board.Add(CreatePawn(), "4", "a");
            string[] expected = new string[]
            {
                "3a"
            };
            string[] actual = board.GetMovements("2", "a");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void GetMovements_ReturnsEmpty_IfThereAreObstacles()
        {
            Board board = CreateBoardMissingOnePiece();
            board.Add(CreatePawn(), "3", "a");
            string[] expected = new string[0];
            string[] actual = board.GetMovements("2", "a");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void AttackMovements_ReturnsPositions_IfThereAreOponents()
        {
            Board board = CreateBoardMissingOnePiece();
            board.Add(CreatePawn(), "3", "b");
            string[] expected = new string[]
            {
                "3b"
            };
            string[] actual = board.GetMovements("2", "a");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        public void AttackMovements_ReturnsEmpty_IfNoOponents()
        {
            Board board = CreateBoardMissingOnePiece();
            string[] expected = new string[0];
            string[] actual = board.GetMovements("2", "a");

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private Board CreateDefaultBoard()
        {
            return new Board();
        }

        private Board CreateBoardMissingOnePiece()
        {
            Board board = new Board();
            board.Remove("1", "a");
            return board;
        }

        private Piece CreatePawn()
        {
            return new Pawn(Color.WHITE, true);
        }

        [TestMethod()]
        public void GetKingCellTest_BlackSet()
        {
            Board board = new Board();
            Cell kingCell = board.GetKingCell(Color.BLACK);
            Assert.AreEqual("8e", kingCell.ToString(), $"King not found");
        }

        [TestMethod()]
        public void GetKingCellTest_WhiteSet()
        {
            Board board = new Board();
            Cell kingCell = board.GetKingCell(Color.WHITE);
            Assert.AreEqual("1e", kingCell.ToString(), $"King not found");
        }
    }
}