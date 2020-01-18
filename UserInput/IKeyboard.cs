using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public interface IKeyboard
    {
        List<UserKey> PressedKeys { get; }

        void Update(int milliseconds);
    }
}
