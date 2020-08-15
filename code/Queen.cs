using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    class Queen : Piece
    {
        public Queen(Color color, Cell position) : base(color, position) { }

        public override Cell AttackMovements()
        {
            throw new NotImplementedException();
        }

        public override Cell captureFreeCells()
        {
            throw new NotImplementedException();
        }

        public override Cell ValidMovements()
        {
            throw new NotImplementedException();
        }
    }
}
