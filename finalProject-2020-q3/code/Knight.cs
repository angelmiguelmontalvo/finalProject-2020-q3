using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    class Knight : Piece
    {
        public Knight (Color color) : base(color) { }

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

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"HW " : $" HB";
            return result;
        }
    }
}
