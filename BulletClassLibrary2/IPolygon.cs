using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public interface IPolygon
    {
        List<Vector2> Corners { get; }
    }
}
