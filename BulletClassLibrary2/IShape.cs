using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public interface IShape
    {
        int MaxX { get; }
        int MinX { get; }
        int MaxY { get; }
        int MinY { get; }
        List<Point> Corners { get; }
    }
}
