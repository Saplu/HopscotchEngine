using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserInput
{
    public class UserKey
    {
        private string _secondary, _primary;
        int _heldDownMilliseconds;

        public string Primary { get => _primary; }
        public string Secondary { get => _secondary; }
        public int HeldDownMilliseconds { get => _heldDownMilliseconds; }
        public bool WasUpdated { get; set; }

        public Key Key { get; }

        public UserKey(Key primary)
        {
            _heldDownMilliseconds = 0;
            WasUpdated = true;
            SetValues(primary);
        }

        public void Update(int milliseconds)
        {
            _heldDownMilliseconds += milliseconds;
            WasUpdated = true; 
        }

        private void SetValues(Key primary)
        {
            switch (primary)
            {
                case Key.A: _primary = "a"; _secondary = "A"; break;
                case Key.B: _primary = "b"; _secondary = "B"; break;
                case Key.C: _primary = "c"; _secondary = "C"; break;
                case Key.D: _primary = "d"; _secondary = "D"; break;
                case Key.E: _primary = "e"; _secondary = "E"; break;
                case Key.F: _primary = "f"; _secondary = "F"; break;
                case Key.G: _primary = "g"; _secondary = "G"; break;
                case Key.H: _primary = "h"; _secondary = "H"; break;
                case Key.I: _primary = "i"; _secondary = "I"; break;
                case Key.J: _primary = "j"; _secondary = "J"; break;
                case Key.K: _primary = "k"; _secondary = "K"; break;
                case Key.L: _primary = "l"; _secondary = "L"; break;
                case Key.M: _primary = "m"; _secondary = "M"; break;
                case Key.N: _primary = "n"; _secondary = "N"; break;
                case Key.O: _primary = "o"; _secondary = "O"; break;
                case Key.P: _primary = "p"; _secondary = "P"; break;
                case Key.Q: _primary = "q"; _secondary = "Q"; break;
                case Key.R: _primary = "r"; _secondary = "R"; break;
                case Key.S: _primary = "s"; _secondary = "S"; break;
                case Key.T: _primary = "t"; _secondary = "T"; break;
                case Key.U: _primary = "u"; _secondary = "U"; break;
                case Key.V: _primary = "v"; _secondary = "V"; break;
                case Key.W: _primary = "w"; _secondary = "W"; break;
                case Key.X: _primary = "x"; _secondary = "X"; break;
                case Key.Y: _primary = "y"; _secondary = "Y"; break;
                case Key.Z: _primary = "z"; _secondary = "Z"; break;
                case Key.D1: _primary = "1"; _secondary = "!"; break;
                case Key.D2: _primary = "2"; _secondary = "\""; break;
                case Key.D3: _primary = "3"; _secondary = "#"; break;
                case Key.D4: _primary = "4"; _secondary = "¤"; break;
                case Key.D5: _primary = "5"; _secondary = "%"; break;
                case Key.D6: _primary = "6"; _secondary = "&"; break;
                case Key.D7: _primary = "7"; _secondary = "/"; break;
                case Key.D8: _primary = "8"; _secondary = "("; break;
                case Key.D9: _primary = "9"; _secondary = ")"; break;
                case Key.D0: _primary = "0"; _secondary = "="; break;
                case Key.Enter: _primary = "Enter"; _secondary = ""; break;
                case Key.Back: _primary = "Backspace"; _secondary = ""; break;
                case Key.Space: _primary = "Space"; _secondary = ""; break;
                case Key.Up: _primary = "Up"; _secondary = ""; break;
                case Key.Down: _primary = "Down"; _secondary = ""; break;
                case Key.Left: _primary = "Left"; _secondary = ""; break;
                case Key.Right: _primary = "Right"; _secondary = ""; break;
                default: _primary = ""; _secondary = ""; break;
            }
        }

        public override bool Equals(object obj)
        {
            var toCompareWith = obj as UserKey;
            if (toCompareWith == null)
                return false;
            if (toCompareWith.Primary == this.Primary)
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            var hashCode = -486032274;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_secondary);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_primary);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Primary);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Secondary);
            hashCode = hashCode * -1521134295 + HeldDownMilliseconds.GetHashCode();
            hashCode = hashCode * -1521134295 + Key.GetHashCode();
            return hashCode;
        }
    }
}
