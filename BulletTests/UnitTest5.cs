using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulletTests
{
    [TestClass]
    public class UnitTest5
    {
        RectangleHitbox box = new RectangleHitbox(100, 100, new Vector2(100, 100), 5);
        OctagonHitbox box2 = new OctagonHitbox(100, 100, new Vector2(100, 100));

        [TestMethod]
        public void TestMethod1()
        {
            bool expected = true;
            bool actual = box.Hit(new Vector2(140, 60));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var testBox = new RectangleHitbox(200, 200, new Vector2(200, 100), 25);
            bool expected = true;
            bool actual = box.Hit(testBox);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var testBox = new OctagonHitbox(20, 2000, new Vector2(200, 140));
            bool expected = true;
            bool actual = box2.Hit(testBox);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var testBox = new RectangleHitbox(200, 200, new Vector2(200, 100), 0);
            bool expected = true;
            bool actual = box2.Hit(testBox);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var actual = box2.CheckHitbox(new Circle(new Vector2(10, 10), 100));

            Assert.AreEqual(false, actual);
        }
    }
}
