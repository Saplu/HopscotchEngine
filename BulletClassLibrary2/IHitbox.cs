using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public interface IHitbox
    {
        bool Hit(Vector2 point);
        bool Hit(Hitbox box);
        bool Hit(RectangleHitbox box);
        //bool Hit(CircleHitbox box);
        bool CheckHitbox(IShape box);
    }
}
