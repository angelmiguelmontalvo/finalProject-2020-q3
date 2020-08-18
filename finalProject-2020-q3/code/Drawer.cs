using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class Drawer
    {
        public static void DrawBoard(Board board)
        {
            StringBuilder rowBoard = new StringBuilder();
            rowBoard.Append("     a   b   c   d   e   f   g   h  ");
            rowBoard.Append("\n  ---------------------------------");
            int row = 8;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8 ; j++)
                {
                    if (j == 0)
                    {
                        rowBoard.Append($"\n{row} |   |");
                    }
                    else
                    {
                        rowBoard.Append("   |");
                    }
                }
                rowBoard.Append("\n  ---------------------------------");
                row--;
            }
            Console.WriteLine(rowBoard.ToString());
        }
    }
}
