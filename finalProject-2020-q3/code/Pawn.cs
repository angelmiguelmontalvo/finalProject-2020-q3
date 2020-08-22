﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Pawn : Piece, IPromotion
    {
        private readonly bool IsTop;

        public Pawn(Color color, bool isTop) : base(color)
        {
            this.IsTop = isTop;
        }
        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellsValid = new CellList();
            Cell cellmovement;
            cellmovement = IsTop ?
                CellMovements.DownStraight(piecesOnBoard, piecesOnBoard[row, column]) : 
                CellMovements.UpStraight(piecesOnBoard, piecesOnBoard[row, column]);
            if (cellmovement != null && cellmovement.IsEmpty())
            {
                cellsValid.Add(cellmovement);                
            }
            CellList list = (CellList)cellsValid.Where(cell => cell != null).ToList();
            return (CellList)list.Where(cell => cell.IsEmpty() == true).ToList();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellsValid = new CellList();
            Cell[] cellMovement = new Cell[2];
            if (IsTop)
            {
                cellMovement[0] = CellMovements.DownLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
                cellMovement[1] = CellMovements.DownLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
            }
            else
            {
                cellMovement[0] = CellMovements.UpLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
                cellMovement[1] = CellMovements.UpRightDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
            }
            for(int i=0; i<2; i++){
                if (!cellMovement[i].IsEmpty())
                {
                    cellsValid.Add(cellMovement[i]);
                }
            }
            CellList list = (CellList)cellsValid.Where(cell => cell != null).ToList();
            return (CellList)list.Where(cell => cell.piece.Color != this.Color).ToList();
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public Piece Promote(PieceType pieceType)
        {
            return PieceFactory.BuildPieces(pieceType, this.Color);
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"pW " : $" pB";
            return result;
        }
    }

}
