using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    class Knight : Piece
    {
        public Knight (Color color, Cell position) : base(color, position) { }

        public override Cell AttackMovements()
        {
            throw new NotImplementedException();
        }

        public override Cell CaptureFreeCells()
        {
            throw new NotImplementedException();
        }

        public override Cell ValidMovements()
        {
            throw new NotImplementedException();
        }
    }
}
