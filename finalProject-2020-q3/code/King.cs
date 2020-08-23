using System;
using System.Linq;

namespace finalProject_2020_q3.code
{
    public class King : Piece, ICastling
    {
        public King(Color color) : base(color) { }

        public void Castling(Rook rook, King king)
        {
            throw new NotImplementedException();
        }

        public override CellList ValidMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList response = new CellList
            {
                CellMovements.UpStraight(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.DownStraight(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.LeftStraight(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.RightStraight(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.UpLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.UpRightDiagonal(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.DownLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]),
                CellMovements.DownRightDiagonal(piecesOnBoard, piecesOnBoard[row, column])
            };
            CellList resultList = new CellList();
            resultList.SetList(response.Where(cell => cell != null).ToList());
            return resultList;
        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellList = ValidMovements(piecesOnBoard, row, column);
            CellList resultList = new CellList();
            resultList.SetList(cellList.Where(cell => cell.IsEmpty() == false).ToList());
            return resultList;
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"KW " : $" KB";
            return result;
        }
    }
}