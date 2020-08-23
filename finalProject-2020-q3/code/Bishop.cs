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
            CellList list = BoardMovements.AllCellsDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
            CellList result = new CellList();
            result.SetList(list.Where(cell => (cell.IsEmpty() == true ||cell.piece.Color != Color)).ToList());
            return result;
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellList = ValidMovements(piecesOnBoard, row, column);
            CellList resultList = new CellList();
            resultList.SetList(cellList.Where(cell => cell.IsEmpty() == false).ToList());
            return resultList;
        }
          
        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"BW " : $" BB";
            return result;
        }
    }
}
