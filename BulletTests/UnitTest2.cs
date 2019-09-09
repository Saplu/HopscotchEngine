using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest2
    {
        
        Hitbox hitbox = new Hitbox(100, 100, new Point(50, 50));

        [TestMethod]
        public void TestMethod1()
        {
            Hitbox testBox = new Hitbox(50, 50, new Point(126, 50));

            bool actual = hitbox.Hit(testBox);

            bool expected = false;
            Assert.AreEqual(expected, actual);
        }  
    }
}
