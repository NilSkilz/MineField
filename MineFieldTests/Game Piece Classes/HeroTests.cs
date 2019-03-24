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
    public class HeroTests
    {
        [TestMethod()]
        public void LoseLifeTest()
        {
            Hero hero = new Hero(3); // Should have 3 lives
            
            if (!hero.TakeLife())
            {
                // Should return True
                Assert.Fail("1"); // 2 lives left
            }
            if (!hero.TakeLife())
            {
                // Should return True
                Assert.Fail("2"); // 1 life left
            }
            if (hero.TakeLife())
            {
                // Should return False
                Assert.Fail("3"); // Game over
            }


            Hero hero2 = new Hero(2); // Should have 3 lives

            if (!hero2.TakeLife())
            {
                // Should return True
                Assert.Fail("4"); // 2 lives left
            }
            if (hero2.TakeLife())
            {
                // Should return False
                Assert.Fail("5"); // Game over
            }
        }
    }
}