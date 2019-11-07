using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public static class GameTime
    {
        static TimeSpan _totalGameTime, _sinceLastUpdate;
        static DateTime _startTime, _previousUpdateTime;

        public static TimeSpan TotalGameTime { get => _totalGameTime; set => _totalGameTime = value; }
        public static TimeSpan SinceLastUpdate { get => _sinceLastUpdate; set => _sinceLastUpdate = value; }

        static GameTime()
        {
            _totalGameTime = new TimeSpan();
            _sinceLastUpdate = new TimeSpan();
            _startTime = DateTime.Now;
            _previousUpdateTime = DateTime.Now;
        }

        public static void Update()
        {
            var now = DateTime.Now;
            _totalGameTime = now - _startTime;
            _sinceLastUpdate = now - _previousUpdateTime;
            _previousUpdateTime = now;
        }
    }
}
