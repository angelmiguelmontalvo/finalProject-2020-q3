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
            CellList list = BoardMovements.AllCrossCells(piecesOnBoard, piecesOnBoard[row, column]);
            CellList result = new CellList();
            result.SetList(list.Where(cell => (cell.IsEmpty() == true || cell.piece.Color != Color)).ToList());
            return result;
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
