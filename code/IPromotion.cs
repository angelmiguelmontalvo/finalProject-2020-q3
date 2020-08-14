using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace finalProject_2020_q3.code
{
    public interface IPromotion
    {
        public Piece Promote(PiceType piceType);
    }
}
