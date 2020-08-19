using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    class PieceFactory
    {
        public static Piece BuildPieces(PieceType pieceType, Color color, bool isTop = true)
        {
            Piece piece = null;
            switch (pieceType)
            {
                case PieceType.PAWN:
                    piece = new Pawn(color, isTop);
                    break;
                case PieceType.QUEEN:
                    piece = new Queen(color);
                    break;
                case PieceType.KNIGHT:
                    piece = new Knight(color);
                    break;
                case PieceType.BISHOP:
                    piece = new Bishop(color);
                    break;
                case PieceType.ROOK:
                    piece = new Rook(color);
                    break;
                case PieceType.KING:
                    piece = new King(color);
                    break;
                default: return null;
            }
            return piece;

        }
    }
}
