using System;
using System.Collections.Generic;
using System.Text;

namespace GameObjects
{
    public class Map
    {
        Dictionary<int, Tile> _tiles;
        Player _player;
        //Texture2D _background;

        public Dictionary<int, Tile> Tiles { get => _tiles; }

        public Map()
        {
            _tiles = new Dictionary<int, Tile>();
            _player = new Player();
        }

        public void AddOrUpdateTile(Tile tile)
        {
            Tiles[tile.Id] = tile;
        }

        //Tämä lienee presentationlayershittiä. Että Draw()it sun muut kuulunee tänne?
    }
}
