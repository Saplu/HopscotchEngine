using System;
using System.Linq;
using Moq;
using BulletClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulletTests
{
    [TestClass]
    public class UnitTest1
    {
        Bullet bullet = new Bullet(10, 10, 100, 0);

        [TestMethod]
        public void TestMethod1()
        {
            /*
            Mock<IPoint> point = new Mock<IPoint>(); <---Aina interface tähän tyyliin!
            point.Setup(x => x.returnTest(bullet.test)).Returns(10);

            bullet.Update(1);
            Assert.AreEqual(10, bullet.test);
            */
        }
    }
}
