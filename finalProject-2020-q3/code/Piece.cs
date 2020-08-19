using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public abstract class Piece
    {
        internal Color Color;

        public Piece(Color color)
        {
            this.Color = color;
        }

        public abstract CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column);
        public abstract CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column);
        public abstract CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column);
    }
}
