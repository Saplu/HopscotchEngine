using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulletTests
{
    [TestClass]
    public class GametimeTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var first = new DateTime(2019, 10, 20, 11, 27, 0, 0);
            var second = new DateTime(2019, 10, 20, 11, 27, 0, 400);
            var third = new DateTime(2019, 10, 20, 11, 27, 0, 700);

            var totalTime = third - first;
            var sinceLast = third - second;
            var previous = third;

            Assert.AreEqual(700, totalTime.Milliseconds);
            Assert.AreEqual(300, sinceLast.Milliseconds);
        }
    }
}
