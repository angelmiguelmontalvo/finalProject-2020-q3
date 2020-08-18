using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public abstract class Piece
    {
        internal Color Color;
        internal Cell Position;

        public Piece(Color color, Cell position)
        {
            this.Color = color;
            this.Position = position;
        }

        public abstract CellList ValidMovements(Piece[,] piecesOnBoard);
        public abstract CellList AttackMovements(Piece[,] piecesOnBoard);
        public abstract CellList CaptureFreeCells(Piece[,] piecesOnBoard);
    }
}
