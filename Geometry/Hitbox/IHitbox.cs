namespace Geometry
{
    public interface IHitbox
    {
        bool Hit(Vector2 point);
        bool Hit(OctagonHitbox box);
        bool Hit(RectangleHitbox box);
        //bool Hit(CircleHitbox box);
        bool CheckHitbox(IShape box);
    }
}
