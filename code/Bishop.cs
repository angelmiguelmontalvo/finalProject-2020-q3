using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Cell position): base(color, position) { }

        public override Cell ValidMovements()
        {
            throw new NotImplementedException();
        }
    }
}
