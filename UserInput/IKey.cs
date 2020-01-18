using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public interface IKey
    {
        string Primary { get; }
        string Secondary { get; }
        int HeldDownMilliseconds { get; }
        bool WasUpdated { get; }

        void Update(int milliseconds);
    }
}
