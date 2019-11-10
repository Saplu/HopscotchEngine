using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace BulletTests
{
    [TestClass]
    public class CircleTests
    {
        CircleHitbox c = new CircleHitbox(100, new Vector2(100, 100));

        [TestMethod]
        public void FindingClosestPointOfCircle()
        {
            var point = new Vector2(400, 100);
            var expected = new Vector2(200, 100);

            var actual = c.Box.FindClosestPoint(point);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CircleHitOctagonTest()
        {
            var oct = new OctagonHitbox(50, 50, new Vector2(120, 210));
            var actual = c.Hit(oct);
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void CircleHitRectangleTest()
        {
            var rect = new RectangleHitbox(70, 70, new Vector2(100, 137), 20);
            var actual = c.Hit(rect);
            Assert.AreEqual(true, actual);
        }
    }
}
