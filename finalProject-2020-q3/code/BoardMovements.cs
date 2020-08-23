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
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                GetCellsUp(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList GetCellsDown(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            Cell next = CellMovements.DownStraight(piecesOnBoard, cell);
            if (ValidateCell(next))
            {
                response.Add(next);
                return next.IsEmpty() ?
                GetCellsDown(piecesOnBoard, next, response) : response;
            }
            return response;
        }

        private static CellList LeftAndRight(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            if (cell != null)
            {
                response.Add(CellMovements.LeftStraight(piecesOnBoard, cell));
                response.Add(CellMovements.RightStraight(piecesOnBoard, cell));
            }
            return response;
        }
        private static CellList UpAndDown(Cell[,] piecesOnBoard, Cell cell, CellList response)
        {
            if (cell != null)
            {
                response.Add(CellMovements.UpStraight(piecesOnBoard, cell));
                response.Add(CellMovements.DownStraight(piecesOnBoard, cell));
            }
            return response;
        }

        public static CellList GetKnightMovement(Cell[,] piecesOnBoard, Cell cell)
        {
            CellList cells = new CellList();
            if ( CellMovements.DownStraight(piecesOnBoard, cell) != null){
                Cell verticalDown = CellMovements.DownStraight(piecesOnBoard, CellMovements.DownStraight(piecesOnBoard, cell));
                LeftAndRight(piecesOnBoard, verticalDown, cells);
            }
            if (CellMovements.UpStraight(piecesOnBoard, cell) != null)
            {
                Cell verticalUp = CellMovements.UpStraight(piecesOnBoard, CellMovements.UpStraight(piecesOnBoard, cell));
                LeftAndRight(piecesOnBoard, verticalUp, cells);
            }
            if (CellMovements.LeftStraight(piecesOnBoard, cell) != null)
            {
                Cell horizontalLeft = CellMovements.LeftStraight(piecesOnBoard, CellMovements.LeftStraight(piecesOnBoard, cell));
                UpAndDown(piecesOnBoard, horizontalLeft, cells);
            }
            if (CellMovements.RightStraight(piecesOnBoard, cell) != null)
            {
                Cell horizontalRight = CellMovements.RightStraight(piecesOnBoard, CellMovements.RightStraight(piecesOnBoard, cell));
                UpAndDown(piecesOnBoard, horizontalRight, cells);
            }

            CellList result = new CellList();
            result.SetList(cells.Where(cell => (cell != null)).ToList());
            return result;
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
