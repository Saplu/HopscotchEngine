using System;
using System.Collections.Generic;
using System.Text;

namespace BulletClassLibrary
{
    public interface IVelocity
    {
        void Update(GravityClassLibrary.Gravity gravity, int milliseconds);
    }
}
