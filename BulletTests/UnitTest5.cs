using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest5
    {
        RectangleHitbox box = new RectangleHitbox(100, 100, new Point(100, 100), 17);

        [TestMethod]
        public void TestMethod1()
        {
            bool expected = false;
            bool actual = box.Hit(new Point(140, 60));
            Assert.AreEqual(expected, actual);
        }
    }
}
