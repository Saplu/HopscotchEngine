using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;
using Geometry;

namespace BulletTests
{
    [TestClass]
    public class UnitTest2
    {
        
        Hitbox hitbox = new Hitbox(100, 100, new Vector2(100, 100));

        [TestMethod]
        public void TestMethod1()
        {
            Vector2 point = new Vector2(100, 100);

            bool actual = hitbox.Hit(point);

            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Hitbox testbox = new Hitbox(20, 20, new Vector2(150, 60));

            bool actual = hitbox.Hit(testbox);

            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
