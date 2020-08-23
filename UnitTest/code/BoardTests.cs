﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        // White initial positions
        [DataRow("1", "a", new string[0])]
        [DataRow("1", "b", new string[] { "3a", "3c" })]
        [DataRow("1", "c", new string[0])]
        [DataRow("1", "d", new string[0])]
        [DataRow("1", "e", new string[0])]
        [DataRow("1", "f", new string[0])]
        [DataRow("1", "g", new string[] { "3f", "3h" })]
        [DataRow("1", "h", new string[0])]
        [DataRow("2", "a", new string[] { "3a", "4a" })]
        [DataRow("2", "b", new string[] { "3b", "4b" })]
        [DataRow("2", "c", new string[] { "3c", "4c" })]
        [DataRow("2", "d", new string[] { "3d", "4d" })]
        [DataRow("2", "e", new string[] { "3e", "4e" })]
        [DataRow("2", "f", new string[] { "3f", "4f" })]
        [DataRow("2", "g", new string[] { "3g", "4g" })]
        [DataRow("2", "h", new string[] { "3h", "4h" })]
        // Black initial positions
        [DataRow("8", "a", new string[0])]
        [DataRow("8", "b", new string[] { "6a", "6c" })]
        [DataRow("8", "c", new string[0])]
        [DataRow("8", "d", new string[0])]
        [DataRow("8", "e", new string[0])]
        [DataRow("8", "f", new string[0])]
        [DataRow("8", "g", new string[] { "6f", "6h" })]
        [DataRow("8", "h", new string[0])]
        [DataRow("7", "a", new string[] { "6a", "5a" })]
        [DataRow("7", "b", new string[] { "6b", "5b" })]
        [DataRow("7", "c", new string[] { "6c", "5c" })]
        [DataRow("7", "d", new string[] { "6d", "5d" })]
        [DataRow("7", "e", new string[] { "6e", "5e" })]
        [DataRow("7", "f", new string[] { "6f", "5f" })]
        [DataRow("7", "g", new string[] { "6g", "5g" })]
        [DataRow("7", "h", new string[] { "6h", "5h" })]
        public void GetMovements_ReturnsPositions_InitialPositions(string row, string column, string[] expected)
        {
            Board board = CreateDefaultBoard();
            string[] actual = board.GetMovements(row, column);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod()]
        [DataRow(PieceType.ROOK, Color.WHITE, "5", "d", new string[] { "6d", "4d", "3d", "5a", "5b", "5c", "5e", "5f", "5g", "5h" })]
        [DataRow(PieceType.ROOK, Color.BLACK, "5", "d", new string[] { "6d", "4d", "3d", "5a", "5b", "5c", "5e", "5f", "5g", "5h" })]
        [DataRow(PieceType.KNIGHT, Color.WHITE, "5", "d", new string[] { "6b", "4b", "6f", "4f", "3c", "3e" })]
        [DataRow(PieceType.KNIGHT, Color.BLACK, "5", "d", new string[] { "6b", "4b", "6f", "4f", "3c", "3e" })]
        [DataRow(PieceType.BISHOP, Color.WHITE, "5", "d", new string[] { "6c", "6e", "4c", "3b", "4e", "3f" })]
        [DataRow(PieceType.BISHOP, Color.BLACK, "5", "d", new string[] { "6c", "6e", "4c", "3b", "4e", "3f" })]
        [DataRow(PieceType.QUEEN, Color.WHITE, "5", "d", new string[] { "6d", "4d", "3d", "5a", "5b", "5c", "5e", "5f", "5g", "5h", "6c", "6e", "4c", "3b", "4e", "3f" })]
        [DataRow(PieceType.QUEEN, Color.BLACK, "5", "d", new string[] { "6d", "4d", "3d", "5a", "5b", "5c", "5e", "5f", "5g", "5h", "6c", "6e", "4c", "3b", "4e", "3f" })]
        [DataRow(PieceType.KING, Color.WHITE, "5", "d", new string[] { "5c", "5e", "4c", "4d", "4e" })]
        [DataRow(PieceType.KING, Color.BLACK, "4", "d", new string[] { "4c", "4e", "5c", "5d", "5e" })]
        public void GetMovements_ReturnsEmptyCells_NoPiecesInTheMiddle(PieceType pieceType, Color color, string row, string column, string[] expected)
        {
            Board board = CreateBoardWithPieceIn(row, column, pieceType, color);
            string[] actual = board.GetMovements(row, column);

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

        private Board CreateBoardWithPieceIn(string row, string column, PieceType pieceType, Color color)
        {
            Board board = new Board(Color.BLACK);
            board.Remove("1", "a");
            board.Add(PieceFactory.BuildPieces(pieceType, color), row, column);
            return board;
        }
    }
}