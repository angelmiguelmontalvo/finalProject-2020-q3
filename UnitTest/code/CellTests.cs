using Microsoft.VisualStudio.TestTools.UnitTesting;
using finalProject_2020_q3.code;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject_2020_q3.code.Tests
{
    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void Test_GetRow()
        {
            string cell = "1a";
            Cell testCell = new Cell(0, 0);
            int result = testCell.GetColumn(cell);
            Assert.AreEqual(0, result, $"{cell} cell is not par of board");
        }

        [TestMethod()]
        public void Test_GetColumn()
        {
            string cell = "1a";
            Cell testCell = new Cell(0, 0);
            int result = testCell.GetRow(cell);
            Assert.AreEqual(0, result, $"{cell} cell is not par of board");
        }

        [TestMethod()]
        [DataRow("1a")]
        [DataRow("2a")]
        [DataRow("3a")]
        [DataRow("4a")]
        [DataRow("5a")]
        [DataRow("6a")]
        [DataRow("7a")]
        [DataRow("8a")]
        [DataRow("1h")]
        [DataRow("8h")]
        public void CreateCell(string input)
        {
            Cell test = new Cell(input);
            string testToString = test.ToString();
            Assert.AreEqual(input, testToString, $"{input} and {testToString} are not equal");
        }
    }
}
