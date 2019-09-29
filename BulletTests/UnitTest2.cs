using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest2
    {
        
        Hitbox hitbox = new Hitbox(100, 100, new Point(100, 100));

        [TestMethod]
        public void TestMethod1()
        {
            Point point = new Point(100, 100);

            bool actual = hitbox.Hit(point);

            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Hitbox testbox = new Hitbox(20, 20, new Point(150, 60));

            bool actual = hitbox.Hit(testbox);

            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
