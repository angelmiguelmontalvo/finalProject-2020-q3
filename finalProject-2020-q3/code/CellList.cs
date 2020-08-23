using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code
{
    public class CellList: List<Cell>
    {
        public void SetList(List<Cell> listCell)
        {
            foreach(var cell in listCell)
            {
                this.Add(cell);
            }
        }
    }
}
