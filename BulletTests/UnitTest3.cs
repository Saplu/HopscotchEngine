using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest3
    {
        RectangleHitbox hb = new RectangleHitbox(100, 100, new Point(100, 100), 0);

        [TestMethod]
        public void TestMethod1()
        {
            RectangleHitbox testBox = new RectangleHitbox(10, 1000, new Point(0, 150), 0);

            bool actual = hb.Hit(testBox);

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
