using Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BulletTests
{
    [TestClass]
    public class RangeTests
    {
        RangeChecker check = new RangeChecker();
         
        [TestMethod]
        public void TestMethod1()
        {
            var a = new Vector2(1, 1);
            var b = new Vector2(2, 0);

            var expected = Math.Sqrt(2);
            var actual = check.CheckRange(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
