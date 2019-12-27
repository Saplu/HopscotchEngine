using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace GameObjects
{
    public class Map : IEnumerable
    {
        Dictionary<int, Tile> _tiles;
        Player _player;

        public Dictionary<int, Tile> Tiles { get => _tiles; }
        public Player Player { get => _player; set => _player = value; }

        public Map()
        {
            _tiles = new Dictionary<int, Tile>();
            _player = new Player();
            _player.Position = new Geometry.Vector2(100, 150);
            CreateMap();
        }

        public void Update(int milliseconds)
        {
            _player.Update(milliseconds);
        }

        public void AddOrUpdateTile(Tile tile)
        {
            Tiles[tile.Id] = tile;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public TileEnum GetEnumerator()
        {
            return new TileEnum(_tiles);
        }

        private void CreateMap()
        {
            for (int i = 340; i < 375; i++)
            {
                AddOrUpdateTile(new Tile(1, i));
            }
            for (int i = 320; i < 325; i++)
            {
                AddOrUpdateTile(new Tile(1, i));
            }
            AddOrUpdateTile(new Tile(1, 263));
            AddOrUpdateTile(new Tile(1, 253));
        }
    }
}
