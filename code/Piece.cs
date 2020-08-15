using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public abstract class Piece
    {
        private Color Color;
        private Cell Position;

        public Piece(Color color, Cell position)
        {
            this.Color = color;
            this.Position = position;
        }

        public abstract Cell ValidMovements();
        public abstract Cell AttackMovements();
        public abstract Cell CaptureFreeCells();
    }
}
