using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace finalProject_2020_q3.code
{
    class CellMovements
    {
        public static Cell UpRightDiagonal(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row + 1, position.Column + 1);
        }

        public static Cell UpLeftDiagonal(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row + 1, position.Column - 1);
        }

        public static Cell DownRightDiagonal(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row - 1, position.Column + 1);
        }

        public static Cell DownLeftDiagonal(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row - 1, position.Column - 1);
        }

        public static Cell DownStraight(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row -1, position.Column);
        }

        public static Cell UpStraight(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row +1, position.Column);
        }

        public static Cell LeftStraight(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row, position.Column -1);
        }

        public static Cell RightStraight(Cell[,] piecesOnBoard, Cell position)
        {
            return ReturnCellInPosition(piecesOnBoard, position.Row, position.Column + 1);
        }

        private static bool ValidatePositionCell (int row, int column)
        {
            if (column<8 && column > 0 && row < 8 && row > 0)
            {
                return true;
            }
            return false;
        }

        private static Cell ReturnCellInPosition(Cell[,] piecesOnBoard, int row, int column)
        {
            if (ValidatePositionCell(row, column))
            {
                return piecesOnBoard[row, column];
            }
            return null;
        }
    }
}
