namespace Geometry
{
    public interface IHitbox
    {
        Vector2 Position { get; }
        bool Hit(IPolygonHitbox box);
        bool Hit(Vector2 point);
        bool Hit(CircleHitbox box);
        bool CheckHitbox(IPolygon hitbox);
        bool CheckHitbox(ICircle circle);
    }
}
