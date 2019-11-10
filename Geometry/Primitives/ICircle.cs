using System;
using System.Collections.Generic;
using System.Text;

namespace Geometry
{
    public interface ICircle : IShape
    {
        double Radius { get; set; }
        Vector2 FindClosestPoint(Vector2 point);
    }
}
