namespace Geometry
{
    public class Circle : IShape
    {
        double maxX, minX, maxY, minY, radius;
        Vector2 position;

        public double MaxX { get => maxX; set => maxX = value; }
        public double MinX { get => minX; set => minX = value; }
        public double MaxY { get => maxY; set => maxY = value; }
        public double MinY { get => minY; set => minY = value; }
        public double Radius { get => radius; set => radius = value; }
        public Vector2 Position { get => position; set => position = value; }

        public Circle(Vector2 position, double radius)
        {
            this.position = position;
            this.radius = radius;
            getMaxMinValues();
        }

        private void getMaxMinValues()
        {
            maxX = position.X + radius;
            minX = position.X - radius;
            maxY = position.Y + radius;
            minY = position.Y - radius;
        }
    }
}
