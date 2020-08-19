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
            throw new NotImplementedException();
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            return GetValidMovements(piecesOnBoard, row, column);
        }

        public void Castling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

        private CellList GetValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList horizontal = BoardMovements.AllCellsHorizontal(piecesOnBoard, piecesOnBoard[row, column]);
            CellList vertical = BoardMovements.AllCellsVertical(piecesOnBoard, piecesOnBoard[row, column]);
            return (CellList)horizontal.Union(vertical).ToList();
        }

    }
}
