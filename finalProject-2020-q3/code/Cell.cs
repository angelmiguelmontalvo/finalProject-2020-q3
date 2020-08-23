using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Cell
    {
        public static readonly Dictionary<int, string> rowsString = new Dictionary<int, string>
        {
            {0, "8"}, {1, "7"}, {2, "6"}, {3, "5"}, {4, "4"}, {5, "3"}, {6, "2"}, {7, "1"},
        };
        public static readonly Dictionary<int, string> columnsString = new Dictionary<int, string>
        {
            {0, "a"}, {1, "b"}, {2, "c"}, {3, "d"}, {4, "e"}, {5, "f"}, {6, "g"}, {7, "h"}
        };
        public Piece piece { get; set; }
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Cell(string cell)
        {
            this.Row = GetRow(cell);
            this.Column = GetColumn(cell);
        }

        public string GetRow()
        {
            return rowsString[Row];
        }

        public string GetColumn()
        {
            return columnsString[Column];
        }

        public int GetRow(string cell)
        {
            var row = -1;
            foreach (var pair in rowsString)
            { 
                if (pair.Value == cell.Substring(0, 1))
                {
                    row = pair.Key;
                }
            }
            return row;
        }

        public int GetColumn(string cell)
        {
            var column = -1;
            foreach (var pair in columnsString) {
                if (pair.Value == cell.Substring(1))
                {
                    column = pair.Key;
                }
            }
            return column;
        }
        public CellList GetValidMovements(Cell[,] cellsOnBoard)
        {
            CellList movements = new CellList();
            if (this.piece == null)
            {
                return movements;
            }
            movements = piece.ValidMovements(cellsOnBoard, this.Row, this.Column);
            return movements;
        }

        public CellList GetAttackMovements(Cell[,] cellsOnBoard)
        {
            CellList movements = new CellList();
            if (this.piece == null)
            {
                return movements;
            }
            movements = piece.AttackMovements(cellsOnBoard, this.Row, this.Column);
            return movements;
        }
        public void RemovePiece() 
        {
            this.piece = null;
        }
        public override string ToString()
        {
            return $"{rowsString[Row]}{columnsString[Column]}";
        }

        public string WritePiece()
        {
            string result = this.piece == null ? "   " : this.piece.ToString();
            return result;
        }

        public bool IsEmpty()
        {
            return piece == null;
        }

        public bool CompareCell(Cell cell)
        {
            return !(cell is null) && cell.Row == Row && cell.Column == Column;
        }
    }
}
