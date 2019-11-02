namespace Geometry
{
    public interface IShape
    {
        double MaxX { get; }
        double MinX { get; }
        double MaxY { get; }
        double MinY { get; }
        Vector2 Position { get; set; }
    }
}
