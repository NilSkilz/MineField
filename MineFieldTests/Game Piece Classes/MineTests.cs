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
            for (int i = 0; i < 100; i++)
            {
                Random rnd = new Random();
                Mine instance = new Mine(rnd);
                Coordinate mine = instance.GenerateRandomCoordinate(rnd);

                if (mine.X < 2 && mine.Y < 2)
                {
                    Assert.Fail("Less than 2");
                }

                if (mine.X > 6 && mine.Y > 6)
                {
                    Assert.Fail(mine.X.ToString() + " : " + mine.Y.ToString());
                }
            }
        }

        [TestMethod()]
        public void CollisionDetectionTest()
        {
            Mine mine = new Mine(new Random());
            mine.location.X = 3;
            mine.location.Y = 4;

            if (mine.hasCollided(new Coordinate()
            {
                X = 1,
                Y = 1
            }))
            {
                Assert.Fail();
            }

            if (mine.hasCollided(new Coordinate()
            {
                X = 3,
                Y = 1
            }))
            {
                Assert.Fail();
            }

            if (mine.hasCollided(new Coordinate()
            {
                X = 1,
                Y = 4
            }))
            {
                Assert.Fail();
            }

            if (!mine.hasCollided(new Coordinate()
            {
                X = 3,
                Y = 4
            }))
            {
                Assert.Fail();
            }
        }
    }
}