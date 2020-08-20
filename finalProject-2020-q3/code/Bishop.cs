using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Bishop : Piece
    {
        public Bishop(Color color): base(color) { }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            return BoardMovements.AllCellsDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellList = ValidMovements(piecesOnBoard, row, column);
            return (CellList)cellList.Where(cell => cell.IsEmpty() == false).ToList();
<<<<<<< HEAD
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"BW " : $" BB";
            return result;
=======
>>>>>>> 89b1aebe1089414cf6c844afbdfaa7923484a9b9
        }
    }
}
