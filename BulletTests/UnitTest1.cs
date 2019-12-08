using System;
using System.Linq;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;

namespace BulletTests
{
    [TestClass]
    public class UnitTest1
    {
        RectangleHitbox _box = new RectangleHitbox(50, 50, new Vector2(100, 100), 0);

        [TestMethod]
        public void TestMethod1()
        {
            Mock<ICircle> circle = new Mock<ICircle>();
            circle.Setup(x => x.FindClosestPoint(_box.Box.Position)).Returns(new Vector2(124, 124));

            var point = circle.Object.FindClosestPoint(_box.Box.Position);
            var actual = _box.Hit(point);
            var expected = true;

            var second = _box.CheckHitbox(circle.Object);

            Assert.AreEqual(expected, actual);
        }
    }
}
