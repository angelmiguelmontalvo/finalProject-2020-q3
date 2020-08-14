using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public abstract class Piece
    {
        private Color color;
        private Cell position;

        public Piece (Color color, Cell position)
        {
            this.color = color;
            this.position = position;
        }

        public abstract Cell ValidMovements();
                
    }
}
