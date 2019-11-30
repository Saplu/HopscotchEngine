using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry.Map;

namespace BulletTests
{
    [TestClass]
    public class MapTests
    {
        [TestMethod]
        public void AddTile()
        {
            var map = new Map();

            map.AddOrUpdateTile(new Tile(1, 4));
            map.AddOrUpdateTile(new Tile(2, 4));
            map.AddOrUpdateTile(new Tile(100, 20, 1));
            map.AddOrUpdateTile(new Tile(3, 4));

            Assert.AreEqual(2, map.Tiles.Count);
        }
    }
}
