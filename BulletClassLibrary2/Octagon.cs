using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class Octagon
    {
        int height, width;
        Point topL, topR, midTopR, midBotR, midTopL, midBotL, botL, botR, position;
        List<Point> corners;

        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public Point TopL { get => topL; set => topL = value; }
        public Point TopR { get => topR; set => topR = value; }
        public Point MidTopR { get => midTopR; set => midTopR = value; }
        public Point MidBotR { get => midBotR; set => midBotR = value; }
        public Point MidTopL { get => midTopL; set => midTopL = value; }
        public Point MidBotL { get => midBotL; set => midBotL = value; }
        public Point BotL { get => botL; set => botL = value; }
        public Point BotR { get => botR; set => botR = value; }
        public Point Position { get => position; set => position = value; }
        public List<Point> Corners { get => corners; set => corners = value; }

        public Octagon(int height, int width, Point position)
        {
            this.position = position;
            topL = new Point(position.X - Convert.ToInt32(width / 4), position.Y - Convert.ToInt32(height / 2));
            topR = new Point(position.X + Convert.ToInt32(width / 4), position.Y - Convert.ToInt32(height / 2));
            midTopR = new Point(position.X + Convert.ToInt32(width / 2), position.Y - Convert.ToInt32(height / 4));
            midBotR = new Point(position.X + Convert.ToInt32(width / 2), position.Y + Convert.ToInt32(height / 4));
            midTopL = new Point(position.X - Convert.ToInt32(width / 2), position.Y - Convert.ToInt32(height / 4));
            midBotL = new Point(position.X - Convert.ToInt32(width / 2), position.Y + Convert.ToInt32(height / 4));
            botL = new Point(position.X - Convert.ToInt32(width / 4), position.Y + Convert.ToInt32(height / 2));
            botR = new Point(position.X + Convert.ToInt32(width / 4), position.Y + Convert.ToInt32(height / 2));
            corners = new List<Point>() { topL, topR, midTopL, midTopR, midBotL, midBotR, botL, botR };
        }
    }
}
