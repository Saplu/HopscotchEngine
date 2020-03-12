using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Geometry;
using System.Linq;

namespace GameObjects
{
    public class Map : IEnumerable
    {
        Dictionary<int, Tile> _tiles;
        Player _player;
        List<IHitbox> _hitboxes;

        public Dictionary<int, Tile> Tiles { get => _tiles; }
        public Player Player { get => _player; set => _player = value; }
        public List<IHitbox> Hitboxes { get => _hitboxes; set => _hitboxes = value; }

        public Map()
        {
            _tiles = new Dictionary<int, Tile>();
            _player = new Player();
            CreateMap();
        }

        public void Update(int milliseconds)
        {
            _player.Update(milliseconds, _hitboxes);
        }

        public void AddOrUpdateTile(Tile tile) =>
            Tiles[tile.Id] = tile;

        IEnumerator IEnumerable.GetEnumerator() =>
            (IEnumerator)GetEnumerator();

        public TileEnum GetEnumerator() =>
            new TileEnum(_tiles);

        private void CreateMap()
        {
            for (int i = 350; i < 375; i++)
            {
                AddOrUpdateTile(new Tile(1, i));
            }
            for (int i = 335; i < 340; i++)
            {
                AddOrUpdateTile(new Tile(1, i));
            }
            for (int i = 320; i < 325; i++)
            {
                AddOrUpdateTile(new Tile(1, i));
            }
            for (int i = 224; i < 229; i++)
            {
                AddOrUpdateTile(new Tile(1, i));
            }
            AddOrUpdateTile(new Tile(1, 198));
            AddOrUpdateTile(new Tile(1, 154));
            AddOrUpdateTile(new Tile(1, 120));
            AddOrUpdateTile(new Tile(1, 263));
            AddOrUpdateTile(new Tile(1, 253));
            AddOrUpdateTile(new Tile(1, 300));
            AddOrUpdateTile(new Tile(1, 325));
            AddOrUpdateTile(new Tile(1, 200));
            AddOrUpdateTile(new Tile(1, 318));
            AddOrUpdateTile(new Tile(1, 45));
            AddOrUpdateTile(new Tile(1, 110));
            AddOrUpdateTile(new Tile(1, 140));
            AddOrUpdateTile(new Tile(1, 100));
            GetHitboxes();
        }

        private void GetHitboxes()
        {
            _hitboxes = new List<IHitbox>();
            _tiles.Values.Select(t => t.Hitbox).ToList().ForEach(b => _hitboxes.AddRange(b));
        }
    }
}
