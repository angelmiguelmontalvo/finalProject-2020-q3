using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    class BoardMovements
    {
        public static CellList AllCellsHorizontal(Cell[,] piecesOnBoard, Cell position)
        {
            CellList left = GetLeftEmpty(piecesOnBoard, position, new CellList());
            CellList response = GetRightEmpty(piecesOnBoard, position, left);
            return response;
        }

        public static CellList AllCellsVertical(Cell[,] piecesOnBoard, Cell position)
        {
            CellList down = GetDownEmpty(piecesOnBoard, position, new CellList());
            CellList response = GetUpEmpty(piecesOnBoard, position, down);
            return response;
        }

        private static CellList GetLeftEmpty(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.LeftStraight(piecesOnBoard, cell);
            if (ValidateEmptyCell(next))
            {
                response.Add(next);
                return GetLeftEmpty(piecesOnBoard, next, response);
            }
            return response;
        }

        private static CellList GetRightEmpty(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.RightStraight(piecesOnBoard, cell);
            if (ValidateEmptyCell(next))
            {
                response.Add(next);
                return GetRightEmpty(piecesOnBoard, next, response);
            }
            return response;
        }

        private static CellList GetUpEmpty(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.UpStraight(piecesOnBoard, cell);
            if (ValidateEmptyCell(next))
            {
                response.Add(next);
                return GetUpEmpty(piecesOnBoard, next, response);
            }
            return response;
        }

        private static CellList GetDownEmpty(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.DownStraight(piecesOnBoard, cell);
            if (ValidateEmptyCell(next))
            {
                response.Add(next);
                return GetDownEmpty(piecesOnBoard, next, response);
            }
            return response;
        }
        private static bool ValidateEmptyCell(Cell cell)
        {
            if (cell != null && cell.IsEmpty())
            {
                return true;
            }
            return false;
        }

    }
}
