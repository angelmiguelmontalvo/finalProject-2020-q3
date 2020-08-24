using System;
using System.Linq;

namespace finalProject_2020_q3.code
{
    public class King : Piece, ICastling, IMoved
    {
        private bool Moved { get; set; } = false;
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
            CellList result = new CellList();
            resultList.SetList(response.Where(cell => cell != null && (cell.IsEmpty() == true || cell.piece.Color != Color)).ToList());
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
            resultList.SetList(cellList.Where(cell => cell.IsEmpty() == false && cell.piece.Color != Color).ToList());
            return resultList;
        }

        public override string ToString()
        {
            string result = Color == Color.WHITE ? $"KW " : $" KB";
            return result;
        }

        public bool IsAbleTocast()
        {
            return !Moved;
        }

        public void PiceMoved(bool move)
        {
            this.Moved = move;
        }
    }
}