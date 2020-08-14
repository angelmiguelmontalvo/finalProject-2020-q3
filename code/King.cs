using System;

namespace finalProject_2020_q3.code
{
    public class King : Piece, ICastling
    {
        public King(Color color, Cell poistion) : base(color, poistion) { }

        public void ICastling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

        public override Cell ValidMovements()
        {
            throw new NotImplementedException();
        }
    }
}