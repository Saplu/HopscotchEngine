using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletClassLibrary
{
    public class GameTime
    {
        TimeSpan _totalGameTime, _sinceLastUpdate;
        DateTime _startTime, _previousUpdateTime;

        public TimeSpan TotalGameTime { get => _totalGameTime; set => _totalGameTime = value; }
        public TimeSpan SinceLastUpdate { get => _sinceLastUpdate; set => _sinceLastUpdate = value; }

        public GameTime()
        {
            _totalGameTime = new TimeSpan();
            _sinceLastUpdate = new TimeSpan();
            _startTime = DateTime.Now;
            _previousUpdateTime = DateTime.Now;
        }

        public void Update()
        {
            var now = DateTime.Now;
            _totalGameTime = now - _startTime;
            _sinceLastUpdate = now - _previousUpdateTime;
            _previousUpdateTime = now;
        }
    }
}
