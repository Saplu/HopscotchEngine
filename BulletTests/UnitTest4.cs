using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest4
    {
        Rectangle rect = new Rectangle(100, 100, new Point(100, 100));
        Octagon oct = new Octagon(100, 100, new Point(100, 100));

        [TestMethod]
        public void TestMethod1()
        {
            oct.Position = new Point(200, 200);

            List<Point> expected = new List<Point>() { new Point(175, 150), new Point(225, 150), new Point(250, 175), new Point(250, 225),
            new Point(225, 250), new Point(175, 250), new Point(150, 225), new Point(150, 175)};

            List<Point> actual = oct.Corners;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            oct.Width = 200;

            List<Point> expected = new List<Point>() { new Point(50, 50), new Point(150, 50), new Point(200, 75), new Point(200, 125),
            new Point(150, 150), new Point(50, 150), new Point(0, 125), new Point(0, 75)};

            List<Point> actual = oct.Corners;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            oct.Position = new Point(100, 150);
            oct.Height = 300;

            List<Point> expected = new List<Point>() { new Point(75, 0), new Point(125, 0), new Point(150, 75), new Point(150, 225),
            new Point(125, 300), new Point(75, 300), new Point(50, 225), new Point(50, 75)};
            List<Point> actual = oct.Corners;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Octagon test = new Octagon(100, 100, new Point(100, 100));

            bool expected = true;

            bool actual = test.Equals(oct);

            Assert.AreEqual(expected, actual);
        }
    }
}
