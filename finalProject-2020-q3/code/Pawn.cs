using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Pawn : Piece, IPromotion, IMoved
    {
        public bool IsTop { get; }
        public bool Moved { get; set; }

        public Pawn(Color color, bool isTop) : base(color)
        {
            this.IsTop = isTop;
        }
        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellsValid = new CellList();
            Cell cellmovement;
            cellmovement = IsTop ?
                CellMovements.UpStraight(piecesOnBoard, piecesOnBoard[row, column]) :
                CellMovements.DownStraight(piecesOnBoard, piecesOnBoard[row, column]);
            cellsValid.Add(cellmovement);
            if (!Moved)
            {
                Cell secondMovement = cellmovement != null && IsTop ?
                    CellMovements.UpStraight(piecesOnBoard, cellmovement):
                    CellMovements.DownStraight(piecesOnBoard, cellmovement);
                cellsValid.Add(secondMovement);
            }
            CellList list = new CellList();
            list.SetList(cellsValid.Where(cell => cell != null).ToList());
            CellList resultList = new CellList();
            resultList.SetList(list.Where(cell => cell.IsEmpty() == true).ToList());
            return resultList;
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellsValid = new CellList();
            Cell[] cellMovement = new Cell[2];
            if (IsTop)
            {
                cellMovement[0] = CellMovements.UpLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
                cellMovement[1] = CellMovements.UpRightDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
            }
            else
            {
                cellMovement[0] = CellMovements.DownLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
                cellMovement[1] = CellMovements.DownRightDiagonal(piecesOnBoard, piecesOnBoard[row, column]);
            }
            for(int i=0; i<2; i++){
                if (cellMovement[i] != null && !cellMovement[i].IsEmpty())
                {
                    cellsValid.Add(cellMovement[i]);
                }
            }
            CellList list = new CellList();
            list.SetList(cellsValid.Where(cell => cell != null).ToList());
            CellList resultList = new CellList();
            resultList.SetList(list.Where(cell => cell.piece.Color != this.Color).ToList());
            return resultList;
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

        public void PiceMoved(bool moved)
        {
            this.Moved = moved;
        }
    }

}
