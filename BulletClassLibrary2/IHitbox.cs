using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    interface IHitbox
    {
        bool Hit(Point point);
        bool Hit(Hitbox box);
        bool Hit(RectangleHitbox box);
    }
}
