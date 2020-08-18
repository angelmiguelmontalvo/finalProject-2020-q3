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
        public Color TopColor { get; set; }
        public Piece[,] Sets { get; }
        private int PiecesOnBoard;

        public Board(Color topColor = Color.WHITE)
        {
            this.TopColor = topColor;
            this.Sets = new Piece[8, 8];
            this.PiecesOnBoard = 16;
            InitPieces();
        }
        private void InitPieces()
        {
            FillSet(TopColor, true);
            FillSet(TopColor == Color.BLACK? Color.WHITE: Color.BLACK, false);
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
                this.Sets[pawnsPosition, i] = PiceFactory.BuildPieces(PieceType.PAWN, color, new Cell(pawnsPosition, i));
            }
            this.Sets[majorsPosition, 0] = PiceFactory.BuildPieces(PieceType.ROOK, color, new Cell(majorsPosition, 0));
            this.Sets[majorsPosition, 1] = PiceFactory.BuildPieces(PieceType.KNIGHT, color, new Cell(majorsPosition, 1));
            this.Sets[majorsPosition, 2] = PiceFactory.BuildPieces(PieceType.BISHOP, color, new Cell(majorsPosition, 2));
            this.Sets[majorsPosition, 3] = PiceFactory.BuildPieces(PieceType.QUEEN, color, new Cell(majorsPosition, 3));
            this.Sets[majorsPosition, 4] = PiceFactory.BuildPieces(PieceType.KING, color, new Cell(majorsPosition, 4));
            this.Sets[majorsPosition, 5] = PiceFactory.BuildPieces(PieceType.BISHOP, color, new Cell(majorsPosition, 5));
            this.Sets[majorsPosition, 6] = PiceFactory.BuildPieces(PieceType.KNIGHT, color, new Cell(majorsPosition, 6));
            this.Sets[majorsPosition, 7] = PiceFactory.BuildPieces(PieceType.ROOK, color, new Cell(majorsPosition, 7));
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
                    this.Sets[rowInMatrix, columnInMatrix] = piece;
                    this.PiecesOnBoard++;
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
                removedPiece = this.Sets[rowInMatrix, columnInMatrix];
                this.Sets[rowInMatrix, columnInMatrix] = null;
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
                Piece piece = this.Sets[rowInMatrix, columnInMatrix];
                CellList validCells = piece.ValidMovements(this.Sets);
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
                Piece piece = this.Sets[rowInMatrix, columnInMatrix];
                CellList validCells = piece.AttackMovements(this.Sets);
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
