using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Rook : Piece, ICastling
    {
        public Rook(Color color) : base(color) { }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public void Castling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"RW " : $" RB";
            return result;
        }
    }
}
