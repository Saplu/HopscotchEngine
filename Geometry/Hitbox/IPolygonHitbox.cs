using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public interface IPolygonHitbox : IHitbox
    {
        IPolygon Box { get; }
    }
}
