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
            CellList response = new CellList();
            response.Add(CellMovements.UpStraight(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.DownStraight(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.LeftStraight(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.RightStraight(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.UpLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.UpRightDiagonal(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.DownLeftDiagonal(piecesOnBoard, piecesOnBoard[row, column]));
            response.Add(CellMovements.DownRightDiagonal(piecesOnBoard, piecesOnBoard[row, column]));
            return (CellList)response.Where(cell => cell != null).ToList();

        }

        public override CellList CaptureFreeCells(Cell[,] piecesOnBoard, int row, int column)
        {
            throw new NotImplementedException();
        }

        public override CellList AttackMovements(Cell[,] piecesOnBoard, int row, int column)
        {
            CellList cellList = ValidMovements(piecesOnBoard, row, column);
            return (CellList)cellList.Where(cell => cell.IsEmpty() == false).ToList();
        }
    }
}