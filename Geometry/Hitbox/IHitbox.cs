namespace Geometry
{
    public interface IHitbox
    {
        bool Hit(IPolygonHitbox box);
        bool Hit(Vector2 point);
        bool Hit(CircleHitbox box);
        bool CheckHitbox(IPolygon hitbox);
        bool CheckHitbox(ICircle circle);
    }
}
