using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Pawn : Piece, IPromotion
    {
        public Pawn(Color color) : base(color)
        {

        }
        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public Piece Promote(PieceType pieceType)
        {
            return PieceFactory.BuildPieces(pieceType, this.Color);
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"pW " : $" pB";
            return result;
        }
    }

}
