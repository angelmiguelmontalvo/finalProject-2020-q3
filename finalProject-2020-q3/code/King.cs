using System;

namespace finalProject_2020_q3.code
{
    public class King : Piece, ICastling
    {
        public King(Color color, Cell poistion) : base(color, poistion) { }

        public void Castling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Piece[,] piecesOnBoard)
        {
            throw new NotImplementedException();
        }

        public override CellList CaptureFreeCells(Piece[,] piecesOnBoard)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Piece[,] piecesOnBoard)
        {
            throw new NotImplementedException();
        }
    }
}