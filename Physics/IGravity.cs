using System;
using System.Collections.Generic;
using System.Text;

namespace Physics
{
    public interface IGravity
    {
        double Update(double currentSpeed, bool falling, int milliseconds);
        void UpdateCounterforce(double counterforce);
    }
}
