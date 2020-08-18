using System;

namespace finalProject_2020_q3.code
{
    public class King : Piece, ICastling
    {
        public King(Color color) : base(color) { }

        public void Castling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }
    }
}