using System;
using System.Collections.Generic;
using System.Text;
using GameObjects;
using SFML.Graphics;
using SFML.System;

namespace Rendering
{
    public class PresentationMap : SFML.Graphics.Drawable
    {
        Map _map;
        Texture _tileTexture;
        Sprite _sprite;

        public PresentationMap(Texture texture)
        {
            _map = new Map();
            _map.AddOrUpdateTile(new Tile(1, 4));
            _map.AddOrUpdateTile(new Tile(1, 9));
            _map.AddOrUpdateTile(new Tile(1, 39));
            _tileTexture = texture;
            _sprite = new Sprite(_tileTexture);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var item in _map.Tiles)
            {
                var tile = new Sprite(_tileTexture);
                tile.TextureRect = new IntRect(new Vector2i(Convert.ToInt32(item.Value.Position.X),
                    Convert.ToInt32(item.Value.Position.Y)), new Vector2i(32, 32));
                tile.Position = new Vector2f((float)item.Value.Position.X, (float)item.Value.Position.Y);
                target.Draw(tile);
            }
        }
    }
}
