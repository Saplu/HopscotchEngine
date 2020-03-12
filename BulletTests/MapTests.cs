using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameObjects;
using System.Linq;

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

            Assert.AreEqual(55, map.Tiles.Count); //53 tulee constructorista atm.
        }

        [TestMethod]
        public void HitboxesGeneratedCorrectly()
        {
            var map = new Map();

            var result = false;

            for (int i = 0; i < map.Hitboxes.Count; i++)
            {
                for (int j = 0; j < map.Hitboxes.Count; j++)
                {
                    if (i != j)
                    {
                        if (map.Hitboxes[j].Equals(map.Hitboxes[i]))
                            result = true;
                    }
                }
            }

            Assert.AreEqual(false, result);
            Assert.AreEqual(53, map.Hitboxes.Count);
        }
    }
}
