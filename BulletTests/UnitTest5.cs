using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest5
    {
        RectangleHitbox box = new RectangleHitbox(100, 100, new Point(100, 100), 5);

        [TestMethod]
        public void TestMethod1()
        {
            bool expected = false;
            bool actual = box.Hit(new Point(140, 60));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var testBox = new RectangleHitbox(200, 200, new Point(200, 100), 25);
            bool expected = true;
            bool actual = box.Hit(testBox);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var testBox = new Hitbox(200, 200, new Point(100, 251));
            bool expected = true;
            bool actual = box.Hit(testBox);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var testBox = new Hitbox(200, 200, new Point(100, 251));
            bool expected = true;
            bool actual = testBox.Hit(box);
            Assert.AreEqual(expected, actual);
        }
    }
}
