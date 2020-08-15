using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Rook : Piece, ICastling
    {
        public Rook(Color color, Cell poistion) : base(color, poistion) { }

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

        public void ICastling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

    }
}
