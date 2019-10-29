using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public interface IGameObject
    {
        Vector2 Position { get; set; }
        Vector2 Speed { get; set; }
    }
}
