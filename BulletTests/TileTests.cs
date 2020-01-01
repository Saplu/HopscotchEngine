using System;
using System.Collections.Generic;
using Geometry;
using Geometry.Hitbox;
using GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BulletTests
{
    [TestClass]
    public class TileTests
    {

        [TestMethod]
        public void TestMethod1()
        {
            //Tile tile1 = new Tile(50, 110, 0);
            //var expected = new List<Vector2>()
            //{
            //    new Vector2(0, 32),
            //    new Vector2(32, 32),
            //    new Vector2(32, 0)
            //};
            //var actual = tile1.GetCornersBetween(3, 0);

            //CollectionAssert.AreEqual(expected, actual);

            Tile tile1 = new Tile(48, 112, 0);
            Tile tile2 = new Tile(95, 32, 0);
            Tile tile3 = new Tile(120, 10, 0);

            var ex1 = 2;
            var ex2 = 1;
            var ex3 = 3;

            Assert.AreEqual(ex1, tile1.Hitbox.Count);
            Assert.AreEqual(ex2, tile2.Hitbox.Count);
            Assert.AreEqual(ex3, tile3.Hitbox.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethod2()
        {
            Tile tile2 = new Tile(128, 110, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod3()
        {
            Tile tile3 = new Tile(100, 110, 0);
        }

        [TestMethod]
        public void FullTile()
        {
            Tile full = new Tile(1, 0);
            var expected = new RectangleHitbox(32, 32, new Vector2(0, 0), 0);

            Assert.AreEqual(expected, full.Hitbox[0]);
        }

        [TestMethod]
        public void HalfTiles()
        {
            Tile down = new Tile(3, 0);
            Tile up = new Tile(2, 0);

            var first = new TriangleHitbox(new Vector2(0, 0), new Vector2(32, 32), new Vector2(0, 32));
            var second = new TriangleHitbox(new Vector2(0, 32), new Vector2(32, 0), new Vector2(32, 32));

            Assert.AreEqual(first, down.Hitbox[0]);
            Assert.AreEqual(second, up.Hitbox[0]);
        }

        [TestMethod]
        public void TilePositions()
        {
            Tile first = new Tile(1, 1);
            Tile second = new Tile(1, 24);
            Tile third = new Tile(1, 25);

            Assert.AreEqual(new Vector2(32, 0), first.Position);
            Assert.AreEqual(new Vector2(768, 0), second.Position);
            Assert.AreEqual(new Vector2(0, 32), third.Position);
        }

        [TestMethod]
        public void TileAngle()
        {
            Tile first = new Tile(96, 32, 111);
            Tile second = new Tile(127, 33, 0);
            Tile third = new Tile(33, 127, 0);
            Tile final = new Tile(80, 16, 0);

            Assert.AreEqual(first.Angle, 45);
            Assert.AreEqual(second.Angle, 0);
            Assert.AreEqual(third.Angle, 180);
            Assert.AreEqual(final.Angle, 90);
        }
    }
}
