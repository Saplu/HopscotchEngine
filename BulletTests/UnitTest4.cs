using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BulletClassLibrary;

namespace BulletTests
{
    [TestClass]
    public class UnitTest4
    {
        Rectangle rect = new Rectangle(100, 100, new Vector2(100, 100));
        Octagon oct = new Octagon(100, 100, new Vector2(100, 100));

        [TestMethod]
        public void TestMethod1()
        {
            oct.Position = new Vector2(200, 200);

            List<Vector2> expected = new List<Vector2>() { new Vector2(175, 150), new Vector2(225, 150), new Vector2(250, 175), new Vector2(250, 225),
            new Vector2(225, 250), new Vector2(175, 250), new Vector2(150, 225), new Vector2(150, 175)};

            List<Vector2> actual = oct.Corners;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            oct.Width = 200;

            List<Vector2> expected = new List<Vector2>() { new Vector2(50, 50), new Vector2(150, 50), new Vector2(200, 75), new Vector2(200, 125),
            new Vector2(150, 150), new Vector2(50, 150), new Vector2(0, 125), new Vector2(0, 75)};

            List<Vector2> actual = oct.Corners;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            oct.Position = new Vector2(100, 150);
            oct.Height = 300;

            List<Vector2> expected = new List<Vector2>() { new Vector2(75, 0), new Vector2(125, 0), new Vector2(150, 75), new Vector2(150, 225),
            new Vector2(125, 300), new Vector2(75, 300), new Vector2(50, 225), new Vector2(50, 75)};
            List<Vector2> actual = oct.Corners;

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Octagon test = new Octagon(100, 100, new Vector2(100, 100));

            bool expected = true;

            bool actual = test.Equals(oct);

            Assert.AreEqual(expected, actual);
        }
    }
}
