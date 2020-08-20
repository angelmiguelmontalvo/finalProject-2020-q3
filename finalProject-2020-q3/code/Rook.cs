using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Rook : Piece, ICastling
    {
        public Rook(Color color) : base(color) { }

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
            return BoardMovements.AllCrossCells(piecesOnBoard, piecesOnBoard[row, column]);
        }

        public void Castling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }
<<<<<<< HEAD

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"RW " : $" RB";
            return result;
        }

        private CellList GetValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList horizontal = BoardMovements.AllCellsHorizontal(piecesOnBoard, piecesOnBoard[row, column]);
            CellList vertical = BoardMovements.AllCellsVertical(piecesOnBoard, piecesOnBoard[row, column]);
            return (CellList)horizontal.Union(vertical).ToList();
        }

=======
>>>>>>> 63ddd19... feature - movements
    }
}
