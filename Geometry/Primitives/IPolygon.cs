using System.Collections.Generic;

namespace Geometry
{
    public interface IPolygon : IShape
    {
        List<Vector2> Corners { get; }
    }
}
