using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendering
{
    public class GameTime
    {
        static TimeSpan _totalGameTime, _sinceLastUpdate;
        static DateTime _startTime, _previousUpdateTime;

        public double TotalGameTime { get => _totalGameTime.TotalMilliseconds; }
        public double SinceLastUpdate { get => _sinceLastUpdate.TotalMilliseconds; }

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
