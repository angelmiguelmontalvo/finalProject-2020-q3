using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Cell
    {
        public static readonly Dictionary<int, string> rowsString = new Dictionary<int, string>
        {
            {0, "1"}, {1, "2"}, {2, "3"}, {3, "4"}, {4, "5"}, {5, "6"}, {6, "7"}, {7, "8"},
        };
        public static readonly Dictionary<int, string> columnsString = new Dictionary<int, string>
        {
            {0, "a"}, {1, "b"}, {2, "c"}, {3, "d"}, {4, "e"}, {5, "f"}, {6, "g"}, {7, "h"}
        };
        public int Row { get; }
        public int Column { get; }

        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public Cell(string cell)
        {
            row = GetRow(cell);
            column = GetColumn(cell);
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
        public override string ToString()
        {
            return $"{rowsString[Row]}{columnsString[Column]}";
        }

    }
}
