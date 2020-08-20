using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    class Queen : Piece
    {
        public Queen(Color color) : base(color) { }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellList = ValidMovements(piecesOnBoard, row, column);
            return (CellList)cellList.Where(cell => cell.IsEmpty() == false).ToList();
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cross = BoardMovements.AllCrossCells(piecesOnBoard, piecesOnBoard[row, column]);
            CellList diagonal = BoardMovements.AllCellsDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
            return (CellList)cross.Union(diagonal).ToList();
<<<<<<< HEAD
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"QW " : $" QB";
            return result;
=======
>>>>>>> 89b1aebe1089414cf6c844afbdfaa7923484a9b9
        }
    }
}
