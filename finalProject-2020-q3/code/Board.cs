using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Board
    {
        public static readonly Dictionary<string, int> positions = new Dictionary<string, int>
        {
            {"1", 0}, {"2", 1}, {"3", 2}, {"4", 3}, {"5", 4}, {"6", 5}, {"7", 6}, {"8", 7},
            {"a", 0}, {"b", 1}, {"c", 2}, {"d", 3}, {"e", 4}, {"f", 5}, {"g", 6}, {"h", 7}
        };
        public Color topColor { get; set; }
        public Piece[,] sets { get; }
        private int piecesOnBoard;

        public Board(Color topColor = Color.WHITE)
        {
            this.topColor = topColor;
            this.sets = new Piece[8, 8];
            this.piecesOnBoard = 16;
            InitPieces();
        }
        private void InitPieces()
        {
            fillSet(topColor, true);
            fillSet(topColor == Color.BLACK? Color.WHITE: Color.BLACK, false);
        }
        private void fillSet(Color color, bool isTop)
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
                this.sets[pawnsPosition, i] = new Pawn(color, new Cell(pawnsPosition, i));
            }
            this.sets[majorsPosition, 0] = new Rook(color, new Cell(majorsPosition, 0));
            this.sets[majorsPosition, 1] = new Knight(color, new Cell(majorsPosition, 1));
            this.sets[majorsPosition, 2] = new Bishop(color, new Cell(majorsPosition, 2));
            this.sets[majorsPosition, 3] = new Queen(color, new Cell(majorsPosition, 3));
            this.sets[majorsPosition, 4] = new King(color, new Cell(majorsPosition, 4));
            this.sets[majorsPosition, 5] = new Bishop(color, new Cell(majorsPosition, 5));
            this.sets[majorsPosition, 6] = new Knight(color, new Cell(majorsPosition, 6));
            this.sets[majorsPosition, 7] = new Rook(color, new Cell(majorsPosition, 7));
        }
        public bool Add(Piece piece, string row, string column)
        {
            bool result = false;
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                if (this.piecesOnBoard < 16)
                {
                    int rowInMatrix = positions[row];
                    int columnInMatrix = positions[column];
                    this.sets[rowInMatrix, columnInMatrix] = piece;
                    this.piecesOnBoard++;
                    result = true;
                }
            }
            return result;
        }
        public Piece Remove(string row, string column)
        {
            Piece removedPiece = null;
            if (positions.ContainsKey(row) && positions.ContainsKey(column))
            {
                int rowInMatrix = positions[row];
                int columnInMatrix = positions[column];
                removedPiece = this.sets[rowInMatrix, columnInMatrix];
                this.sets[rowInMatrix, columnInMatrix] = null;
                this.piecesOnBoard--;
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
                Piece piece = this.sets[rowInMatrix, columnInMatrix];
                CellList validCells = piece.ValidMovements(this.sets);
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
                Piece piece = this.sets[rowInMatrix, columnInMatrix];
                CellList validCells = piece.AttackMovements(this.sets);
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
