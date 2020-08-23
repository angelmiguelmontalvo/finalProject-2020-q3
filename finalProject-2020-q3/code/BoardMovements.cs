using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalProject_2020_q3.code
{
    class BoardMovements
    {
        public static CellList AllCrossCells(Cell[,] piecesOnBoard, Cell position)
        {
            CellList left = GetCellsLeft(piecesOnBoard, position, new CellList());
            CellList right = GetCellsRight(piecesOnBoard, position, left);
            CellList down = GetCellsDown(piecesOnBoard, position, right);
            CellList response = GetCellsUp(piecesOnBoard, position, down);
            return response;
        }

        public static CellList AllCellsDiagonal(Cell[,] piecesOnBoard, Cell position)
        {
            CellList downLeft = GetCellDownLeft(piecesOnBoard, position, new CellList());
            CellList downRight = GetCellDownRight(piecesOnBoard, position, downLeft);
            CellList upLeaft = GetCellUpLeaft(piecesOnBoard, position, downRight);
            CellList response = GetCellUpRight(piecesOnBoard, position, upLeaft);
            return response;
        }

        private static CellList GetCellUpLeaft(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.UpLeftDiagonal(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                    GetCellUpLeaft(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellUpRight(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.UpRightDiagonal(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                    GetCellUpRight(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellDownRight(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.DownRightDiagonal(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                    GetCellDownRight(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellDownLeft(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.DownLeftDiagonal(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                    GetCellDownLeft(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellsLeft(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.LeftStraight(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ? 
                    GetCellsLeft(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellsRight(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.RightStraight(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                    GetCellsRight(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellsUp(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.UpStraight(piecesOnBoard, cell);
            if (ValidateEmptyCell(next))
            {
                response.Add(next);
                return GetCellsUp(piecesOnBoard, next, response);
            }
            return response;
        }

        private static CellList GetCellsDown(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.DownStraight(piecesOnBoard, cell);
            if (ValidateEmptyCell(next))
            {
                response.Add(next);
                return GetCellsDown(piecesOnBoard, next, response);
            }
            return response;
        }

        private static CellList LeftAndRight(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            response.Add(CellMovements.LeftStraight(piecesOnBoard, cell));
            response.Add(CellMovements.RightStraight(piecesOnBoard, cell));
            return response;
        }
        private static CellList UpAndDown(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            response.Add(CellMovements.UpStraight(piecesOnBoard, cell));
            response.Add(CellMovements.DownStraight(piecesOnBoard, cell));
            return response;
        }

        public static CellList GetKnightMovement(Cell[,] piecesOnBoard, Cell cell)
        {
            CellList cells = new CellList();
            Cell verticalDown = CellMovements.DownStraight(piecesOnBoard, CellMovements.DownStraight(piecesOnBoard, cell));
            Cell verticalUp = CellMovements.UpStraight(piecesOnBoard, CellMovements.UpStraight(piecesOnBoard, cell));

            Cell horizontalLeft = CellMovements.LeftStraight(piecesOnBoard, CellMovements.LeftStraight(piecesOnBoard, cell));
            Cell horizontalRight = CellMovements.RightStraight(piecesOnBoard, CellMovements.RightStraight(piecesOnBoard, cell));

            LeftAndRight(piecesOnBoard, verticalDown, cells);
            LeftAndRight(piecesOnBoard, verticalUp, cells);
            UpAndDown(piecesOnBoard, horizontalLeft, cells);
            UpAndDown(piecesOnBoard, horizontalRight, cells);
            CellList resultList = new CellList();
            resultList.SetList(cells.Where(cell => !(cell is null)).ToList());
            return resultList;
        }
        private static bool ValidateEmptyCell(Cell cell)
        {
            if (cell != null && cell.IsEmpty())
            {
                return true;
            }
            return false;
        }

        private static bool ValidateCell(Cell cell)
        {
            return cell != null;
        }

        private static bool ValidateCellPiece(Cell position, Cell next, int count)
        {
            if (count > 0) {
                return false;
            }
            if (next.IsEmpty() == false && next.piece.Color != position.piece.Color)
            {
                return true;
            }
            return false;
        }
    }
}
