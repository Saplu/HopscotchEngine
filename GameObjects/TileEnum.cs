using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace GameObjects
{
    public class TileEnum : IEnumerator
    {
        Dictionary<int, Tile> _tiles;
        int _position;

        public TileEnum(Dictionary<int, Tile> tiles)
        {
            _position = -1;
            _tiles = tiles;
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < _tiles.Count);
        }

        public void Reset()
        {
            _position = -1;
        }

        public Tile Current
        {
            get 
            {
                try
                {
                    return _tiles.ElementAt(_position).Value;
                }
                catch(IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
