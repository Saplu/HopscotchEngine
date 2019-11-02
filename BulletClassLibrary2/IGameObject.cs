using Geometry;

namespace BulletClassLibrary
{
    public interface IGameObject
    {
        Vector2 Position { get; set; }
        Vector2 Speed { get; set; }
    }
}
