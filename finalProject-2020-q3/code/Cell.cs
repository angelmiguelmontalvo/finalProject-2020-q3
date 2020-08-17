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
        private int row;
        private int column;

        public Cell(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public override string ToString()
        {
            return $"{rowsString[row]}{columnsString[column]}";
        }
    }
}
