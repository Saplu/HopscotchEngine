using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest5
    {
        Rectangle r = new Rectangle(100, 100, new Point(100, 100), 30);

        [TestMethod]
        public void TestMethod1()
        {
            Point expected = new Point(70, 70);
            Point actual = r.Corners[0];
            Assert.AreEqual(expected, actual);
        }
    }
}
