using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserInput
{
    public class UserKeyBoard
    {
        private List<UserKey> _pressedKeys;
        private readonly List<Key> _alphabeticKeys, _specialKeys;
        private bool _secondary;

        public List<UserKey> PressedKeys { get => _pressedKeys; }

        public UserKeyBoard()
        {
            _pressedKeys = new List<UserKey>();
            _secondary = false;
            _alphabeticKeys = new List<Key>()
            { Key.A,
            Key.B,
            Key.C,
            Key.D,
            Key.E,
            Key.F,
            Key.G,
            Key.H,
            Key.I,
            Key.J,
            Key.K,
            Key.L,
            Key.M,
            Key.N,
            Key.O,
            Key.P,
            Key.Q,
            Key.R,
            Key.S,
            Key.T,
            Key.U,
            Key.V,
            Key.X,
            Key.Y,
            Key.Z,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
            Key.D0,
            };
            _specialKeys = new List<Key>()
            {
            Key.Up,
            Key.Down,
            Key.Left,
            Key.Right,
            Key.Back,
            Key.Enter,
            Key.Space
            };
        }

        public void Update(int milliseconds)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
                _secondary = true;
            else _secondary = false;

            _pressedKeys.ForEach(item => item.WasUpdated = false);

            foreach (var key in _alphabeticKeys)
            {
                if (Keyboard.IsKeyDown(key))
                    AddOrUpdate(key, milliseconds);
            }
            foreach(var spec in _specialKeys)
            {
                if (Keyboard.IsKeyDown(spec))
                    AddOrUpdate(spec, milliseconds);
            }
            var newList = from Key in _pressedKeys
                          where Key.WasUpdated == true
                          select Key;
            _pressedKeys = newList.ToList();
        }

        private void AddOrUpdate(Key key, int milliseconds)
        {
            var newKey = new UserKey(key);
            var existingKey = _pressedKeys.FirstOrDefault(x => x.Equals(newKey));
            if (existingKey != null)
            {
                existingKey.Update(milliseconds);
            }
            else _pressedKeys.Add(newKey);
        }
    }
}
