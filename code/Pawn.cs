using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Pawn : Piece, IPromotion
    {
        public Pawn(Color color, Cell position) : base(color, position)
        {

        }
        public override Cell ValidMovements()
        {
            throw new NotImplementedException();
        }

        public override Cell AttackMovements()
        {
            throw new NotImplementedException();
        }

        public override Cell CaptureFreeCells()
        {
            throw new NotImplementedException();
        }

        public Piece Promote(PieceType pieceType)
        {
            throw new NotImplementedException();
        }

    }

}
