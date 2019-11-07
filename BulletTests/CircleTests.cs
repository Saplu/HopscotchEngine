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

            var actual = c.FindClosestPoint(point);

            Assert.AreEqual(expected, actual);
        }
    }
}
