using System;
using System.Collections.Generic;
using System.Text;
using GameObjects;
using SFML.Graphics;
using SFML.System;

namespace Rendering
{
    public class PresentationMap : Drawable
    {
        Map _map;
        Texture _tileTexture, _background, _playerTexture;
        Sprite _bgs, _playerSprite;

        public PresentationMap(Texture tileTexture, Texture backgroundTexture, Texture playerTexture)
        {
            _map = new Map();
            _tileTexture = tileTexture;
            _background = backgroundTexture;
            _playerTexture = playerTexture;
            _bgs = new Sprite(_background);
            _bgs.TextureRect = new IntRect(new Vector2i(0, 0), new Vector2i(800, 480));
            _bgs.Position = new Vector2f(0, 0);
            _playerSprite = new Sprite(_playerTexture, new IntRect(0, 0, 32, 32));
            _playerSprite.Position = new Vector2f((float)_map.Player.Position.X, (float)_map.Player.Position.Y);
        }

        public void Update(int milliseconds)
        {
            _map.Update(milliseconds);
            _playerSprite.Position = new Vector2f((float)_map.Player.Position.X, (float)_map.Player.Position.Y);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_bgs);
            foreach(Tile tile in _map)
            {
                var sprite = new Sprite(_tileTexture);
                sprite.Rotation = (float)tile.Angle;
                sprite.TextureRect = new IntRect(new Vector2i((int)tile.Position.X, (int)tile.Position.Y), new Vector2i(32, 32));
                sprite.Position = new Vector2f((float)tile.Position.X, (float)tile.Position.Y);
                target.Draw(sprite);
            }
            target.Draw(_playerSprite);
        }
    }
}
