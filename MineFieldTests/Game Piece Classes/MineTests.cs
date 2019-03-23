using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineField.Game_Piece_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineField.Game_Piece_Classes.Tests
{
    [TestClass()]
    public class MineTests
    {
        [TestMethod()]
        public void GenerateRandomCoordinateTest()
        {
            Mine mine = new Mine(0, 0, 1, 1, 8, 8, new Random());

            if (mine.location.X < 2 && mine.location.Y < 2)
            {
                Assert.Fail();
            }

        }
    }
}