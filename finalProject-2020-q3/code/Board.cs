﻿using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Board
    {
        public static readonly Dictionary<string, int> positions = new Dictionary<string, int>
        {
            {"8", 0}, {"7", 1}, {"6", 2}, {"5", 3}, {"4", 4}, {"3", 5}, {"2", 6}, {"1", 7},
            {"a", 0}, {"b", 1}, {"c", 2}, {"d", 3}, {"e", 4}, {"f", 5}, {"g", 6}, {"h", 7}
        };
        public Color TopColor { get; set; }
        public Cell[,] Sets { get; }
        private int PiecesOnBoard;

        public Board(Color topColor = Color.WHITE)
        {
            this.TopColor = topColor;
            this.Sets = new Cell[8, 8];
            this.PiecesOnBoard = 16;
            InitPieces();
        }
        private void InitPieces()
        {
            FillBoardCells();
            FillSet(TopColor, true);
            FillSet(TopColor == Color.BLACK? Color.WHITE: Color.BLACK, false);
        }
        private void FillBoardCells() 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this.Sets[i, j] = new Cell(i, j);
                }
            }
        }
        private void FillSet(Color color, bool isTop)
        {
            int pawnsPosition;
            int majorsPosition;
            if (isTop)
            {
                pawnsPosition = 6;
                majorsPosition = 7;
            }
            else
            {
                pawnsPosition = 1;
                majorsPosition = 0;
            }

            for (int i = 0; i < 8; i++)
            {
                this.Sets[pawnsPosition, i].piece = PieceFactory.BuildPieces(PieceType.PAWN, color);
            }
            this.Sets[majorsPosition, 0].piece = PieceFactory.BuildPieces(PieceType.ROOK, color);
            this.Sets[majorsPosition, 1].piece = PieceFactory.BuildPieces(PieceType.KNIGHT, color);
            this.Sets[majorsPosition, 2].piece = PieceFactory.BuildPieces(PieceType.BISHOP, color);
            this.Sets[majorsPosition, 3].piece = PieceFactory.BuildPieces(PieceType.QUEEN, color);
            this.Sets[majorsPosition, 4].piece = PieceFactory.BuildPieces(PieceType.KING, color);
            this.Sets[majorsPosition, 5].piece = PieceFactory.BuildPieces(PieceType.BISHOP, color);
            this.Sets[majorsPosition, 6].piece = PieceFactory.BuildPieces(PieceType.KNIGHT, color);
            this.Sets[majorsPosition, 7].piece = PieceFactory.BuildPieces(PieceType.ROOK, color);
        }

        public Cell GetCell(string cell)
        {
            string rowString = cell.Substring(0,1);
            string columnString = cell.Substring(1);
            int rowInMatrix = positions[rowString];
            int columnInMatrix = positions[columnString];
            return this.Sets[rowInMatrix, columnInMatrix];
        }

        public void ApplyMovement(Cell source, Cell target)
        {
            Piece piece = RemovePiece(source);
            if (target.piece != null) {
                RemovePiece(target);
            }
            AddPiece(piece, target);
        }

        public bool AddPiece(Piece piece, Cell cell) {
            return Add(piece, cell.GetRow(), cell.GetColumn());
        }
        
        public bool Add(Piece piece, string row, string column)
        {
            bool result = false;
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                if (this.PiecesOnBoard < 16)
                {
                    int rowInMatrix = positions[row];
                    int columnInMatrix = positions[column];
                    this.Sets[rowInMatrix, columnInMatrix].piece = piece;
                    this.PiecesOnBoard++;
                    result = true;
                }
            }
            return result;
        }

        public Piece RemovePiece(Cell cell)
        {
            return Remove(cell.GetRow(), cell.GetColumn());
        }
        public Piece Remove(string row, string column)
        {
            Piece removedPiece = null;
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                removedPiece = this.Sets[rowInMatrix, columnInMatrix].piece;
                this.Sets[rowInMatrix, columnInMatrix].RemovePiece();
                this.PiecesOnBoard--;
            }
            return removedPiece;
        }
        public string[] GetMovements(string row, string column)
        {
            string[] movements= new string[0];
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                Cell cell = this.Sets[rowInMatrix, columnInMatrix];
                CellList validCells = cell.GetValidMovements(this.Sets);
                movements = new string[validCells.Count];
                for (int i = 0; i < movements.Length; i++)
                {
                    movements[i] = validCells[i].ToString();
                }
            }
            return movements;
        }

        public String[] AttackMovements(string row, string column)
        {
            string[] attackMovements = new string[0];
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                Cell cell = this.Sets[rowInMatrix, columnInMatrix];
                CellList validCells = cell.GetAttackMovements(this.Sets);
                attackMovements = new string[validCells.Count];
                for (int i = 0; i < attackMovements.Length; i++)
                {
                    attackMovements[i] = validCells[i].ToString();
                }
            }
            return attackMovements;
        }
        public String[] CaptureFreeCells(string row, string column)
        {
            return new String[0];
        }
    }
}
