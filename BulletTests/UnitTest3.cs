using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulletTests
{
    [TestClass]
    public class UnitTest3
    {
        RectangleHitbox hb = new RectangleHitbox(100, 100, new Vector2(100, 100), 0);

        [TestMethod]
        public void TestMethod1()
        {
            RectangleHitbox testBox = new RectangleHitbox(10, 1000, new Vector2(0, 100), 0);

            bool actual = hb.Hit(testBox);

            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
