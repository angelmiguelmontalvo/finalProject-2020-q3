using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    class PieceFactory
    {
        public static Piece BuildPieces(PieceType pieceType, Color color, Cell position)
        {
            Piece piece = null;
            switch (pieceType)
            {
                case PieceType.PAWN:
                    piece = new Pawn(color, position);
                    break;
                case PieceType.QUEEN:
                    piece = new Queen(color, position);
                    break;
                case PieceType.KNIGHT:
                    piece = new Knight(color, position);
                    break;
                case PieceType.BISHOP:
                    piece = new Bishop(color, position);
                    break;
                case PieceType.ROOK:
                    piece = new Rook(color, position);
                    break;
                case PieceType.KING:
                    piece = new King(color, position);
                    break;
                default: return null;
            }
            return piece;

        }
    }
}
