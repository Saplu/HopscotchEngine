using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class GameTime
    {
        TimeSpan totalGameTime, sinceLastUpdate;
        DateTime startTime, previousUpdateTime;

        public TimeSpan TotalGameTime { get => totalGameTime; set => totalGameTime = value; }
        public TimeSpan SinceLastUpdate { get => sinceLastUpdate; set => sinceLastUpdate = value; }

        public GameTime()
        {
            totalGameTime = new TimeSpan();
            sinceLastUpdate = new TimeSpan();
            startTime = DateTime.Now;
            previousUpdateTime = DateTime.Now;
        }

        public void Update()
        {
            var now = DateTime.Now;
            totalGameTime = now - startTime;
            sinceLastUpdate = now - previousUpdateTime;
            previousUpdateTime = now;
        }
    }
}
