using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public interface IShape
    {
        double MaxX { get; }
        double MinX { get; }
        double MaxY { get; }
        double MinY { get; }
        List<Vector2> Corners { get; }
    }
}
