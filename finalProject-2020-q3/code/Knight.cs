using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    class Knight : Piece
    {
        public Knight (Color color) : base(color) { }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellList = ValidMovements(piecesOnBoard, row, column); 
            CellList resultList = new CellList();
            resultList.SetList(cellList.Where(cell => cell.IsEmpty() == false && cell.piece.Color != Color).ToList());
            return resultList;
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            return BoardMovements.GetKnightMovement(piecesOnBoard, piecesOnBoard[row, column]);
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"HW " : $" HB";
            return result;
        }
    }
}
